using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Repairs
{
    public class RepairFault
    {
        public int RepairFaultID { get; set; }
        [Required]
        [StringLength(75)]
        public string RepairFaultName { get; set; }
        public int SortOrder { get; set; }
        public int Notes { get; set; }
        [Timestamp] public byte[] RowVersion { get; set; }
    }

}
