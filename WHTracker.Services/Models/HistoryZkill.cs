using System;
using System.Collections.Generic;
using System.Text;

namespace WHTracker.Services.Models
{
    public class HistoryZkill
    {
        public DateTime Date { get; set; }

        public ICollection<KillmailHash>? KillmailHashes { get; set; }
    }

    public class KillmailHash
    {

        public KillmailHash(int killId, string killHash)
        {
            KillId = killId;
            KillHash = killHash;
        }

        // Eve KillId
        public int KillId { get; set; }

        // Eve KillHash
        public string? KillHash { get; set; }
    }
}
