using Nisos.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nisos.Data.Repositories
{
    public interface IQueryRepository<TEntity> : IRepository
        where TEntity :class,IEntity
    {
        /// <summary>
        /// Get all data as async and queryable
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<TEntity>> GetAllAsync();
        /// <summary>
        /// Get all data as quaryable
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();
        /// <summary>
        /// Find a data using expression 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Find a data
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// Get list
        /// </summary>
        /// <returns></returns>
        List<TEntity> GetList();
        /// <summary>
        /// Get list using expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<TEntity> GetList(Expression<Func<TEntity,bool>> predicate);
        /// <summary>
        /// Get list as async
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync();
        /// <summary>
        /// Get list async using expression.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);

    }

    public interface IQueryRepository<TKey, TEntity> : IQueryRepository<TEntity>, IRepository<TKey, TEntity>
        where TEntity : class, IEntity<TKey>
    {
        /// <summary>
        /// Get a data with id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(TKey id);
        /// <summary>
        /// Get a data using id as async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(TKey id);

    }
}
