using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GlobalEventNepal.Domain.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
<<<<<<< HEAD
=======


>>>>>>> e5dabf91d2f1a4f47facbeaddab054328fc6aa54
    }
}
