using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class CityTbl
    {
        public CityTbl()
        {
            CityPrepDaysTbl = new HashSet<CityPrepDaysTbl>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public int? RoastingDay { get; set; }
        public int? DeliveryDelay { get; set; }

        public virtual ICollection<CityPrepDaysTbl> CityPrepDaysTbl { get; set; }
    }
}
