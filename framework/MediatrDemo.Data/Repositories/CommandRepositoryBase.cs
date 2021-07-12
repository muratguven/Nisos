using MediatrDemo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.Data.Repositories
{
    public abstract class CommandRepositoryBase<TEntity> : ICommandRepository<TEntity>
        where TEntity : class, IEntity
    {
        public abstract void Delete(TEntity input);


        public abstract Task DeleteAsync(TEntity input);


        public abstract void Insert(TEntity input);


        public abstract Task InsertAsync(TEntity input);
        
    }

    public abstract class CommandRepositoryBase<TKey, TEntity> : CommandRepositoryBase<TEntity>, ICommandRepository<TKey, TEntity>
        where TEntity : class, IEntity<TKey>
    {
        public abstract void Delete(TKey id);


        public abstract Task DeleteAsync(TKey id);


        public abstract TEntity Update(TKey id, TEntity input);


        public abstract Task<TEntity> UpdateAsync(TKey id, TEntity input);
        
    }
}
