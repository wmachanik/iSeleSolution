using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class PersonsTbl
    {
        public int PersonId { get; set; }
        public string Person { get; set; }
        public string Abreviation { get; set; }
        public bool? Enabled { get; set; }
        public int? NormalDeliveryDoW { get; set; }
        public string SecurityUsername { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
