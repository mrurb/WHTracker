using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WHTracker.Data;
using WHTracker.Data.Models;
using WHTracker.Services.Models;

using Z.EntityFramework.Plus;

using Corporation = WHTracker.Data.Models.Corporation;

namespace WHTracker.Services
{
    public class AggregateService
    {
        private readonly ILogger<AggregateService> _logger;
        private readonly ApplicationContext context;
        private readonly ESIService eSIService;
        private readonly ZKillHistoryAPIService zKillHistoryAPIService;

        public AggregateService(ILogger<AggregateService> _logger, ApplicationContext context, ESIService eSIService, ZKillHistoryAPIService zKillHistoryAPIService)
        {
            this._logger = _logger;
            this.context = context;
            this.eSIService = eSIService;
            this.zKillHistoryAPIService = zKillHistoryAPIService;
        }

        public async Task<T> GetAggregateCorporation<T>(int corporationId, DateTime date) where T : AggregateCorporation
        {
            DbSet<T> dbSet = context.Set<T>();
            return await dbSet.FirstOrDefaultAsync(x => x.CorporationID == corporationId && x.TimeStamp == date);
        }

        public async Task<T> GetOrCreateAggregateCorporation<T>(Corporation corporation, DateTime date) where T : AggregateCorporation, new()
        {
            T aggregate = await GetAggregateCorporation<T>(corporation.Id, date);
            if (aggregate == null)
            {
                aggregate = new T()
                {
                    CorporationID = corporation.Id,
                    TimeStamp = date
                };

                context.Attach(aggregate);
            }
            return aggregate;
        }

        private async Task<Corporation> GetOrCreateCorporation(int corporationId)
        {

            Corporation corp = await context.Corporations.FirstOrDefaultAsync(x => x.Id == corporationId);
            if (corp == null)
            {
                var corpdata = await eSIService.GetCorporation(corporationId);

                corp = new Corporation
                {
                    Id = corporationId,
                    Name = corpdata.Name,
                    Ticker = corpdata.Ticker,
                    MemberCount = corpdata.MemberCount,
                    LastUpdated = DateTime.UtcNow
                };

                await context.AddAsync(corp);
            }
            else if (corp.LastUpdated < DateTime.UtcNow.AddHours(-24))
            {
                var corpdata = await eSIService.GetCorporation(corporationId);
                corp.Name = corpdata.Name;
                corp.Ticker = corpdata.Ticker;
                corp.MemberCount = corpdata.MemberCount;
                corp.LastUpdated = DateTime.UtcNow;
            }

            return corp;
        }

        public async Task<T> GetAggregateAlliance<T>(int allianceId, DateTime date) where T : AggregateAlliance
        {
            DbSet<T> dbSet = context.Set<T>();
            return await dbSet.FirstOrDefaultAsync(x => x.AllianceId == allianceId && x.TimeStamp == date);
        }

        public async Task<T> GetOrCreateAggregateAlliance<T>(Data.Models.Alliance alliance, DateTime date) where T : AggregateAlliance, new()
        {

            T aggregate = await GetAggregateAlliance<T>(alliance.Id, date);
            if (aggregate == null)
            {
                aggregate = new T
                {
                    AllianceId = alliance.Id,
                    TimeStamp = date
                };

                context.Attach(aggregate);
            }
            return aggregate;
        }

        private async Task<Data.Models.Alliance> GetOrCreateAlliance(int allianceId)
        {
            Data.Models.Alliance alliance = await context.Alliances.FirstOrDefaultAsync(x => x.Id == allianceId);

            if (alliance == null)
            {
                var alliancedata = await eSIService.GetAlliance(allianceId);

                alliance = new Data.Models.Alliance
                {
                    Id = allianceId,
                    Name = alliancedata.Name,
                    Ticker = alliancedata.Ticker,
                    MemberCount = await eSIService.GetAllianceMemberCount(allianceId),
                    LastUpdated = DateTime.UtcNow
                };

                await context.AddAsync(alliance);
            }
            else if (alliance.LastUpdated < DateTime.UtcNow.AddHours(-24))
            {
                var alliancedata = await eSIService.GetAlliance(allianceId);
                alliance.Name = alliancedata.Name;
                alliance.Ticker = alliancedata.Ticker;
                alliance.MemberCount = await eSIService.GetAllianceMemberCount(allianceId);
                alliance.LastUpdated = DateTime.UtcNow;
            }

            return alliance;
        }

