using MediatR;
using MediatrDemo.CoreLib.Models;
using MediatrDemo.CoreLib.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.CoreLib.Handlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonalModel>
    {
        private readonly IMediator _mediator;

        public GetPersonByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<PersonalModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {

            var results = await _mediator.Send(new GetPeopleQuery());

            var output = results.FirstOrDefault(x => x.Id == request.Id);
            return output;
        }
    }
}
