using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

using WHTracker.Data;
using WHTracker.Data.Models;
using WHTracker.Services.Cache;

namespace WHTracker.Services
{
    public class AggregateCacheManagerService
    {
        private readonly AggregateCache<DailyAggregateAlliance> aggregateCacheAD;
        private readonly AggregateCache<DailyAggregateCorporation> aggregateCacheCD;
        private readonly AggregateCache<MonthlyAggregateAlliance> aggregateCacheAM;
        private readonly AggregateCache<MonthlyAggregateCorporation> aggregateCacheCM;
        private readonly ApplicationContext applicationContext;

        public AggregateCacheManagerService(AggregateCache<DailyAggregateAlliance> aggregateCache, AggregateCache<DailyAggregateCorporation> aggregateCacheCD, AggregateCache<MonthlyAggregateAlliance> aggregateCacheAM, AggregateCache<MonthlyAggregateCorporation> aggregateCacheCM, ApplicationContext applicationContext)
        {
            this.aggregateCacheAD = aggregateCache;
            this.aggregateCacheCD = aggregateCacheCD;
            this.aggregateCacheAM = aggregateCacheAM;
            this.aggregateCacheCM = aggregateCacheCM;
            this.applicationContext = applicationContext;
        }
        public async Task<(DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateCorporation> dailyAggregateCorporation)> GetAggregateCorporation(DateTime dateTime)
        {
            (DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateCorporation> dailyAggregateCorporation)? aggregate = aggregateCacheCD.GetAggregateCorporation(dateTime);

            if (aggregate.Value.dailyAggregateCorporation is not null)
            {
                if (aggregate.Value.lastPulled < DateTime.UtcNow.AddMinutes(-5))
                {
                    (DateTime Date, DateTime UtcNow, List<DailyAggregateCorporation> lists) newAggregate = await GetDACFromDatabase(dateTime);
                    aggregateCacheCD.Update(newAggregate);
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
                aggregateCacheCD.Add(newAggregate);
                return newAggregate;
            }
        }
        public async Task<(DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateAlliance> dailyAggregateAlliances)> GetAggregateAlliance(DateTime dateTime)
        {
            (DateTime day, DateTime lastPulled, IEnumerable<DailyAggregateAlliance> dailyAggregateAlliances)? aggregate = aggregateCacheAD.GetAggregateCorporation(dateTime);

            if (aggregate.Value.dailyAggregateAlliances is not null)
            {
                if (aggregate.Value.lastPulled < DateTime.UtcNow.AddMinutes(-5))
                {
                    (DateTime Date, DateTime UtcNow, List<DailyAggregateAlliance> lists) newAggregate = await GetDAAFromDatabase(dateTime);
                    aggregateCacheAD.Update(newAggregate);
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
                aggregateCacheAD.Add(newAggregate);
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
           //await GetMACFromDatabase(dateTime);
            return newAggregate;
        }


        private async Task GetMACFromDatabase(DateTime dateTime)
        {
                var queryables = await applicationContext.DailyAggregateCorporations
                    .Where(c => c.TimeStamp.Month == dateTime.Month)
                    .GroupBy (p => new {  p.corporation.CorporationName, p.corporation.CorporationId, p.corporation.CorporationTicker , p.TimeStamp.Year, p.TimeStamp.Month })
                        .Select(c => new DailyAggregateCorporation {

                        //CorporationID = c.Key.CorporationID,
                        corporation = new Corporation { CorporationId = c.Key.CorporationId, CorporationName = c.Key.CorporationName, CorporationTicker = c.Key.CorporationTicker},
                        TimeStamp = new DateTime(c.Key.Year, c.Key.Month, 1),
                        //corporation = c.FirstOrDefault().corporation,
                        KillsTotal = c.Sum(x => x.KillsTotal),
                        LossesTotal = c.Sum(x => x.LossesTotal),
                        KillsSubCap = c.Sum(x => x.KillsSubCap),
                        LossesSubCap = c.Sum(x => x.LossesSubCap),
                        KillsPod = c.Sum(x => x.KillsPod),
                        LossesPod = c.Sum(x => x.LossesPod),
                        KillsCapital = c.Sum(x => x.KillsCapital),
                        LossesCapital = c.Sum(x => x.LossesCapital),
                        KillsStructure = c.Sum(x => x.KillsStructure),
                        LossesStructure = c.Sum(x => x.LossesStructure),

                        ISKKilledTotal = c.Sum(x => x.ISKKilledTotal),
                        ISKLostTotal = c.Sum(x => x.ISKLostTotal),
                        ISKKilledPod = c.Sum(x => x.ISKKilledPod),
                        ISKLostPod = c.Sum(x => x.ISKLostPod),
                        ISKKilledSubCap = c.Sum(x => x.ISKKilledSubCap),
                        ISKLostSubCap = c.Sum(x => x.ISKLostSubCap),
                        ISKKilledCapital = c.Sum(x => x.ISKKilledCapital),
                        ISKKilledStructure = c.Sum(x => x.ISKKilledStructure),
                        ISKLostStructure = c.Sum(x => x.ISKLostStructure),

                        DamageDealtTotal = c.Sum(x => x.DamageDealtTotal),
                        DamageTakenTotal = c.Sum(x => x.DamageTakenTotal),
                        DamageDealtPod = c.Sum(x => x.DamageDealtPod),
                        DamageTakenPod = c.Sum(x => x.DamageTakenPod),
                        DamageDealtSubCap = c.Sum(x => x.DamageDealtSubCap),
                        DamageTakenSubCap = c.Sum(x => x.DamageTakenSubCap),
                        DamageDealtCapital = c.Sum(x => x.DamageDealtCapital),
                        DamageTakenCapital = c.Sum(x => x.DamageTakenCapital),
                        DamageDealtStructure = c.Sum(x => x.DamageDealtStructure),
                        DamageTakenStructure = c.Sum(x => x.DamageTakenStructure),

                        RorqualKills = c.Sum(x => x.RorqualKills),
                        RorqualLosses = c.Sum(x => x.RorqualLosses),
                        DreadKills = c.Sum(x => x.DreadKills),
                        DreadLosses = c.Sum(x => x.DreadLosses),
                        CarrierKills = c.Sum(x => x.CarrierKills),
                        CarrierLosses = c.Sum(x => x.CarrierLosses),
                        FaxesKills = c.Sum(x => x.FaxesKills),
                        FaxesLosses = c.Sum(x => x.FaxesLosses),
                        MediumStructureKills = c.Sum(x => x.MediumStructureKills),
                        MediumStructureLosses = c.Sum(x => x.MediumStructureLosses),
                        LargeStructureKills = c.Sum(x => x.LargeStructureKills),
                        LargeStructureLosses = c.Sum(x => x.LargeStructureLosses),
                        XLStructureKills = c.Sum(x => x.XLStructureKills),
                        XLStructureLosses = c.Sum(x => x.XLStructureLosses),
                        })
                        .ToListAsync();

                //var lists = await applicationContext.DailyAggregateCorporations.Where(c => c.TimeStamp.Month == dateTime.Month).GroupBy(c => o).ToListAsync();
                //var newAggregate = (dateTime.Date, DateTime.UtcNow, lists);
                //return newAggregate;.Include(c => c.corporation)
    
        }
    }
}
