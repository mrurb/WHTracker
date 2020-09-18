using Microsoft.Extensions.DependencyInjection;

using Polly;

using System;

using WHTracker.Services.Cache;

namespace WHTracker.Services
{
    public static class ESIExtension
    {
        public static IServiceCollection AddESIService(this IServiceCollection services)
        {
            services.AddSingleton<ESICache>();

            services.AddHttpClient<ESIService>()
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
                .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

            return services;
        }
    }
}
