using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class ItemTypeTbl
    {
        public int ItemTypeId { get; set; }
        public string Sku { get; set; }
        public string ItemDesc { get; set; }
        public bool? ItemEnabled { get; set; }
        public string ItemsCharacteritics { get; set; }
        public string ItemDetail { get; set; }
        public int? ServiceTypeId { get; set; }
        public int? ReplacementId { get; set; }
        public string ItemShortName { get; set; }
        public int? SortOrder { get; set; }
        public float? UnitsPerQty { get; set; }
        public int? ItemUnitId { get; set; }
        public float? BasePrice { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
    }
}
