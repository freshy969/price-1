using System.Collections.Generic;
using System.Reflection;
using System.Web.Http.Dispatcher;
using WebApi.Controllers;

namespace Web.App_Start.WebApi
{
    public class WebApiAssembliesResolver : IAssembliesResolver
    {
        ICollection<Assembly> IAssembliesResolver.GetAssemblies()
        {
            Assembly assembly = typeof(ItemController).Assembly;
            return new[] { assembly };
        }
    }
}