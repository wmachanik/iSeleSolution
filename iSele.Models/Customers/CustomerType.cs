using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Customers
{
    public class CustomerType
    {
        public int CustomerTypeID { get; set; }
        [StringLength(100)]
        [Required]
        public string CustomerTypeName { get; set; }
        public bool HasExtendedOptions { get; set; }
        public string Notes { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }
    }
}
