using System;
using System.Linq;

namespace GlobalEventNepal.Domain
{
    /// <summary>
    /// interface for generic repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Create(TEntity entity);
        void Attach(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById<T>(T key);
        IQueryable<TEntity> GetAll();
        void SaveChanges();
    }
}
