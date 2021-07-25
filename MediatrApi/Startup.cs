using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatrApp.MongoDb.Db;
using MediatrApp.MongoDb.DependencyInjection;
using MediatrApp.MongoDb.Repositories.Customers;
using MediatrDemo.CoreLib;
using MediatrDemo.CoreLib.DataAccess;
using MediatrDemo.MongoDb.DependencyInjection.Microsoft;
using MediatrDemo.MongoDb.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MediatrApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MediatrApi", Version = "v1" });
            });

            services.AddMongoDb<MediatrAppMongoDbContext>(Configuration);
            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));
           
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerQueryRepository>().As<ICustomerQueryRepository>();
            builder.RegisterType<DemoDataAccess>().As<IDemoDataAccess>();
            builder.RegisterMediatR(typeof(Startup).GetTypeInfo().Assembly);
            builder.RegisterMediatR(typeof(CoreLibStartup).Assembly);
            
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MediatrApi v1"));
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
