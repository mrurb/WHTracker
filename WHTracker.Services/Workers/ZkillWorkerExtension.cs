using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WHTracker.Services.Models;

namespace WHTracker.Services.Workers
{
    public static class ZkillWorkerExtension
    {
        public static IServiceCollection AddZKillWorkers(this IServiceCollection services)
        {

            services.AddHostedService<ZkillRedisQWorker>();
            services.AddHostedService<ZkillHistoryWorker>();

            services.AddSingleton<IBackgroundTaskQueue<IEnumerable<KillmailHash>>, BackgroundTaskQueue<IEnumerable<KillmailHash>>>();
            services.AddHostedService<KillmailHashWorker>();

            services.AddSingleton<IBackgroundTaskQueue<IEnumerable<KillmailValue>>, BackgroundTaskQueue<IEnumerable<KillmailValue>>>();
            services.AddHostedService<KillmailValueWorker>();
            return services;
        }
    }
}
