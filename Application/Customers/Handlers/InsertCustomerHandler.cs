using Application.Customers.Commands;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Handlers
{
    public class InsertCustomerHandler : IRequestHandler<InsertCustomerCommand, int>
    {
        private readonly IDataContext _dbContext;

        public InsertCustomerHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(InsertCustomerCommand request, CancellationToken cancellationToken = default)
        {
            var lastestId = _dbContext.Customers.Count() + 1;
            var customer = new Customer()
            {
                Name = $"Nhan - {lastestId}"
            };

            await _dbContext.Customers.AddAsync(customer, cancellationToken);
            return await _dbContext.SaveAsync(cancellationToken);


        }
    }
}
