using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;

using WHTracker.Services.Models;
using WHTracker.Services.Workers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WHTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorAPIController : ControllerBase
    {

        private readonly IBackgroundTaskQueue<IEnumerable<KillmailHash>> killmailHashBackgroundQueue;
        private readonly IBackgroundTaskQueue<IEnumerable<KillmailValue>> killmailValueBackgroundQueue;

        public MonitorAPIController(IBackgroundTaskQueue<IEnumerable<KillmailHash>> KillmailHashBackgroundQueue, IBackgroundTaskQueue<IEnumerable<KillmailValue>> KillmailValueBackgroundQueue)
        {
            killmailHashBackgroundQueue = KillmailHashBackgroundQueue;
            killmailValueBackgroundQueue = KillmailValueBackgroundQueue;
        }


        [HttpGet]
        public object GetCorporationDay()
        {

            return new
            {
                HashLength = killmailHashBackgroundQueue.GetQueueLength(),
                ValueLength = killmailValueBackgroundQueue.GetQueueLength(),
                HashLastExecutionTime = killmailHashBackgroundQueue.LastExecutionTime.Any() ? killmailHashBackgroundQueue.LastExecutionTime[0] : 0,
                HashAverageExecutionTime = killmailHashBackgroundQueue.LastExecutionTime.Any() ? killmailHashBackgroundQueue.LastExecutionTime.Average() : 0,
                ValueLastExecutionTime = killmailValueBackgroundQueue.LastExecutionTime.Any() ? killmailValueBackgroundQueue.LastExecutionTime[0] : 0,
                ValueAverageExecutionTime = killmailValueBackgroundQueue.LastExecutionTime.Any() ? killmailValueBackgroundQueue.LastExecutionTime.Average() : 0,
            };
        }

    }
}
