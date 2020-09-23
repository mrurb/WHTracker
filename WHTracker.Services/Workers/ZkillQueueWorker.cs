using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WHTracker.Services.Models;

namespace WHTracker.Services.Workers
{
    public interface IBackgroundTaskQueue<T>
    {
        void QueueBackgroundWorkItem(T workItem);

        Task<T> DequeueAsync(
            CancellationToken cancellationToken);
    }

    public class BackgroundTaskQueue<T> : IBackgroundTaskQueue<T>
    {
        private ConcurrentQueue<T> _workItems = new ConcurrentQueue<T>();

        private SemaphoreSlim _signal = new SemaphoreSlim(0);

        public void QueueBackgroundWorkItem(
            T workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException(nameof(workItem));
            }

            _workItems.Enqueue(workItem);
            _signal.Release();
        }

        public async Task<T> DequeueAsync(
            CancellationToken cancellationToken)
        {
            await _signal.WaitAsync(cancellationToken);
            _workItems.TryDequeue(out var workItem);

            return workItem;
        }
    }

    public abstract class QueueBackgroundWorker<T> : BackgroundService
    {
        private readonly ILogger<QueueBackgroundWorker<T>> _logger;

        public QueueBackgroundWorker(IBackgroundTaskQueue<T> taskQueue,
            ILogger<QueueBackgroundWorker<T>> logger)
        {
            TaskQueue = taskQueue;
            _logger = logger;
        }

        public IBackgroundTaskQueue<T> TaskQueue { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Queued Hosted Service is running.{Environment.NewLine}");

            await BackgroundProcessing(stoppingToken);
        }

        private async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var workItem =
                    await TaskQueue.DequeueAsync(stoppingToken);

                try
                {
                    await ProcessItem(workItem, stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex,
                        "Error occurred executing {WorkItem}.", nameof(workItem));
                }
            }
        }
        protected abstract Task ProcessItem(T item, CancellationToken stoppingToken);

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Queued Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }

    public class KillmailHashWorker : QueueBackgroundWorker<IEnumerable<KillmailHash>>
    {
        public IServiceProvider Services { get; }

        public KillmailHashWorker(IBackgroundTaskQueue<IEnumerable<KillmailHash>> taskQueue, ILogger<QueueBackgroundWorker<IEnumerable<KillmailHash>>> logger, IServiceProvider services, IBackgroundTaskQueue<IEnumerable<KillmailValue>> killmailValueQueue) : base(taskQueue, logger)
        {
            Services = services;
            this.killmailValueQueue = killmailValueQueue;
        }

        private readonly IBackgroundTaskQueue<IEnumerable<KillmailValue>> killmailValueQueue;

        protected override async Task ProcessItem(IEnumerable<KillmailHash> item, CancellationToken stoppingToken)
        {
            using (var scope = Services.CreateScope())
            {
                var eSIService =
                    scope.ServiceProvider
                        .GetRequiredService<ESIService>();
                var aggregateService =
                    scope.ServiceProvider
                        .GetRequiredService<AggregateService>();

                List<KillmailValue> outputKillmailValues = new List<KillmailValue>();

                foreach (var killmailHash in item)
                {
                    Killmail killmail = await eSIService.GetKillmail(killmailHash.KillId, killmailHash.KillHash);

                    float value = 0;

                    if (aggregateService.IsWormholeKill(killmail))
                    {
                        value = (float)(await aggregateService.CalculateKillmailValue(killmail));
                    }

                    outputKillmailValues.Add(new KillmailValue(killmailHash.KillId, killmailHash.KillHash, killmail, value));
                }

                killmailValueQueue.QueueBackgroundWorkItem(outputKillmailValues);
            }
        }
    }

    public class KillmailValueWorker : QueueBackgroundWorker<IEnumerable<KillmailValue>>
    {
        public IServiceProvider Services { get; }

        public KillmailValueWorker(IBackgroundTaskQueue<IEnumerable<KillmailValue>> taskQueue, ILogger<QueueBackgroundWorker<IEnumerable<KillmailValue>>> logger, IServiceProvider services) : base(taskQueue, logger)
        {
            Services = services;
        }

        protected override async Task ProcessItem(IEnumerable<KillmailValue> item, CancellationToken stoppingToken)
        {
            using (var scope = Services.CreateScope())
            {
                var aggregateService =
                    scope.ServiceProvider
                        .GetRequiredService<AggregateService>();

                var missingKills = aggregateService.GetMissingKillmails(item);

                foreach (var killmail in missingKills)
                {
                    await aggregateService.ProcessKillmailValue(killmail);
                }

                await aggregateService.AddProcessedKillmails(missingKills);
            }
        }
    }
}
