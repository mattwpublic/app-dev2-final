using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CardSort.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // all cards from all categories
            routes.MapRoute(null, "", new
            {
                controller = "Card",
                action = "List",
                category = (string)null,
                page = 1
            });

            // /Page2 - specific page, all categories 
            routes.MapRoute(null, "Page{page}", new
            {
                controller = "Card",
                action = "List",
                category = (string)null
            },
            new { page = @"\d+" });

            // /Creature - first page in a specific category
            routes.MapRoute(null, "{category}", new
            {
                controller = "Card",
                action = "List",
                page = 1
            });

            // /Creature/Page2 - specific category, specific page
            routes.MapRoute(null, "{category}/Page{page}", new
            {
                controller = "Card",
                Action = "List"
            },
            new { page = @"\d+" });

            /*// newer one
            routes.MapRoute(name: null,
                url: "Page{page}",
                defaults: new
                {
                    Controller = "Card",
                    action = "List"
                });

            //Default route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Card", action = "List", id = UrlParameter.Optional }
            );*/

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
