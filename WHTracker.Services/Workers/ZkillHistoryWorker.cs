using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WHTracker.Services.Models;

namespace WHTracker.Services.Workers
{
    public class ZkillHistoryWorker : IHostedService, IDisposable
    {
        private readonly ILogger<ZkillHistoryWorker> _logger;
        private readonly IServiceProvider services;
        private readonly IBackgroundTaskQueue<IEnumerable<KillmailHash>> killmailHashQueue;
        private Timer _timer;
        private int running;

        public ZkillHistoryWorker(ILogger<ZkillHistoryWorker> logger, IServiceProvider services, IBackgroundTaskQueue<IEnumerable<KillmailHash>> killmailHashQueue)
        {
            _logger = logger;
            this.services = services;
            this.killmailHashQueue = killmailHashQueue;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        private async void DoWork(object? state)
        {
            if (running == 1)
            {
                _logger.LogInformation("Skipping allready running");
                return;
            }

            Interlocked.Exchange(ref running, 1);

            try
            {
                for(var i = 1; i <=1; i++)
                {
                    using var scope = services.CreateScope();
                    var killmailHistoryService =
                        scope.ServiceProvider
                            .GetRequiredService<KillmailHistoryService>();

                    DateTime day = DateTime.UtcNow.AddDays((-1) * i);

                    await killmailHistoryService.QueueHistoricalDay(day);

                }


            }
            catch (HttpRequestException e)
            {

                _logger.LogCritical("Failed to get killmail from history error: {1}", e);
            }
            finally
            {
                Interlocked.Exchange(ref running, 0);
            }
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}
