using MediatR;
using MediatrDemo.CoreLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.CoreLib.Commands
{
    public class InsertPersonCommand:IRequest<PersonalModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public InsertPersonCommand(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
