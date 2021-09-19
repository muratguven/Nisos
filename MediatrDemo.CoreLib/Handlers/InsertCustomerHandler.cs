using MediatR;
using MediatrApp.Domain.Customers;
using MediatrApp.MongoDb.Test;
using MediatrDemo.CoreLib.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.CoreLib.Handlers
{
    public class InsertCustomerHandler : IRequestHandler<InsertCustomerCommand,Customer>
    {

        private readonly ITestMongoDb TestMongoDb;

        public InsertCustomerHandler(ITestMongoDb testMongoDb)
        {
            TestMongoDb = testMongoDb;
        }

        public async Task<Customer> Handle(InsertCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = new(request.Name, request.Surname, request.PlateNumber, request.PhoneNumber, request.Email);
            //TODO: Customer Create düzenlenecek!
            await TestMongoDb.CreateCustomerAsync(customer);
            
            return customer;
        }
    }
}
