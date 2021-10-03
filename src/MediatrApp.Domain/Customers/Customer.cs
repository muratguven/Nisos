using Nisos.MongoDb.Attributes;
using Nisos.MongoDb.Entities;
using System;

namespace MediatrApp.Domain.Customers
{
    [BsonCollection("Customers")]
    public class Customer : MongoDbEntity<Guid>
    {

        public Customer()
        {

        }

        public Customer(string name, string surname, string platenumber, string phonenumber, string email)
        {
            Name = name;
            Surname = surname;
            PlateNumber = platenumber;
            PhoneNumber = phonenumber;
            Email = email;
        }
   
        public string Name { get; protected set; }
        public string Surname { get; protected set; }

        public string PlateNumber { get; protected set; }

        public string PhoneNumber { get; protected set; }

        public string Email { get; protected set; }


        public void SetName(string name)
        {
            Name = name;
        }

        public void SetSurname(string surname)
        {
            Surname = surname;
        }
        public void SetPlateNumber(string plateNumber)
        {
            PlateNumber = plateNumber;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }
    }
}
