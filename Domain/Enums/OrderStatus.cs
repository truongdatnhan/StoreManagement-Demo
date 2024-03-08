using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Hoàn thành")]
        SUCCESSFUL,
        [Display(Name = "Hủy")]
        CANCELLED,
        [Display(Name = "Còn thiếu")]
        PARTIAL,
        [Display(Name = "Đã trả đủ")]
        PAID,
        [Display(Name = "Chưa thanh toán")]
        WAITING_FOR_PAYMENT,
        [Display(Name = "Hoàn tiền")]
        REFUNDED
    }
}
