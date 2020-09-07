using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WHTracker.Data;
using WHTracker.Data.Models;
using WHTracker.Services.Cache;

namespace WHTracker.Services
{
    public class AggregateCacheManagerService
    {
        private readonly AggregateCache aggregateCache;
        private readonly ApplicationContext applicationContext;

        public AggregateCacheManagerService(AggregateCache aggregateCache, ApplicationContext applicationContext)
        {
            this.aggregateCache = aggregateCache;
            this.applicationContext = applicationContext;
        }
        public async Task<(DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateCorporation> dailyAggregateCorporation)> GetAggregateCorporation(DateTime dateTime)
        {
            (DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateCorporation> dailyAggregateCorporation)? aggregate = aggregateCache.GetAggregateCorporation(dateTime);

            if (aggregate.Value.dailyAggregateCorporation is not null)
            {
                if (aggregate.Value.lastPulled < DateTime.UtcNow.AddMinutes(-5))
                {
                    (DateTime Date, DateTime UtcNow, List<DailyAggregateCorporation> lists) newAggregate = await GetDACFromDatabase(dateTime);
                    aggregateCache.Update(newAggregate);
                    return newAggregate;
                }
                else
                {
                    return aggregate.Value;
                }
            }
            else
            {
                (DateTime Date, DateTime UtcNow, List<DailyAggregateCorporation> lists) newAggregate = await GetDACFromDatabase(dateTime);
                aggregateCache.Add(newAggregate);
                return newAggregate;
            }
        }

        private async Task<(DateTime Date, DateTime UtcNow, List<DailyAggregateCorporation> lists)> GetDACFromDatabase(DateTime dateTime)
        {
            List<DailyAggregateCorporation> lists = await applicationContext.DailyAggregateCorporations.Where(c => c.TimeStamp.Date == dateTime.Date).Include(c => c.Corporation).ToListAsync();
            var newAggregate = (dateTime.Date, DateTime.UtcNow, lists);
            return newAggregate;
        }
    }
}
