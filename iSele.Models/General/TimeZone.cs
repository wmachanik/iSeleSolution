using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.General
{
    public class TimeZone
    {
        public int TimZoneID { get; set; }
        [Required]
        [StringLength(10)]
        public string ISOAbbreviation { get; set; }
        [StringLength(30)]
        public string TiemZoneName { get; set; }
        public short UTCOffset { get; set; }
        public bool HasDaylightSavings { get; set; }
        [Timestamp] public byte[] RowVersion { get; set; }
    }
}
