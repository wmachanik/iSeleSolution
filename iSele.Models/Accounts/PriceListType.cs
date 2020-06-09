using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Accounts
{
    public class PriceListType
    {
        public int PriceListTypeID { get; set; }
        [StringLength(80)]
        [DisplayName("Price List")]
        public string PriceListName { get; set; }
        public int PriceTypeID { get; set; }
        public int VATTaxTypeID { get; set; }
         public string Notes { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }

        //public PriceType PriceType { get; set; }
        public VATTaxType VATTaxType { get; set; }
    }

}
