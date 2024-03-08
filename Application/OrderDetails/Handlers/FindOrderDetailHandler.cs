using Application.Customers.Queries;
using Application.OrderDetails.Queries;
using Dapper;
using Domain.Entities;
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
    public class FindOrderDetailHandler : IRequestHandler<FindOrderDetailQuery, OrderDetail>
    {
        private readonly IDataContext _dbContext;

        public FindOrderDetailHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderDetail> Handle(FindOrderDetailQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.OrderDetails.FindAsync(request.Id, cancellationToken);
        }
    }
}
