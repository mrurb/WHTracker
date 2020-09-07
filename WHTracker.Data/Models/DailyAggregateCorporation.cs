using System;
using System.Collections.Generic;
using System.Text;

namespace WHTracker.Data.Models
{
    public class DailyAggregateCorporation : AggregateData
    {
        public int DailyAggregateCorporationID { get; set; }
        public int CorporationID { get; set; }
        public Corporation Corporation { get; set; }
    }


}
