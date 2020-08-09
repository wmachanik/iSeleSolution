using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class ClientUsageLinesTbl
    {
        public int ClientUsageLineNo { get; set; }
        public int CustomerId { get; set; }
        public DateTime? Date { get; set; }
        public int? CupCount { get; set; }
        public int ServiceTypeId { get; set; }
        public float? Qty { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
