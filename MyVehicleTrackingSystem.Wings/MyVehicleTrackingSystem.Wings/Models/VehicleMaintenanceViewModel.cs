using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class VehicleMaintenanceViewModel
    {
        public int VehicleMaintenanceId
        {
            get;
            protected set;
        }

        public int VehicleId
        {
            get;
            set;
        }

        [DisplayFormat(DataFormatString = "{0:dd/MMMM/yyyy}")]
        [DisplayName("Maintenance Date")]
        [Required]
        public DateTime MaintenanceDate
        {
            get;
            set;
        }

        [DisplayName("Maintenance Description")]
        [Required]
        public string MaintenanceDescription
        {
            get;
            set;
        }

        [DisplayName("Cost")]
        [Required]
        public decimal? Cost
        {
            get;
            set;
        }

        [DisplayName("Vehicle License Plate Number")]
        public string VehicleNumber
        {
            get;
            set;
        }

        [Display(Name = "Number of Diesel Liters")]
        public string DieselLiters
        {
            get;
            set;
        }

        [Required]
        public SelectListItem VehicleNumberselectitem
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

        public bool IsAvailable
        {
            get;
            set;
        }
        public DateTime Modified
        {
            get;
            set;
        }
        public virtual VehicleListViewModel Vehicle
        {
            get;
            set;
        }
    }
}