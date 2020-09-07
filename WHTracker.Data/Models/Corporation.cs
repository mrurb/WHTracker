using System;
using System.Collections.Generic;
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

        public IEnumerable<DailyAggregateCorporation> DailyAggregateCorporations { get; set; }
    }
}