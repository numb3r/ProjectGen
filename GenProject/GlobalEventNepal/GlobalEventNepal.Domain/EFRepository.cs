using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace GlobalEventNepal.Domain
{
    public abstract class EFRepository<TEntity, Context> : IRepository<TEntity> where TEntity : class where Context:GlobalEventNepalContext
    {
        private GlobalEventNepalContext context = new GlobalEventNepalContext();
        private IObjectSet<TEntity> _objectSet;
 
        public EFRepository()
        {
            throw new NotImplementedException();
        }
        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById<T>(T key)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
