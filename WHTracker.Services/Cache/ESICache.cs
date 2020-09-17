using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHTracker.Services.Models;

namespace WHTracker.Services.Cache
{
    public class ESICache
    {
        private Dictionary<int, EveType> EveTypes { get; set; }

        public ESICache()
        {
            EveTypes = new Dictionary<int, EveType>();
        }

        public EveType? GetType(int id) {
            return EveTypes.FirstOrDefault(kv => kv.Key == id).Value;
        }

        public void AddType(int id, EveType type)
        {
            if(!EveTypes.Any(kv => kv.Key == id))
            {
                EveTypes.Add(id, type);
            }
        }

    }
}
