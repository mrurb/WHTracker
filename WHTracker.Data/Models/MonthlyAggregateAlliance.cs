using System;
using System.Collections.Generic;
using System.Text;

namespace WHTracker.Data.Models
{
    public class MonthlyAggregateAlliance : AggregateData
    {
        public int MonthlyAggregateAllianceID { get; set; }

        public int AllianceId { get; set; }

        public Alliance Alliance { get; set; }
    }
}
