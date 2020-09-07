using System;

namespace WHTracker.Services.Models
{
    public class RedisQZkill
    {
        public Package package { get; set; }
    }
    public class Package
    {
        public int killID { get; set; }
        public Killmail killmail { get; set; }
        public Zkb zkb { get; set; }
    }

    public class Killmail
    {
        public Attacker[] attackers { get; set; }
        public int killmail_id { get; set; }
        public DateTime killmail_time { get; set; }
        public int solar_system_id { get; set; }
        public Victim victim { get; set; }
    }

    public class Victim
    {
        public int character_id { get; set; }
        public int corporation_id { get; set; }
        public int damage_taken { get; set; }
        public object[] items { get; set; }
        public Position position { get; set; }
        public int ship_type_id { get; set; }
    }

    public class Position
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Attacker
    {
        public int alliance_id { get; set; }
        public int character_id { get; set; }
        public int corporation_id { get; set; }
        public int damage_done { get; set; }
        public bool final_blow { get; set; }
        public float security_status { get; set; }
        public int ship_type_id { get; set; }
        public int weapon_type_id { get; set; }
    }

    public class Zkb
    {
        public int locationID { get; set; }
        public string hash { get; set; }
        public int fittedValue { get; set; }
        public int totalValue { get; set; }
        public int points { get; set; }
        public bool npc { get; set; }
        public bool solo { get; set; }
        public bool awox { get; set; }
        public string href { get; set; }
    }


}
