using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Suppliers.Commands
{
    public record InsertSupplierCommand(string Name) : IRequest<int>;
}
