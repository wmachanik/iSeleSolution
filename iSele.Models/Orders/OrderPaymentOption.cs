using iSele.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Orders
{
    public class OrderPaymentOption
    {
        public int OrderPaymentOptionID { get; set; }
        [Required]
        public int OrderID { get; set; }
        [StringLength(100)]
        public string PurchaseOrder { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }
        public int PaymentTypeID { get; set; }

        public PaymentType PaymentType { get; set; }

    }
}
