using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using System;
using System.Collections.Generic;
using System.Linq;

using WHTracker.Data;
using WHTracker.Data.Models;

using Z.EntityFramework.Plus;

namespace WHTracker.Services
{
    public class AggregateReposetory
    {
        private readonly ApplicationContext applicationContext;

        private static readonly MemoryCacheEntryOptions MemoryCacheEntryOptions = new MemoryCacheEntryOptions() { SlidingExpiration = TimeSpan.FromMinutes(5) };

        public AggregateReposetory(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
            QueryCacheManager.DefaultMemoryCacheEntryOptions = MemoryCacheEntryOptions;
        }

        public List<DailyAggregateCorporation> GetDACFromDatabaseAsync(DateTime dateTime)
        {
            List<DailyAggregateCorporation> lists = applicationContext.DailyAggregateCorporations.Where(c => c.TimeStamp.Date == dateTime.Date).Include(c => c.Corporation).FromCache(MemoryCacheEntryOptions, Tag.Daily.ToString()).ToList();
            return lists;
        }
        public List<DailyAggregateAlliance> GetDAAFromDatabaseAsync(DateTime dateTime)
        {
            List<DailyAggregateAlliance> lists = applicationContext.DailyAggregateAlliances.Where(c => c.TimeStamp.Date == dateTime.Date).Include(c => c.Alliance).FromCache(Tag.Daily.ToString()).ToList();
            return lists;
        }

        public List<MonthlyAggregateCorporation> GetMACFromDatabaseAsync(DateTime dateTime)
        {
            List<MonthlyAggregateCorporation> lists = applicationContext.MonthlyAggregateCorporations.Where(c => c.TimeStamp.Date == dateTime.Date).Include(c => c.Corporation).FromCache(Tag.Monthly.ToString()).ToList();
            return lists;
        }
        public List<MonthlyAggregateAlliance> GetMAAFromDatabaseAsync(DateTime dateTime)
        {
            List<MonthlyAggregateAlliance> lists = applicationContext.MonthlyAggregateAlliances.Where(c => c.TimeStamp.Date == dateTime.Date).Include(c => c.Alliance).FromCache(Tag.Monthly.ToString()).ToList();
            return lists;
        }

        enum Tag
        {
            Daily,
            Monthly
        }
        
    }
}
