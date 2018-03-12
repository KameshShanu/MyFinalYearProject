using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyVehicleTrackingSystem.Wings
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
                namespaces: new string[] { "MyVehicleTrackingSystem.Wings.Controllers" });

            //routes.MapRoute(
            //  "Api_V1",
            //  "Api/{controller}/{action}/{id}",
            //  new { controller = "Service", action = "Get", id = UrlParameter.Optional },
            //  new string[] { "MyVehicleTrackingSystem.Wings.Areas.Api.Controllers" }).DataTokens["UseNamespaceFallback"] = false;
        }
    }
}
