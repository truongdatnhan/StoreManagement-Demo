using Application.Products.Queries;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Handlers
{
    public class GetProductsFilteredNameHandler : IRequestHandler<GetProductsFilteredNameQuery, List<Product>>
    {
        private readonly IDataContext _dbContext;

        public GetProductsFilteredNameHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> Handle(GetProductsFilteredNameQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Products.Where(x => x.Name.Contains(request.Name, StringComparison.InvariantCultureIgnoreCase)).ToListAsync();
        }
    }
}
