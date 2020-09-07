using System;

namespace WHTracker.Data.Models
{
    public class DailyAggregateAlliance : AggregateData
    {

        public int DailyAggregateAllianceID { get; set; }

        public int AllianceID { get; set; }

        public Alliance Alliance { get; set; }

    }
}
