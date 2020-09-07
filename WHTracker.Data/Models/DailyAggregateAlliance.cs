using System;
#nullable disable
namespace WHTracker.Data.Models
{
    public class DailyAggregateAlliance : AggregateData
    {

        public int DailyAggregateAllianceID { get; set; }

        public int AllianceId { get; set; }

        public Alliance Alliance { get; set; }

    }
}
