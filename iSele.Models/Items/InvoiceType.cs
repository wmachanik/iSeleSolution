using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Items
{
    public class InvoiceType
    {
        public int InvoiceTypeID { get; set; }
        [Required]
        [StringLength(30)]
        [DisplayName("Invoice Type")]
        public string InvoiceTypeName { get; set; }
        [DisplayName("Enabled")]
        public bool IsEnabled { get; set; }
        public string Notes { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }
    }
}
