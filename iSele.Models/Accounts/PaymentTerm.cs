using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Accounts
{
    public class PaymentTerm
    {
        public int PaymentTermID { get; set; }
        [Required(ErrorMessage = "Payment Term is required")]
        [StringLength(50)]
        [DisplayName("Payment Term")]
        public string PaymentTermName { get; set; }
        [DisplayName("Payment Days")]
        public int PaymentDays { get; set; }
        [DisplayName("Payment Day of Month")]
        public int DayOfMonth { get; set; }
        [DisplayName("Use Days?")]
        public bool UseDays { get; set; }
        [DisplayName("Enabled?")]
        public bool IsEnabled { get; set; }
        public string Notes { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }
    }

}
