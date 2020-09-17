using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WHTracker.Data.Models;

namespace WHTracker.API.Models
{
    public class JsonDataCorporation
    {
        public IEnumerable<DailyAggregateCorporation> Data { get; set; }

        public JsonDataCorporation(IEnumerable<DailyAggregateCorporation> data)
        {
            Data = data;
        }
    }

    public class JsonDataAlliance
    {
        public IEnumerable<DailyAggregateAlliance> Data { get; set; }

        public JsonDataAlliance(IEnumerable<DailyAggregateAlliance> data)
        {
            Data = data;
        }
    }
}
