using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class PreDefineTripViewModel
    {
        public int PreDefineTripId
        {
            get;
            set;
        }

        [Display(Name = "Package Name")]
        [Required]
        public string PreDefineTripName
        {
            get;
            set;
        }
        [Display(Name = "Package Type")]
        [Required]
        public string TripType
        {
            get;
            set;
        }

        [Display(Name = "Amount")]
        [Required]
        public decimal Amount
        {
            get;
            set;
        }

        [Display(Name = "Distance (KM)")]
        [Required]
        public string Distance
        {
            get;
            set;
        }

        [Display(Name = "Vehicle Type")]
        [Required]
        public string VehicleType
        {
            get;
            set;
        }

        [Display(Name = "Vehicle Model")]
        [Required]
        public string VehicleModel
        {
            get;
            set;
        }

        [Display(Name = "Rate")]
        [Required]
        public decimal Rate
        {
            get;
            set;
        }

        public List<SelectListItem> Vehicle
        {
            get;
            set;
        }
        public List<SelectListItem> Type
        {
            get;
            set;
        }
    }
}