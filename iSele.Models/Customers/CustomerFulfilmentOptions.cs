using iSele.Models.Lookups;
using iSele.Models.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iSele.Models.Customers
{
    public class CustomerFulfilmentOptions
    {
        public int CustomerFulfilmentOptionsID { get; set; }
        public int CustomerID { get; set; }
        public int? PreferedPostalAddressID { get; set; }
        public int? PreferedShippingAddressID { get; set; }
        [DisplayName("Fulfilment is automatic")]
        public bool IsAutoFulfilled { get; set; }
        [DisplayName("Normally replies")]
        public bool DoesNormallyRespond { get; set; }
        [DisplayName("Always send notifications")]
        public bool AlwaysSendNotification { get; set; }
        public bool PredictionIsEnabled { get; set; }
        public int? PreferedDispatchDayID { get; set; }
        public int? PreferedDeliveryTimeID { get; set; }
        [DisplayName("Number of reminers sent")]
        public int ReminderCount { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Reminder Last Sent")]
        public int LastReminderDate { get; set; }

        [ForeignKey("PreferedDispatchDayID")]
        public WeekDay PreferedDispatchDay { get; set; }
        [ForeignKey("PreferedDeliveryTimeID")]
        public PreferedDeliveryTime PreferedDeliveryTime { get; set; }
        [ForeignKey("CustomerID, PreferedPostalAddressID")]
        public CustomerPostalAddress PreferedPostalAddress { get; set; }
        [ForeignKey("CustomerID, PreferedShippingAddressID")]
        public CustomerShippingAddress PreferedShippingAddress { get; set; }

        [ForeignKey("CustomerID")]
        public ICollection<RecurringOrder> RecurringOrders { get; set; }
        [ForeignKey("CustomerID")]
        public ICollection<CustomerPostalAddress> CustomerPostalAddresses { get; set; }
        [ForeignKey("CustomerID")]
        public ICollection<CustomerShippingAddress> CustomerShippingAddresses { get; set; }
    }
}
