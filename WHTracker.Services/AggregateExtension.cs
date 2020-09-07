using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WHTracker.Services
{
    public static class AggregateExtension
    {
        public static IServiceCollection AddAggregateServices(this IServiceCollection services)
        {

            services.AddScoped<AggregateService>();

            return services;
        }
    }
}
