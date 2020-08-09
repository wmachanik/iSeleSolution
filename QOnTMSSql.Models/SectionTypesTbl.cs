using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class SectionTypesTbl
    {
        public int SectionId { get; set; }
        public string SectionType { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
