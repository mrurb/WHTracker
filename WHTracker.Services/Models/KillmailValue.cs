using System;
using System.Collections.Generic;
using System.Text;

namespace WHTracker.Services.Models
{
    public class KillmailValue
    {
        public KillmailValue()
        {

        }

        public KillmailValue(int killmailId, string killmailHash, Killmail killmail, float value)
        {
            KillmailId = killmailId;
            KillmailHash = killmailHash;
            Killmail = killmail;
            Value = value;
        }

        public int KillmailId{ get; set; }

        public string KillmailHash { get; set; }

        public Killmail Killmail { get; set; }

        public float Value { get; set; }
    }
}
