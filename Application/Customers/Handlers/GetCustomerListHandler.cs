using Application.Customers.Queries;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Handlers
{
    public class FindCustomerHandler : IRequestHandler<FindCustomerQuery, Customer>
    {
        private readonly IDataContext _dbContext;

        public FindCustomerHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> Handle(FindCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Customers.FindAsync(request.Id, cancellationToken);
        }
    }
}
