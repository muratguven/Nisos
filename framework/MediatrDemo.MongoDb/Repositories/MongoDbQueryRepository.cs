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

        protected  IMongoDbContextProvider<TMongoDbContext> _contextProvider;
        protected  IMongoCollection<TEntity> Collection { get; set; }

        public MongoDbQueryRepository(IMongoDbContextProvider<TMongoDbContext> contextProvider)
        {
            _contextProvider = contextProvider;
            Collection = contextProvider.GetDbContext().Collection<TEntity>();
        }


        public override TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Collection.Find(predicate).FirstOrDefault();            
        }

        public override Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Collection.Find(predicate).FirstOrDefaultAsync();
        }

        public override IQueryable<TEntity> GetAll()
        {
            return Collection.AsQueryable();
        }

        public override async Task<IQueryable<TEntity>> GetAllAsync()
        {

            var result = (await Collection.Find(_ => true).ToListAsync()) as IQueryable<TEntity>;
            return result;
        }

        public override List<TEntity> GetList()
        {
            return Collection.Find(_ => true).ToList();
        }

        public override List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return Collection.Find(predicate).ToList();
        }

        public override Task<List<TEntity>> GetListAsync()
        {
            return Collection.Find(_ => true).ToListAsync();
        }

        public override Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Collection.Find(predicate).ToListAsync();
        }
    }
}
