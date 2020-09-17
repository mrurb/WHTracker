using System;
using System.Collections.Generic;
using System.Text;

namespace WHTracker.Data.Models
{
    public class MonthlyAggregateCorporation : AggregateData
    {
        public int MonthlyAggregateCorporationId { get; set; }
        public int CorporationID { get; set; }
        public virtual Corporation corporation { get; set; }
    }
}
