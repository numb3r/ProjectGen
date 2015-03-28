using System;
using GlobalEventNepal.Domain.Entities;

namespace GlobalEventNepal.Domain.Services.UnitOfWork
{
    public interface IEventUnitOfWork: IDisposable
    {
        Event Create(Event entity);
        Event Update(Event update);
        void Delete(Guid id);
    }
}
