using MediatrDemo.CoreLib.Models;
using System.Collections.Generic;

namespace MediatrDemo.CoreLib.DataAccess
{
    public interface IDemoDataAccess
    {
        List<PersonalModel> GetPeople();
        PersonalModel Insert(string firstName, string lastName);
    }
}