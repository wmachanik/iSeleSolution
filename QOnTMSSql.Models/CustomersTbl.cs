using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class CustomersTbl
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactTitle { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactAltFirstName { get; set; }
        public string ContactAltLastName { get; set; }
        public string Department { get; set; }
        public string BillingAddress { get; set; }
        public int? City { get; set; }
        public string StateOrProvince { get; set; }
        public string PostalCode { get; set; }
        public string CountryRegion { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public string FaxNumber { get; set; }
        public string CellNumber { get; set; }
        public string EmailAddress { get; set; }
        public string AltEmailAddress { get; set; }
        public string ContractNo { get; set; }
        public int? CustomerTypeId { get; set; }
        public string CustomerTypeOld { get; set; }
        public int? EquipType { get; set; }
        public int? CoffeePreference { get; set; }
        public float? PriPrefQty { get; set; }
        public int? PrefPrepTypeId { get; set; }
        public int? PrefPackagingId { get; set; }
        public int? SecondaryPreference { get; set; }
        public float? SecPrefQty { get; set; }
        public bool? TypicallySecToo { get; set; }
        public int? PreferedAgent { get; set; }
        public int? SalesAgentId { get; set; }
        public string MachineSn { get; set; }
        public bool? UsesFilter { get; set; }
        public bool? Autofulfill { get; set; }
        public bool? Enabled { get; set; }
        public bool? PredictionDisabled { get; set; }
        public bool? AlwaysSendChkUp { get; set; }
        public bool? NormallyResponds { get; set; }
        public int? ReminderCount { get; set; }
        public string Notes { get; set; }
        public bool? SendDeliveryConfirmation { get; set; }
        public DateTime? LastDateSentReminder { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
