using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iSele.Models.Customers
{
    public class CustomerContact
    {
        [Key]
        public int ContactID { get; set; }
        public int CustomerID { get; set; }
        [StringLength(100)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [StringLength(100)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [StringLength(100)]
        [DisplayName("Email")]
        public string Email { get; set; }
        [StringLength(25)]
        public string Telephone { get; set; }
        [StringLength(25)]
        public string Mobile { get; set; }
        public int ShippingAddressID { get; set; }
        public int PostalAddressID { get; set; }
        [DisplayName("Enabled")]
        public bool? IsEnabled { get; set; }
        [DisplayName("Contact Type")]
        public int ContactTypeID { get; set; }
        public string Notes { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ForeignKey("ShippingAddressID")]
        public Address ShippingAddress { get; set; }
        [ForeignKey("PostalAddressID")]
        public Address PostalAddress { get; set; }

        public ContactType ContactType { get; set; }
    }
}
