using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class DailyVehiclePerformanceViewModel
    {
        public IEnumerable<DailyVehiclePerformanceDto> VehicleReport { get; set; }
        public DateTime CurrentDate
        {
            get;
            set;
        }
    }
}