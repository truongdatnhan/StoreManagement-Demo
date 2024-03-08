using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Suppliers.Queries
{
    public record GetSupplierPaginationQuery(string? Name, int PageNumber, int PageSize) : IRequest<List<Supplier>>;
}
