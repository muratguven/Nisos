using MediatrApp.MongoDb.Db;
using System;
using MediatrApp.Domain.Customers;
using Nisos.MongoDb.Repositories;
using Nisos.MongoDb.Db;

namespace MediatrApp.MongoDb.Repositories.Customers
{
    public class CustomerCommandRepository : MongoDbCommandRepository<MediatrAppMongoDbContext, Customer, Guid>, ICustomerCommandRepository
    {

        public CustomerCommandRepository(IMongoDbContextProvider<MediatrAppMongoDbContext> contextProvider) : base(contextProvider)
        {
        }

    }
}
