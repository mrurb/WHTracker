using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WHTracker.Services.Models
{
    //RedisQZkill
    [DataContract]
    public class RedisQZkill
    {
        [DataMember(Name = "package")]
        public Package? Package { get; set; }
    }

    [DataContract]
    public class Package
    {
        [DataMember(Name = "killID")]
        public int KillId { get; set; }

        [DataMember(Name = "killmail")]
        public Killmail Killmail { get; set; }

        [DataMember(Name = "zkb")]
        public Zkb Zkb { get; set; }
    }

    [DataContract]
    public class Killmail
    {
        [DataMember(Name = "attackers")]
        public IEnumerable<Attacker> Attackers { get; set; }

        [DataMember(Name = "killmail_id")]
        public int KillmailId { get; set; }

        [DataMember(Name = "killmail_time")]
        public DateTime KillmailTime { get; set; }

        [DataMember(Name = "moon_id")]
        public int? MoonId { get; set; }

        [DataMember(Name = "solar_system_id")]
        public int SolarSystemId { get; set; }

        [DataMember(Name = "victim")]
        public Victim victim { get; set; }

        [DataMember(Name = "war_id")]
        public int? WarId { get; set; }
    }

    [DataContract]
    public class Victim
    {
        [DataMember(Name = "alliance_id")]
        public int? AllianceId { get; set; }

        [DataMember(Name = "character_id")]
        public int? CharacterId { get; set; }

        [DataMember(Name = "corporation_id")]
        public int? CorporationId { get; set; }

        [DataMember(Name = "damage_taken")]
        public int DamageTaken { get; set; }

        [DataMember(Name = "faction_id")]
        public int? FactionId { get; set; }

        [DataMember(Name = "items")]
        public IEnumerable<Item>? Items { get; set; }

        [DataMember(Name = "position")]
        public Position? Position { get; set; }

        [DataMember(Name = "ship_type_id")]
        public int ShipTypeId { get; set; }
    }

    [DataContract]
    public class Position
    {

        [DataMember(Name = "x")]
        public float X { get; set; }

        [DataMember(Name = "y")]
        public float Y { get; set; }

        [DataMember(Name = "z")]
        public float Z { get; set; }
    }

    [DataContract]
    public class Item
    {

        [DataMember(Name = "flag")]
        public int Flag { get; set; }

        [DataMember(Name = "item_type_id")]
        public int ItemTypeId { get; set; }

        [DataMember(Name = "items")]
        public IEnumerable<Item>? Items { get; set; }

        [DataMember(Name = "quantity_destroyed")]
        public int? QuantityDestroyed { get; set; }

        [DataMember(Name = "singleton")]
        public int Singleton { get; set; }

        [DataMember(Name = "quantity_dropped")]
        public int? QuantityDropped { get; set; }
    }

    [DataContract]
    public class Attacker
    {

        [DataMember(Name = "alliance_id")]
        public int? AllianceId { get; set; }

        [DataMember(Name = "character_id")]
        public int? CharacterId { get; set; }

        [DataMember(Name = "corporation_id")]
        public int? CorporationId { get; set; }

        [DataMember(Name = "damage_done")]
        public int DamageDone { get; set; }

        [DataMember(Name = "faction_id")]
        public int? FactionId { get; set; }

        [DataMember(Name = "final_blow")]
        public bool FinalBlow { get; set; }

        [DataMember(Name = "security_status")]
        public float SecurityStatus { get; set; }

        [DataMember(Name = "ship_type_id")]
        public int? ShipTypeId { get; set; }

        [DataMember(Name = "weapon_type_id")]
        public int? WeaponTypeId { get; set; }
    }

    [DataContract]
    public class Zkb
    {

        [DataMember(Name = "locationID")]
        public int LocationId { get; set; }

        [DataMember(Name = "hash")]
        public string Gash { get; set; }

        [DataMember(Name = "fittedValue")]
        public float FittedValue { get; set; }

        [DataMember(Name = "totalValue")]
        public float TotalValue { get; set; }

        [DataMember(Name = "points")]
        public int Points { get; set; }

        [DataMember(Name = "npc")]
        public bool Npc { get; set; }

        [DataMember(Name = "solo")]
        public bool Solo { get; set; }

        [DataMember(Name = "awox")]
        public bool Awox { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }
    }



}
