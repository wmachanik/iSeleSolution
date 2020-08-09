using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class VisitLogTbl
    {
        public int Id { get; set; }
        public int? Client { get; set; }
        public DateTime VisitDate { get; set; }
        public int? CupsMade { get; set; }
        public bool? Cleaned { get; set; }
        public bool? Descaled { get; set; }
        public float? CoffeeQty { get; set; }
        public int? CoffeeTypeProvided { get; set; }
        public string InvRef { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
