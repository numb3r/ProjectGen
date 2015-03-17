using System;
using System.Collections.ObjectModel;
using System.Linq;
using GlobalEventNepal.Domain.Abstract;
using GlobalEventNepal.Domain.Entities;
using System.Data.Entity; 

namespace GlobalEventNepal.Domain.Concrete
{
    public class EventRepository : IEventRepository
    {
        private GlobalEventNepalContext context = new GlobalEventNepalContext();
        public IQueryable<Event> Events
        {
            get { return context.Events ; }
        }

        public void SaveEvent(Event entity)
        {
            //Create
            if (entity == null)
            {
                entity.Id = new Guid();
                context.Events.Add(entity);
            }//Edit
            else
            {
                FindEvent(entity);
            }
            context.SaveChanges();
        }

        private void FindEvent(Event entity)
        {
            Event eventEntry = context.Events.Find(entity.Id);
            if (eventEntry != null)
            {
                eventEntry.EventName = entity.EventName;
                eventEntry.Location = entity.Location;
                eventEntry.Organization = entity.Organization;
                eventEntry.Description = entity.Description;
                eventEntry.Starts = entity.Starts;
                eventEntry.Ends = entity.Ends;
                eventEntry.Category = entity.Category;
                eventEntry.Price = entity.Price;
                eventEntry.Contacts = new Collection<Contact>();
            }
        }


        public void DeleteEvent(Event entity)
        {
            bool oldValidateOnSaveEnabled = context.Configuration.ValidateOnSaveEnabled;

            try
            {
                context.Configuration.ValidateOnSaveEnabled = false;

                entity = new Event { Id  = entity.Id};

                context.Events.Attach(entity);
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
            finally
            {
                context.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled ;
            }
            

        }



        public void AddEvent(Event entity)
        {
            entity.Id = Guid.NewGuid();
            context.Events.Add(entity);
            
            context.SaveChanges();
        }
    }
}
