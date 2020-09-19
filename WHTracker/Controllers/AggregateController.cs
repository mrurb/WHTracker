using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using WHTracker.API.Models;
using WHTracker.Data.Models;
using WHTracker.Services;
using WHTracker.Services.Cache;
using WHTracker.Services.MiscServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WHTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(Duration = 300, VaryByQueryKeys = new string[] { "date" })]
    public class AggregateController : ControllerBase
    {
        private const string Format = "yyyy-MM-dd HH:mm";
        private readonly AggregateReposetory aggregateCacheManagerService;
        private readonly LastUpdatedService lastUpdatedService;

        public AggregateController(AggregateReposetory aggregateCacheManagerService, LastUpdatedService lastUpdatedService)
        {
            this.aggregateCacheManagerService = aggregateCacheManagerService;
            this.lastUpdatedService = lastUpdatedService;
        }

        // GET: api/<ValuesController1>
        [HttpGet("Corporation/day/{date}")]
        public JsonData<DailyAggregateCorporation> GetCorporationDay(DateTime date)
        {
            var p = aggregateCacheManagerService.GetDACFromDatabaseAsync(date);

            JsonData<DailyAggregateCorporation> jsonData = new JsonData<DailyAggregateCorporation>(p, lastUpdatedService.Time.ToString(Format));
            return jsonData;

        }

        [HttpGet("Alliance/day/{date}")]
        public JsonData<DailyAggregateAlliance> GetAllianceDay(DateTime date)
        {
            var p = aggregateCacheManagerService.GetDAAFromDatabaseAsync(date);
            JsonData<DailyAggregateAlliance> jsonData = new JsonData<DailyAggregateAlliance>(p, lastUpdatedService.Time.ToString(Format));
            return jsonData;

        }
        [HttpGet("Corporation/month/{date}")]
        public JsonData<MonthlyAggregateCorporation> GetCorporationMonth(DateTime date)
        {
            var p = aggregateCacheManagerService.GetMACFromDatabaseAsync(date);
            JsonData<MonthlyAggregateCorporation> jsonData = new JsonData<MonthlyAggregateCorporation>(p, lastUpdatedService.Time.ToString(Format));
            return jsonData;

        }

        [HttpGet("Alliance/month/{date}")]
        public JsonData<MonthlyAggregateAlliance> GetAllainceMonth(DateTime date)
        {
            var p = aggregateCacheManagerService.GetMAAFromDatabaseAsync(date);
            JsonData<MonthlyAggregateAlliance> jsonData = new JsonData<MonthlyAggregateAlliance>(p, lastUpdatedService.Time.ToString(Format));
            return jsonData;

        }
    }
}
