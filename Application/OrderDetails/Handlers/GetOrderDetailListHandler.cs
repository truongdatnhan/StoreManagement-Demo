using Application.Customers.Queries;
using Application.DTOs;
using Application.OrderDetails.Queries;
using Dapper;
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

namespace Application.OrderDetails.Handlers
{
    public class GetOrderDetailListHandler : IRequestHandler<GetOrderDetailListQuery, List<OrderDetailViewModel>>
    {
        private readonly IDataContext _dbContext;
        private readonly ISqlQuery _sqlDataAccess;

        public GetOrderDetailListHandler(IDataContext dbContext, ISqlQuery sqlDataAccess)
        {
            _dbContext = dbContext;
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task<List<OrderDetailViewModel>> Handle(GetOrderDetailListQuery request, CancellationToken cancellationToken)
        {
            var query = @"SELECT
	                        order_detail.Id, 
                            order_detail.ProductId,
                            product.Name ProductName, 
                            order_detail.Quantity, 
                            order_detail.Price, 
                            order_detail.Price * order_detail.Quantity Total
                        FROM order_detail
                        INNER JOIN product ON order_detail.ProductId = product.Id
                        WHERE order_detail.OrderId = @orderId";
            var list = await _sqlDataAccess.QueryAsync<OrderDetailViewModel>(query, new { orderId = request.OrderId });
            return list.ToList();
            //return await _dbContext.OrderDetails.Where(x => x.OrderId == request.OrderId).ToListAsync(cancellationToken);
        }
    }
}
