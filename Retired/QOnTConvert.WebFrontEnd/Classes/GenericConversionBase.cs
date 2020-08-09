using System;
using System.Collections.Generic;
using System.Text;

namespace QOnTConvert.WebFrontEnd.Classes
{
    class GenericConversionBase
    {
        public int RecordsRead { get; set; }
        public int RecordsInserted { get; set; }
        public int RecordsUpdated { get; set; }
        public string SourceTable { get; set; }
        public string DestinationTable { get; set; }
    }
}
