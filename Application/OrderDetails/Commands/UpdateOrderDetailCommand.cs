using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderDetails.Commands
{
    public record UpdateOrderDetailCommand(int Id, int ProductId, int Price, int Quantity) : IRequest<int>;
}
