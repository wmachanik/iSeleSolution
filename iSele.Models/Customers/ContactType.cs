using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Customers
{
    public class ContactType
    {
        public int ContactTypeID { get; set; }
        [Required]
        [StringLength(100)]
        public string ContactTypeName { get; set; }
        public bool IsFulfillmentContact { get; set; }
        public bool IsAccountsContact { get; set; }
    }
}
