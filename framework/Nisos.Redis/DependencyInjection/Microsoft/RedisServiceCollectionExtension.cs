using Nisos.Redis.Cache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nisos.Redis.DependencyInjection.Microsoft
{
    public static class RedisServiceCollectionExtension
    {
        public static IServiceCollection AddMediatrRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:ConnectionString"];
                options.InstanceName = configuration["Redis:Instance"];
            });

            services.AddScoped<ICacheProvider, CacheProvider>();
            return services;
        }
    }
}
