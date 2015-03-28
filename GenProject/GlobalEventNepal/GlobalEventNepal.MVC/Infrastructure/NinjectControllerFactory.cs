using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using GlobalEventNepal.Domain;
using GlobalEventNepal.Domain.Entities;
using Moq;
using Ninject;
using GlobalEventNepal.Domain.Services.UnitOfWork;

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
            //Binding the ObjectContext
            ninjectKernel.Bind<IObjectContextAdapter>().To<GlobalEventNepalContext>();

            //Unit of Work Binding
            ninjectKernel.Bind<IEventUnitOfWork>().To<EventUnitOfWork>();
        }
    }
}