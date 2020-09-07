using System;
using System.Collections.Generic;
using System.Text;

namespace WHTracker.Data.Models
{
    public class DailyAggregateCorporation
    {
        public int DailyAggregateCorporationID { get; set; }
        public int CorporationID { get; set; }
        public int CorporationMembersCount { get; set; }
        public int Kills { get; set; }
        public int Losses { get; set; }
        public int ISKKilledTotal { get; set; }
        public int ISKLostTotal { get; set; }
        public int ISKKilledSubCap { get; set; }
        public int ISKLostSubCap { get; set; }
        public int ISKKilledCapital { get; set; }
        public int ISKLostCapital { get; set; }
        public int ISKKilledStructure { get; set; }
        public int ISKLostStructure { get; set; }

        public int DamageDealtTotal { get; set; }
        public int DamageTakenTotal { get; set; }
        public int DamageDealtSubCap { get; set; }
        public int DamageTakenSubCAp { get; set; }
        public int DamageDealtCapital { get; set; }
        public int DamageTakenCapital { get; set; }
        public int DamageDealtStructure { get; set; }
        public int DamageTakenStructure { get; set; }


        public int PointsKilledTotal { get; set; }
        public int PointsLostTotal { get; set; }
        public int PointsKilledSubCap { get; set; }
        public int PointsLostSubCap { get; set; }
        public int PointsKilledCapital { get; set; }
        public int PointsLostCapital { get; set; }
        public int PointsKilledStructure { get; set; }
        public int PointsLostStructure { get; set; }


        public int RorqualKills { get; set; }
        public int DreadKills { get; set; }
        public int CarrierKills { get; set; }
        public int FaxesKills { get; set; }
        public int MediumStrctureKills { get; set; }
        public int LargetrctureKills { get; set; }
        public int XLStrctureKills { get; set; }
    }
}
