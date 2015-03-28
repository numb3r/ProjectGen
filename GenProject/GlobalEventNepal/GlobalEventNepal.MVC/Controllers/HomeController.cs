using System;
using System.Collections;
using System.Linq;
using System.Web.Mvc;
using GlobalEventNepal.Domain;
using GlobalEventNepal.Domain.Entities;
using GlobalEventNepal.MVC.Models;

namespace GlobalEventNepal.MVC.Controllers
{
    public class HomeController : Controller
    {
       private IRepository<Event> eventRepository;
        public int PageSize = 4;
        
        public HomeController(IRepository<Event> iEventRepository)
        {
            eventRepository = iEventRepository;
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
                Events = eventRepository.GetAll()
                .Where(p => p.Starts >= DateTime.Today)
                .OrderBy(p => p.Starts)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = eventRepository.GetAll().Count()
                }
            };
            return model;
        }
    }
}
