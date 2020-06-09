using iSele.Models.Customers;
using iSele.Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace iSele.Models.Repairs
{
    public class Repair
    {
        public int RepairID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [StringLength(75)]
        [DisplayName("Contact Name for Repair")]
        public string ContactName { get; set; }
        [StringLength(75)]
        [DisplayName("Contact Email for Repair")]
        public string ContactEmail { get; set; }
        [StringLength(20)]
        [DisplayName("Job Card Number")]
        public string JobCardNumber { get; set; }
        [DisplayName("Logged Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateLogged { get; set; }
        [DisplayName("Last Status Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastStatusChange { get; set; }
        [DisplayName("Equipment Type")]
        public int EquipmentTypeID { get; set; }
        [DisplayName("Equipment Serial Number")]
        [StringLength(75)]
        public string EquipmentSerialNumber { get; set; }
        public int SwopOutEquipmentID { get; set; }
        public int MachineConditionID { get; set; }
        [DisplayName("We took the frother ")]
        public bool TakenFrother { get; set; }
        [DisplayName("We took the Bean lid")]
        public bool TakenBeanLid { get; set; }
        [DisplayName("We took the water")]
        public bool TakenWaterLid { get; set; }
        [DisplayName("Is the frother in working order")]
        public bool IsFrotherWorking { get; set; }
        [DisplayName("Is bean lid ok")]
        public bool IsBeanLidOk { get; set; }
        [DisplayName("Is bater lid ok")]
        public bool IsWaterLidOk { get; set; }
        public int RepairFaultID { get; set; }
        [DisplayName("What is the fault")]
        [StringLength(255)]
        public string RepairFaultDesc { get; set; }
        public int RepairStatusID { get; set; }
        public int RelatedOrderID { get; set; }
        [DisplayName("Any additionla Notes")]
        public int Notes { get; set; }
        [Timestamp] public byte[] RowVersion { get; set; }

        public Customer Customer { get; set; }
        public EquipmentType EquipmentType { get; set; }
        [ForeignKey("SwopOutEquipmentID")]
        public DemoEquipment SwopOutEquipment { get; set; }
        public MachineCondition MachineCondition { get; set; }
        public RepairFault RepairFault { get; set; }
        public RepairStatus RepairStatus { get; set; }
    }

}
