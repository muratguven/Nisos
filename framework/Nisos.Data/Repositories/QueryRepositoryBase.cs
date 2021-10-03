using Nisos.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nisos.Data.Repositories
{
    public abstract class QueryRepositoryBase<TEntity> : IQueryRepository<TEntity>
        where TEntity : class, IEntity
    {
        public abstract TEntity Find(Expression<Func<TEntity, bool>> predicate);

        public abstract Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);


        public abstract IQueryable<TEntity> GetAll();


        public abstract Task<IQueryable<TEntity>> GetAllAsync();


        public abstract List<TEntity> GetList();


        public abstract List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);


        public abstract Task<List<TEntity>> GetListAsync();


        public abstract Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);
        
    }


    public abstract class QueryRepositoryBase<TKey, TEntity> : QueryRepositoryBase<TEntity>, IQueryRepository<TKey, TEntity>
        where TEntity:class,IEntity<TKey>
    {
        public abstract TEntity Get(TKey id);

        public abstract Task<TEntity> GetAsync(TKey id);
        
    }
}
