using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Commands
{
    public record InsertOrderCommand(int CustomerId,DateTime? PickUp = default) : IRequest<int>;
}
