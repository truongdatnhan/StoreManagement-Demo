using Application.Customers.Commands;
using Application.DTOs;
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

namespace Application.OrderDetails.Handlers
{
    public class UpdateOrderDetailHandler : IRequestHandler<UpdateOrderDetailCommand, int>
    {
        private readonly ISqlCommand _sqlDataAccess;

        public UpdateOrderDetailHandler(ISqlCommand sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task<int> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken = default)
        {
            var query = @"UPDATE order_detail
                        SET ProductId = @productId,
                        Quantity = @quantity,
                        Price = @price
                        WHERE Id = @id";
            return await _sqlDataAccess.ExecuteAsync(query, new { productId = request.ProductId, quantity = request.Quantity, price = request.Price, id = request.Id });
        }
    }
}
