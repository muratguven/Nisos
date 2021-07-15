using MediatrDemo.Data.Entities;
using MediatrDemo.Data.Repositories;
using MediatrDemo.MongoDb.Db;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.MongoDb.Repositories
{
    public class MongoDbQueryRepository<TMongoDbContext, TEntity>
        : QueryRepositoryBase<TEntity>,
        IMongoDbQueryRepository<TEntity>
        where TMongoDbContext : IMongoDbContext
        where TEntity : class, IEntity

    {

        private readonly IMongoCollection<TEntity> _collection;

        public MongoDbQueryRepository()
        {
           
        }


        public override TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            
            throw new NotImplementedException();
        }

        public override Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<IQueryable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override List<TEntity> GetList()
        {
            throw new NotImplementedException();
        }

        public override List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override Task<List<TEntity>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
