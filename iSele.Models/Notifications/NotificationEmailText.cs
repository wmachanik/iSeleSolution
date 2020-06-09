using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Notifications
{
    public class NotificationEmailText
    {
        public int NotificationEmailTextID { get; set; }
        [DisplayName("Notification Email Header")]
        public string Header { get; set; }
        [DisplayName("Notification Email Body")]
        public string Body { get; set; }
        [DisplayName("Notification Email Footer")]
        public string Footer { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Last Changed")]
        public DateTime DateLastChange { get; set; }
        public string Notes { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
