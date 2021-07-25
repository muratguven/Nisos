
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrApp.MongoDb.DependencyInjection
{
    public static class MediatrDemoDbServiceCollectionExtension
    {
        public static AutofacServiceProvider AddMediatrDemoMongoDb(this IServiceCollection services)
        {
            

            ContainerBuilder containerBuilder = new();
            //containerBuilder.RegisterType<MediatrAppMongoDbContext>().As<IMongoDbContext>().
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
           
        }
    }
}
