using MediatR;
using MediatrDemo.CoreLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.CoreLib.Queries
{
    public record GetPeopleQuery():IRequest<List<PersonalModel>>;

    // Record tipi değiştirilemez read only bir yapı sunar
    // Class tipinde kullanmak istediğimizde aşağıdaki gibi kullanabiliriz.
    //public class GetPeopleQuery : IRequest<List<PersonalModel>> { }
    
}
