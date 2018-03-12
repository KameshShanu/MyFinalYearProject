using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MyVehicleTrackingSystem.Wings.Startup))]
namespace MyVehicleTrackingSystem.Wings
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
