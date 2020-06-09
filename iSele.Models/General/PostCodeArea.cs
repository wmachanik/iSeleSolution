using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iSele.Models.General
{
    public class PostCodeArea
    {
        public int PostCodeAreaID { get; set; }
        [Required]
        [StringLength(15)]
        [DisplayName("Postal Code Start")]
        public string PostCodeStart { get; set; }
        [Required]
        [StringLength(15)]
        [DisplayName("Postal Code End")]
        public string PostCodeEnd { get; set; }
        public int AreaDayID { get; set; }
        public string Notes { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ForeignKey("AreaDayID")]
        public AreaDaySetting AreaDaySetting { get; set; }
    }
}
