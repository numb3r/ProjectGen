using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalEventNepal.Domain.Abstract;
using GlobalEventNepal.Domain.Entities;

namespace GlobalEventNepal.Domain.Concrete
{
    public class EventUnitOfWork:IEventUnitOfWork
    {
        private readonly ObjectContext context;
        private readonly IRepository<Event> eventRepository;

        public EventUnitOfWork(IObjectContextAdapter iContextAdapter)
        {
            context = iContextAdapter.ObjectContext;
            eventRepository = new EFRepository<Event>(iContextAdapter);
        }

        public Event Create(Event entity)
        {
            entity.Id = Guid.NewGuid();
            eventRepository.Create(entity);
            context.SaveChanges();
            return entity;
        }

        public Event Update(Event update)
        {
            Event entity = eventRepository.GetById(update.Id);
            //if (entity == null)
                return null;

            
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

