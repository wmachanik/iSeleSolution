using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class ClientUsageTbl
    {
        public int CustomerId { get; set; }
        public int? LastCupCount { get; set; }
        public DateTime? NextCoffeeBy { get; set; }
        public DateTime? NextCleanOn { get; set; }
        public DateTime? NextFilterEst { get; set; }
        public DateTime? NextDescaleEst { get; set; }
        public DateTime? NextServiceEst { get; set; }
        public float? DailyConsumption { get; set; }
        public float? FilterAveCount { get; set; }
        public float? DescaleAveCount { get; set; }
        public float? ServiceAveCount { get; set; }
        public float? CleanAveCount { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
