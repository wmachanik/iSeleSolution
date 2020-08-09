using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Orders
{
    public class OrderOptions
    {
        public int OrderOptionsID { get; set; }
        public int OrderID { get; set; }
        [Display(Name = "Invoice Prepared")]
        public bool? InvoiceIsPrepared { get; set; }
        [Display(Name = "Email Confimation Sent")]
        public bool? EmailConfirmationSent { get; set; }
        [Display(Name = "Is Ready to Be Disaptch")]
        public bool? IsReadyForDispatch { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expected Delivery Date ")]
        public DateTime? ExpectedDeliveryDate { get; set; }
        [Display(Name = "Order Is Done")]
        public bool? IsDone { get; set; }
        [Display(Name = "Path where POD is")]
        public string PODImagePath { get; set; }
    }
}
