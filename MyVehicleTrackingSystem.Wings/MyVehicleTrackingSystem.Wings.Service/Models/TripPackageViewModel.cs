using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class TripPackageViewModel
    {
        public IEnumerable<PreDefineTripViewModel> Packages { get; set; }
        public IEnumerable<VehicleRateViewModel> FarePackages { get; set; }
    }
}