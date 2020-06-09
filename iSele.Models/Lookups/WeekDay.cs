using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Lookups
{
    public class WeekDay
    {
        public int WeekDaysID  { get; set; }
        [Required]
        [StringLength(10)]
        public string WeekDayName { get; set; }
        public bool IsDispatchDay { get; set; }
    }
}
