using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? PickUp { get; set; }
        public int Total { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
