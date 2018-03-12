using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Api_default",
                "Api/{controller}/{action}/{id}",
                new { action = "Get", id = UrlParameter.Optional },
                namespaces: new[] { "MyVehicleTrackingSystem.Wings.Areas.Api.Controllers" }
            );
        }
    }
}