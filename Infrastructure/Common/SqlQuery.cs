using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Common;

public class SqlQuery : ISqlQuery, IDisposable
{
    private readonly IDbConnection connection;
    private string connectionString = @"server=localhost; port=3306; database=store_management; user=root; password=";

    public SqlQuery(IConfiguration configuration)
    {
        connection = new MySqlConnection(connectionString);
    }

    public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    {
        return (await connection.QueryAsync<T>(sql, param, transaction)).AsList();
    }

    public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    {
        return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
    }

    public async Task<T> QuerySingleAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    {
        return await connection.QuerySingleAsync<T>(sql, param, transaction);
    }

    public void Dispose()
    {
        connection.Dispose();
    }
}
