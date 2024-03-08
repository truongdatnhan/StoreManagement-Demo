using Application.Customers.Commands;
using Application.OrderDetails.Commands;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Application.OrderDetails.Handlers
{
    public class InsertOrderDetailHandler : IRequestHandler<InsertOrderDetailCommand, int>
    {
        private readonly IDataContext _dbContext;
        private readonly ISqlCommand _sqlDataAccess;

        public InsertOrderDetailHandler(IDataContext dbContext, ISqlCommand sqlDataAccess)
        {
            _dbContext = dbContext;
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task<int> Handle(InsertOrderDetailCommand request, CancellationToken cancellationToken = default)
        {
            //Sometime 2nd query the connection got open automatically. No idea why :/
            if (_dbContext.Database.GetDbConnection().State != ConnectionState.Open && _dbContext.Database.GetDbConnection().State != ConnectionState.Connecting)
            {
                _dbContext.Database.GetDbConnection().Close();
                _dbContext.Database.GetDbConnection().Open();
            }
            
            using (var transaction = _dbContext.Database.GetDbConnection().BeginTransaction())
            {
                try
                {
                    _dbContext.Database.UseTransaction(transaction as DbTransaction);
                    var orderDetail = new OrderDetail()
                    {
                        OrderId = request.OrderId,
                        ProductId = request.ProductId,
                        Quantity = request.Quantity,
                        Price = request.Price
                    };
                    var query = @"UPDATE `product`
                        SET Quantity = Quantity - @quantity
                        WHERE Id = @id";

                    await _dbContext.OrderDetails.AddAsync(orderDetail, cancellationToken);
                    await _sqlDataAccess.ExecuteAsync(query, new { quantity = request.Quantity, id = request.ProductId }, transaction);
                    await _dbContext.SaveAsync(cancellationToken);
                    transaction.Commit();
                    return request.OrderId;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    //Set transaction as null after to use to avoid
                    //The transaction associated with this command is not the connection’s active transaction
                    _dbContext.Database.UseTransaction(null);
                    _dbContext.Database.GetDbConnection().Close();
                }
            }
        }
    }
}
