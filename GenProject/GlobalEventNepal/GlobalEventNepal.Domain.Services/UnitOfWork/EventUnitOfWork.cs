using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalEventNepal.Domain.Services.Extensions;
using GlobalEventNepal.Domain.Services.UnitOfWork;
using GlobalEventNepal.Domain.Entities;


namespace GlobalEventNepal.Domain.Services.UnitOfWork
{
    public class EventUnitOfWork : IEventUnitOfWork
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
            entity.CreatedDate = DateTime.Now;
            if (entity.Contact != null)
            {
                if(entity.Contact.Id == Guid.Empty)
                {
                    entity.Contact.SetIds(Guid.NewGuid());
                }
                else
                {
                    entity.Contact = null;
                }
            }
            eventRepository.Create(entity);
            context.SaveChanges();

            return entity;
        }

        public Event Update(Event update)
        {
            Event entity = eventRepository.GetById(update.Id);
            if (entity == null) return null;
                        
            entity.Category = update.Category;
            entity.UpdatedDate = DateTime.Now;
            entity.Location = update.Location;
            entity.Organization = update.Organization;
            entity.Price = update.Price;
            entity.Starts = update.Starts;
            entity.Ends = update.Ends;
            entity.Description = update.Description;
            entity.EventName = update.EventName;
            UpdateContacts(entity, update);

            context.SaveChanges();
            return entity;            
        }

        public void Delete(Guid id)
        {
            Event entity = eventRepository.GetById(id);
            if (entity == null) return;
            entity.IsDeleted = true;
            if (entity.Contact != null)
            {
                entity.Contact.IsDeleted = true;
            }

            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        private void UpdateContacts(Event currentEvent, Event updatedEvent)
        {
            if (updatedEvent != null && updatedEvent.Contact != null)
            {
                if (currentEvent.Contact == null)
                {
                    updatedEvent.Contact.SetIds(Guid.NewGuid());
                    currentEvent.Contact = updatedEvent.Contact;
                }
                else
                {
                    updatedEvent.Contact.SetIds(updatedEvent.Contact.Id);
                    List<object> objectList = new List<object>();

                    if (currentEvent.Contact == null)
                    {
                        currentEvent.Contact = updatedEvent.Contact;
                    }
                    else if (updatedEvent.Contact == null || currentEvent.Contact.Id != updatedEvent.Contact.Id)
                    {
                        objectList.Add(currentEvent.Contact);
                        currentEvent.Contact = updatedEvent.Contact;
                    }
                    else
                    {
                        currentEvent.Contact = currentEvent.Contact.UpdateContact(updatedEvent.Contact, objectList);
                    }

                    foreach (object obj in objectList)
                    {
                        context.DeleteObject(obj);
                    }
                }
            }
        }
    }
}

