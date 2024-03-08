using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands
{
    public record InsertProductCommand(int BrandId, int CategoryId, string Name, int Price, int Quantity, string Note) : IRequest<int>;
}
