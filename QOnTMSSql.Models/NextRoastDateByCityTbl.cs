using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class NextRoastDateByCityTbl
    {
        public int NextRoastDayId { get; set; }
        public int? CityId { get; set; }
        public DateTime? PreperationDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public short? DeliveryOrder { get; set; }
        public DateTime? NextPreperationDate { get; set; }
        public DateTime? NextDeliveryDate { get; set; }
    }
}
