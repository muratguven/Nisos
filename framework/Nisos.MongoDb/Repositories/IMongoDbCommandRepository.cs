using Nisos.Data.Entities;
using Nisos.Data.Repositories;

namespace Nisos.MongoDb.Repositories
{
    public interface IMongoDbCommandRepository<TEntity> : ICommandRepository<TEntity>
        where TEntity:class,IEntity
    {
    }

    public interface IMongoDbCommandRepository<TKey, TEntity> : IMongoDbCommandRepository<TEntity>, ICommandRepository<TKey, TEntity>
    where TEntity:class,IEntity<TKey>
    {

    }
}
