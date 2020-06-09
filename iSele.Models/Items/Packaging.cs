using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Items
{
    public class Packaging
    {
        public int PackagingID { get; set; }		
        [Required]
        [StringLength(50)]
        [DisplayName("Packaging Type")]
        public string PackagingName { get; set; }
        [StringLength(255)]
        [DisplayName("Additional Notes")]
        public string AdditionalNotes { get; set; }
        [StringLength(2)]
        public string Symbol { get; set; }
        [StringLength(11)]
        public int Colour { get; set; }
        [StringLength(11)]
        [DisplayName("Background Colour")]
        public string BGColour { get; set; }
        [Timestamp] public byte[] RowVersion { get; set; }
    }
}
