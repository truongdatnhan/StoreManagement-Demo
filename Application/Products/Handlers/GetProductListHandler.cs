using Application.DTOs;
using Application.Products.Queries;
using Domain.Entities;
using Infrastructure.Common;
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
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, List<ProductViewModel>>
    {
        private readonly IDataContext _dbContext;
        private readonly ISqlQuery _sqlDataAccess;

        public GetProductListHandler(IDataContext dbContext, ISqlQuery sqlDataAccess)
        {
            _dbContext = dbContext;
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task<List<ProductViewModel>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var query = @"SELECT product.Id,
                            brand.Name BrandName,
                            category.Name CategoryName,
                            product.Name,
                            product.Price,
                            product.Quantity,
                            product.Note
                            FROM `product`
                            INNER JOIN brand on product.BrandId = brand.Id
                            INNER JOIN category on product.CategoryId = category.Id";
            var list = await _sqlDataAccess.QueryAsync<ProductViewModel>(query);
            return list.ToList();
            //return await _dbContext.Products.ToListAsync(cancellationToken);
        }
    }
}
