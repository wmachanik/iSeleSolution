using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class TotalCountTrackerTbl
    {
        public int Id { get; set; }
        public DateTime? CountDate { get; set; }
        public int? TotalCount { get; set; }
        public string Comments { get; set; }
    }
}
