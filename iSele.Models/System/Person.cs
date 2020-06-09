using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSele.Models.System
{
    public class Person
    {
        public int PersonID { get; set; }
        [Required]
        [StringLength(50)]
        public string PersonsName { get; set; }
        [StringLength(5)]
        public string Abbreviation { get; set; }
        public bool Enabled { get; set; }
        public int NormalDeliveryDoW { get; set; }
        [StringLength(255)]
        public string LoginUsername { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }
    }

}
