using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iSele.Models.Customers
{
    public class CustomerPostalAddress
    {
        [Key, Column(Order = 1)]
        public int CustomerID { get; set; }
        [Key, Column(Order = 2)]
        public int AddressID { get; set; }
    }
}
