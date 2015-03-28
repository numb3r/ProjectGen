using GlobalEventNepal.Domain.Entities;
using GlobalEventNepal.Domain.Services.UnitOfWork;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace GlobalEventNepal.Domain.Services.App_Start
{
    public class DIConfig
    {
        public static void RegisterBindings(IKernel kernel)
        {
            // Binding for ObjectContext.
            kernel.Bind<IObjectContextAdapter>().To<GlobalEventNepalContext>();

            // Unit of Work bindings
            kernel.Bind<IContactUnitOfWork>().To<ContactUnitOfWork>();
            kernel.Bind<IEventUnitOfWork>().To<EventUnitOfWork>();

            // individual Entity bindings
            kernel.Bind<IRepository<Contact>>().To<EFRepository<Contact>>().InSingletonScope();
            kernel.Bind<IRepository<ContactAddress>>().To<EFRepository<ContactAddress>>().InSingletonScope();
            kernel.Bind<IRepository<ContactEmail>>().To<EFRepository<ContactEmail>>().InSingletonScope();
            kernel.Bind<IRepository<ContactPhone>>().To<EFRepository<ContactPhone>>().InSingletonScope();
            kernel.Bind<IRepository<Event>>().To<EFRepository<Event>>().InSingletonScope();
        }
    }
}