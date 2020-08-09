using iSele.Models.System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iSele.Models.Orders
{
    public class OrderFulfillment
    {
        public int OrderFulfillmentID{ get; set; }
        public int OrderID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fulfillment Date")]
        public DateTime DateFulfilled { get; set; }
        public int? FulfilledByID { get; set; }
        [StringLength(60)]
        [DisplayName("Tracking Number")]
        public string TrackingNumber { get; set; }
        public string Notes { get; set; }
        [ForeignKey("FulfilledByID")]
        public Party FulfilledBy { get; set; }
    }
}
