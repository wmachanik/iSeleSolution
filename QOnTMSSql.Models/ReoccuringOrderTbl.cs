using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class ReoccuringOrderTbl
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? ReoccuranceType { get; set; }
        public byte? Value { get; set; }
        public int? ItemRequiredId { get; set; }
        public double? QtyRequired { get; set; }
        public DateTime? DateLastDone { get; set; }
        public DateTime? NextDateRequired { get; set; }
        public DateTime? RequireUntilDate { get; set; }
        public bool? Enabled { get; set; }
        public string Notes { get; set; }
        public int? PackagingId { get; set; }
        public int? DeliveryById { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
