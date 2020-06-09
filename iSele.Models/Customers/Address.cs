using iSele.Models.General;
using iSele.Models.Lookups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Customers
{
    public class Address
    {
        public int AddressID { get; set; }
        [DisplayName("Address Line 1")]
        [StringLength(75)]
        public string AddressLine1 { get; set; }
        [DisplayName("Address Line 2")]
        [StringLength(75)]
        public string AddressLine2 { get; set; }
        [DisplayName("Address Line 3")]
        [StringLength(75)]
        public string AddressLine3 { get; set; }
        [DisplayName("City")]
        public int CityID { get; set; }
        [StringLength(10)]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
        public string Notes { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }

        public City City { get; set; }
    }
}
