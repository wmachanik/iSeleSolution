using iSele.Models.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iSele.Models.Orders
{
    public class OrderLine
    {
        public int OrderLineID { get; set; }
        public int OrderID { get; set; }
        public int? ItemID { get; set; }
        [DataType("decimal(12,4)")]
        [Column(TypeName = "decimal(8,4)")]
        [DisplayName("Qty")]
        public decimal QtyOrdered { get; set; }
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
