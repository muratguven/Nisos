using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.Data.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        bool SaveChanges();
    }
}
