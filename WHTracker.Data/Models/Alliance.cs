using System;
using System.Collections.Generic;

namespace WHTracker.Data.Models
{
    public class Alliance
    {
        public int AllianceID { get; set; }
        public string AllianceName { get; set; }
        public string AllianceTicker { get; set; }
        public int MemberCount { get; set; }
        public DateTime LastUpdated { get; set; }

        public IEnumerable<DailyAggregateAlliance> dailyAggregateAlliances { get; set; }
    }
}