        public IEnumerable<KillmailValue> GetMissingKillmails(IEnumerable<KillmailValue> original)
        {
            return original.Where(x => !context.Killmails.Any(c => x.KillmailId == c.KiilmailId));
        }

        public async Task AddProcessedKillmails(IEnumerable<KillmailValue> list)
        {
            List<Killmails> KillMails = list.Select(c => new Killmails { KiilmailId = c.KillmailId, KillmailHash = c.KillmailHash, TimeStamp = c.Killmail.KillmailTime }).ToList();
            await context.AddRangeAsync(KillMails);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<KillmailHash>> GetKillmailHistoryDay(DateTime day)
        {
            var killmailsDetails = await zKillHistoryAPIService.GetHistoryData(day);
            return killmailsDetails.Select(kv => new KillmailHash(kv.Key, kv.Value)).ToList();
        }

        public async Task ProcessKillmailValue(KillmailValue killmailValue)
        {
            Killmail killmail = killmailValue.Killmail;
            float value = killmailValue.Value;
            // Check wormmhole kill
            if (IsWormholeKill(killmail))
            {
                EveType victimType = await eSIService.GetEveType(killmail.Victim.ShipTypeId);

                // Process Victim
                if (killmail.Victim.CorporationId != null)
                {
                    _logger.LogDebug("Loss for corp: {0}", killmail.Victim.CorporationId);

                    var corp = await GetOrCreateCorporation(killmail.Victim.CorporationId.Value);
                    DailyAggregateCorporation victimAggregate = await GetOrCreateAggregateCorporation<DailyAggregateCorporation>(corp, killmail.KillmailTime.Date);
                    MonthlyAggregateCorporation victimAggregateMonthly = await GetOrCreateAggregateCorporation<MonthlyAggregateCorporation>(corp, killmail.KillmailTime.Date);
                    IncrementAggregate(victimAggregate, victimType, value, killmail.Victim.DamageTaken, false);
                    IncrementAggregate(victimAggregateMonthly, victimType, value, killmail.Victim.DamageTaken, false);
                }

                if (killmail.Victim.AllianceId != null)
                {
                    var alliance = await GetOrCreateAlliance(killmail.Victim.AllianceId.Value);
                    DailyAggregateAlliance victimAggregate = await GetOrCreateAggregateAlliance<DailyAggregateAlliance>(alliance, killmail.KillmailTime.Date);
                    MonthlyAggregateAlliance victimAggregateMonthly = await GetOrCreateAggregateAlliance<MonthlyAggregateAlliance>(alliance, killmail.KillmailTime.Date);
                    IncrementAggregate(victimAggregate, victimType, value, killmail.Victim.DamageTaken, false);
                    IncrementAggregate(victimAggregateMonthly, victimType, value, killmail.Victim.DamageTaken, false);
                }


                // Process Attackers
                var attackerCorporations = killmail.Attackers.Where(a => a.CorporationId != null && a.CorporationId != killmail.Victim.CorporationId).Select(a => a.CorporationId.Value).Distinct();
                foreach (var corporationId in attackerCorporations)
                {
                    var corp = await GetOrCreateCorporation(corporationId);
                    _logger.LogDebug("Kill for corp: {0}", killmail.Victim.CorporationId);
                    DailyAggregateCorporation attackerAggregate = await GetOrCreateAggregateCorporation<DailyAggregateCorporation>(corp, killmail.KillmailTime.Date);
                    MonthlyAggregateCorporation monthlyAggregateCorporation = await GetOrCreateAggregateCorporation<MonthlyAggregateCorporation>(corp, killmail.KillmailTime.Date);
                    IncrementAggregate(attackerAggregate, victimType, value, killmail.Attackers.Where(a => a.CorporationId == corp.Id).Sum(a => a.DamageDone), true);
                    IncrementAggregate(monthlyAggregateCorporation, victimType, value, killmail.Attackers.Where(a => a.CorporationId == corp.Id).Sum(a => a.DamageDone), true);
                }

                var attackerAlliances = killmail.Attackers.Where(a => a.AllianceId != null && a.AllianceId != killmail.Victim.AllianceId).Select(a => a.AllianceId.Value).Distinct();
                foreach (var allianceId in attackerAlliances)
                {
                    var alliance = await GetOrCreateAlliance(allianceId);
                    DailyAggregateAlliance attackerAggregate = await GetOrCreateAggregateAlliance<DailyAggregateAlliance>(alliance, killmail.KillmailTime.Date);
                    MonthlyAggregateAlliance monthlyAggregateAlliance = await GetOrCreateAggregateAlliance<MonthlyAggregateAlliance>(alliance, killmail.KillmailTime.Date);
                    IncrementAggregate(attackerAggregate, victimType, value, killmail.Attackers.Where(a => a.AllianceId == alliance.Id).Sum(a => a.DamageDone), true);
                    IncrementAggregate(monthlyAggregateAlliance, victimType, value, killmail.Attackers.Where(a => a.AllianceId == alliance.Id).Sum(a => a.DamageDone), true);
                }
                await context.SaveChangesAsync();
            }
        }

        public AggregateData IncrementAggregate(AggregateData data, EveType type, float value, int damage, bool kills)
        {
            if (kills)
            {
                data.KillsTotal += 1;
                data.ISKKilledTotal += value;
                data.DamageDealtTotal += damage;

                if (IsStructure(type.TypeId))
                {
                    data.KillsStructure += 1;
                    data.ISKKilledStructure += value;
                    data.DamageDealtStructure += damage;

                    if (IsMediumStructure(type.TypeId))
                    {
                        data.MediumStructureKills += 1;
                    }
                    else if (IsLargeStructure(type.TypeId))
                    {
                        data.LargeStructureKills += 1;
                    }
                    else if (IsXLargeStructure(type.TypeId))
                    {
                        data.XLStructureKills += 1;
                    }
                }
                else if (IsCapital(type))
                {
                    data.KillsCapital += 1;
                    data.ISKKilledCapital += value;
                    data.DamageDealtCapital += damage;

                    if (IsDreadnought(type))
                    {
                        data.DreadKills += 1;
                    }
                    else if (IsCarrier(type))
                    {
                        data.CarrierKills += 1;
                    }
                    else if (IsForceAuxiliary(type))
                    {
                        data.FaxesKills += 1;
                    }
                    else if (IsRorqual(type))
                    {
                        data.RorqualKills += 1;
                    }
                }
                else if (IsPod(type.TypeId))
                {
                    data.KillsPod += 1;
                    data.ISKKilledPod += value;
                    data.DamageDealtPod += damage;
                }
                else if (IsDic(type.TypeId))
                {
                    data.KillsDic += 1;
                    data.ISKKilledDic += value;
                    data.DamageDealtDic += damage;
                }
                else
                {
                    data.KillsSubCap += 1;
                    data.ISKKilledSubCap += value;
                    data.DamageDealtSubCap += damage;
                }

            }
            else
            {
                data.LossesTotal += 1;
                data.ISKLostTotal += value;
                data.DamageTakenTotal += damage;

                if (IsStructure(type.TypeId))
                {
                    data.LossesStructure += 1;
                    data.ISKLostStructure += value;
                    data.DamageTakenStructure += damage;

                    if (IsMediumStructure(type.TypeId))
                    {
                        data.MediumStructureLosses += 1;
                    }
                    else if (IsLargeStructure(type.TypeId))
                    {
                        data.LargeStructureLosses += 1;
                    }
                    else if (IsXLargeStructure(type.TypeId))
                    {
                        data.XLStructureLosses += 1;
                    }
                }
                else if (IsCapital(type))
                {
                    data.LossesCapital += 1;
                    data.ISKLostCapital += value;
                    data.DamageTakenCapital += damage;

                    if (IsDreadnought(type))
                    {
                        data.DreadLosses += 1;
                    }
                    else if (IsCarrier(type))
                    {
                        data.CarrierLosses += 1;
                    }
                    else if (IsForceAuxiliary(type))
                    {
                        data.FaxesLosses += 1;
                    }
                    else if (IsRorqual(type))
                    {
                        data.RorqualLosses += 1;
                    }
                }
                else if (IsPod(type.TypeId))
                {
                    data.LossesPod += 1;
                    data.ISKLostPod += value;
                    data.DamageTakenPod += damage;
                }
                else if (IsDic(type.TypeId))
                {
                    data.LossesDic += 1;
                    data.ISKLostDic += value;
                    data.DamageTakenDic += damage;
                }
                else
                {
                    data.LossesSubCap += 1;
                    data.ISKLostSubCap += value;
                    data.DamageTakenSubCap += damage;
                }
            }

            return data;
        }

        private bool IsDic(int typeId)
        {
            return typeId == 22456 || typeId == 22452 || typeId == 22464 || typeId == 22460;
        }

        #region Checkers

        public bool IsCapital(EveType type)
        {

            return IsRorqual(type) || IsDreadnought(type) || IsForceAuxiliary(type) || IsCarrier(type);
        }

        public bool IsRorqual(EveType type)
        {

            return type.GroupId == 883;
        }

        public bool IsDreadnought(EveType type)
        {

            return type.GroupId == 485;
        }

        public bool IsForceAuxiliary(EveType type)
        {

            return type.GroupId == 1538;
        }

        public bool IsCarrier(EveType type)
        {

            return type.GroupId == 547;
        }

        public bool IsStructure(int typeId)
        {

            return IsMediumStructure(typeId) || IsLargeStructure(typeId) || IsXLargeStructure(typeId);

        }

        public bool IsMediumStructure(int typeId)
        {

            return IsAstrahus(typeId) || IsRaitaru(typeId) || IsAthanor(typeId);

        }

        public bool IsLargeStructure(int typeId)
        {

            return IsFortizar(typeId) || IsAzbel(typeId) || IsTatara(typeId);

        }

        public bool IsXLargeStructure(int typeId)
        {

            return IsKeepstar(typeId) || IsSotiyo(typeId);

        }

        public bool IsAstrahus(int typeId)
        {

            return typeId == 35832;
        }

        public bool IsFortizar(int typeId)
        {

            return typeId == 35833 || typeId == 47512 || typeId == 47513 || typeId == 47514 || typeId == 47515 || typeId == 47516;
        }

        public bool IsKeepstar(int typeId)
        {

            return typeId == 35834 || typeId == 40340;
        }

        public bool IsRaitaru(int typeId)
        {

            return typeId == 35825;
        }

        public bool IsAzbel(int typeId)
        {

            return typeId == 35826;
        }

        public bool IsSotiyo(int typeId)
        {

            return typeId == 35827;
        }

        public bool IsAthanor(int typeId)
        {

            return typeId == 35835;
        }

        public bool IsTatara(int typeId)
        {

            return typeId == 35836;
        }
        public bool IsPod(int typeId)
        {

            return typeId == 670 || typeId == 33328;
        }
        public bool IsSkin(EveType type)
        {

            return type.GroupId == 1950 || type.GroupId == 1951;
        }

        public bool IsTypeExcludedFromValue(EveType type)
        {
            if (IsPod(type.TypeId) || IsSkin(type))
            {
                return true;
            }
            return false;
        }

        public async Task<double> CalculateKillmailValue(Killmail killmail)
        {
            double value = 0;


            var shipTypeData = await eSIService.GetEveType(killmail.Victim.ShipTypeId);

            if (!IsTypeExcludedFromValue(shipTypeData))
            {
                double itemValue = await eSIService.GetMarketHistoryValue(killmail.Victim.ShipTypeId, killmail.KillmailTime);
                value += itemValue;
            }

            if (killmail.Victim.Items != null)
            {
                foreach (var item in killmail.Victim.Items)
                {
                    var typeData = await eSIService.GetEveType(item.ItemTypeId);
                    if (item.Singleton != 2 && typeData.MarketGroupId != null && !IsTypeExcludedFromValue(typeData))
                    {
                        double itemValue = await eSIService.GetMarketHistoryValue(item.ItemTypeId, killmail.KillmailTime);
                        value += itemValue * (item.QuantityDestroyed ?? 0 + item.QuantityDropped ?? 0);
                    }

                    if (item.Items != null && item.Items.Count() > 0)
                    {
                        foreach (var subItem in item.Items)
                        {
                            var subTypeData = await eSIService.GetEveType(subItem.ItemTypeId);
                            if (subItem.Singleton != 2 && typeData.MarketGroupId != null && !IsTypeExcludedFromValue(subTypeData))
                            {
                                double itemValue = await eSIService.GetMarketHistoryValue(subItem.ItemTypeId, killmail.KillmailTime);
                                value += itemValue * (subItem.QuantityDestroyed ?? 0 + subItem.QuantityDropped ?? 0);

                            }
                        }
                    }
                }
            }

            return value;
        }

        public bool IsWormholeKill(Killmail killmail)
        {
            return killmail.SolarSystemId > 31000000 && killmail.SolarSystemId < 32000000;
        }
        #endregion
    }
}
