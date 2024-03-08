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
    public class FindProductHandler : IRequestHandler<FindProductQuery, Product>
    {
        private readonly IDataContext _dbContext;

        public FindProductHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> Handle(FindProductQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Products.FindAsync(request.Id, cancellationToken);
        }
    }
}
