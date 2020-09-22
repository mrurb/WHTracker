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
        private readonly ESIService eSIService;
        private readonly AggregateService aggregateService;

        public AggregateController(AggregateReposetory aggregateCacheManagerService, ESIService eSIService, AggregateService aggregateService)
        {
            this.aggregateCacheManagerService = aggregateCacheManagerService;
            this.eSIService = eSIService;
            this.aggregateService = aggregateService;
        }

        // GET: api/<ValuesController1>
        [HttpGet("Corporation/day/{date}")]
        public async Task<JsonData<DailyAggregateCorporation>> GetCorporationDayAsync(DateTime date)
        {
            var p = aggregateCacheManagerService.GetDACFromDatabaseAsync(date);
            string v = await GetTime();
            JsonData<DailyAggregateCorporation> jsonData = new JsonData<DailyAggregateCorporation>(p, v);
            return jsonData;
        }

        private static async Task<string> GetTime()
        {
            return System.IO.File.Exists(Path) ? await System.IO.File.ReadAllTextAsync(Path) : "";
        }

        [HttpGet("Alliance/day/{date}")]
        public async Task<JsonData<DailyAggregateAlliance>> GetAllianceDayAsync(DateTime date)
        {
            var p = aggregateCacheManagerService.GetDAAFromDatabaseAsync(date);
            string v = await GetTime();
            JsonData<DailyAggregateAlliance> jsonData = new JsonData<DailyAggregateAlliance>(p, v);
            return jsonData;

        }
        [HttpGet("Corporation/month/{date}")]
        public async Task<JsonData<MonthlyAggregateCorporation>> GetCorporationMonthAsync(DateTime date)
        {
            var p = aggregateCacheManagerService.GetMACFromDatabaseAsync(date);
            string v = await GetTime();
            JsonData<MonthlyAggregateCorporation> jsonData = new JsonData<MonthlyAggregateCorporation>(p, v);
            return jsonData;

        }

        [HttpGet("Alliance/month/{date}")]
        public async Task<JsonData<MonthlyAggregateAlliance>> GetAllainceMonthAsync(DateTime date)
        {
            var p = aggregateCacheManagerService.GetMAAFromDatabaseAsync(date);
            string v = await GetTime();
            JsonData<MonthlyAggregateAlliance> jsonData = new JsonData<MonthlyAggregateAlliance>(p, v);
            return jsonData;

        }


        [HttpGet("KillmailHistory/{date}")]
        public async Task<int> ProcessKillmailHistory(DateTime date)
        {
            var value = await aggregateService.ProcessHistoryDay(date);
            return value;

        }
        [HttpGet("KillmailValue/{killId}/{hash}/")]
        public async Task<double> GetKillmailValue(int killId, string hash)
        {
            var killmail = await eSIService.GetKillmail(killId, hash);

            var value = await aggregateService.CalculateKillmailValue(killmail);
            return value;

        }
    }
}
