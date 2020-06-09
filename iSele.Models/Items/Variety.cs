using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.Items
{
    public class Variety
    {
        public int VarietyID  { get; set; }		
        [Required]
        [StringLength(50)]
        [DisplayName("Variety Type")]
        public string VarietyName { get; set; }
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
