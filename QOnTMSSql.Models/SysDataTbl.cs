using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class SysDataTbl
    {
        public int Id { get; set; }
        public DateTime? LastReoccurringDate { get; set; }
        public bool? DoReoccuringOrders { get; set; }
        public DateTime? DateLastPrepDateCalcd { get; set; }
        public DateTime? MinReminderDate { get; set; }
        public int? GroupItemTypeId { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
