using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Orders
{
    public class RecurringType
    {
        public int RecurringTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string TypeName { get; set; }
        public string Notes { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }
    }
}

