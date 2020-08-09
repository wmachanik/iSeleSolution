using iSele.Models.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iSele.Models.Notifications
{
    public class NotificationsSentLog
    {
        public int NotificationsSentLogID {get; set; }
        public int CustomerID { get; set; }
        public DateTime DateSentNotification { get; set; }
        // public DateTime NextPreperationDate { get; set; }
        public int? NotificationTypeID { get; set; }
        public bool NotificationWasSent { get; set; }
        public string NotificationDesription { get; set; }

        // used to have these - now that will go into description
        //public bool HadAutoFulfilItem { get; set; }
        //public bool HadReoccurItems { get; set; }
        
        [Timestamp] 
        public byte[] RowVersion { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
        public NotificationType NotificationType { get; set; }

    }

}
