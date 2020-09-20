using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int KillsDic { get; set; }
        public int LossesDic { get; set; }
        public int KillsPod { get; set; }
        public int LossesPod { get; set; }
        public int KillsCapital { get; set; }
        public int LossesCapital { get; set; }
        public int KillsStructure { get; set; }
        public int LossesStructure { get; set; }


        public float ISKKilledTotal { get; set; }
        public float ISKLostTotal { get; set; }
        public float ISKKilledPod { get; set; }
        public float ISKLostPod { get; set; }
        public float ISKKilledSubCap { get; set; }
        public float ISKLostSubCap { get; set; }
        public float ISKkilledDic { get; set; }
        public float ISKLostDic { get; set; }
        public float ISKKilledCapital { get; set; }
        public float ISKLostCapital { get; set; }
        public float ISKKilledStructure { get; set; }
        public float ISKLostStructure { get; set; }

        public int DamageDealtTotal { get; set; }
        public int DamageTakenTotal { get; set; }
        public int DamageDealtPod { get; set; }
        public int DamageTakenPod { get; set; }
        public int DamageDealtSubCap { get; set; }
        public int DamageTakenSubCap { get; set; }
        public int DamageDealtDic { get; set; }
        public int DamageTakenDic { get; set; }
        public int DamageDealtCapital { get; set; }
        public int DamageTakenCapital { get; set; }
        public int DamageDealtStructure { get; set; }
        public int DamageTakenStructure { get; set; }


        public int RorqualKills { get; set; }
        public int RorqualLosses { get; set; }
        public int DreadKills { get; set; }
        public int DreadLosses { get; set; }
        public int CarrierKills { get; set; }
        public int CarrierLosses { get; set; }
        public int FaxesKills { get; set; }
        public int FaxesLosses { get; set; }
        [DisplayName("AK")]
        [Title("Medium Structure kills")]
        public int MediumStructureKills { get; set; }
        [DisplayName("AL")]
        public int MediumStructureLosses { get; set; }
        [DisplayName("FK")]
        public int LargeStructureKills { get; set; }
        [DisplayName("FL")]
        public int LargeStructureLosses { get; set; }
        [DisplayName("KK")]
        public int XLStructureKills { get; set; }
        [DisplayName("LK")]
        public int XLStructureLosses { get; set; }
    }
}
