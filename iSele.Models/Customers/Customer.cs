using iSele.Models.Accounts;
using iSele.Models.Contacts;
using iSele.Models.Lookups;
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
        public int CustomerName { get; set; }
        [Required(ErrorMessage = "Provide a primare contact's first name")]
        [StringLength(100)]
        [DisplayName("Primary Contact First Name")]
        public int PrimaryContactFirstName { get; set; }
        [StringLength(100)]
        [DisplayName("Primary Contact Last Name")]
        public int PrimaryContactLastName { get; set; }
        [StringLength(100)]
        [DisplayName("Primary Contact email")]
        public string PrimaryContactEmail { get; set; }
        [StringLength(50)]
        [DisplayName("Primary Contact Telephone")]
        public string Telephone { get; set; }
        [DisplayName("Primary Contact Mobile")]
        public string Mobile { get; set; }
        [DisplayName("Is Mobilee Primary")]
        public bool IsMobilePrimary { get; set; }
        public int? CustomerTypeID { get; set; }
        public int? PreferedDeliveryDayID { get; set; }
        public int? PreferedDeliveryTimeID { get; set; }
        
        public int? PriceLevelID { get; set; }
        [Timestamp] public byte[] RowVersion { get; set; }

        public CustomerType CustomerType { get; set; }
        [ForeignKey("PreferedDeliveryDayID")]
        public WeekDay PreferedDeliveryDay { get; set; }
        [ForeignKey("PreferedDeliveryTimeID")]
        public PreferedDeliveryTime PreferedDeliveryTime { get; set; }
        public PriceLevel PriceLevel { get; set; }
        [ForeignKey("CustomerID")]
        public CustomerAccountingOptions CustomerAccountingOptions { get; set; }

        [ForeignKey("CustomerID")]
        public ICollection<CustomerPrefPerType> CustomerPrefPerTypes { get; set; }

        [ForeignKey("CustomerID")]
        public ICollection<CustomerEquipment> CustomerEquipment { get; set; }

    }
}
