using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class PriceLevelsTbl
    {
        public int PriceLevelId { get; set; }
        public string PriceLevelDesc { get; set; }
        public float? PricingFactor { get; set; }
        public bool? Enabled { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
