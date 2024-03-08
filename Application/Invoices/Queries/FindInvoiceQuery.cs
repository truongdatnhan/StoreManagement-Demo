using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invoices.Queries
{
    public record FindInvoiceQuery(int Id) : IRequest<Invoice>;
}
