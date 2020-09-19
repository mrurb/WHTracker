using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using WHTracker.Data;
using WHTracker.Data.Models;
using WHTracker.Services.MiscServices;
using WHTracker.Services.Models;

namespace WHTracker.Services.Workers
{
    public class ZkillRedisQWorker : IHostedService, IDisposable
    {
        private readonly ILogger<ZkillRedisQWorker> _logger;
        private readonly ZKillRedisQAPIService zKillRedisQAPI;
        private readonly IServiceProvider services;
        private readonly LastUpdatedService lastUpdatedService;
        private Timer? _timer;

        public ZkillRedisQWorker(ILogger<ZkillRedisQWorker> logger, ZKillRedisQAPIService zKillRedisQAPI, IServiceProvider services, LastUpdatedService lastUpdatedService)
        {
            _logger = logger;
            this.zKillRedisQAPI = zKillRedisQAPI;
            this.services = services;
            this.lastUpdatedService = lastUpdatedService;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(15));

            return Task.CompletedTask;
        }

        private async void DoWork(object? state)
        {

            var killmails = new List<RedisQZkill>();

            RedisQZkill res;
            while ((res = await zKillRedisQAPI.GetRedisQCall(3)).Package is not null)
            {
                if (!killmails.Any(c => c.Package.KillId == res.Package.KillId))
                {
                    killmails.Add(res);
                    _logger.LogDebug("Killmail: {0}", res.Package.KillId);
                }
            }
            List<RedisQZkill> lists;
            int WHKills = 0;
            if (killmails.Any())
            {
                using var scope = services.CreateScope();
                var context =
                    scope.ServiceProvider
                        .GetRequiredService<ApplicationContext>();
                var aggregateService =
                    scope.ServiceProvider
                        .GetRequiredService<AggregateService>();
                lists = killmails.Where(x => !context.Killmails.Any(c => x.Package.KillId == c.KiilmailId)).ToList();
                foreach (var killmail in lists)
                {
                    await aggregateService.ProcessKillmailValue(killmail.Package.Killmail, killmail.Package.Zkb.TotalValue);
                    if (killmail.Package?.Killmail.SolarSystemId >= 31000000 && killmail.Package.Killmail.SolarSystemId <= 32000000)
                    {
                        WHKills += 1;
                        _logger.LogDebug("WH system kill {0}", killmail.Package?.KillId);
                    }
                    else
                    {
                        _logger.LogDebug("kspace {0}", killmail.Package?.KillId);

                    }
                }

                List<Killmails> KillMails = lists.Select(c => new Killmails { KiilmailId = c.Package.KillId, KillmailHash = c.Package.Zkb.Hash, TimeStamp = c.Package.Killmail.KillmailTime }).ToList();
                await context.AddRangeAsync(KillMails);
                await context.SaveChangesAsync();
                lastUpdatedService.UpdateTime();
            }
            _logger.LogInformation("Zkill redisQ done working processed {0} WH kills, setting time to {1}", WHKills, lastUpdatedService.Time);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}
