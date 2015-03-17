using System;
using System.Collections;
using System.Linq;
using System.Web.Mvc;
using GlobalEventNepal.Domain.Abstract;
using GlobalEventNepal.MVC.Models;

namespace GlobalEventNepal.MVC.Controllers
{
    public class HomeController : Controller
    {
       private IEventRepository repository;
        public int PageSize = 4;
        
        public HomeController(IEventRepository eventRepository)
        {
            this.repository = eventRepository;
        }

        public ViewResult Index()
        {
            EventListViewModel model = ListOfEvents();
            return View(model);
        }

        private EventListViewModel ListOfEvents(int page = 1)
        {
            EventListViewModel model = new EventListViewModel
            {
                Events = repository.Events
                .Where(p => p.Starts >= DateTime.Today)
                .OrderBy(p => p.Starts)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Events.Count()
                }
            };
            return model;
        }
    }
}
