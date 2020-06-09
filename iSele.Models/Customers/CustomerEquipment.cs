using iSele.Models.General;
using iSele.Models.Lookups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Customers
{
    public class CustomerEquipment
    {
        public int CustomerEquipmentID { get; set; }
        public int CustomerID { get; set; }
        public int EquipmentTypeID { get; set; }
        [StringLength(50)]
        public string EquipSerialNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }
        public string Notes { get; set; }
        [Timestamp] public byte[] RowVersion { get; set; }
        public Customer Customer { get; set; }
        public EquipmentType EquipmentType { get; set; }
    }
}
