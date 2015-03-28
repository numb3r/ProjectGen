using GlobalEventNepal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlobalEventNepal.Domain.Services.UnitOfWork
{
    public interface IContactUnitOfWork
    {
<<<<<<< HEAD
        IQueryable<Contact> GeAll();
=======
        IQueryable<Contact> GetAll();
>>>>>>> e5dabf91d2f1a4f47facbeaddab054328fc6aa54
        Contact Create(Contact entity);
        Contact UpdateIfExistsElseInsert(Contact update);
        void DeleteContact(Guid id);
    }
}