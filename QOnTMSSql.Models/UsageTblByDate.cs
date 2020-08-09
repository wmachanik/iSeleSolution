using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class UsageTblByDate
    {
        public int UsaageId { get; set; }
        public int? ClientId { get; set; }
        public DateTime Date { get; set; }
        public int? CupCount { get; set; }
        public bool? CoffeeProvded { get; set; }
        public bool? MachineCleaned { get; set; }
        public bool? FilterProvided { get; set; }
        public bool? MachineDescaled { get; set; }
        public bool? CountCheckOnly { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
