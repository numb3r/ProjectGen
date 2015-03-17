using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlobalEventNepal.Domain.Abstract;
using GlobalEventNepal.Domain.Entities;
using GlobalEventNepal.Domain;

namespace GlobalEventNepal.MVC.Controllers
{
    public class AdminController : Controller
    {
        private IEventRepository repository;

        public AdminController(IEventRepository repo)
        {
            repository = repo;
        }
        // GET: /Event/

        public ActionResult Index()
        {
            return View(repository.Events);
        }

        public ActionResult Create(Event e)
        {

            if (ModelState.IsValid)
            {
                repository.AddEvent(e);
                repository.SaveEvent(e);         
                return RedirectToAction("Index");
            }
            return View(e);

        }

        public ViewResult Edit(Guid id)
        {
            Event e = repository.Events
            .FirstOrDefault(p => p.Id == id);

            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(Event e)
        {
            if (ModelState.IsValid)
            {
                repository.SaveEvent(e);
                return RedirectToAction("Index");
            }
            return View(e);
        }


        public ActionResult Delete(Event entity)
        {
            //repository.DeleteEvent(entity);
            return RedirectToAction("Index");
        }

    }
}
