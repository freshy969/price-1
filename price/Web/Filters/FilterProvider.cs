using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Web.Filters
{
    public class FilterProvider : IFilterProvider
    {
        private readonly IUnityContainer _container;

        public FilterProvider(IUnityContainer container)
        {
            _container = container;
        }

        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            return _container.ResolveAll<IActionFilter>().Select(actionFilter => new Filter(actionFilter, FilterScope.First, null));
        }
    }
}