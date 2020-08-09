using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class TmpOrdersReplyTbl
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public bool? ThisWeekPlease { get; set; }
        public DateTime? NextCoffeeBy { get; set; }
        public int? Item1 { get; set; }
        public float? Item1Qty { get; set; }
        public int? Item2 { get; set; }
        public float? Item2Qty { get; set; }
        public int? Item3 { get; set; }
        public float? Item3Qty { get; set; }
        public int? Item4 { get; set; }
        public float? Item4Qty { get; set; }
        public int? Item5 { get; set; }
        public float? Item5Qty { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
