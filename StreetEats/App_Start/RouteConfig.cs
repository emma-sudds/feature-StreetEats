﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StreetEats
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Weddings",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Wedding", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "About",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "Gallery",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Gallery", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "News",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "News", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "Privacy",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Privacy", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}
