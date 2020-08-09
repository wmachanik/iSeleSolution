using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class TrackedServiceItemTbl
    {
        public int TrackerServiceItemId { get; set; }
        public int? ServiceTypeId { get; set; }
        public float? TypicalAvePerItem { get; set; }
        public string UsageDateFieldName { get; set; }
        public string UsageAveFieldName { get; set; }
        public bool? ThisItemSetsDailyAverage { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
