using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class SendCheckEmailTextsTbl
    {
        public int Scemtid { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
        public DateTime? DateLastChange { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
