
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
        public List<(DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateAlliance> dailyAggregateAlliances)> dailyAggregateAlliances { get; set; }

        public AggregateCache()
        {
            dailyAggregateCorporations = new List<(DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateCorporation> dailyAggregateCorporation)>();
            dailyAggregateAlliances = new List<(DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateAlliance> dailyAggregateAlliances)>();
        }

        public (DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateCorporation> dailyAggregateCorporation)? GetAggregateCorporation(DateTime dateTime)
        {
            (DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateCorporation> dailyAggregateCorporation)? aggregate = findAggregate(dateTime);

            return aggregate;
        }

        public (DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateAlliance> dailyAggregateAlliances)? GetAggregateAlliance(DateTime dateTime)
        {
            (DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateAlliance> dailyAggregateAlliances)? aggregate = findAggregateAlliance(dateTime);

            return aggregate;
        }

        private (DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateAlliance> dailyAggregateAlliances)? findAggregateAlliance(DateTime dateTime)
        {
            return dailyAggregateAlliances.SingleOrDefault(c => c.day.Date == dateTime.Date);
        }

        private (DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateCorporation> dailyAggregateCorporation)? findAggregate(DateTime dateTime)
        {
            return dailyAggregateCorporations.SingleOrDefault(c => c.day.Date == dateTime.Date);
        }

        internal void Add((DateTime Date, DateTime UtcNow, List<DailyAggregateCorporation> lists) newAggregate)
        {
            dailyAggregateCorporations.Add(newAggregate);
        }

        internal void Update((DateTime Date, DateTime UtcNow, List<DailyAggregateCorporation> lists) newAggregate)
        {
            (DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateCorporation> dailyAggregateCorporation) v = findAggregate(newAggregate.Date.Date).GetValueOrDefault();
            v.lastPulled = DateTime.UtcNow;
            v.dailyAggregateCorporation = newAggregate.lists;
        }

        internal void Add((DateTime Date, DateTime UtcNow, List<DailyAggregateAlliance> lists) newAggregate)
        {
            dailyAggregateAlliances.Add(newAggregate);
        }

        internal void Update((DateTime Date, DateTime UtcNow, List<DailyAggregateAlliance> lists) newAggregate)
        {
            (DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateAlliance> dailyAggregateAlliances) v = findAggregateAlliance(newAggregate.Date.Date).GetValueOrDefault();
            v.lastPulled = DateTime.UtcNow;
            v.dailyAggregateAlliances = newAggregate.lists;
        }

        /*public async Task<DailyAggregateAlliance> GetDailyAggregateAllianceAsync(DateTime dateTime)
        {
        
        }*/
    }
}
