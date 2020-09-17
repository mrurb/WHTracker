
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WHTracker.Data;
using WHTracker.Data.Models;

namespace WHTracker.Services.Cache
{
    public class AggregateCache <T>
    {

        public List<(DateTime day, DateTime lastPulled, IEnumerable<T> dailyAggregateCorporation)> dailyAggregateCorporations { get; set; }

        public AggregateCache()
        {
            dailyAggregateCorporations = new List<(DateTime day, DateTime lastPulled, IEnumerable<T> dailyAggregateCorporation)>();
        }

        public (DateTime day, DateTime lastPulled, IEnumerable<T> dailyAggregateCorporation)? GetAggregateCorporation(DateTime dateTime)
        {
            (DateTime day, DateTime lastPulled, IEnumerable<T> dailyAggregateCorporation)? aggregate = findAggregate(dateTime);

            return aggregate;
        }

        private (DateTime day, DateTime lastPulled, IEnumerable<T> dailyAggregateAlliances)? findAggregate(DateTime dateTime)
        {
            return dailyAggregateCorporations.SingleOrDefault(c => c.day.Date == dateTime.Date);
        }

        internal void Add((DateTime Date, DateTime UtcNow, List<T> lists) newAggregate)
        {
            dailyAggregateCorporations.Add(newAggregate);
        }

        internal void Update((DateTime Date, DateTime UtcNow, List<T> lists) newAggregate)
        {
            (DateTime day, DateTime lastPulled, IEnumerable<T> dailyAggregateCorporation) v = findAggregate(newAggregate.Date.Date).GetValueOrDefault();
            v.lastPulled = DateTime.UtcNow;
            v.dailyAggregateCorporation = newAggregate.lists;
        }
    }
}
