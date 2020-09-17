using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
#nullable disable
namespace WHTracker.Data.Models
{
    public class Corporation
    {
        public int CorporationId { get; set; }
        public string CorporationName { get; set; }
        public string CorporationTicker { get; set; }
        public int MemberCount { get; set; }
        public DateTime LastUpdated { get; set; }
        [JsonIgnore]
        public IEnumerable<DailyAggregateCorporation> DailyAggregateCorporations { get; set; }
        [JsonIgnore]
        public IEnumerable<MonthlyAggregateCorporation> MonthlyAggregateCorporations { get; set; }
    }
}