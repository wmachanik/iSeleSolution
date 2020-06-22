using iSele.Models.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.General
{
    public class DemoEquipmentUsage
    {
        public int DemoEquipmentUsageID { get; set; }
        public int CustomerID { get; set; }
        public int DemoEquipmentID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Received")]
        public DateTime ReceiveDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Returned")]
        public DateTime ReturneDate { get; set; }

        public Customer Customer;
        public DemoEquipment DemoEquipment;
    }
}
