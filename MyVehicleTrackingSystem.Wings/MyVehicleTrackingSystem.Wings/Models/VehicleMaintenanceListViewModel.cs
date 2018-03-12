using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class VehicleMaintenanceListViewModel
    {
        public IEnumerable<VehicleMaintenanceViewModel> VechicleMaintenanceList { get; set; }

        public VehicleMaintenanceViewModel VehicleMaintenance { get; set; }

        [DisplayName("Vehicle License Plate Number")]
        public string VehicleNumber
        {
            get;
            set;
        }

        [Display(Name = "Vehicle Number")]
        public List<SelectListItem> VehicleNumbers
        {
            get;
            set;
        }
    }
}