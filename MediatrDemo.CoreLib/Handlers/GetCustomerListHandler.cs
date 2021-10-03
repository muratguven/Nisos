using MediatR;
using MediatrApp.MongoDb.Repositories.Customers;
using MediatrDemo.CoreLib.Models;
using MediatrDemo.CoreLib.Queries;
using MediatrDemo.Redis.Cache;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.CoreLib.Handlers
{
    public class GetCustomerListHandler : IRequestHandler<GetCustomerQuery, List<CustomerModel>>
    {
        private readonly ICustomerQueryRepository CustomerQueryRepository;
        private readonly ICacheProvider Cache;

        public GetCustomerListHandler(ICacheProvider cache, ICustomerQueryRepository customerQueryRepository)
        {

            Cache = cache;
            CustomerQueryRepository = customerQueryRepository;
        }

        public async Task<List<CustomerModel>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {

            var cachedCustomer = await Cache.GetAsync<List<CustomerModel>>("customers");
            if (cachedCustomer == null)
            {
                var customers = await CustomerQueryRepository.GetListAsync();
                //Mapping
                cachedCustomer = new List<CustomerModel>();
                foreach (var item in customers)
                {
                    cachedCustomer.Add(new CustomerModel { Name = item.Name, Surname = item.Surname, PhoneNumber = item.PhoneNumber, Email = item.Email, PlateNumber = item.PlateNumber });
                }

                var options = new DistributedCacheEntryOptions();
                options.SetSlidingExpiration(TimeSpan.FromMinutes(5));
                options.SetAbsoluteExpiration(DateTime.Now.AddHours(1));
                await Cache.SetAsync<List<CustomerModel>>("customers", cachedCustomer, options);
            }
            
            return cachedCustomer;
        }
    }
}
