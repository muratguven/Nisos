using MediatR;
using MediatrDemo.CoreLib.Commands;
using MediatrDemo.CoreLib.Models;
using MediatrDemo.CoreLib.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MediatrApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DemoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<DemoController>
        [HttpGet]
        public async Task<List<PersonalModel>> Get()
        {
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
            return await _mediator.Send(new InsertPersonCommand(input.FirstName, input.LastName));
        }

    
    }
}
