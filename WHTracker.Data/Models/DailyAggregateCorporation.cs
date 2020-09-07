using System;
using System.Collections.Generic;
using System.Text;
#nullable disable
namespace WHTracker.Data.Models
{
    public class DailyAggregateCorporation : AggregateData
    {
        public int DailyAggregateCorporationId { get; set; }
        public int CorporationID { get; set; }
        public Corporation Corporation { get; set; }
    }


}
