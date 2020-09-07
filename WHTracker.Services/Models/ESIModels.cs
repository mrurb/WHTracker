using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WHTracker.Services.Models
{
    [DataContract]
    public class SolarSystem
    {
        [DataMember(Name = "constellation_id")]
        public int ConstellationId { get; set; }

        public string Name { get; set; }

        public IEnumerable<Planet> Planets { get; set; }

        public Position Position { get; set; }

        [DataMember(Name = "security_class")]
        public string SecurityClass { get; set; }

        [DataMember(Name = "security_status")]
        public float SecurityStatus { get; set; }

        [DataMember(Name = "star_id")]
        public int StarId { get; set; }

        public IEnumerable<int> Stargates { get; set; }

        public IEnumerable<int> Stations { get; set; }

        [DataMember(Name = "system_status")]
        public int SystemId { get; set; }
    }

    [DataContract]
    public class Planet
    {
        [DataMember(Name = "asteroid_belts")]
        public IEnumerable<int> AsteroidBelts { get; set; }

        public IEnumerable<int> Moons { get; set; }

        [DataMember(Name = "planet_id")]
        public int PlanteId { get; set; }

    }
}
