using MediatrApp.Domain.Customers;
using MediatrApp.MongoDb.Db;
using Nisos.MongoDb.Db;
using Nisos.MongoDb.Repositories;
using System;
using System.Threading.Tasks;

namespace MediatrApp.MongoDb.Repositories.Customers
{
    public class CustomerQueryRepository : MongoDbQueryRepository<MediatrAppMongoDbContext, Customer>, ICustomerQueryRepository
    {
        public CustomerQueryRepository(IMongoDbContextProvider<MediatrAppMongoDbContext> contextProvider) : base(contextProvider)
        {
        }

        public Customer Get(Guid id)
        {
            return base.Find(z => z.Id == id);
        }

        public async Task<Customer> GetAsync(Guid id)
        {
            return await base.FindAsync(x => x.Id == id);
        }
    }
}
