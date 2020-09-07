using System;
using System.Collections.Generic;
using System.Text;
#nullable disable
namespace WHTracker.Data.Models
{
    public class Killmails
    {
        public int KiilmailId { get; set; }
        public string KillmailHash { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
