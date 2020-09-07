using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WHTracker.Services.Models
{
    public class SolarSystem
    {
        [JsonPropertyName("constellation_id")]
        public int ConstellationId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("planets")]
        public IEnumerable<Planet>? Planets { get; set; }

        [JsonPropertyName("position")]
        public Position Position { get; set; }

        [JsonPropertyName("security_class")]
        public string? SecurityClass { get; set; }

        [JsonPropertyName("security_status")]
        public float SecurityStatus { get; set; }

        [JsonPropertyName("star_id")]
        public int? StarId { get; set; }

        [JsonPropertyName("stargates")]
        public IEnumerable<int>? Stargates { get; set; }

        [JsonPropertyName("stations")]
        public IEnumerable<int>? Stations { get; set; }

        [JsonPropertyName("system_status")]
        public int SystemId { get; set; }
    }

    public class Planet
    {
        [JsonPropertyName("asteroid_belts")]
        public IEnumerable<int>? AsteroidBelts { get; set; }

        [JsonPropertyName("moons")]
        public IEnumerable<int>? Moons { get; set; }

        [JsonPropertyName("planet_id")]
        public int PlanteId { get; set; }

    }

    public class Corporation
    {
        [JsonPropertyName("alliance_id")]
        public int? AllianceId { get; set; }

        [JsonPropertyName("ceo_id")]
        public int CeoId { get; set; }

        [JsonPropertyName("creator_id")]
        public int CreatorId { get; set; }

        [JsonPropertyName("date_founded")]
        public DateTime? DateFounded { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("faction_id")]
        public int? FactionId { get; set; }

        [JsonPropertyName("home_station_id")]
        public int? HomeStationId { get; set; }

        [JsonPropertyName("member_count")]
        public int MemberCount { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("shares")]
        public long? Shares { get; set; }

        [JsonPropertyName("tax_rate")]
        public float TaxRate { get; set; }

        [JsonPropertyName("ticker")]
        public string Ticker { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("war_eligible")]
        public bool? WarEligible { get; set; }
    }

    public class Alliance
    {
        [JsonPropertyName("creator_corporation_id")]
        public int CreatorCorporationId { get; set; }

        [JsonPropertyName("creator_id")]
        public int CreatorId { get; set; }

        [JsonPropertyName("date_founded")]
        public DateTime? DateFounded { get; set; }

        [JsonPropertyName("executor_corporation_id")]
        public int? ExecutorCorporationId { get; set; }

        [JsonPropertyName("faction_id")]
        public int? FactionId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("ticker")]
        public string Ticker { get; set; }
    }


    public class EveType
    {
        [JsonPropertyName("capacity")]
        public float? Capacity { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("dogma_attributes")]
        public IEnumerable<DogmaAttributes>? DogmaAttributes { get; set; }

        [JsonPropertyName("dogma_effects")]
        public IEnumerable<DogmaEffects>? DogmaEffects { get; set; }

        [JsonPropertyName("graphic_id")]
        public int? GraphicId { get; set; }

        [JsonPropertyName("group_id")]
        public int GroupId { get; set; }

        [JsonPropertyName("icon_id")]
        public int? IconId { get; set; }

        [JsonPropertyName("market_group_id")]
        public int? MarketGroupId { get; set; }

        [JsonPropertyName("mass")]
        public float? Mass { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("packaged_volume")]
        public float? PackagedVolume { get; set; }

        [JsonPropertyName("portion_size")]
        public int? PortionSize { get; set; }

        [JsonPropertyName("published")]
        public bool Published { get; set; }

        [JsonPropertyName("radius")]
        public float? Radius { get; set; }

        [JsonPropertyName("type_id")]
        public int TypeId { get; set; }

        [JsonPropertyName("volume")]
        public float? Volume { get; set; }
    }

    public class DogmaAttributes
    {
        [JsonPropertyName("attribute_id")]
        public int AttributeId { get; set; }

        [JsonPropertyName("value")]
        public float Value { get; set; }
    }

    public class DogmaEffects
    {
        [JsonPropertyName("effect_id")]
        public int EffectId { get; set; }

        [JsonPropertyName("is_default")]
        public bool IsDefault { get; set; }
    }

}
