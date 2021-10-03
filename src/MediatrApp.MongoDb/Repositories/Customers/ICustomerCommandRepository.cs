using MediatrApp.Domain.Customers;
using Nisos.MongoDb.Repositories;

namespace MediatrApp.MongoDb.Repositories.Customers
{
    public interface ICustomerCommandRepository : IMongoDbCommandRepository<Customer>
    {

    }
}
