
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WHTracker.Data;
using WHTracker.Data.Models;

namespace WHTracker.Services.Cache
{
    public class AggregateCache <T> where T : AggregateData
    {
        private readonly ApplicationContext applicationContext;
        internal DbSet<T> dbset;

        public List<(DateTime day, DateTime lastPulled, IEnumerable<T> dailyAggregateCorporation)> dailyAggregateCorporations { get; set; }

        public AggregateCache(ApplicationContext applicationContext)
        {
            dailyAggregateCorporations = new List<(DateTime day, DateTime lastPulled, IEnumerable<T> dailyAggregateCorporation)>();
            this.applicationContext = applicationContext;
            dbset = applicationContext.Set<T>();
        }

        public async Task<(DateTime day, DateTime lastPulled, IEnumerable<T> dailyAggregateCorporation)> GetAggregateCorporationout(DateTime dateTime)
        {
            (DateTime day, DateTime lastPulled, IEnumerable<T> dailyAggregateCorporation)? aggregate = GetAggregateCorporation(dateTime);

            if (aggregate.Value.dailyAggregateCorporation is not null)
            {
                if (aggregate.Value.lastPulled < DateTime.UtcNow.AddMinutes(-5))
                {
                    (DateTime Date, DateTime UtcNow, List<T> lists) newAggregate = await GetDACFromDatabase(dateTime);
                    Update(newAggregate);
                    return newAggregate;
                }
                else
                {
                    return aggregate.Value;
                }
            }
            else
            {
                (DateTime Date, DateTime UtcNow, List<T> lists) newAggregate = await GetDACFromDatabase(dateTime);
                Add(newAggregate);
                return newAggregate;
            }
        }

        private async Task<(DateTime Date, DateTime UtcNow, List<T> lists)> GetDACFromDatabase(DateTime dateTime)
        {
            List<T> lists = await dbset.Where(c => c.TimeStamp.Date == dateTime.Date).ToListAsync();
            var newAggregate = (dateTime.Date, DateTime.UtcNow, lists);
            return newAggregate;
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
