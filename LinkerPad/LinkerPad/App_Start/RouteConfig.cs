using System.Web.Mvc;
using System.Web.Routing;

namespace LinkerPad
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Report",
                url: "v1/report/{projectId}/{reportDate}",
                defaults: new { controller = "Report", action = "CreatePdfReport" }
            );
            routes.MapRoute(
                name: "BasicRoute",
                url: "v1/{controller}/{action}",
                defaults: new { controller = "WidgetPanel", action = "Home" }
            );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "WidgetPanel", action = "Home" }
            );

            routes.MapRoute(
                name: "Error",
                url: "{*url}",
                defaults: new { controller = "WidgetPanel", action = "PanelErrorPage", siteStatus = 0 }
            );
        }
    }
}
