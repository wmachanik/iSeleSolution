using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class UsedItemGroupTbl
    {
        public int UsedItemGroupId { get; set; }
        public int? ContactId { get; set; }
        public int? GroupItemTypeId { get; set; }
        public int? LastItemTypeId { get; set; }
        public int? LastItemTypeSortPos { get; set; }
        public DateTime? LastItemDateChanged { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
