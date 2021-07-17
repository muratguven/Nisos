using MediatrDemo.Data.Entities;
using MediatrDemo.Data.Repositories;
using MediatrDemo.MongoDb.Db;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.MongoDb.Repositories
{
    public class MongoDbCommandRepository<TMongoDbContext, TEntity, TKey> :
        CommandRepositoryBase<TEntity>,
        IMongoDbCommandRepository<TKey,TEntity>
        where TEntity : class, IEntity<TKey>
        where TMongoDbContext : IMongoDbContext
    {

        protected IMongoDbContext DbContext;
        protected IMongoCollection<TEntity> _collection;
        public MongoDbCommandRepository(IMongoDbContext dbContext)
        {
            DbContext = dbContext;
            _collection = DbContext.Collection<TEntity>();
        }

        public override void Delete(TEntity input)
        {
            _collection.DeleteOne(x => x.Id.Equals(input.Id));          
        }

        public void Delete(TKey id)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(TEntity input)
        {
           return _collection.DeleteOneAsync(x => x.Id.Equals(input.Id));
        }

        public Task DeleteAsync(TKey id)
        {
            return _collection.DeleteOneAsync(x => x.Id.Equals(id));
        }

        public override void Insert(TEntity input)
        {
            _collection.InsertOne(input);
        }

        public override Task InsertAsync(TEntity input)
        {
            return _collection.InsertOneAsync(input);
        }

        public TEntity Update(TKey id, TEntity input)
        {
            return _collection.FindOneAndReplace(f => f.Id.Equals(id), input);
        }

        public Task<TEntity> UpdateAsync(TKey id, TEntity input)
        {
            return _collection.FindOneAndReplaceAsync(x => x.Id.Equals(id), input);
        }
    }
}
