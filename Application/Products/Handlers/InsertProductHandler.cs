using Application.Products.Commands;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Products.Handlers
{
    public class InsertProductHandler : IRequestHandler<InsertProductCommand, int>
    {
        private readonly IDataContext _dbContext;

        public InsertProductHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            /*var lastestId = _dbContext.Products.Count() + 1;
            var product = new Product
            {
                BrandId = 1,
                CategoryId = 1,
                Name = $"Item {lastestId}",
                Price = 1000,
                Quantity = 100
            };*/
            var product = new Product
            {
                BrandId = request.BrandId,
                CategoryId = request.CategoryId,
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                Note = request.Note
            };
            await _dbContext.Products.AddAsync(product);
            return await _dbContext.SaveAsync(cancellationToken);

        }
    }
}
