using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Accounts
{
    public class InvoiceType
    {
        public int InvoiceTypeID { get; set; }
        [Required(ErrorMessage = "Invoice Type is required")]
        [StringLength(50)]
        [DisplayName("Invoice Type")]
        public string InvoiceTypeName { get; set; }
        [DisplayName("Is Enabled")]
        public bool? IsEnabled { get; set; }
        public string Notes { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }
    }
}
