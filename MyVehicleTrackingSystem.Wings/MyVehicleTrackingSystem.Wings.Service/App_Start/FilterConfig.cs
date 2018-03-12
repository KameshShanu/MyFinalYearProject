using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyVehicleTrackingSystem.Wings.Service
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());          
        }
    }
}
