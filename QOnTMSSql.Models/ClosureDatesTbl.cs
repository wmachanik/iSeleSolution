using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class ClosureDatesTbl
    {
        public int Id { get; set; }
        public DateTime? DateClosed { get; set; }
        public DateTime? DateReopen { get; set; }
        public DateTime? NextRoastDate { get; set; }
        public string Comments { get; set; }
    }
}
