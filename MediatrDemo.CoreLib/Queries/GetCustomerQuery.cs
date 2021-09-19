using MediatR;
using MediatrApp.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.CoreLib.Queries
{
    public record GetCustomerQuery():IRequest<List<Customer>>;
}
