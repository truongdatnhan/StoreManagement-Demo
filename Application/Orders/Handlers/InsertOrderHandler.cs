using Application.Categories.Commands;
using Application.Orders.Commands;
using Application.Suppliers.Commands;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Handlers
{
    public class InsertOrderHandler : IRequestHandler<InsertOrderCommand, int>
    {
        private readonly IDataContext _dbContext;

        public InsertOrderHandler(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(InsertOrderCommand request, CancellationToken cancellationToken = default)
        {
            var order = new Order()
            {
                CustomerId = request.CustomerId,
                Created = DateTime.Now,
                PickUp = request.PickUp,
                OrderStatus = OrderStatus.WAITING_FOR_PAYMENT
            };

            await _dbContext.Orders.AddAsync(order, cancellationToken);
            return await _dbContext.SaveAsync(cancellationToken);


        }
    }
}
