using MediatrApp.Domain.Customers;
using MediatrDemo.MongoDb.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrApp.MongoDb.Test
{
    public class TestMongoDb : ITestMongoDb
    {
        private IMongoDbSettings MongoDbSettings;
        private IMongoCollection<Customer> Customers;

        public TestMongoDb(IMongoDbSettings mongoDbSettings)
        {
            MongoDbSettings = mongoDbSettings;

            var client = new MongoClient("mongodb://admin:pass@localhost:27017");
            var database = client.GetDatabase(MongoDbSettings.DatabaseName);
            Customers = database.GetCollection<Customer>("Customers");
        }

        public async Task CreateCustomerAsync(Customer input)
        {
           input.Id = Guid.NewGuid();
           await Customers.InsertOneAsync(input);
        }

        public Task<List<Customer>> GelAllListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
