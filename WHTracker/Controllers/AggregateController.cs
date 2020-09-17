using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using WHTracker.API.Models;
using WHTracker.Data.Models;
using WHTracker.Services;
using WHTracker.Services.Cache;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WHTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AggregateController : ControllerBase
    {
        private readonly AggregateCacheManagerService aggregateCacheManagerService;

        public AggregateController(AggregateCacheManagerService aggregateCacheManagerService)
        {
            this.aggregateCacheManagerService = aggregateCacheManagerService;
        }

        // GET: api/<ValuesController1>
        [HttpGet("Corporation/day/{date}")]
        public async Task<JsonDataCorporation> GetCorporationDayAsync(DateTime date)
        {
            (DateTime day, DateTime lastPulled, IEnumerable<Data.Models.DailyAggregateCorporation> dailyAggregateCorporation) p = await aggregateCacheManagerService.GetAggregateCorporation(date);
    
            JsonDataCorporation jsonData = new JsonDataCorporation ( p.dailyAggregateCorporation );
            return jsonData;

        }

        [HttpGet("Alliance/day/{date}")]
        public async Task<JsonDataAlliance> GetAllianceDayAsync(DateTime date)
        {
            (DateTime day, DateTime lastPulled, IEnumerable<Data.Models.DailyAggregateAlliance> dailyAggregateAlliances) p = await aggregateCacheManagerService.GetAggregateAlliance(date);

            JsonDataAlliance jsonData = new JsonDataAlliance(p.dailyAggregateAlliances);
            return jsonData;

        }
        [HttpGet("Corporation/month/{date}")]
        public async Task<JsonDataCorporation> GetCorporationMonthAsync(DateTime date)
        {
            (DateTime day, DateTime lastPulled, IEnumerable<Data.Models.DailyAggregateCorporation> dailyAggregateCorporation) p = await aggregateCacheManagerService.GetAggregateCorporation(date);

            JsonDataCorporation jsonData = new JsonDataCorporation(p.dailyAggregateCorporation);
            return jsonData;

        }

        [HttpGet("Alliance/month/{date}")]
        public async Task<JsonDataAlliance> GetAllainceMonthAsync(DateTime date)
        {
            (DateTime day, DateTime lastPulled, IEnumerable<Data.Models.DailyAggregateAlliance> dailyAggregateAlliances) p = await aggregateCacheManagerService.GetAggregateAlliance(date);

            JsonDataAlliance jsonData = new JsonDataAlliance(p.dailyAggregateAlliances);
            return jsonData;

        }
    }
}
