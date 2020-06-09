using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Accounts
{
    public class PriceLevel
    {
        public int PriceLevelID { get; set; }
        [Required]
        [StringLength(50)]
        public string PriceLevelName { get; set; }
        public int PriceLeveTypeID { get; set; }
        [Timestamp] public byte[] RowVersion { get; set; }

//        public PriceLeveType PriceLeveTypes { get; set; }
    }

}
