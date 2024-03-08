using Application.Customers.Commands;
using Application.DTOs;
using Application.Invoices.Commands;
using Application.OrderDetails.Commands;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invoices.Handlers
{
    public class UpdateInvoiceHandler : IRequestHandler<UpdateInvoiceCommand, int>
    {
        private readonly ISqlCommand _sqlDataAccess;

        public UpdateInvoiceHandler(ISqlCommand sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task<int> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken = default)
        {
            var query = @"UPDATE `invoice`
                        SET SupplierId = @supplierId,
                        Total = @total,
                        Updated = @updated,
                        InvoiceStatus = @invoiceStatus
                        WHERE Id = @id";
            return await _sqlDataAccess.ExecuteAsync(query, new { supplierId = request.SupplierId, total = request.Total, updated = DateTime.Now, invoiceStatus = request.InvoiceStatus, id = request.Id });
        }
    }
}
