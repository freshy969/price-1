using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartupAttribute(typeof(Web.Startup))]
namespace Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            HttpConfiguration httpConfig = new HttpConfiguration();
            WebApiConfig.Register(httpConfig);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureAuth(app);
            app.UseWebApi(httpConfig);
        }
    }
}
