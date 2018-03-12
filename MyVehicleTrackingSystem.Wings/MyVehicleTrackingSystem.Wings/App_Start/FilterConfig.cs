using StructureMap;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wings;

namespace MyVehicleTrackingSystem.Wings
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());

            IContainer container = (IContainer)IoC.Initialize();
            DependencyResolver.SetResolver(new SmDependencyResolver(container));
            IFilterProvider oldProvider = FilterProviders.Providers.Single(fp => fp is FilterAttributeFilterProvider);
            FilterProviders.Providers.Remove(oldProvider);
            IFilterProvider newProvider = new StructureMapFilterAttributeFilterProvider(container);
            FilterProviders.Providers.Add(newProvider);
        }
    }
}


