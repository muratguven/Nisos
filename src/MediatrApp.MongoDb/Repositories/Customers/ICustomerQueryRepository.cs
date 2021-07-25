using MediatrApp.Domain.Customers;
using MediatrDemo.MongoDb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrApp.MongoDb.Repositories.Customers
{
    public interface ICustomerQueryRepository : IMongoDbQueryRepository<Guid,Customer>
    {

    }
}
