using MediatR;
using MediatrDemo.CoreLib.Commands;
using MediatrDemo.CoreLib.DataAccess;
using MediatrDemo.CoreLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.CoreLib.Handlers
{
    public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, PersonalModel>
    {
        private readonly IDemoDataAccess _demoDataAccess;

        public InsertPersonHandler(IDemoDataAccess demoDataAccess)
        {
            _demoDataAccess = demoDataAccess;
        }
        public Task<PersonalModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
        {
           return Task.FromResult(_demoDataAccess.Insert(request.FirstName, request.LastName));
        }
    }
}
