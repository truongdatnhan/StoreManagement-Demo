using Application.Customers.Commands;
using Application.InvoiceDetails.Commands;
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

namespace Application.InvoiceDetails.Handlers
{
    public class InsertInvoiceDetailHandler : IRequestHandler<InsertInvoiceDetailCommand, int>
    {
        private readonly IDataContext _dbContext;
        private readonly ISqlCommand _sqlDataAccess;

        public InsertInvoiceDetailHandler(IDataContext dbContext, ISqlCommand sqlDataAccess)
        {
            _dbContext = dbContext;
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task<int> Handle(InsertInvoiceDetailCommand request, CancellationToken cancellationToken = default)
        {
            //Sometime 2nd query the connection got open automatically. No idea why :/
            if (_dbContext.Database.GetDbConnection().State != ConnectionState.Open && _dbContext.Database.GetDbConnection().State != ConnectionState.Connecting)
            {
                _dbContext.Database.GetDbConnection().Open();
            }
            
            using (var transaction = _dbContext.Database.GetDbConnection().BeginTransaction())
            {
                try
                {
                    _dbContext.Database.UseTransaction(transaction as DbTransaction);
                    var invoiceDetail = new InvoiceDetail()
                    {
                        InvoiceId = request.InvoiceId,
                        ProductId = request.ProductId,
                        Price = request.Price,
                        Quantity = request.Quantity,
                        RealReceive = request.RealReceive
                    };
                    var query = @"UPDATE `product`
                        SET Quantity = Quantity + @quantity
                        WHERE Id = @id";

                    await _dbContext.InvoiceDetails.AddAsync(invoiceDetail, cancellationToken);
                    await _sqlDataAccess.ExecuteAsync(query, new { quantity = request.RealReceive, id = request.ProductId }, transaction);
                    await _dbContext.SaveAsync(cancellationToken);
                    transaction.Commit();
                    return request.InvoiceId;
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
