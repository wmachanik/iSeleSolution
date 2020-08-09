using iSele.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iSele.Models.Items
{
    public class Item
    {
        public int ItemID { get; set; }
        [Required(ErrorMessage = "Item name")]
        [StringLength(80)]
        [DisplayName("Item name")]
        public string ItemName { get; set; }
        [StringLength(20)]
        public string SKU { get; set; }
        [DisplayName("Enabled?")]
        public bool? IsEnabled { get; set; }
        [DisplayName("Item charateristics")]
        [StringLength(100)]
        public string ItemCharacteritics { get; set; }
        [DisplayName("Item Details")]
        [StringLength(255)]
        public string ItemDetail { get; set; }
        public int? ItemTypeID { get; set; }
        public int? ReplacementItemID { get; set; }
        [StringLength(10, ErrorMessage = "Abbreviated name")]
        public string ItemAbbreviatedame { get; set; }
        //public int? MerchantID { get; set; }
        public short SortOrder { get; set; }
        [DisplayName("Qty/unit")]
        [Column(TypeName = "decimal(12,4)")] 
        public decimal QtyPerUnits { get; set; }
        public int? ItemUnitID { get; set; }
        [DisplayName("Cost Price X VAT")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal CostPriceEXVAT { get; set; }
        [DisplayName("Cost Price inc VAT")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal CostPriceIncVAT { get; set; }
        [DisplayName("Base Price X VAT")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal BasePriceEXVAT { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        [DisplayName("Base Price inc VAT")]
        public decimal BasePriceIncVAT { get; set; }
        public int? VATTaxTypeID { get; set; }
//        [Timestamp]
//        public DateTime CreatedAt { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }

        public ItemType ItemType { get; set; }
        [ForeignKey("ReplacementItemID")]
        public Item ReplacementItem { get; set; }
        //public Merchant Merchant { get; set; }
        public ItemUnit ItemUnit { get; set; }

        public VATTaxType VATTaxType { get; set; }
        [ForeignKey("ItemID")]
        public IEnumerable<ItemPrice> ItemPrices { get; set; }
    }

}
