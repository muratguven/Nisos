using MediatR;
using MediatrApp.Domain.Customers;
using MediatrApp.MongoDb.Repositories.Customers;
using MediatrApp.MongoDb.Test;
using MediatrDemo.CoreLib.Commands;
using MediatrDemo.CoreLib.Models;
using MediatrDemo.CoreLib.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MediatrApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IMediator _mediator;

        private ICustomerQueryRepository _customerQueryRepository;
        private ICustomerCommandRepository _customerCommandRepository;
        private ITestMongoDb TestMongoDb;

        public DemoController(
            IMediator mediator, 
            ICustomerQueryRepository customerQueryRepository, 
            ICustomerCommandRepository customerCommandRepository, 
            ITestMongoDb testMongoDb)
        {
            _mediator = mediator;
            _customerQueryRepository = customerQueryRepository;
            _customerCommandRepository = customerCommandRepository;
            TestMongoDb = testMongoDb;
        }

        // GET: api/<DemoController>
        [HttpGet]
        public async Task<List<PersonalModel>> Get()
        {
            var t =  _customerQueryRepository.GetList();
            return await _mediator.Send(new GetPeopleQuery());
        }

        // GET api/<DemoController>/5
        [HttpGet("{id}")]
        public async Task<PersonalModel> Get(int id)
        {
            return await _mediator.Send(new GetPersonByIdQuery(id));            
        }

        // POST api/<DemoController>
        [HttpPost]
        public async Task<PersonalModel> Post([FromBody] PersonalModel input)
        {
            Customer customer = new("Test", "Surname", "34BDC778", "5545637933", "murat@email.com");
            await _customerCommandRepository.InsertAsync(customer);
            //await TestMongoDb.CreateCustomerAsync(customer);

            return await _mediator.Send(new InsertPersonCommand(input.FirstName, input.LastName));
        }

    
    }
}
