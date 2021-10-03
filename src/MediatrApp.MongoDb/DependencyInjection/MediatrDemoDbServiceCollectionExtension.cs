using MediatrApp.MongoDb.Db;
using MediatrApp.MongoDb.Repositories.Customers;
using MediatrApp.MongoDb.Test;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nisos.MongoDb.DependencyInjection.Microsoft;

namespace MediatrApp.MongoDb.DependencyInjection
{
    public static class MediatrDemoDbServiceCollectionExtension
    {
        public static IServiceCollection AddMediatrDemoMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongoDb<MediatrAppMongoDbContext>(configuration);
            services.AddTransient<ICustomerQueryRepository, CustomerQueryRepository>();
            services.AddTransient<ICustomerCommandRepository, CustomerCommandRepository>();
            services.AddSingleton<ITestMongoDb, TestMongoDb>();

            return services;
           
        }
    }
}
