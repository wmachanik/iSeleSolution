using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Repairs
{
    public class MachineCondition
    {
        public int MachineConditionID { get; set; }
        [Required]
        [StringLength(75)]
        [DisplayName("Condition")]
        public string ConditionName { get; set; }
        [Required]
        [DisplayName("Sort ORder")]
        public int SortOrder { get; set; }
        public int Notes { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }
    }
}

