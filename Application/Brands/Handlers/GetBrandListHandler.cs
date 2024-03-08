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
    public class GetBrandListHandler : IRequestHandler<GetBrandListQuery, List<Brand>>
    {
        private readonly IDataContext _dbContext;

        public GetBrandListHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Brand>> Handle(GetBrandListQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Brands.ToListAsync(cancellationToken);
        }
    }
}
