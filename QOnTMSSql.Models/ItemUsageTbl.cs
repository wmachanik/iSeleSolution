using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class ItemUsageTbl
    {
        public int ClientUsageLineNo { get; set; }
        public int CustomerId { get; set; }
        public DateTime? Date { get; set; }
        public int? ItemProvided { get; set; }
        public float AmountProvided { get; set; }
        public int? PrepTypeId { get; set; }
        public int? PackagingId { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
