using iSele.Models.Customers;
using iSele.Models.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iSele.Models.Orders
{
    public class Order
    {
        public int OrderID { get; set; }
        public int? CustomerID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Order date")]
        public DateTime OrderDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Preparation date")]
        public DateTime PreparationDate { get; set; }
        public int? OrderMethodTypeID { get; set; }
        public int? DeliveryByID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Dispatch or Delivery Date ")]
        public DateTime DispatchDate { get; set; }
        public string Notes { get; set; }
        // Other tables referenced
        public Customer Customer { get; set; }
        [ForeignKey("OrderID")]
        public OrderOptions OrderOptions { get; set; }
        [ForeignKey("OrderID")]
        public OrderPaymentOptions OrderPaymentOptions { get; set; }
        public OrderMethodType OrderMethodType { get; set; }
        [ForeignKey("OrderID")]
        public OrderFulfillment OrderFulfillment { get; set; }

        [ForeignKey("DeliveryByID")]
        public Party DeliveryBy { get; set; }
        [ForeignKey("OrderID")]
        public IEnumerable<OrderLine> OrderLines { get; set; }
    }
}
