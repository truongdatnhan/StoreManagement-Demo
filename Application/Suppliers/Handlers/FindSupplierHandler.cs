using Application.Categories.Queries;
using Application.Orders.Queries;
using Application.Suppliers.Queries;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Suppliers.Handlers
{
    public class FindSupplierHandler : IRequestHandler<FindSupplierQuery, Supplier>
    {
        private readonly IDataContext _dbContext;

        public FindSupplierHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Supplier> Handle(FindSupplierQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Suppliers.FindAsync(request.Id, cancellationToken);
        }
    }
}
