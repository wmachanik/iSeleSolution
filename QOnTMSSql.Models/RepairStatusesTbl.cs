using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class RepairStatusesTbl
    {
        public int RepairStatusId { get; set; }
        public string RepairStatusDesc { get; set; }
        public bool? EmailClient { get; set; }
        public int? SortOrder { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
