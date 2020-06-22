using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iSele.Models.General
{
    public class DemoEquipment
    {
        public int DemoEquipmentID { get; set; }
        [Required]
        [DisplayName("Demo Equipment Name")]
        [StringLength(80)]
        public string DemoEquipmentName { get; set; }
        public int EquipmentTypeID { get; set; }
        [DisplayName("Serial Number")]
        [StringLength(80)]
        public string SerialNumber { get; set; }
        public string Notes { get; set; }
        public EquipmentType EquipmentType { get; set; }
        [ForeignKey("DemoEquipmentID")]
        public ICollection<DemoEquipmentUsage> DemoEquipmentUsages { get; set; }
    }
}
