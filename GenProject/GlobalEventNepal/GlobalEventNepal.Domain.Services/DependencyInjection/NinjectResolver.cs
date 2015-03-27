using Ninject;
using System.Web.Http.Dependencies;

namespace GlobalEventNepal.Domain.Services.DependencyInjection
{
    public class NinjectResolver  : NinjectScope, IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver(IKernel iKernel) : base(iKernel)
        {
            kernel = iKernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectScope(kernel.BeginBlock());
        }

    }
}