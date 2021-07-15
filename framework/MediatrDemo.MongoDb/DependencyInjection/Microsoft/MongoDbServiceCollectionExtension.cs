﻿using MediatrDemo.MongoDb.Db;
using MediatrDemo.MongoDb.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace MediatrDemo.MongoDb.DependencyInjection.Microsoft
{
    public static class MongoDbServiceCollectionExtension
    {
        public static IServiceCollection AddMongoDb(
            this IServiceCollection services, IConfiguration configuration)
        {
            // MongoDb settings 
            var section = configuration.GetSection("MongoDbSettings") as MongoDbSettings;
            services.Configure<MongoDbSettings>(opt => {
                opt.ConnectionString = section.ConnectionString;
                opt.DatabaseName = section.DatabaseName;

            });

            services.AddTransient<IMongoDbContext, MongoDbContextBase>();
            services.AddSingleton<IMongoDbSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            return services;
        }
    }
}
