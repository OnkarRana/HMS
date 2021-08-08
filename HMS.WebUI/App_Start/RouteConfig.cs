using System.Web.Mvc;
using System.Web.Routing;

namespace HMS.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "DashBoard", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Leads",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Leads", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
