using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CRMManagement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                         name: "EzSystem",
                         url: "{controller}/{action}/{id}",
                         defaults: new { controller = "Authentication", action = "Index", id = UrlParameter.Optional }
                     );

            routes.MapRoute(
                name: "EzUsers",
                url: "EzUsers/{controller}/{action}/{id}",
                defaults: new { controller = "Authentication", action = "Index", id = UrlParameter.Optional }
            );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "HumanResource",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Authentication", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Authentication", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
