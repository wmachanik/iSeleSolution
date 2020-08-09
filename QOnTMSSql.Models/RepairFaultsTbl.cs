using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class RepairFaultsTbl
    {
        public int RepairFaultId { get; set; }
        public string RepairFaultDesc { get; set; }
        public int? SortOrder { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
