using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class CityPrepDaysTbl
    {
        public int CityPrepDaysId { get; set; }
        public int CityId { get; set; }
        public byte PrepDayOfWeekId { get; set; }
        public short DeliveryDelayDays { get; set; }
        public short? DeliveryOrder { get; set; }

        public virtual CityTbl City { get; set; }
    }
}
