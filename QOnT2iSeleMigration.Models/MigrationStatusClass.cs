//using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace QOnT2iSeleMigration.Web.FrontEnd.Models
{
    public class MigrationStatusClass
    {
        public string SourceTable { get; set; }
        public int CurrentSourceRecorderNumber { get; set; }
        public int TotalSourceRecorders { get; set; }
        public string TargetTable { get; set; }
        public int TargetRecordsInserted { get; set; }
        public int TargetRecordsUpdated { get; set; }
        public string MergeStatus { get; set; }

        public MigrationStatusClass()
        {
            Clear();
        }

        public void Clear()
        {
            SourceTable = string.Empty;
            CurrentSourceRecorderNumber = TotalSourceRecorders = 0;
            TargetTable = string.Empty;
            TargetRecordsInserted = TargetRecordsUpdated = 0;
            MergeStatus = string.Empty;
        }

    }
}
