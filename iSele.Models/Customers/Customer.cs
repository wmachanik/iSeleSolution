using iSele.Models.Accounts;
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
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required(ErrorMessage ="A Company name is required")]
        [StringLength(100)]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Provide a primare contact's first name")]
        [StringLength(100)]
        [DisplayName("Primary Contact First Name")]
        public string PrimaryContactFirstName { get; set; }
        [StringLength(100)]
        [DisplayName("Primary Contact Last Name")]
        public string PrimaryContactLastName { get; set; }
        [StringLength(100)]
        [DisplayName("Primary Contact email")]
        public string PrimaryContactEmail { get; set; }
        [StringLength(50)]
        [DisplayName("Primary Contact Telephone")]
        public string Telephone { get; set; }
        [DisplayName("Primary Contact Mobile")]
        public string Mobile { get; set; }
        [DisplayName("Mobile Is Primary Number")]
        public bool IsMobilePrimary { get; set; }
        [DisplayName("Is Enabled")]
        public bool? IsEnabled { get; set; }
        public int? CustomerTypeID { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }

        public CustomerType CustomerType { get; set; }
        [ForeignKey("CustomerID")]
        public CustomerFulfilmentOptions CustomerFulfilmentOptions { get; set; }
        [ForeignKey("CustomerID")]
        public CustomerAccountingOptions CustomerAccountingOptions { get; set; }
        [ForeignKey("CustomerID")]
        public ICollection<CustomerPrefPerType> CustomerPrefPerTypes { get; set; }

        [ForeignKey("CustomerID")]
        public ICollection<CustomerEquipment> CustomerEquipment { get; set; }

        [ForeignKey("CustomerID")]
        public ICollection<CustomerContact> CustomerContacts { get; set; }
    }
}
