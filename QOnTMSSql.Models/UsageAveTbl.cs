using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class UsageAveTbl
    {
        public int ClientId { get; set; }
        public int? CoffeeCycle { get; set; }
        public int? CoffeeProvided { get; set; }
        public int? PreferedCoffeeId { get; set; }
        public DateTime? LastOrderedDate { get; set; }
        public DateTime? EstReorderDate { get; set; }
        public int? CupsPerDaysConsumed { get; set; }
        public DateTime? LastCleanDate { get; set; }
        public DateTime? EstCleanDate { get; set; }
        public DateTime? LastFilterDate { get; set; }
        public DateTime? EstFilterDate { get; set; }
        public DateTime? LastDescaleDate { get; set; }
        public DateTime? EstDescaleDate { get; set; }
        public bool? FitlerOnlyClient { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
