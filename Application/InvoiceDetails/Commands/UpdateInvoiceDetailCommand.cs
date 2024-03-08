using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InvoiceDetails.Commands
{
    public record UpdateInvoiceDetailCommand(int Id, int ProductId, int Price, int Quantity, int RealReceive) : IRequest<int>;
}
