using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

using WHTracker.API.Models;
using WHTracker.Data.Models;
using WHTracker.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WHTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(Duration = 300, VaryByQueryKeys = new string[] { "date" })]
    public class AggregateController : ControllerBase
    {
        private const string Format = "yyyy-MM-dd HH:mm";
        private const string Path = "./wwwroot/time.txt";
        private readonly AggregateReposetory aggregateCacheManagerService;

        public AggregateController(AggregateReposetory aggregateCacheManagerService)
        {
            this.aggregateCacheManagerService = aggregateCacheManagerService;
        }

        // GET: api/<ValuesController1>
        [HttpGet("Corporation/day/{date}")]
        public async Task<JsonData<DailyAggregateCorporation>> GetCorporationDayAsync(DateTime date)
        {
            var p = aggregateCacheManagerService.GetDACFromDatabaseAsync(date);
            string v = await System.IO.File.ReadAllTextAsync(Path);
            JsonData<DailyAggregateCorporation> jsonData = new JsonData<DailyAggregateCorporation>(p, v);
            return jsonData;
        }

        [HttpGet("Alliance/day/{date}")]
        public async Task<JsonData<DailyAggregateAlliance>> GetAllianceDayAsync(DateTime date)
        {
            var p = aggregateCacheManagerService.GetDAAFromDatabaseAsync(date);
            string v = await System.IO.File.ReadAllTextAsync(Path);
            JsonData<DailyAggregateAlliance> jsonData = new JsonData<DailyAggregateAlliance>(p, v);
            return jsonData;

        }
        [HttpGet("Corporation/month/{date}")]
        public async Task<JsonData<MonthlyAggregateCorporation>> GetCorporationMonthAsync(DateTime date)
        {
            var p = aggregateCacheManagerService.GetMACFromDatabaseAsync(date);
            string v = await System.IO.File.ReadAllTextAsync(Path);
            JsonData<MonthlyAggregateCorporation> jsonData = new JsonData<MonthlyAggregateCorporation>(p, v);
            return jsonData;

        }

        [HttpGet("Alliance/month/{date}")]
        public async Task<JsonData<MonthlyAggregateAlliance>> GetAllainceMonthAsync(DateTime date)
        {
            var p = aggregateCacheManagerService.GetMAAFromDatabaseAsync(date);
            string v = await System.IO.File.ReadAllTextAsync(Path);
            JsonData<MonthlyAggregateAlliance> jsonData = new JsonData<MonthlyAggregateAlliance>(p, v);
            return jsonData;

        }
    }
}
