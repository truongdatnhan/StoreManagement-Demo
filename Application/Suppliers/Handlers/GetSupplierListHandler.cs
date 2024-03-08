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
    public class GetSupplierListHandler : IRequestHandler<GetSupplierListQuery, List<Supplier>>
    {
        private readonly IDataContext _dbContext;

        public GetSupplierListHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Supplier>> Handle(GetSupplierListQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Suppliers.ToListAsync(cancellationToken);
        }
    }
}
