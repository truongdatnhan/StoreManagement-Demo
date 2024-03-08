using Application.Customers.Commands;
using Application.DTOs;
using Application.InvoiceDetails.Commands;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InvoiceDetails.Handlers
{
    public class UpdateInvoiceDetailHandler : IRequestHandler<UpdateInvoiceDetailCommand, int>
    {
        private readonly ISqlCommand _sqlDataAccess;

        public UpdateInvoiceDetailHandler(ISqlCommand sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task<int> Handle(UpdateInvoiceDetailCommand request, CancellationToken cancellationToken = default)
        {
            var query = @"UPDATE invoice_detail
                        SET ProductId = @productId,
                        Quantity = @quantity,
                        Price = @price,
                        RealReceive = @realReceive
                        WHERE Id = @id";
            return await _sqlDataAccess.ExecuteAsync(query, new { productId = request.ProductId, quantity = request.Quantity, price = request.Price, realReceive = request.RealReceive, id = request.Id });
        }
    }
}
