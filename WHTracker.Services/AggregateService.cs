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


        public AggregateService(ILogger<AggregateService> _logger, ApplicationContext context, ESIService eSIService)
        {
            this._logger = _logger;
            this.context = context;
            this.eSIService = eSIService;
        }

        public async Task<DailyAggregateCorporation> GetDailyAggregateCorporation(int corporationId, DateTime date)
        {
            return await context.DailyAggregateCorporations.FirstOrDefaultAsync(x => x.CorporationID == corporationId && x.TimeStamp == date);
        }
        public async Task<MonthlyAggregateCorporation> GetMonthlyAggregateCorporation(int corporationId, DateTime date)
        {
            return await context.MonthlyAggregateCorporations.FirstOrDefaultAsync(x => x.CorporationID == corporationId && x.TimeStamp == date);
        }

        public async Task<DailyAggregateCorporation> GetOrCreateDailyAggregateCorporation(Corporation corporation, DateTime date)
        {


            DailyAggregateCorporation aggregate = await GetDailyAggregateCorporation(corporation.Id, date);
            if (aggregate == null)
            {
                aggregate = new DailyAggregateCorporation
                {
                    CorporationID = corporation.Id,
                    TimeStamp = date
                };

                context.Attach(aggregate);
            }
            return aggregate;
        }

        public async Task<MonthlyAggregateCorporation> GetOrCreateMonthlyAggregateCorporation(Corporation corporation, DateTime date)
        {
            var dateMonth = new DateTime(date.Year, date.Month, 1);

            MonthlyAggregateCorporation aggregate = await GetMonthlyAggregateCorporation(corporation.Id, dateMonth);
            if (aggregate == null)
            {
                aggregate = new MonthlyAggregateCorporation
                {
                    CorporationID = corporation.Id,
                    TimeStamp = dateMonth
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

        public async Task<DailyAggregateAlliance> GetDailyAggregateAlliance(int allianceId, DateTime date)
        {
            return await context.DailyAggregateAlliances.FirstOrDefaultAsync(x => x.AllianceId == allianceId && x.TimeStamp == date);
        }

        public async Task<MonthlyAggregateAlliance> GetMonthlyAggregateAlliance(int allianceId, DateTime date)
        {
            return await context.MonthlyAggregateAlliances.FirstOrDefaultAsync(x => x.AllianceId == allianceId && x.TimeStamp == date);
        }

        public async Task<DailyAggregateAlliance> GetOrCreateDailyAggregateAlliance(Data.Models.Alliance alliance, DateTime date)
        {

            DailyAggregateAlliance aggregate = await GetDailyAggregateAlliance(alliance.Id, date);
            if (aggregate == null)
            {
                aggregate = new DailyAggregateAlliance
                {
                    AllianceId = alliance.Id,
                    TimeStamp = date
                };

                context.Attach(aggregate);
            }
            return aggregate;
        }
        public async Task<MonthlyAggregateAlliance> GetOrCreateMonthlyAggregateAlliance(Data.Models.Alliance alliance, DateTime date)
        {
            var dateMonth = new DateTime(date.Year, date.Month, 1);

            MonthlyAggregateAlliance aggregate = await GetMonthlyAggregateAlliance(alliance.Id, dateMonth);
            if (aggregate == null)
            {
                aggregate = new MonthlyAggregateAlliance
                {
                    AllianceId = alliance.Id,
                    TimeStamp = dateMonth
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

        public async Task ProcessKillmail(Killmail killmail)
        {
            float value = await CalculateKillmailValue(killmail);
            await ProcessKillmailValue(killmail, value);
        }

        public async Task ProcessKillmailValue(Killmail killmail, float value)
        {
            // Check wormmhole kill
            if (IsWormholeKill(killmail))
            {
                EveType victimType = await eSIService.GetEveType(killmail.Victim.ShipTypeId);

                // Process Victim
                if (killmail.Victim.CorporationId != null)
                {
                    _logger.LogDebug("Loss for corp: {0}", killmail.Victim.CorporationId);

                    var corp = await GetOrCreateCorporation(killmail.Victim.CorporationId.Value);
                    DailyAggregateCorporation victimAggregate = await GetOrCreateDailyAggregateCorporation(corp, killmail.KillmailTime.Date);
                    MonthlyAggregateCorporation victimAggregateMonthly = await GetOrCreateMonthlyAggregateCorporation(corp, killmail.KillmailTime.Date);
                    IncrementAggregate(victimAggregate, victimType, value, killmail.Victim.DamageTaken, false);
                    IncrementAggregate(victimAggregateMonthly, victimType, value, killmail.Victim.DamageTaken, false);
                }

                if (killmail.Victim.AllianceId != null)
                {
                    var alliance = await GetOrCreateAlliance(killmail.Victim.AllianceId.Value);
                    DailyAggregateAlliance victimAggregate = await GetOrCreateDailyAggregateAlliance(alliance, killmail.KillmailTime.Date);
                    MonthlyAggregateAlliance victimAggregateMonthly = await GetOrCreateMonthlyAggregateAlliance(alliance, killmail.KillmailTime.Date);
                    IncrementAggregate(victimAggregate, victimType, value, killmail.Victim.DamageTaken, false);
                    IncrementAggregate(victimAggregateMonthly, victimType, value, killmail.Victim.DamageTaken, false);
                }


                // Process Attackers
                var attackerCorporations = killmail.Attackers.Where(a => a.CorporationId != null && a.CorporationId != killmail.Victim.CorporationId).Select(a => a.CorporationId.Value).Distinct();
                foreach (var corporationId in attackerCorporations)
                {
                    var corp = await GetOrCreateCorporation(corporationId);
                    _logger.LogDebug("Kill for corp: {0}", killmail.Victim.CorporationId);
                    DailyAggregateCorporation attackerAggregate = await GetOrCreateDailyAggregateCorporation(corp, killmail.KillmailTime.Date);
                    MonthlyAggregateCorporation monthlyAggregateCorporation = await GetOrCreateMonthlyAggregateCorporation(corp, killmail.KillmailTime.Date);
                    IncrementAggregate(attackerAggregate, victimType, value, killmail.Attackers.Where(a => a.CorporationId == corp.Id).Sum(a => a.DamageDone), true);
                    IncrementAggregate(monthlyAggregateCorporation, victimType, value, killmail.Attackers.Where(a => a.CorporationId == corp.Id).Sum(a => a.DamageDone), true);
                }


                var attackerAlliances = killmail.Attackers.Where(a => a.AllianceId != null && a.AllianceId != killmail.Victim.AllianceId).Select(a => a.AllianceId.Value).Distinct();
                foreach (var allianceId in attackerAlliances)
                {
                    var alliance = await GetOrCreateAlliance(allianceId);
                    DailyAggregateAlliance attackerAggregate = await GetOrCreateDailyAggregateAlliance(alliance, killmail.KillmailTime.Date);
                    MonthlyAggregateAlliance monthlyAggregateAlliance = await GetOrCreateMonthlyAggregateAlliance(alliance, killmail.KillmailTime.Date);
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
                else
                {
                    data.LossesSubCap += 1;
                    data.ISKLostSubCap += value;
                    data.DamageTakenSubCap += damage;
                }
            }

            return data;
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

        public async Task<float> CalculateKillmailValue(Killmail killmail)
        {
            throw new NotImplementedException();
        }

        public bool IsWormholeKill(Killmail killmail)
        {
            return killmail.SolarSystemId > 31000000 && killmail.SolarSystemId < 32000000;
        }
        #endregion
    }
}
