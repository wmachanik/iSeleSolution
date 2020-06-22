using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iSele.Models.Items
{
    public class UsedItemGroup
    {
        public int UsedItemGroupID  { get; set; }
        public int CustomerID { get; set; }
        public int GroupItemD { get; set; }
        public int LastItemID { get; set; }
        public int LastItemSortPos { get; set; }
        public DateTime LastItemDateChanged { get; set; }
        //[Timestamp] 
        //public byte[] RowVersion { get; set; }
        //[ForeignKey("GroupItemID")]
        //public Item GroupItemName { get; set; }
        //[ForeignKey("LastItemID")]
        //public Item LastItem { get; set; }

    }
}
