using System;
using System.Collections.Generic;
using System.Text;

namespace WHTracker.Data.Models
{
    public class AggregateData
    {
        public DateTime TimeStamp { get; set; }

        public int MembersCount { get; set; }
        public int KillsTotal { get; set; }
        public int LossesTotal { get; set; }
        public int KillsSubCap { get; set; }
        public int LossesSubCap { get; set; }
        public int KillsCapital { get; set; }
        public int LossesCapital { get; set; }
        public int KillsStrcture { get; set; }
        public int LossesStrcture { get; set; }


        public float ISKKilledTotal { get; set; }
        public float ISKLostTotal { get; set; }
        public float ISKKilledSubCap { get; set; }
        public float ISKLostSubCap { get; set; }
        public float ISKKilledCapital { get; set; }
        public float ISKLostCapital { get; set; }
        public float ISKKilledStructure { get; set; }
        public float ISKLostStructure { get; set; }

        public int DamageDealtTotal { get; set; }
        public int DamageTakenTotal { get; set; }
        public int DamageDealtSubCap { get; set; }
        public int DamageTakenSubCap { get; set; }
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
