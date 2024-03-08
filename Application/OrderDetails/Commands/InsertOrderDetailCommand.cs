using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderDetails.Commands
{
    public record InsertOrderDetailCommand(int OrderId, int ProductId, int Price, int Quantity) : IRequest<int>;
}
