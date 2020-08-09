using iSele.Models.Lookups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iSele.Models.General
{
    public class AreaDaySetting
    {
        public int AreaDaySettingID { get; set; }
        //[StringLength(80)]
        //[DisplayName("Area Name")]
        [ForeignKey("Area")]
        public int? AreaID { get; set; }
        // public int? CityID { get; set; }
        public int? PreperationDayOfWeekID { get; set; }
        [DisplayName("Dispatch Delay Days")]
        public short DispatchDelayDays { get; set; }
        [DisplayName("Delivery Order")]
        public short DeliveryOrder { get; set; }
        [DisplayName("Estimate Delivery Daily")]
        public short EstimateDeliveryDelay { get; set; }
        public string Notes { get; set; }

        public Area Area { get; set; }
        //public City City { get; set; }
        [ForeignKey("PreperationDayOfWeekID")]
        public WeekDay PreperationDayOfWeek { get; set; }

    }
}
