using Ninject;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace GlobalEventNepal.Domain.Services.DependencyInjection
{
    public class NinjectScope : IDependencyScope
    {
        private readonly IResolutionRoot kernel;

        public NinjectScope(IResolutionRoot root)
        {
            kernel = root;
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void Dispose()
        {

        }
    }
}