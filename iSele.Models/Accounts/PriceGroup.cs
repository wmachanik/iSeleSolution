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
    public class PriceGroup
    {
        public int PriceGroupID { get; set; }
        [StringLength(75)]
        [Required]
        [DisplayName("Price Group Name")]
        public string PriceGroupName { get; set; }
        public int PriceListTypeID { get; set; }
        public string Notes { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }
        [ForeignKey("PriceListTypeID")]
        public PriceListType PriceListType { get; set; }
    }
}
