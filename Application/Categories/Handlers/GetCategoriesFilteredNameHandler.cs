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
    public class GetCategoriesFilteredNameHandler : IRequestHandler<GetCategoriesFilteredNameQuery, List<Category>>
    {
        private readonly IDataContext _dbContext;

        public GetCategoriesFilteredNameHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> Handle(GetCategoriesFilteredNameQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Categories.Where(x => x.Name.Contains(request.Name, StringComparison.InvariantCultureIgnoreCase)).ToListAsync();
        }
    }
}
