using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //convention - based routing
            //routes.MapRoute(
            //    name: "MoviesByReleaseByDate",
            //    url: "movies/released/{year}/{month}",
            //    defaults: new {
            //        Controller = "Movies",
            //        Action = "ByReleaseDate"
            //    },
            //    //parameter constraints
            //    new {year = @"2015|2016", month=@"\d{2}"});

            //default routing
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
