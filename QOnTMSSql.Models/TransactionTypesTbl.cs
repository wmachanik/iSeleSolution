using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class TransactionTypesTbl
    {
        public int TransactionId { get; set; }
        public string TransactionType { get; set; }
        public string Notes { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
