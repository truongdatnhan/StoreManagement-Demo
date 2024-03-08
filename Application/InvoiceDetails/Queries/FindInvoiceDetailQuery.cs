using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InvoiceDetails.Queries
{
    public record FindInvoiceDetailQuery(int Id) : IRequest<InvoiceDetail>;
}
