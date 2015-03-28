using GlobalEventNepal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GlobalEventNepal.Domain.Services.Extensions;

namespace GlobalEventNepal.Domain.Services.UnitOfWork
{
    public class ContactUnitOfWork : IContactUnitOfWork
    {
        private readonly ObjectContext context;
        private readonly IRepository<Contact> contactRepository;

        public ContactUnitOfWork(IObjectContextAdapter iContext)
        {
            context = iContext.ObjectContext;
            contactRepository = new EFRepository<Contact>(iContext);
        }
        public IQueryable<Contact> GeAll()
        {
            return contactRepository.GetAll().OfType<Contact>();
        }

        public Contact Create(Contact entity)
        {
            entity.SetIds(Guid.NewGuid());
            entity.CreatedDate = DateTime.Now;
            contactRepository.Create(entity);

            context.SaveChanges();
            return entity;
        }

        public Contact UpdateIfExistsElseInsert(Contact update)
        {
            Contact existingContact = contactRepository.GetById(update.Id);
            if (existingContact == null)
            {
                return Create(update);
            }
            else
            {
                update.SetIds(update.Id);
                update.UpdatedDate = DateTime.Now;
                SaveUpdatedContact(existingContact, update);
            }
            return update;
        }

        public void DeleteContact(Guid id)
        {
            Contact contact = contactRepository.GetById(id);
            if (contact == null) return;

            contact.IsDeleted = true;
            context.SaveChanges();
        }

        private void SaveUpdatedContact(Contact existing, Contact updated)
        {
            List<object> objectsToDelete = new List<object>();

            existing.UpdateContact(updated, objectsToDelete);
            existing.Source = updated.Source;
            existing.UpdatedDate = updated.UpdatedDate;

            context.SaveChanges();
            foreach (object obj in objectsToDelete.Where(o => o != null))
            {
                context.DeleteObject(obj);
            }
            context.SaveChanges();
        }
    }
}