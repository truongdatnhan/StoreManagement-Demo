using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? PickUp { get; set; }
        public int Total { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public Customer? Customer { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
