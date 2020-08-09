using iSele.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iSele.Models.Items
{
    public class ItemPrice
    {
        public int ItemPriceID { get; set; }
        public int ItemID { get; set; }
        public int? PriceListTypeID { get; set; }
        public string Notes { get; set; }
        [Timestamp]    
        public byte[] RowVersion { get; set; }

//        [ForeignKey("ItemID")]
//        public Item Item { get; set; }

        [ForeignKey("PriceListTypeID")]
        public PriceListType PriceListType { get; set; }
    }
}
