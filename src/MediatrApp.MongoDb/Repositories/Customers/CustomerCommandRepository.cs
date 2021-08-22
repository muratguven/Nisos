using MediatrApp.MongoDb.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatrDemo.MongoDb.Repositories;
using MediatrApp.Domain.Customers;
using MediatrDemo.MongoDb.Db;

namespace MediatrApp.MongoDb.Repositories.Customers
{
    public class CustomerCommandRepository : MongoDbCommandRepository<MediatrAppMongoDbContext, Customer, Guid>, ICustomerCommandRepository
    {

        public CustomerCommandRepository(IMongoDbContextProvider<MediatrAppMongoDbContext> contextProvider) : base(contextProvider)
        {
        }

    }
}
