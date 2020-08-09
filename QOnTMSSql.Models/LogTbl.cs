using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class LogTbl
    {
        public int LogId { get; set; }
        public DateTime? DateAdded { get; set; }
        public int? UserId { get; set; }
        public int? SectionId { get; set; }
        public int? TranactionTypeId { get; set; }
        public int? CustomerId { get; set; }
        public string Details { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
