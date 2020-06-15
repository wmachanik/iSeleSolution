using iSele.Models.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iSele.Models.Orders
{
    public class RecurringOrder
    {
        [Key]
        public int RecurringOrderID { get; set; }
        public int CustomerID { get; set; }
        public int RecurringTypeID { get; set; }
        public int RecurringValue { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Next recurring order date")]
        public DateTime NextDateRequired { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date until recurring order will run")]
        public DateTime RequireUntilDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Last Done")]
        public DateTime DateLastDone { get; set; }
        public int DeliveryByID { get; set; }
        public bool Enabled { get; set; }
        public string Notes { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }

        public RecurringType RecurringType { get; set; }
        [ForeignKey("DeliveryByID")]
        public Person DeliveryBy { get; set; }
        [ForeignKey("RecurringOrderID")]
        public ICollection<RecurringOrderItem> RecurringOrderItems { get; set; }
    }
}
