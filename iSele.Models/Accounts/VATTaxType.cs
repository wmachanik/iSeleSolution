using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iSele.Models.Accounts
{
    public class VATTaxType
    {
        public int VATTaxTypeID  { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("VAT or Tax name")]
        public string VATTaxName { get; set; }
        [DataType("decimal(8,4)")]
        [Column(TypeName = "decimal(8,4)")]
        [DisplayName("VAT or Tax rate")]
        public decimal VATTaxRate { get; set; }
        [DisplayName("Is this the default rate")]
        public bool IsDefault { get; set; }
        public string Notes { get; set; }
        [Timestamp] public byte[] RowVersion { get; set; }
}

}
