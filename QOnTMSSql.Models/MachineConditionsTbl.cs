using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class MachineConditionsTbl
    {
        public int MachineConditionId { get; set; }
        public string ConditionDesc { get; set; }
        public int? SortOrder { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
