using iSele.Models.Accounts;
using iSele.Models.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace iSele.Models.Contacts
{
    public class CustomerAccountingOptions
    {
        public int CustomerAccountingOptionsID { get; set; }
        public int CustomerID { get; set; }
        [StringLength(50)]
        [Required]
        [DisplayName("VAT/Tax Number")]
        public string VATTaxNum { get; set; }
        public int PrimaryBillingAddressID { get; set; }
        public int PrimaryShippingAddressID { get; set; }
        [StringLength(200)]
        public string AccEmails { get; set; }
        [DisplayName("Only Email Invoices")]
        public bool OnlyEmailInvoices { get; set; }
        public int PaymentTermsID { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Limit { get; set; }
        [StringLength(100), DisplayName("Full Company Name")]
        public string FullCompanyName { get; set; }
        [StringLength(100), DisplayName("Account Contact Name")]
        public string AccountContactName { get; set; }
        [DisplayName("Purchase Order is Required")]
        public bool IsPORequired { get; set; }
        public int PriceLevelID { get; set; }
        public int InvoiceTypeID { get; set; }
        [DefaultValue("TRUE"), DisplayName("Account is enabled")]
        public bool AccountIsEnabled { get; set; }
        public string Notes { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }


        [ForeignKey("PrimaryBillingAddressID")]
        [DisplayName("Primary Billing Address")]
        public Address PrimaryBillingAddress { get; set; }
        [ForeignKey("PrimaryShippingAddressID")]
        [DisplayName("Primary Shipping Address")]
        public Address PrimaryShippingAddress { get; set; }
        [ForeignKey("InvoiceTypeID")]
        [DisplayName("Invoice Type")]
        public InvoiceType InvoiceType { get; set; }

        [DisplayName("Price Level")]
        [ForeignKey("PriceLevelID")]
        public PriceLevel PriceLevel { get; set; }
        [DisplayName("Payment Terms")]
        public PaymentTerm PaymentTerms { get; set; }

    }
}
