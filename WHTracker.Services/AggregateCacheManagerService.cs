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
        public async Task<(DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateAlliance> dailyAggregateAlliances)> GetAggregateAlliance(DateTime dateTime)
        {
            (DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateAlliance> dailyAggregateAlliances)? aggregate = aggregateCache.GetAggregateAlliance(dateTime);

            if (aggregate.Value.dailyAggregateAlliances is not null)
            {
                if (aggregate.Value.lastPulled < DateTime.UtcNow.AddMinutes(-5))
                {
                    (DateTime Date, DateTime UtcNow, List<DailyAggregateAlliance> lists) newAggregate = await GetDAAFromDatabase(dateTime);
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
                (DateTime Date, DateTime UtcNow, List<DailyAggregateAlliance> lists) newAggregate = await GetDAAFromDatabase(dateTime);
                aggregateCache.Add(newAggregate);
                return newAggregate;
            }
        }

        private async Task<(DateTime Date, DateTime UtcNow, List<DailyAggregateCorporation> lists)> GetDACFromDatabase(DateTime dateTime)
        {
            List<DailyAggregateCorporation> lists = await applicationContext.DailyAggregateCorporations.Where(c => c.TimeStamp.Date == dateTime.Date).Include(c => c.corporation).ToListAsync();
            var newAggregate = (dateTime.Date, DateTime.UtcNow, lists);
            return newAggregate;
        }
        private async Task<(DateTime Date, DateTime UtcNow, List<DailyAggregateAlliance> lists)> GetDAAFromDatabase(DateTime dateTime)
        {
            List<DailyAggregateAlliance> lists = await applicationContext.DailyAggregateAlliances.Where(c => c.TimeStamp.Date == dateTime.Date).Include(c => c.Alliance).ToListAsync();
            var newAggregate = (dateTime.Date, DateTime.UtcNow, lists);
           // await GetMACFromDatabase(dateTime);
            return newAggregate;
        }


        private async Task GetMACFromDatabase(DateTime dateTime)
        {
            IQueryable<IGrouping<int, DailyAggregateCorporation>> queryables = applicationContext.DailyAggregateCorporations.GroupBy(c => c.TimeStamp.Month);
            var lists = await queryables.ToListAsync();
            //var lists = await applicationContext.DailyAggregateCorporations.Where(c => c.TimeStamp.Month == dateTime.Month).GroupBy(c => o).ToListAsync();
            var newAggregate = (dateTime.Date, DateTime.UtcNow, lists);
            //return newAggregate;.Include(c => c.corporation)
        }
    }
}
