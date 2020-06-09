using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Items
{
    public class ItemType
    {
        public int ItemTypeID { get; set; }
        [Required]
        [StringLength(75)]
        [DisplayName("Item Type")]
        public string ItemTypeName { get; set; }
        public string Notes { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
