using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.System
{
    public class SystemPreferences
    {
        public int SystemPreferencesID { get; set; }
        public DateTime LastReccurringDate { get; set; }
        public bool DoReccuringOrders { get; set; }
        public DateTime DateLastPrepDateCalcd { get; set; }
        public DateTime MinReminderDate { get; set; }
        public int GroupItemTypeID { get; set; }
        [StringLength(100)]
        public string ImageFolderPath { get; set; }
        public int DefaultDeliveryPersonID { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }
    }
}
