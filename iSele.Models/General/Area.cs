using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace iSele.Models.General
{
    public class Area
    {
        public int AreaID { get; set; }
        [StringLength(75)]
        [NotNull]
        [DisplayName("Area")]
        public string AreaName { get; set; }
        [Required]
        [DisplayName("Next Manufacturing Day")]
        public short NextManufacturingDay { get; set; }
        [Required]
        [DisplayName("Next Dispach Day")]
        public short NextDispatchDay { get; set; }
        [DisplayName("Estimate Delivery Delay")]
        public short? EstimatedDeliveryDelay { get; set; }
        public string Note { get; set; }

        [ForeignKey("AreaID")]
        public ICollection<AreaDaySetting> AreaDaySettings { get; set; }

        [Timestamp] 
        public byte[] RowVersion { get; set; }
    }
 }
