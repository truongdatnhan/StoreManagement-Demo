using Application.Categories.Commands;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Handlers
{
    public class InsertCategoryHandler : IRequestHandler<InsertCategoryCommand, int>
    {
        private readonly IDataContext _dbContext;

        public InsertCategoryHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(InsertCategoryCommand request, CancellationToken cancellationToken = default)
        {
            var category = new Category()
            {
                Name = request.Name
            };

            await _dbContext.Categories.AddAsync(category, cancellationToken);
            return await _dbContext.SaveAsync(cancellationToken);


        }
    }
}
