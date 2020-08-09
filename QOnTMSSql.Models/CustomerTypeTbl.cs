using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class CustomerTypeTbl
    {
        public int CustTypeId { get; set; }
        public string CustTypeDesc { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
