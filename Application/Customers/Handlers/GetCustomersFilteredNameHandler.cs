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
    public class GetCustomersFilteredNameHandler : IRequestHandler<GetCustomersFilteredNameQuery, List<Customer>>
    {
        private readonly IDataContext _dbContext;

        public GetCustomersFilteredNameHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Customer>> Handle(GetCustomersFilteredNameQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Customers.Where(x => x.Name.Contains(request.Name, StringComparison.InvariantCultureIgnoreCase)).ToListAsync(cancellationToken);
        }
    }
}
