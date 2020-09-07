using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHTracker.Data;
using WHTracker.Data.Models;
using WHTracker.Services.Models;

namespace WHTracker.Services
{
    public class AggregateService
    {
        private readonly ApplicationContext context;
        private readonly ESIService eSIService;


        public AggregateService(ApplicationContext context, ESIService eSIService)
        {
            this.context = context;
            this.eSIService = eSIService;
        }

        public async Task<DailyAggregateCorporation> GetDailyAggregateCorporation(int corporationId, DateTime date)
        {
            return await context.DailyAggregateCorporations.FirstOrDefaultAsync(x => x.CorporationID == corporationId && x.TimeStamp == date);
        }

        public async Task<DailyAggregateCorporation> GetOrCreateDailyAggregateCorporation(int corporationId, DateTime date)
        {
            DailyAggregateCorporation aggregate = await GetDailyAggregateCorporation(corporationId, date);
            if(aggregate == null)
            {
                aggregate = new DailyAggregateCorporation();

                aggregate.CorporationID = corporationId;
                aggregate.TimeStamp = date;

                context.Attach(aggregate);
            }
            return aggregate;
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
                EveType victimType = await eSIService.GetEveType(killmail.victim.ShipTypeId);

                // Process Victim
                if(killmail.victim.CorporationId != null)
                {

                }


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

        public async Task<float> CalculateKillmailValue(Killmail killmail)
        {
            throw new NotImplementedException();
        }

        public bool IsWormholeKill(Killmail killmail)
        {
            return killmail.SolarSystemId > 3100000 && killmail.SolarSystemId < 32000000;
        }
        #endregion
    }
}
