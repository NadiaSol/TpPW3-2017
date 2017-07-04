using System.Web.Mvc;
using System.Web.Routing;

namespace Tp_Cines_
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Inicio", id = UrlParameter.Optional }
            );
            routes.MapRoute(
            name: "Reservas",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Peliculas", action = "Reservas", id = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "Login",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Home Administrador",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Administracion", action = "Inicio", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Peliculas",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Administracion", action = "Peliculas", id = UrlParameter.Optional }
            );
            routes.MapRoute(
            name: "Sedes",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Administracion", action = "Sedes", id = UrlParameter.Optional }
        );

            routes.MapRoute(
            name: "Crear Sede",
            url: "{controller}/{action}/",
            defaults: new { controller = "Administracion", action = "CrearSede"}
            );
            routes.MapRoute(
            name: "Editar Sede",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Administracion", action = "EditarSede"}
            );

            routes.MapRoute(
                name: "Carteleras",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Administracion", action = "Carteleras" }
            );
                routes.MapRoute(
                name: "Crear Cartelera",
                url: "{controller}/{action}",
                defaults: new { controller = "Administracion", action = "CrearCartelera"}
                );
            routes.MapRoute(
            name: "Editar Cartelera",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Administracion", action = "EditarCartelera" }
            );
            routes.MapRoute(
                name: "Reportes",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Administracion", action = "Reportes", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Versiones",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Peliculas", action = "Versiones", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Seleccionado",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Peliculas", action = "Seleccionado", id = UrlParameter.Optional }
            );
          

        }
    }
}