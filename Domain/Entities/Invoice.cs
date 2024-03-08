using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public int Total { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }

        public Supplier? Supplier { get; set; } 
        public List<InvoiceDetail>? InvoiceDetails { get; set; }
    }
}
