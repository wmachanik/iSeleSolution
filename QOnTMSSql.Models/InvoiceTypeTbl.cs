using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class InvoiceTypeTbl
    {
        public int InvoiceTypeId { get; set; }
        public string InvoiceTypeDesc { get; set; }
        public bool? Enabled { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
