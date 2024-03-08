using Application.Brands.Queries;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Brands.Handlers
{
    public class GetBrandsFilteredNameHandler : IRequestHandler<GetBrandsFilteredNameQuery, List<Brand>>
    {
        private readonly IDataContext _dbContext;

        public GetBrandsFilteredNameHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Brand>> Handle(GetBrandsFilteredNameQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Brands.Where(x => x.Name.Contains(request.Name, StringComparison.InvariantCultureIgnoreCase)).ToListAsync();
        }
    }
}
