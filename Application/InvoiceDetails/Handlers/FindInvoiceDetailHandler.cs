using Application.Customers.Queries;
using Application.InvoiceDetails.Queries;
using Dapper;
using Domain.Entities;
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
    public class FindInvoiceDetailHandler : IRequestHandler<FindInvoiceDetailQuery, InvoiceDetail>
    {
        private readonly IDataContext _dbContext;

        public FindInvoiceDetailHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<InvoiceDetail> Handle(FindInvoiceDetailQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.InvoiceDetails.FindAsync(request.Id, cancellationToken);
        }
    }
}
