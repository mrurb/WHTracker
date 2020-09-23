using Microsoft.Extensions.DependencyInjection;

namespace WHTracker.Services
{
    public static class AggregateExtension
    {
        public static IServiceCollection AddAggregateServices(this IServiceCollection services)
        {

            services.AddScoped<AggregateService>();
            services.AddScoped<AggregateReposetory>();

            services.AddScoped<KillmailHistoryService>();

            return services;
        }
    }
}
