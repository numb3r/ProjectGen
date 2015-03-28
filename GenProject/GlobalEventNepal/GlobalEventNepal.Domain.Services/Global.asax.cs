<<<<<<< HEAD
﻿using System;
=======
﻿using GlobalEventNepal.Domain.Services.App_Start;
using GlobalEventNepal.Domain.Services.DependencyInjection;
using Ninject;
using System;
>>>>>>> e5dabf91d2f1a4f47facbeaddab054328fc6aa54
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace GlobalEventNepal.Domain.Services
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
<<<<<<< HEAD
            AreaRegistration.RegisterAllAreas();

=======
            IKernel kernel = new StandardKernel();
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);

            AreaRegistration.RegisterAllAreas();
            DIConfig.RegisterBindings(kernel);
>>>>>>> e5dabf91d2f1a4f47facbeaddab054328fc6aa54
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}