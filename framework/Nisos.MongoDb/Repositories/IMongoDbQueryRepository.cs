using Nisos.Data.Entities;
using Nisos.Data.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nisos.MongoDb.Repositories
{
    public interface IMongoDbQueryRepository<TEntity> : IQueryRepository<TEntity> 
        where TEntity:class, IEntity
    {
      

    }


    public interface IMongoDbQueryRepository<TKey, TEntity> : IMongoDbQueryRepository<TEntity>, IQueryRepository<TKey,TEntity>
        where TEntity:class, IEntity<TKey>
    {

    }
}
