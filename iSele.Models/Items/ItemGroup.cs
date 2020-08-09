using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iSele.Models.Items
{
    public class ItemGroup
    {
        public int ItemGroupID { get; set; }
        // this is the ItemTypeID of of the group in the Item Table
        public int? GroupItemID { get; set; }
        public int? ItemID { get; set; }
        public int ItemSortPos { get; set; }
        public bool IsEnabled { get; set; }
        public string Notes { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ForeignKey("GroupItemID")]
        public Item GroupItem { get; set; }
        [ForeignKey("ItemID")]
        public Item Item { get; set; }
    }
}
