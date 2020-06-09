using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Items
{
    public class ServiceType
    {
        public int ServiceTypeID { get; set; }
        [Required(ErrorMessage ="Service Type is required")]
        [StringLength(20)]
        [DisplayName("Serivce Type")]
        public string ServiceTypeName { get; set; }
        [StringLength(100)]
        [DisplayName("Serivce Type Description")]
        public string Description { get; set; }
        public int PackagingID { get; set; }
        public int VarietyID { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }

        public Packaging Packaging { get; set; }
        public Variety Variety { get; set; }
    }
}
