using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*

            //                          Convension Routing
            
            routes.MapRoute(
                name: "MoviesByReleaseDate", //should be unique and clear
                url: "Movies/released/{year}/{month}",//"{Movies}/{released}/{year}/{month}" wmomkn nsheel name w el url
                defaults: new  { Controller = "Movies",action = "ByReleaseDate"},
                constraints: new {year = "2015|2016", month = "\\d{2}"  }// aw ynf3 tkon kda@"\d{2}"

            );
            */
            //                                      enable attribuate routing
        
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
