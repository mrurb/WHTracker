using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
#nullable disable
namespace WHTracker.Data.Models
{
    public class DailyAggregateCorporation : AggregateData
    {
        public int DailyAggregateCorporationId { get; set; }
        public int CorporationID { get; set; }
        public virtual Corporation Corporation { get; set; }
    }


}
