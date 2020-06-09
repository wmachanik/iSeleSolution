using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Items
{
    public class ItemUnit
    {
        public int ItemUnitID { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Unit Name")]
        public string UnitName { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Unit of measure must be of length 1-10")]
        [DisplayName("Unit of Measure")]
        public string UnitOfMeasure { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }
    }
}
