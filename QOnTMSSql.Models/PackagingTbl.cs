using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class PackagingTbl
    {
        public int PackagingId { get; set; }
        public string Description { get; set; }
        public string AdditionalNotes { get; set; }
        public string Symbol { get; set; }
        public int? Colour { get; set; }
        public string Bgcolour { get; set; }
    }
}
