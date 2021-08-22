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

        protected IMongoDbContextProvider<TMongoDbContext> _contextProvider;
        protected IMongoCollection<TEntity> Collection;
        public MongoDbCommandRepository(IMongoDbContextProvider<TMongoDbContext> contextProvider)
        {

            _contextProvider = contextProvider;
            Collection = contextProvider.GetDbContext().Collection<TEntity>();
        }

        public override void Delete(TEntity input)
        {
            Collection.DeleteOne(x => x.Id.Equals(input.Id));          
        }

        public void Delete(TKey id)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(TEntity input)
        {
           return Collection.DeleteOneAsync(x => x.Id.Equals(input.Id));
        }

        public Task DeleteAsync(TKey id)
        {
            return Collection.DeleteOneAsync(x => x.Id.Equals(id));
        }

        public override void Insert(TEntity input)
        {
            Collection.InsertOne(input);
        }

        public override Task InsertAsync(TEntity input)
        {
            return Collection.InsertOneAsync(input);
        }

        public TEntity Update(TKey id, TEntity input)
        {
            return Collection.FindOneAndReplace(f => f.Id.Equals(id), input);
        }

        public Task<TEntity> UpdateAsync(TKey id, TEntity input)
        {
            return Collection.FindOneAndReplaceAsync(x => x.Id.Equals(id), input);
        }
    }
}
