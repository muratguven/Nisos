using MediatR;
using MediatrApp.Domain.Customers;
using MediatrApp.MongoDb.Test;
using MediatrDemo.CoreLib.Queries;
using MediatrDemo.Redis.Cache;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.CoreLib.Handlers
{
    public class GetCustomerListHandler : IRequestHandler<GetCustomerQuery, List<Customer>>
    {
        private readonly ITestMongoDb TestMongoDb;
        private readonly ICacheProvider Cache;

        public GetCustomerListHandler(ITestMongoDb testMongoDb, ICacheProvider cache)
        {
            TestMongoDb = testMongoDb;
            Cache = cache;
        }

        public async Task<List<Customer>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {

            var cachedCustomer = await Cache.GetAsync<List<Customer>>("customers");
            if (cachedCustomer == null)
            {
                 cachedCustomer = await TestMongoDb.GelAllListAsync();

                var options = new DistributedCacheEntryOptions();
                options.SetSlidingExpiration(TimeSpan.FromMinutes(5));
                options.SetAbsoluteExpiration(DateTime.Now.AddHours(1));
                await Cache.SetAsync<List<Customer>>("customers", cachedCustomer, options);
            }
            
            return cachedCustomer;
        }
    }
}
