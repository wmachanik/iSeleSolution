using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class OrdersTbl
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RoastDate { get; set; }
        public int? ItemTypeId { get; set; }
        public float? QuantityOrdered { get; set; }
        public DateTime? RequiredByDate { get; set; }
        public int? PrepTypeId { get; set; }
        public int? PackagingId { get; set; }
        public int? ToBeDeliveredBy { get; set; }
        public bool? Confirmed { get; set; }
        public bool? Done { get; set; }
        public bool? Packed { get; set; }
        public string Notes { get; set; }
        public string PurchaseOrder { get; set; }
        public bool? InvoiceDone { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
