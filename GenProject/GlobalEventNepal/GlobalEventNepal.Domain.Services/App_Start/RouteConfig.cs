<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
=======
﻿using System.Web.Http;
>>>>>>> e5dabf91d2f1a4f47facbeaddab054328fc6aa54
using System.Web.Mvc;
using System.Web.Routing;

namespace GlobalEventNepal.Domain.Services
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

<<<<<<< HEAD
=======
            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

>>>>>>> e5dabf91d2f1a4f47facbeaddab054328fc6aa54
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}