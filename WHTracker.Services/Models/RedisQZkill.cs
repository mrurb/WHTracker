using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WHTracker.Services.Models
{
    //RedisQZkill
    public class RedisQZkill
    {
        [JsonPropertyName("package")]
        public Package? Package { get; set; }
    }

    public class Package
    {
        [JsonPropertyName("killID")]
        public int KillId { get; set; }

        [JsonPropertyName("killmail")]
        public Killmail Killmail { get; set; }

        [JsonPropertyName("zkb")]
        public Zkb Zkb { get; set; }
    }

    public class Killmail
    {
        [JsonPropertyName("attackers")]
        public IEnumerable<Attacker> Attackers { get; set; }

        [JsonPropertyName("killmail_id")]
        public int KillmailId { get; set; }

        [JsonPropertyName("killmail_time")]
        public DateTime KillmailTime { get; set; }

        [JsonPropertyName("moon_id")]
        public int? MoonId { get; set; }

        [JsonPropertyName("solar_system_id")]
        public int SolarSystemId { get; set; }

        [JsonPropertyName("victim")]
        public Victim victim { get; set; }

        [JsonPropertyName("war_id")]
        public int? WarId { get; set; }
    }

    public class Victim
    {
        [JsonPropertyName("alliance_id")]
        public int? AllianceId { get; set; }

        [JsonPropertyName("character_id")]
        public int? CharacterId { get; set; }

        [JsonPropertyName("corporation_id")]
        public int? CorporationId { get; set; }

        [JsonPropertyName("damage_taken")]
        public int DamageTaken { get; set; }

        [JsonPropertyName("faction_id")]
        public int? FactionId { get; set; }

        [JsonPropertyName("items")]
        public IEnumerable<Item>? Items { get; set; }

        [JsonPropertyName("position")]
        public Position? Position { get; set; }

        [JsonPropertyName("ship_type_id")]
        public int ShipTypeId { get; set; }
    }

    public class Position
    {

        [JsonPropertyName("x")]
        public float X { get; set; }

        [JsonPropertyName("y")]
        public float Y { get; set; }

        [JsonPropertyName("z")]
        public float Z { get; set; }
    }

    public class Item
    {

        [JsonPropertyName("flag")]
        public int Flag { get; set; }

        [JsonPropertyName("item_type_id")]
        public int ItemTypeId { get; set; }

        [JsonPropertyName("items")]
        public IEnumerable<Item>? Items { get; set; }

        [JsonPropertyName("quantity_destroyed")]
        public int? QuantityDestroyed { get; set; }

        [JsonPropertyName("singleton")]
        public int Singleton { get; set; }

        [JsonPropertyName("quantity_dropped")]
        public int? QuantityDropped { get; set; }
    }

    public class Attacker
    {

        [JsonPropertyName("alliance_id")]
        public int? AllianceId { get; set; }

        [JsonPropertyName("character_id")]
        public int? CharacterId { get; set; }

        [JsonPropertyName("corporation_id")]
        public int? CorporationId { get; set; }

        [JsonPropertyName("damage_done")]
        public int DamageDone { get; set; }

        [JsonPropertyName("faction_id")]
        public int? FactionId { get; set; }

        [JsonPropertyName("final_blow")]
        public bool FinalBlow { get; set; }

        [JsonPropertyName("security_status")]
        public float SecurityStatus { get; set; }

        [JsonPropertyName("ship_type_id")]
        public int? ShipTypeId { get; set; }

        [JsonPropertyName("weapon_type_id")]
        public int? WeaponTypeId { get; set; }
    }

    public class Zkb
    {

        [JsonPropertyName("locationID")]
        public int LocationId { get; set; }

        [JsonPropertyName("hash")]
        public string Gash { get; set; }

        [JsonPropertyName("fittedValue")]
        public float FittedValue { get; set; }

        [JsonPropertyName("totalValue")]
        public float TotalValue { get; set; }

        [JsonPropertyName("points")]
        public int Points { get; set; }

        [JsonPropertyName("npc")]
        public bool Npc { get; set; }

        [JsonPropertyName("solo")]
        public bool Solo { get; set; }

        [JsonPropertyName("awox")]
        public bool Awox { get; set; }

        [JsonPropertyName("href")]
        public string Href { get; set; }
    }



}
