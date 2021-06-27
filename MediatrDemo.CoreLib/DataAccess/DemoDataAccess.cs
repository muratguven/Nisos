using MediatrDemo.CoreLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.CoreLib.DataAccess
{
    public class DemoDataAccess : IDemoDataAccess
    {
        List<PersonalModel> people = new();

        public DemoDataAccess()
        {
            people.Add(new PersonalModel { Id = 1, FirstName = "Murat", LastName = "Güven" });
            people.Add(new PersonalModel { Id = 2, FirstName = "Ebru", LastName = "Güven" });
            people.Add(new PersonalModel { Id = 3, FirstName = "Nisan", LastName = "Güven" });
        }

        public List<PersonalModel> GetPeople()
        {
            return people;
        }

        public PersonalModel Insert(string firstName, string lastName)
        {
            PersonalModel p = new() { FirstName = firstName, LastName = lastName };
            p.Id = people.Max(x => x.Id) + 1;
            people.Add(p);
            return p;
        }
    }


}
