using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using WHTracker.Data;
using WHTracker.Data.Models;
using WHTracker.Services.Models;

namespace WHTracker.Services.Workers
{
    public class ZkillRedisQWorker : IHostedService, IDisposable
    {
        private readonly ILogger<ZkillRedisQWorker> _logger;
        private readonly ZKillRedisQAPIService zKillRedisQAPI;
        private readonly IServiceProvider services;
        private readonly IBackgroundTaskQueue<IEnumerable<KillmailValue>> killmailValueQueue;
        private Timer _timer;
        private int running;

        public ZkillRedisQWorker(ILogger<ZkillRedisQWorker> logger, ZKillRedisQAPIService zKillRedisQAPI, IServiceProvider services, IBackgroundTaskQueue<IEnumerable<KillmailValue>> killmailValueQueue)
        {
            _logger = logger;
            this.zKillRedisQAPI = zKillRedisQAPI;
            this.services = services;
            this.killmailValueQueue = killmailValueQueue;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");
            _timer = new Timer(DoWork, null,TimeSpan.FromMinutes(2) , TimeSpan.FromMinutes(15));
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


            var killmails = new List<RedisQZkill>();
            try
            {
                RedisQZkill res;
                while ((res = await zKillRedisQAPI.GetRedisQCall(3)).Package is not null)
                {
                    if (!killmails.Any(c => c.Package.KillId == res.Package.KillId))
                    {
                        killmails.Add(res);
                        _logger.LogDebug("Killmail: {0}", res.Package.KillId);
                    }
                }

                if (killmails.Any())
                {
                    using var scope = services.CreateScope();
                    var aggregateService =
                        scope.ServiceProvider
                            .GetRequiredService<AggregateService>();

                    IEnumerable<KillmailValue> data = killmails.Select(rkill => new KillmailValue(rkill.Package.KillId, rkill.Package.Zkb.Hash, rkill.Package.Killmail, rkill.Package.Zkb.TotalValue)).ToList();

                    killmailValueQueue.QueueBackgroundWorkItem(data);

                    //lastUpdatedService.UpdateTime();
                    await File.WriteAllTextAsync("./wwwroot/time.txt", $"{DateTime.UtcNow:yyyy-MM-dd HH:mm}");
                    _logger.LogInformation("Zkill redisQ done working processed {0} WH kills out of {1}, setting time to {2}", killmails.Count(k => aggregateService.IsWormholeKill(k.Package.Killmail)), killmails.Count, DateTime.UtcNow);

                }

            }
            catch (HttpRequestException e)
            {

                _logger.LogCritical("Failed to get killmail from redisq error: {1}", e);
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
