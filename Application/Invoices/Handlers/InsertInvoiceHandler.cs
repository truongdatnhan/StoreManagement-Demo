using Application.Categories.Commands;
using Application.Invoices.Commands;
using Application.Suppliers.Commands;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invoices.Handlers
{
    public class InsertInvoiceHandler : IRequestHandler<InsertInvoiceCommand, int>
    {
        private readonly IDataContext _dbContext;

        public InsertInvoiceHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(InsertInvoiceCommand request, CancellationToken cancellationToken = default)
        {
            var invoice = new Invoice()
            {
                SupplierId = request.SupplierId,
                Created = DateTime.Now,
                InvoiceStatus = InvoiceStatus.NEW
            };

            await _dbContext.Invoices.AddAsync(invoice, cancellationToken);
            return await _dbContext.SaveAsync(cancellationToken);
        }
    }
}
