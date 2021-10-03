using MediatrApp.Domain.Customers;
using Nisos.MongoDb.Repositories;
using System;

namespace MediatrApp.MongoDb.Repositories.Customers
{
    public interface ICustomerQueryRepository : IMongoDbQueryRepository<Guid,Customer>
    {

    }
}
