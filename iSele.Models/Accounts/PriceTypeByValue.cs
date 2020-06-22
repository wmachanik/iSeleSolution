using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace iSele.Models.Accounts
{
    public class PriceTypeByValue
    {
        [Key]
        public int PriceTypeByValueID { get; set; }
        [StringLength(75)]
        [Required]
        [DisplayName("Price Type By Value Name")]
        public string PriceTypeByValueName { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Value { get; set; }
        public string Notes { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }
    }
}
