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
    public class PriceTypeByPercent
    {
        [Key]
        public int PriceTypeByPercentID { get; set; }
        [StringLength(75)]
        [Required]
        [DisplayName("Price Type By Percent Name")]
        public string PriceTypeByPercentName { get; set; }
        [Column(TypeName = "decimal(8,4)")]
        public decimal Precentage { get; set; }
        public string Notes { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
