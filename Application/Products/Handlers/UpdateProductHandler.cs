using Application.Products.Commands;
using Domain.Entities;
using Infrastructure.Common;
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
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly ISqlCommand _sqlDataAccess;

        public UpdateProductHandler(ISqlCommand sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var query = @"UPDATE product
                        SET BrandId = @brandId,
                        CategoryId = @categoryId,
                        Name = @name,
                        Price = @price,
                        Quantity = @quantity,
                        Note = @note
                        WHERE Id = @id";

            return await _sqlDataAccess.ExecuteAsync(query, new { brandId = request.BrandId, categoryId = request.CategoryId, price = request.Price, quantity = request.Quantity, note = request.Note, id = request.Id });
        }
    }
}
