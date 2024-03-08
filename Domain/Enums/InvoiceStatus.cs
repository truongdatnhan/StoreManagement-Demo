using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Enums
{
    public enum InvoiceStatus
    {
        [Display(Name = "Mới tạo")]
        NEW,
        [Display(Name = "Hoàn thành")]
        COMPLETED,
        [Display(Name = "Thiếu")]
        PARTIAL,
    }
}
