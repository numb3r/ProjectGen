using System;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace GlobalEventNepal.Domain
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields 

        private readonly ObjectContext context;
        private string _entitySetName;

        public string EntitySetName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_entitySetName))
                {
                    ObjectSet<TEntity> set = context.CreateObjectSet<TEntity>();
                    _entitySetName = set.Context.DefaultContainerName + "." + set.EntitySet.Name;
                }
                return _entitySetName;
            }
        }

        private string _keyPropertyName;

        public string KeyPropertyName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_keyPropertyName))
                {
                    ObjectSet<TEntity> set = GetObjectSet();
                    _keyPropertyName = set.EntitySet.ElementType.KeyMembers[0].ToString();
                }
                return _keyPropertyName;
            }
        }
        #endregion End Fields

        public EFRepository(IObjectContextAdapter contextAdapter)
        {
            context = contextAdapter.ObjectContext;
        }

        #region Public Methods
        
        /// <summary>
        /// Adds an entity to the Context
        /// </summary>
        /// <param name="entity"></param>
        public void Create(TEntity entity)
        {
            ObjectSet<TEntity> set = GetObjectSet();
            set.AddObject(entity);
        }

        /// <summary>
        /// Attaches an unattached entity to an context
        /// </summary>
        /// <param name="entity"></param>
        public void Attach(TEntity entity)
        {
            ObjectStateEntry entry = GetObjectStateEntry(entity);
            if (entry == null || entry.State == EntityState.Detached)
            {
                context.AttachTo(EntitySetName, entity);
            }

        }

        /// <summary>
        /// Removes an entity from the context
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            ObjectSet<TEntity> set = GetObjectSet();
            Attach(entity);
            set.DeleteObject(entity);
        }

        /// <summary>
        /// Retrieves a Tentity by its T key
        /// </summary>
        /// <typeparam name="T">Generic Type Key</typeparam>
        /// <param name="key">Key value to retrieve the TEntity by</param>
        /// <see cref="http://stackoverflow.com/questions/3328325/how-to-get-objectsets-entiy-key-name"/>
        /// <returns></returns>
        public TEntity GetById<T>(T key)
        {
            EntityKey entityKey = new EntityKey(EntitySetName, new[] {new EntityKeyMember(KeyPropertyName, key)});
            object entity;
            context.TryGetObjectByKey(entityKey, out entity);
            return (TEntity) entity;
        }

        /// <summary>
        /// Retrieves all Tentity 
        /// </summary>
        /// <returns>IQueryable of type TEntity</returns>
        public IQueryable<TEntity> GetAll()
        {
            ObjectSet<TEntity> set = GetObjectSet();
            return set.AsQueryable();
        }

        /// <summary>
        /// Saves any pending changes to the context
        /// </summary>
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        #endregion End Public Methods

        #region Private Methods
        
        private ObjectSet<TEntity> GetObjectSet()
        {
            return context.CreateObjectSet<TEntity>();
        } 

        private ObjectStateEntry GetObjectStateEntry(TEntity entity)
        {
            ObjectStateEntry entry = null;
            context.ObjectStateManager.TryGetObjectStateEntry(
                context.CreateEntityKey(EntitySetName,entity), out entry);
            return entry;
        }
        
        #endregion End Private Methods
    }
}
