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

namespace WHTracker.Services.Workers
{
    public class ZkillRedisQWorker : IHostedService, IDisposable
    {
        private readonly ILogger<ZkillRedisQWorker> _logger;
        private readonly ZKillRedisQAPIService zKillRedisQAPI;
        private readonly ApplicationContext applicationContext;
        private Timer? _timer;

        public ZkillRedisQWorker(ILogger<ZkillRedisQWorker> logger, ZKillRedisQAPIService zKillRedisQAPI, ApplicationContext applicationContext)
        {
            _logger = logger;
            this.zKillRedisQAPI = zKillRedisQAPI;
            this.applicationContext = applicationContext;
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

        private async void DoWork(object? state)
        {
            IQueryable<Data.Models.Killmails> queryables = applicationContext.Killmails.Where(c => c.TimeStamp.Date == DateTime.UtcNow.Date);

            var killmails = new List<RedisQZkill>();

            RedisQZkill res;
            while ((res = await zKillRedisQAPI.GetRedisQCall(3)).Package is not null)
            {
                killmails.Add(res);
                _logger.LogInformation("{0}", res.Package.KillId);
            }

            applicationContext.Killmails.Where(c => killmails.Any(x => x.Package.Zkb.Gash == c.KillmailHash && x.Package.KillId == c.KiilmailId)).ToList();
            
            foreach (var killmail in from killmail in killmails
                                     where killmail.Package?.Zkb.LocationId >= 31000000 && killmail.Package?.Zkb.LocationId <= 32000000
                                     select killmail)
            {
                _logger.LogInformation("WH system kill {0}", killmail.Package?.KillId);
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
