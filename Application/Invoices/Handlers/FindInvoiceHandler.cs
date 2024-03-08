using Application.Invoices.Queries;
using Domain.Entities;
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
    public class FindInvoiceHandler : IRequestHandler<FindInvoiceQuery, Invoice>
    {
        private readonly IDataContext _dbContext;

        public FindInvoiceHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Invoice> Handle(FindInvoiceQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Invoices.FindAsync(request.Id, cancellationToken);
        }
    }
}
