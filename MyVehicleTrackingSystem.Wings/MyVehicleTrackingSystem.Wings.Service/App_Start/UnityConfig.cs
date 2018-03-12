using Application.Driver;
using DBStorage.Driver;
using Domain.Driver;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace MyVehicleTrackingSystem.Wings.Service
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();          
            container.RegisterType<IDriverRepository, DriverRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}