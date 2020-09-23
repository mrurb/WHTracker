using Microsoft.Extensions.Logging;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHTracker.Services.Models;
using WHTracker.Services.Workers;

namespace WHTracker.Services
{
    public class KillmailHistoryService
    {
        private readonly IBackgroundTaskQueue<IEnumerable<KillmailHash>> killmailHashQueue;
        private readonly AggregateService aggregateService;
        private readonly ILogger<KillmailHistoryService> _logger;
        public KillmailHistoryService(ILogger<KillmailHistoryService> logger, AggregateService aggregateService, IBackgroundTaskQueue<IEnumerable<KillmailHash>> killmailHashQueue)
        {
            this.killmailHashQueue = killmailHashQueue;
            this.aggregateService = aggregateService;
            this._logger = logger;
        }


        public async Task QueueHistoricalDay(DateTime day)
        {
            var history = await aggregateService.GetKillmailHistoryDay(day);

            var hashes = aggregateService.GetMissingKillmails(history);

            var hashBatches = hashes.Batch(50);

            foreach (var batch in hashBatches)
            {
                killmailHashQueue.QueueBackgroundWorkItem(batch);
            }

            _logger.LogInformation("Zkill history queued {0} hashes out of {1} for {2}", hashes.Count(), history.Count(), day);
        }
    }
}
