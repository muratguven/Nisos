using MediatrApp.Domain.Customers;
using MongoDB.Driver;
using Nisos.MongoDb.Settings;
using System;
using System.Collections.Generic;
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
