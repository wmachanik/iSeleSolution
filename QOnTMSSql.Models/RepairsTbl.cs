using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class RepairsTbl
    {
        public int RepairId { get; set; }
        public int? CustomerId { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string JobCardNumber { get; set; }
        public DateTime? DateLogged { get; set; }
        public DateTime? LastStatusChange { get; set; }
        public int? MachineTypeId { get; set; }
        public string MachineSerialNumber { get; set; }
        public int? SwopOutMachineId { get; set; }
        public int? MachineConditionId { get; set; }
        public bool? TakenFrother { get; set; }
        public bool? TakenBeanLid { get; set; }
        public bool? TakenWaterLid { get; set; }
        public bool? BrokenFrother { get; set; }
        public bool? BrokenBeanLid { get; set; }
        public bool? BrokenWaterLid { get; set; }
        public int? RepairFaultId { get; set; }
        public string RepairFaultDesc { get; set; }
        public int? RepairStatusId { get; set; }
        public int? RelatedOrderId { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
