using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class PaymentTermsTbl
    {
        public int PaymentTermId { get; set; }
        public string PaymentTermDesc { get; set; }
        public int? PaymentDays { get; set; }
        public int? DayOfMonth { get; set; }
        public bool? UseDays { get; set; }
        public bool? Enabled { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
