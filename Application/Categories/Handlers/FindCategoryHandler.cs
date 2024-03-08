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
    public class FindCategoryHandler : IRequestHandler<FindCategoryQuery, Category>
    {
        private readonly IDataContext _dbContext;

        public FindCategoryHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> Handle(FindCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Categories.FindAsync(request.Id, cancellationToken);
        }
    }
}
