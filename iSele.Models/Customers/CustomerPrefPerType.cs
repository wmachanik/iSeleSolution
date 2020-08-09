using iSele.Models.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Customers
{
    public class CustomerPrefPerType
    {

        public int CustomerPrefPerTypeID { get; set; }
        public int CustomerID { get; set; }
        public int? ItemID { get; set; }
        public int? PackagingID { get; set; }
        public int? VarietyID { get; set; }
        public string Notes { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public Item Item { get; set; }
        public Packaging Packaging { get; set; }
        public Variety Variety { get; set; }
    }
}
