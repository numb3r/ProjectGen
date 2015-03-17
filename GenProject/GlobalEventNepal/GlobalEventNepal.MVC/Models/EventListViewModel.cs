using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GlobalEventNepal.Domain.Entities;

namespace GlobalEventNepal.MVC.Models
{
    public class EventListViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public PagingInfo PagingInfo { get; set; }
        
    }
}