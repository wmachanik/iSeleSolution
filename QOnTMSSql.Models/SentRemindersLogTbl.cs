using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class SentRemindersLogTbl
    {
        public int ReminderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? DateSentReminder { get; set; }
        public DateTime? NextPrepDate { get; set; }
        public bool? ReminderSent { get; set; }
        public bool? HadAutoFulfilItem { get; set; }
        public bool? HadReoccurItems { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
