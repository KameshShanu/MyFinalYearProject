using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Areas.HypercentPortal
{
    public class MyVehicleTrackingSystemPortalAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MyVehicleTrackingSystemPortal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MyVehicleTrackingSystemPortal_default",
                "MyVehicleTrackingSystemPortal/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MyVehicleTrackingSystem.Wings.Areas.MyVehicleTrackingSystemPortal.Controllers" }
            );
        }
    }
}