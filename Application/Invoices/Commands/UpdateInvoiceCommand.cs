using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invoices.Commands
{
    public record UpdateInvoiceCommand(int Id, int SupplierId, int Total, InvoiceStatus InvoiceStatus) : IRequest<int>;
}
