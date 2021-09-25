using MediatR;
using MediatrApp.Domain.Customers;
using MediatrDemo.CoreLib.Commands;
using MediatrDemo.CoreLib.Models;
using MediatrDemo.CoreLib.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatrApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<CustomerModel>> Get()
        {
            return await _mediator.Send(new GetCustomerQuery());
        }

        [HttpPost]
        public async Task<Customer> Post([FromBody] CustomerModel customer)
        {
           return await _mediator.Send(new InsertCustomerCommand(customer.Name, customer.Surname, customer.PlateNumber, customer.PhoneNumber, customer.Email));
        }
    }
}
