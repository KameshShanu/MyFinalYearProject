using Domain.Driver;
using Domain.Trips;
using Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class TripCommonViewModel
    {
        public IEnumerable<TripDto> ClosedTrips { get; set; }
        public IEnumerable<TripDto> OpenTrips { get; set; }
        public IEnumerable<TripDto> CancelledTrips { get; set; }
        public IEnumerable<Driver> DriverList { get; set; }
        public IEnumerable<Vehicle> VehicleList { get; set; }
    }
}