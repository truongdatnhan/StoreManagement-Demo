using Application.Customers.Commands;
using Application.DTOs;
using Application.OrderDetails.Commands;
using Application.Orders.Commands;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Handlers
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, int>
    {
        private readonly ISqlCommand _sqlDataAccess;

        public UpdateOrderHandler(ISqlCommand sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken = default)
        {
            var query = @"UPDATE `order`
                        SET CustomerId = @customerId,
                        Total = @total,
                        Updated = @updated,
                        PickUp = @pickUp,
                        OrderStatus = @orderStatus
                        WHERE Id = @id";
            return await _sqlDataAccess.ExecuteAsync(query, new { customerId = request.CustomerId, total = request.Total, updated = request.Updated, pickUp = request.PickUp,orderStatus = request.OrderStatus, id = request.Id });
        }
    }
}
