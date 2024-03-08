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
    public class FindBrandHandler : IRequestHandler<FindBrandQuery, Brand>
    {
        private readonly IDataContext _dbContext;

        public FindBrandHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Brand> Handle(FindBrandQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Brands.FindAsync(request.Id, cancellationToken);
        }
    }
}
