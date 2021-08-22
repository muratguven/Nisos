using MediatrApp.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrApp.MongoDb.Test
{
    public interface ITestMongoDb
    {
        Task CreateCustomerAsync(Customer input);
        Task<List<Customer>> GelAllListAsync();
    }
}
