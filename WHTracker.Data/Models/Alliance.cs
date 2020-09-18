using System;
using System.Collections.Generic;
#nullable disable
namespace WHTracker.Data.Models
{
    public class Alliance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        public int MemberCount { get; set; }
        public DateTime LastUpdated { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public IEnumerable<DailyAggregateAlliance> DailyAggregateAlliances { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public IEnumerable<MonthlyAggregateAlliance> MonthlyAggregateAlliances { get; set; }
    }
}