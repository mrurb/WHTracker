using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Polly;

using System;

using WHTracker.Options;

namespace WHTracker.Services
{
    public static class ZKillAPIExtension
    {
        public static IServiceCollection AddZKillRedisQAPI(this IServiceCollection services)
        {

            services.AddHttpClient<ZKillRedisQAPIService>()
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
                .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

            return services;
        }
    }
}
