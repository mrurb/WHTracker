using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WHTracker.Data.Models;

namespace WHTracker.API.Models
{
    public class JsonData <T>
    {
        public IEnumerable<T> Data { get; set; }
        public string LastUpdated { get; set; }

        public JsonData(IEnumerable<T> data, string lastUpdated)
        {
            Data = data;
            LastUpdated = lastUpdated;
        }
    }
}
