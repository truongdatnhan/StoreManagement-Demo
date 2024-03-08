using Application.DTOs;
using Application.Invoices.Queries;
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

namespace Application.Invoices.Handlers
{
    public class GetInvoiceListHandler : IRequestHandler<GetInvoiceListQuery, List<InvoiceViewModel>>
    {
        private readonly IDataContext _dbContext;
        private readonly ISqlQuery _sqlDataAccess;

        public GetInvoiceListHandler(IDataContext dbContext, ISqlQuery sqlDataAccess)
        {
            _dbContext = dbContext;
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task<List<InvoiceViewModel>> Handle(GetInvoiceListQuery request, CancellationToken cancellationToken)
        {
            var query = @"SELECT invoice.Id,
                            supplier.Name SupplierName,
                            invoice.Created,
                            invoice.Updated,
                            invoice.Total,
                            invoice.InvoiceStatus
                            FROM `invoice`
                            INNER JOIN supplier on invoice.SupplierId = supplier.Id;";
            var list = await _sqlDataAccess.QueryAsync<InvoiceViewModel>(query);
            return list.ToList();
            //return await _dbContext.Invoices.ToListAsync(cancellationToken);
        }
    }
}
