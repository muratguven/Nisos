using MediatrDemo.Data.Entities;
using MediatrDemo.Data.Repositories;
using MediatrDemo.MongoDb.Db;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MediatrDemo.MongoDb.Repositories
{
    public class MongoDbQueryRepository<TMongoDbContext, TEntity>
        : QueryRepositoryBase<TEntity>,
        IMongoDbQueryRepository<TEntity>
        where TMongoDbContext : IMongoDbContext
        where TEntity : class, IEntity

    {

        protected readonly IMongoDbContextProvider<TMongoDbContext> _contextProvider;
        protected readonly IMongoCollection<TEntity> _collection;

        public MongoDbQueryRepository(IMongoDbContextProvider<TMongoDbContext> contextProvider)
        {
            _contextProvider = contextProvider;
            _collection = contextProvider.GetDbContext().Collection<TEntity>();
        }


        public override TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.Find(predicate).FirstOrDefault();            
        }

        public override Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.Find(predicate).FirstOrDefaultAsync();
        }

        public override IQueryable<TEntity> GetAll()
        {
            return _collection.AsQueryable();
        }

        public override async Task<IQueryable<TEntity>> GetAllAsync()
        {

            return (await _collection.Find(_ => true).ToListAsync()) as IQueryable<TEntity>;
        }

        public override List<TEntity> GetList()
        {
            return _collection.Find(_ => true).ToList();
        }

        public override List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.Find(predicate).ToList();
        }

        public override Task<List<TEntity>> GetListAsync()
        {
            return _collection.Find(_ => true).ToListAsync();
        }

        public override Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.Find(predicate).ToListAsync();
        }
    }
}
