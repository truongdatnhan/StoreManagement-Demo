using Application.Customers.Queries;
using Application.DTOs;
using Application.InvoiceDetails.Queries;
using Dapper;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InvoiceDetails.Handlers
{
    public class GetInvoiceDetailListHandler : IRequestHandler<GetInvoiceDetailListQuery, List<InvoiceDetailViewModel>>
    {
        private readonly IDataContext _dbContext;
        private readonly ISqlQuery _sqlDataAccess;

        public GetInvoiceDetailListHandler(IDataContext dbContext, ISqlQuery sqlDataAccess)
        {
            _dbContext = dbContext;
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task<List<InvoiceDetailViewModel>> Handle(GetInvoiceDetailListQuery request, CancellationToken cancellationToken)
        {
            var query = @"SELECT
	                        invoice_detail.Id, 
                            invoice_detail.ProductId,
                            product.Name ProductName, 
                            invoice_detail.Quantity, 
                            invoice_detail.Price, 
                            invoice_detail.Price * invoice_detail.Quantity Total
                        FROM invoice_detail
                        INNER JOIN product ON invoice_detail.ProductId = product.Id
                        WHERE invoice_detail.InvoiceId = @invoiceId";
            var list = await _sqlDataAccess.QueryAsync<InvoiceDetailViewModel>(query, new { invoiceId = request.InvoiceId });
            return list.ToList();
            //return await _dbContext.InvoiceDetails.Where(x => x.Id == request.InvoiceId).ToListAsync(cancellationToken);
        }
    }
}
