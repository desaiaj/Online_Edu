using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineEducation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //   name: "Home",
            //   url: "s",
            //   defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //   name: "UsersList",
            //   url: "UsersList",
            //   defaults: new { Areas = "Admin", controller = "Deshbord", action = "Index" },
            //   namespaces: new[] { "OnlineEducation.Controllers" }
            //);



            routes.MapRoute(
               name: "Registration",
               url: "Accounts",
               defaults: new { controller = "Registration", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
             name: "Homes",
             url: "",
             defaults: new { Areas = "", controller = "Homes", action = "Index", id = UrlParameter.Optional }
             //namespaces: new[] { "OnlineEducation.Areas.Users.Controllers" }
             );
            routes.MapRoute(
              name: "Homes1",
              url: "Homes/*",
              defaults: new { Areas = "", controller = "Homes", action = "Index", id = UrlParameter.Optional }
              //namespaces: new[] { "OnlineEducation.Controllers" }
              );

            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { Areas = "Admin", controller = "Home", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "OnlineEducation.Areas.Users.Controllers" }
            );      
        }
    }
}
