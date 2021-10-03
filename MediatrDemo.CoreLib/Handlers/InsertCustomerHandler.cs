using MediatR;
using MediatrApp.Domain.Customers;
using MediatrApp.MongoDb.Repositories.Customers;
using MediatrDemo.CoreLib.Commands;
using Nisos.Redis.Cache;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.CoreLib.Handlers
{
    public class InsertCustomerHandler : IRequestHandler<InsertCustomerCommand,Customer>
    {

        private ICustomerCommandRepository CustomerCommandRepository;
        private readonly ICacheProvider Cache;

        public InsertCustomerHandler(ICustomerCommandRepository customerCommandRepository, ICacheProvider cache)
        {
            CustomerCommandRepository = customerCommandRepository;
            Cache = cache;
        }

        public async Task<Customer> Handle(InsertCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = new(request.Name, request.Surname, request.PlateNumber, request.PhoneNumber, request.Email);
            //TODO: Customer Create düzenlenecek!
            await CustomerCommandRepository.InsertAsync(customer);
            // Clear to Cache
            await Cache.RemoveAsync("customers");
            return customer;
        }
    }
}
