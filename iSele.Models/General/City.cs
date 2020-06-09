using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iSele.Models.General
{
    public class City
    {
        public int CityID { get; set; }
        [Required]
        [StringLength(75)]
        [DisplayName("City")]
        public string CityName { get; set; }
        [DisplayName("Area City is found")]
        public int? AreaID { get; set; }
        [StringLength(3, ErrorMessage = "Please use only the 3 leter ISO country code")]
        [DisplayName("ISO Country Code")]
        public string CountryCode { get; set; }
        public string Notes { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }

        [ForeignKey("AreaID")]
        public Area Area { get; set; }
    }

}
