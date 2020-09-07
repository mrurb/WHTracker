
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WHTracker.Data;
using WHTracker.Data.Models;

namespace WHTracker.Services.Cache
{
    public class AggregateCache
    {

        public List<(DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateCorporation> dailyAggregateCorporation)> dailyAggregateCorporations { get; set; }
        public List<DailyAggregateAlliance> dailyAggregateAlliances { get; set; }


        public async Task<(DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateCorporation> dailyAggregateCorporation)?> GetAggregateCorporationAsync(DateTime dateTime)
        {
            (DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateCorporation> dailyAggregateCorporation)? aggregate = dailyAggregateCorporations.SingleOrDefault(c => c.day.Date == dateTime.Date);

            return aggregate;


        }

        /*public async Task<DailyAggregateAlliance> GetDailyAggregateAllianceAsync(DateTime dateTime)
        {
        
        }*/
    }
}
