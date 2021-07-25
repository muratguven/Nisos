using MediatrApp.MongoDb.Db;
using MediatrApp.MongoDb.Repositories.Customers;
using MediatrDemo.MongoDb.Db;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrApp.MongoDb.DependencyInjection
{
    public static class MediatrDemoDbServiceCollectionExtension
    {
        public static IServiceCollection AddMediatrDemoMongoDb(this IServiceCollection services)
        {

            services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
            
            return services;
           
        }
    }
}
