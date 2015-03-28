using GlobalEventNepal.Domain.Entities;
using GlobalEventNepal.Domain.Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GlobalEventNepal.Domain.Services.Controllers
{
    public class ContactController : ApiController
    {
        private readonly IContactUnitOfWork contactUnitOfWork;

        public ContactController(IContactUnitOfWork contactUnitOfWork)
        {
            this.contactUnitOfWork = contactUnitOfWork;
        }

        public  IQueryable<Contact> Get()
        {
            return contactUnitOfWork.GetAll();
        }

        public  HttpResponseMessage Post(Contact entity)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            entity = contactUnitOfWork.Create(entity);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, entity);
            return response;
        }

        public  HttpResponseMessage Put(Guid key, Contact update)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            update = contactUnitOfWork.UpdateIfExistsElseInsert(update);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, update);
           
            return response;
        }

        public  void Delete(Guid key)
        {
            contactUnitOfWork.DeleteContact(key);
        }
    }
}
