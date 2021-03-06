using Nisos.MongoDb.Db;
using Nisos.MongoDb.Repositories;
using Nisos.MongoDb.Settings;
using Nisos.MongoDb.Uow;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Nisos.MongoDb.DependencyInjection.Microsoft
{
    public static class MongoDbServiceCollectionExtension
    {
        public static IServiceCollection AddMongoDb<TDbContext>(
            this IServiceCollection services, IConfiguration configuration)
            where TDbContext: MongoDbContextBase
        {
            // MongoDb settings 
            //var section = configuration.GetSection("MongoDbSettings") as MongoDbSettings;
            //services.Configure<MongoDbSettings>(opt => {
            //    opt.ConnectionString = section.ConnectionString;
            //    opt.DatabaseName = section.DatabaseName;

            //});

            

            services.AddSingleton(typeof(IMongoDbContextProvider<>), typeof(MongoDbContextProvider<>));
            services.AddSingleton(typeof(IMongoDbContext), typeof(TDbContext));
            services.AddSingleton<IMongoDbSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            services.AddScoped(typeof(IMongoDbQueryRepository<>), typeof(MongoDbQueryRepository<,>));
            services.AddScoped(typeof(IMongoDbCommandRepository<,>), typeof(MongoDbCommandRepository<,,>));
            services.AddScoped<IMongoUnitOfWork, MongoUnitOfWork>();
            return services;
        }
    }
}
