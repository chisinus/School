using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            //routes.Add(myRoute);

            //routes.MapRoute("", "X{controller}/{action}");        // with static prefix

            routes.MapRoute("ShopSchema2", "Shop/OldAction", new { controller = "Admin", action = "Index" });        // aliase

            routes.MapRoute("ShopSchema", "Shop/{action}", new { controller = "Home" });   

            //routes.MapRoute("MyRoute", "{controller}/{action}", new { controller = "Home", action = "Index" });   // This overwrites default route

            //routes.MapRoute("", "Public/{controller}/{action}", new { controller = "Home", action = "Index" });   // With static path

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",      // id is a custom variable
                //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                defaults: new { controller = "Home", action = "Index", id = "Default ID" }
            );
        }
    }
}
