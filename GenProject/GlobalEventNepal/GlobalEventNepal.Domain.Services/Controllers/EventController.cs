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
    public class EventController : ApiController
    {
        private readonly IRepository<Event> eventRepository;
        private readonly IEventUnitOfWork eventUnitOfWork;

        public EventController(IRepository<Event> iEventRepository, IEventUnitOfWork iEventUnitOfWork)
        {
            eventRepository = iEventRepository;
            eventUnitOfWork = iEventUnitOfWork;
        }

        public override IQueryable<Event> Get()
        {
            return eventRepository.GetAll();
        }

        public override HttpResponseMessage Post(Event entity)
        {
            if (!ModelState.IsValid) return new HttpResponseMessage(HttpStatusCode.BadRequest);

            Event created = eventUnitOfWork.Create(entity);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, created);
          
            return response;
        }

        public override HttpResponseMessage Put(Guid key, Event update)
        {
            if (!ModelState.IsValid) 
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            Event updated = eventUnitOfWork.Update(update);

            if (updated == null) 
                return Post(update);

            return Request.CreateResponse(HttpStatusCode.OK, updated);
        }

        //void returns an empty 204 status (No Content)
        public override void Delete(Guid key)
        {
            eventUnitOfWork.Delete(key);
        }
    }
}
