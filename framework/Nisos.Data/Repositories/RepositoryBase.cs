using Nisos.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nisos.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : 
        ICommandRepository<TEntity>, 
        IQueryRepository<TEntity> 
        where TEntity:class,IEntity
    {
        public void Delete(TEntity input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity input)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetList()
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity input)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(TEntity input)
        {
            throw new NotImplementedException();
        }
    }


    public abstract class RepositoryBase<TKey, TEntity> : 
        RepositoryBase<TEntity>, 
        ICommandRepository<TKey, TEntity>, 
        IQueryRepository<TKey, TEntity> 
        where TEntity : class, IEntity<TKey>
    {
        public void Delete(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TKey id, TEntity input)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TKey id, TEntity input)
        {
            throw new NotImplementedException();
        }
    }

}
