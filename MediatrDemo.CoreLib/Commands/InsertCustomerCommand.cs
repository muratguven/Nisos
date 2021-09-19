using MediatR;
using MediatrApp.Domain.Customers;

namespace MediatrDemo.CoreLib.Commands
{
    public class InsertCustomerCommand : IRequest<Customer>
    {


        public InsertCustomerCommand(string name, string surname, string plateNumber, string phoneNumber, string email)
        {
            Name = name;
            Surname = surname;
            PlateNumber = plateNumber;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public string Name { get; set; }
        public string Surname { get;  set; }

        public string PlateNumber { get;  set; }

        public string PhoneNumber { get;  set; }

        public string Email { get;  set; }


    }
}
