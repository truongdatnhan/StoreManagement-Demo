using Application.Categories.Queries;
using Application.Orders.Queries;
using Application.Suppliers.Queries;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Suppliers.Handlers
{
    public class GetSuppliersFilteredNameHandler : IRequestHandler<GetSuppliersFilteredNameQuery, List<Supplier>>
    {
        private readonly IDataContext _dbContext;

        public GetSuppliersFilteredNameHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Supplier>> Handle(GetSuppliersFilteredNameQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Suppliers.Where(x => x.Name.Contains(request.Name, StringComparison.InvariantCultureIgnoreCase)).ToListAsync(cancellationToken);
        }
    }
}
