using MediatrApp.Domain.Customers;
using MediatrApp.MongoDb.Db;
using MediatrDemo.MongoDb.Db;
using MediatrDemo.MongoDb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrApp.MongoDb.Repositories.Customers
{
    public class CustomerQueryRepository : MongoDbQueryRepository<MediatrAppMongoDbContext, Customer>, ICustomerQueryRepository
    {
        public CustomerQueryRepository(IMongoDbContext dbContext) : base(dbContext)
        {

        }

        public Customer Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
