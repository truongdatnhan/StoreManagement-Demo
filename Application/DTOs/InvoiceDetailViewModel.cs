﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class InvoiceDetailViewModel
    {
        public int Id { get; set; }
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
    }
}
