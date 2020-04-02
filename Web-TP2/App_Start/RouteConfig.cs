using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web_TP2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Nouveaute",
                url: "film/nouveaute",
                defaults: new { controller = "Film", action = "Nouveaute" }
                );

            routes.MapRoute(
                name: "AjoutMaListe",
                url: "film/AjoutMaListe",
                defaults: new { controller = "Film", action = "AjoutMaListe"}
                );

            routes.MapRoute(
                name: "MaListe",
                url: "film/maListe",
                defaults: new { controller = "Film", action = "MaListe" }
                );

            routes.MapRoute(
                name: "FilmById",
                url: "film/{id}",
                defaults: new { controller = "Film", action = "Get", id = "1" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
