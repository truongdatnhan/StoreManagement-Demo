using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Commands
{
    public record UpdateOrderCommand(int Id, int CustomerId, int Total, DateTime? Updated, OrderStatus OrderStatus, DateTime? PickUp = default) : IRequest<int>;
}
