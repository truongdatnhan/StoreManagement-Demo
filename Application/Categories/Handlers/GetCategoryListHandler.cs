using Application.Categories.Queries;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Handlers
{
    public class GetCategoryListHandler : IRequestHandler<GetCategoryListQuery, List<Category>>
    {
        private readonly IDataContext _dbContext;

        public GetCategoryListHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Categories.ToListAsync(cancellationToken);
        }
    }
}
