using MediatR;
using MediatrDemo.CoreLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.CoreLib.Queries
{
    public record GetPersonByIdQuery(int Id):IRequest<PersonalModel>;

    //public class GetPersonByIdQuery : IRequest<PersonalModel>
    //{
    //    public int Id { get; set; }

    //    public GetPersonByIdQuery(int id)
    //    {
    //        this.Id = id;
    //    }

    //}
}
