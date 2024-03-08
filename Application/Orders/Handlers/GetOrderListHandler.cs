using Application.DTOs;
using Application.Orders.Queries;
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

namespace Application.Orders.Handlers
{
    public class GetOrderListHandler : IRequestHandler<GetOrderListQuery, List<OrderViewModel>>
    {
        private readonly IDataContext _dbContext;
        private readonly ISqlQuery _sqlDataAccess;

        public GetOrderListHandler(IDataContext dbContext, ISqlQuery sqlDataAccess)
        {
            _dbContext = dbContext;
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task<List<OrderViewModel>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var query = @"SELECT o.Id,
                            customer.Name CustomerName,
                            o.Created,
                            o.Updated,
                            o.PickUp,
                            o.Total,
                            o.OrderStatus
                            FROM `order` o
                            INNER JOIN customer on o.CustomerId = customer.Id";
            var list = await _sqlDataAccess.QueryAsync<OrderViewModel>(query);
            return list.ToList();
            //return await _dbContext.Orders.ToListAsync(cancellationToken);
        }
    }
}
