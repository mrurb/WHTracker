using System;
using System.Collections.Generic;
using System.Text;

namespace WHTracker.Data.Models
{
#nullable disable
    public class AggregateCorporation : AggregateData
    {
        public int CorporationID { get; set; }
        public virtual Corporation Corporation { get; set; }
    }
}
