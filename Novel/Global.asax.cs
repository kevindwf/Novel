using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Novel
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute("Category",
                "{category}/{index}",
                new { controller = "Home", action = "NovelList", index=UrlParameter.Optional },
                new { category= @"(\w)+"}
                );

            routes.MapRoute("Chapter",
                "Chapter/{chapterId}",
                new { controller = "Home", action = "Chapter" }
                );

            routes.MapRoute("Content",
                "Content/{chapterId}/{contentId}",
                new { controller = "Home", action = "Content" }
                );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}