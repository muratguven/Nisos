using MediatrDemo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrApp.Domain.Customers
{
    public class Customer : Entity<Guid>
    {
        public string Name { get; protected set; }
        public string Surname { get; protected set; }

        public string PlateNumber { get; protected set; }


    }
}
