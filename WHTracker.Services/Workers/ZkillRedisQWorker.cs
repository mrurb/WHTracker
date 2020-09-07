using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using WHTracker.Services.Models;

namespace WHTracker.Services.Workers
{
    public class ZkillRedisQWorker : IHostedService, IDisposable
    {
        private readonly ILogger<ZkillRedisQWorker> _logger;
        private readonly ZKillRedisQAPIService zKillRedisQAPI;
        private Timer _timer;

        public ZkillRedisQWorker(ILogger<ZkillRedisQWorker> logger, ZKillRedisQAPIService zKillRedisQAPI)
        {
            _logger = logger;
            this.zKillRedisQAPI = zKillRedisQAPI;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            RedisQZkill res;
            while ((res = await zKillRedisQAPI.GetRedisQCall(3)).Package is not null)
            {
                _logger.LogInformation("{0}", res.Package.killID);
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
