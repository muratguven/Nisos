using MediatrDemo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.Data.Repositories
{
    public interface IRepository
    {

    }

    public interface IRepository<TKey, TEntity> : IRepository  
        where TEntity: IEntity<TKey>
    {

    }

}
