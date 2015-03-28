using GlobalEventNepal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlobalEventNepal.Domain.Services.UnitOfWork
{
    public interface IContactUnitOfWork
    {

        IQueryable<Contact> GetAll();
        Contact Create(Contact entity);
        Contact UpdateIfExistsElseInsert(Contact update);
        void DeleteContact(Guid id);
    }
}