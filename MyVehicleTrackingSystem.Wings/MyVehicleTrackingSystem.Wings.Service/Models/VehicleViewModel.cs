using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class VehicleViewModel
    {
        public IEnumerable<VehicleListViewModel> VehicleList { get; set; }
        public VehicleListViewModel Vehicle { get; set; }
        public IEnumerable<VehicleListViewModel> VehicleAvailableList { get; set; }
        public IEnumerable<VehicleListViewModel> VehicleUnAvailableList { get; set; }
    }
}