using iSele.Models.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace iSele.Models.General
{
    public class DemoEquipmentUsage
    {
        public int DemoEquipmentUsageID { get; set; }
        public int DemoEquipmentID { get; set; }
        public int CustomerID { get; set; }
        public DateTime ReceiveDated { get; set; }
        public DateTime ReturneDated { get; set; }

        public Customer Customer;
    }
}
