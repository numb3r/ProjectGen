using System;
﻿using GlobalEventNepal.Domain.Services.App_Start;
using GlobalEventNepal.Domain.Services.DependencyInjection;
using Ninject;
using System;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Routing;
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

            AreaRegistration.RegisterAllAreas();
            IKernel kernel = new StandardKernel();
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);

            AreaRegistration.RegisterAllAreas();
            DIConfig.RegisterBindings(kernel);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}