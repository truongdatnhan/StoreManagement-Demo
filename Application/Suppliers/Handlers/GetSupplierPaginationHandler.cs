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
    public class GetSupplierPaginationHandler : IRequestHandler<GetSupplierPaginationQuery, List<Supplier>>
    {
        private readonly IDataContext _dbContext;

        public GetSupplierPaginationHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Supplier>> Handle(GetSupplierPaginationQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Supplier> query = _dbContext.Suppliers;
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                query.Where(x => x.Name.Contains(request.Name, StringComparison.InvariantCultureIgnoreCase));
            }

            //Will skip item on previous pages
            var skipItems = (request.PageNumber - 1) * request.PageSize;

            return await query.Skip(skipItems).Take(request.PageSize).ToListAsync();
        }
    }
}
