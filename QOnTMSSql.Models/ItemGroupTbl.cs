using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class ItemGroupTbl
    {
        public int ItemGroupId { get; set; }
        public int? GroupItemTypeId { get; set; }
        public int? ItemTypeId { get; set; }
        public int? ItemTypeSortPos { get; set; }
        public bool? Enabled { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
