using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.General
{
    public class EquipmentType
    {
        public int EquipmentTypeID { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Equipment Type Name")]
        public string EquipmentTypeName { get; set; }
        [StringLength(100)]
        [DisplayName("Equipment Type Description")]
        public string EquipmentTypeDesc { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
