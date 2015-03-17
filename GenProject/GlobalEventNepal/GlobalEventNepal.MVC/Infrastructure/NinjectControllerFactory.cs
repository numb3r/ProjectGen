using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using GlobalEventNepal.Domain.Abstract;
using GlobalEventNepal.Domain.Concrete;
using GlobalEventNepal.Domain.Entities;
using Moq;
using Ninject;

namespace GlobalEventNepal.MVC.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext
        requestContext, Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            //Mock<IEventRepository> mock = new Mock<IEventRepository>();
            //mock.Setup(m => m.Events).Returns(new List<Event>
            //{
            //    new Event { EventName = "Test Event", Category = "Test Category", Description = "Test Description", Starts = new DateTime(), Ends = new DateTime(), Location = "test location", Organization = "test organization"},
            //    new Event{ EventName = "Test1 Event", Category = "Test1 Category", Description = "Test1 Description", Starts = new DateTime(), Ends = new DateTime(), Location = "test1 location", Organization = "test1 organization"},
            //    new Event{ EventName = "Test2 Event", Category = "Test2 Category", Description = "Test2 Description", Starts = new DateTime(), Ends = new DateTime(), Location = "test2 location", Organization = "test2 organization"},
            //}.AsQueryable());

            //ninjectKernel.Bind<IEventRepository>().ToConstant(mock.Object);
            ninjectKernel.Bind<IEventRepository>().To<EventRepository>();
        }
    }
}