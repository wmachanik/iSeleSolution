using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class PredictedOrdersTbl
    {
        public int PredictedOrderId { get; set; }
        public bool? Pinned { get; set; }
        public int? ContactId { get; set; }
        public DateTime? PrepDate { get; set; }
        public int? ItemId { get; set; }
        public int? PrepTypeId { get; set; }
        public int? PackagingId { get; set; }
        public float? Quantity { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? DeliveryPersonId { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
