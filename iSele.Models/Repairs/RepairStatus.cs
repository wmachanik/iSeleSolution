using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Repairs
{
    public class RepairStatus
    {
        public int RepairStatusID { get; set; }
        [Required]
        [StringLength(50)]
        public string RepairStatusName { get; set; }
        public bool EmailClient { get; set; }
        public int SortOrder { get; set; }
        public string Notes { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }
    }
}
