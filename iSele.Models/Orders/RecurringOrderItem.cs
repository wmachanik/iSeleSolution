using iSele.Models.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iSele.Models.Orders
{
    public class RecurringOrderItem
    {
        public int RecurringOrderItemID { get; set; }
        public int RecurringOrderID { get; set; }
        public int ItemRequiredID { get; set; }
        public int PackagingRequiredID { get; set; }
        public int VarietyRequiredID { get; set; }

        public decimal QtyRequired { get; set; }
        public bool Enabled { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        [ForeignKey("ItemRequiredID")]
        public Item ItemRequired { get; set; }
        [ForeignKey("PackagingRequiredID")]
        public Packaging Packaging { get; set; }
        [ForeignKey("VarietyRequiredID")]
        public Variety Variety { get; set; }
    }
}
