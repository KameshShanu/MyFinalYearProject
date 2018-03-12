using AutoMapper;
using Domain.Driver;
using MyVehicleTrackingSystem.Wings.Common.Models;

namespace MyVehicleTrackingSystem.Wings.Service.App_Start
{
    /// <summary>
    /// Auto Mapper Config class.
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Register all the auto mapping.
        /// </summary>
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Driver, DriverModel>().ReverseMap();
            });
        }
    }
}