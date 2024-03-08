using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public string? SupplierName { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public int Total { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
    }
}
