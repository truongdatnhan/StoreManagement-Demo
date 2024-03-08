using Application.Orders.Queries;
using Domain.Entities;
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
    public class FindOrderHandler : IRequestHandler<FindOrderQuery, Order>
    {
        private readonly IDataContext _dbContext;

        public FindOrderHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> Handle(FindOrderQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Orders.FindAsync(request.Id, cancellationToken);
        }
    }
}
