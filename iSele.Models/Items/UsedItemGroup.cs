using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Items
{
    public class UsedItemGroup
    {
        public int UsedItemGroupID  { get; set; }
        public int CustomerID { get; set; }
        public int GroupItemTypeID { get; set; }
        public int LastItemTypeID { get; set; }
        public int LastItemTypeSortPos { get; set; }
        public DateTime LastItemDateChanged { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }
    }
}
