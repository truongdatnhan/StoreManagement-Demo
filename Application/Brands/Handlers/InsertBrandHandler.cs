using Application.Brands.Commands;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Brands.Handlers
{
    public class InsertBrandHandler : IRequestHandler<InsertBrandCommand, int>
    {
        private readonly IDataContext _dbContext;

        public InsertBrandHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(InsertBrandCommand request, CancellationToken cancellationToken = default)
        {
            var brand = new Brand()
            {
                Name = request.Name,
            };

            await _dbContext.Brands.AddAsync(brand, cancellationToken);
            return await _dbContext.SaveAsync(cancellationToken);


        }
    }
}
