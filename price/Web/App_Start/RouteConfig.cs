using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Item",
                url: "prop/{url}",
                defaults: new { controller = "Item", action = "Details" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{url}",
                defaults: new { controller = "Home", action = "Index", url = UrlParameter.Optional }
            );
        }
    }
}
