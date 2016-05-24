using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Unity.WebApi;
using Web.App_Start;
using Web.App_Start.WebApi;

namespace Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            config.DependencyResolver = new UnityDependencyResolver(container);
            config.Services.Replace(typeof(IAssembliesResolver), new WebApiAssembliesResolver());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonSettings = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSettings.NullValueHandling = NullValueHandling.Ignore;
            jsonSettings.DefaultValueHandling = DefaultValueHandling.Include;
        }
    }
}
