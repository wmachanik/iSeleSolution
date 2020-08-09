using System;
using System.Collections.Generic;

namespace QOnTMSSql.Models
{
    public partial class ServiceTypesTbl
    {
        public int ServiceTypeId { get; set; }
        public string ServiceType { get; set; }
        public string Description { get; set; }
        public int? PackagingId { get; set; }
        public int? PrepTypeId { get; set; }
    }
}
