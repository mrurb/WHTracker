using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

using WHTracker.Data;
using WHTracker.Services.Models;
using WHTracker.Data.Models;
using Microsoft.Extensions.DependencyInjection;

namespace WHTracker.Services.Workers
{
    public class ZkillRedisQWorker : IHostedService, IDisposable
    {
        private readonly ILogger<ZkillRedisQWorker> _logger;
        private readonly ZKillRedisQAPIService zKillRedisQAPI;
        private readonly IServiceProvider services;
        private Timer? _timer;

        public ZkillRedisQWorker(ILogger<ZkillRedisQWorker> logger, ZKillRedisQAPIService zKillRedisQAPI, IServiceProvider services)
        {
            _logger = logger;
            this.zKillRedisQAPI = zKillRedisQAPI;
            this.services = services;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(3));

            return Task.CompletedTask;
        }

        private async void DoWork(object? state)
        {

            var killmails = new List<RedisQZkill>();

            RedisQZkill res;
            while ((res = await zKillRedisQAPI.GetRedisQCall(3)).Package is not null)
            {
                killmails.Add(res);
                _logger.LogInformation("Killmail: {0}", res.Package.KillId);
            }
            List<RedisQZkill> lists;
            if (killmails.Any())
            {
                using (var scope = services.CreateScope())
                {
                    var context =
                        scope.ServiceProvider
                            .GetRequiredService<ApplicationContext>();
                    lists = killmails.Where(x => !context.Killmails.Any(c => x.Package.KillId == c.KiilmailId)).ToList();
                    
                    foreach (var killmail in lists)
                    {
                        if (killmail.Package?.Killmail.SolarSystemId >= 31000000 && killmail.Package.Killmail.SolarSystemId <= 32000000)
                        {
                            _logger.LogDebug("WH system kill {0}", killmail.Package?.KillId);
                        }
                        else
                        {
                            _logger.LogDebug("kspace {0}", killmail.Package?.KillId);

                        }

                    }

                }



            }
            _logger.LogInformation("Zkill redisQ done working");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}
