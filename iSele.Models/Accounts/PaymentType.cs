using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Accounts
{
    public class PaymentType
    {
        public int PaymentTypeID { get; set; }
        [Required(ErrorMessage ="Payment Type is required")]
        [StringLength(50, ErrorMessage = "Payment Type can only be 50 characters long")]
        [DisplayName("Payment Type")]
        public string PaymentTypeName { get; set; }
        [DisplayName("Enabled?")]
        public bool? IsEnabled { get; set; }
        public string Notes { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
