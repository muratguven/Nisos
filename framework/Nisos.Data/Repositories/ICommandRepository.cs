using Nisos.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nisos.Data.Repositories
{
    public interface ICommandRepository<TEntity> : IRepository
        where TEntity:class, IEntity
    {
        /// <summary>
        /// Create a row
        /// </summary>
        /// <param name="input"></param>
        void Insert(TEntity input);
        /// <summary>
        /// Create a row as async
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task InsertAsync(TEntity input);
        /// <summary>
        /// Delete a row
        /// </summary>
        /// <param name="input"></param>
        void Delete(TEntity input);
        /// <summary>
        /// Delete a row as async
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteAsync(TEntity input);

    }


    public  interface ICommandRepository<TKey,TEntity> : ICommandRepository<TEntity>, IRepository<TKey, TEntity>
     where TEntity: class, IEntity<TKey>
    {
        /// <summary>
        /// Update a row
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        TEntity Update(TKey id, TEntity input);
        /// <summary>
        /// Update a row as async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TKey id, TEntity input);
        /// <summary>
        /// Delete a row with key
        /// </summary>
        /// <param name="id"></param>
        void Delete(TKey id);
        /// <summary>
        /// Delete a row with key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(TKey id);

    }
}
