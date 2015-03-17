using System.Linq;
using GlobalEventNepal.Domain.Entities;

namespace GlobalEventNepal.Domain.Abstract
{
    public interface IEventRepository
    {
        IQueryable<Event> Events { get; } 
        void SaveEvent(Event entity);
        void DeleteEvent(Event entity);
        void AddEvent(Event entity);
    }
}
