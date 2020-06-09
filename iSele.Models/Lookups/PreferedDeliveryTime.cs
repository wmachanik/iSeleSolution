using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;

namespace iSele.Models.Lookups
{
    public class PreferedDeliveryTime
    {
        public int PreferedDeliveryTimeID { get; set; }
        [Required(ErrorMessage = "Start Time required") ]
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public string Notes { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

}
