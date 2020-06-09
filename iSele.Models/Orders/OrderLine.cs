using iSele.Models.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Orders
{
    class OrderLine
    {
        public int OrderLineID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public decimal QuantityOrdered { get; set; }
        public int VarietyTypeID { get; set; }
        public int PackagingID { get; set; }
        public string Notes { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }

        public Item Item { get; set; }
        public Packaging Packaging { get; set; }
        public Variety Variety { get; set; }
    }

}
