using Application.Categories.Commands;
using Application.Suppliers.Commands;
using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Suppliers.Handlers
{
    public class InsertSupplierHandler : IRequestHandler<InsertSupplierCommand, int>
    {
        private readonly IDataContext _dbContext;

        public InsertSupplierHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(InsertSupplierCommand request, CancellationToken cancellationToken = default)
        {
            var supplier = new Supplier()
            {
                Name = request.Name
            };

            await _dbContext.Suppliers.AddAsync(supplier, cancellationToken);
            return await _dbContext.SaveAsync(cancellationToken);


        }
    }
}
