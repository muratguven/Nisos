using MediatR;
using MediatrDemo.CoreLib.DataAccess;
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
    public class GetPersonListHandler : IRequestHandler<GetPeopleQuery, List<PersonalModel>>
    {
        IDemoDataAccess _data;

        public GetPersonListHandler(IDemoDataAccess data)
        {
            _data = data;
        }


        public Task<List<PersonalModel>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.GetPeople());
        }
    }
}
