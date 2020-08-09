using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class CustomersAccInfoTbl
    {
        public int CustomersAccInfoId { get; set; }
        public int? CustomerId { get; set; }
        public bool? RequiresPurchOrder { get; set; }
        public string CustomerVatno { get; set; }
        public string BillAddr1 { get; set; }
        public string BillAddr2 { get; set; }
        public string BillAddr3 { get; set; }
        public string BillAddr4 { get; set; }
        public string BillAddr5 { get; set; }
        public string ShipAddr1 { get; set; }
        public string ShipAddr2 { get; set; }
        public string ShipAddr3 { get; set; }
        public string ShipAddr4 { get; set; }
        public string ShipAddr5 { get; set; }
        public string AccEmail { get; set; }
        public string AltAccEmail { get; set; }
        public int? PaymentTermId { get; set; }
        public float? Limit { get; set; }
        public string FullCoName { get; set; }
        public string AccFirstName { get; set; }
        public string AccLastName { get; set; }
        public string AltAccFirstName { get; set; }
        public string AltAccLastName { get; set; }
        public int? PriceLevelId { get; set; }
        public int? InvoiceTypeId { get; set; }
        public string RegNo { get; set; }
        public string BankAccNo { get; set; }
        public string BankBranch { get; set; }
        public bool? Enabled { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
