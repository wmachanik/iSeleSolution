using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class CustomerTrackedServiceItemsTbl
    {
        public int CustomerTrackedServiceItemsId { get; set; }
        public int? CustomerTypeId { get; set; }
        public int? ServiceTypeId { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
