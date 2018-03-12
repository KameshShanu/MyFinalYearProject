using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class VehicleRateViewModel
    {

        public int VehicleRateId
        {
            get;
            set;
        }

        [DisplayName("Vehicle Type")]
        [Required]
        public string VehicleType
        {
            get;
            set;
        }

        [Display(Name = "Fare Per Km")]
        [Required]
        public decimal FarePerKm
        {
            get;
            set;
        }

        [Display(Name = "Waiting Chargers Per Hour")]
        [Required]
        public decimal WaitingChargers
        {
            get;
            set;
        }

        public int PassengerId
        {
            get;
            set;
        }

        [Display(Name = "Passenger Type")]
        [Required]
        public IEnumerable<SelectListItem> Passenger
        {
            get;
            set;
        }

        [Display(Name = "Passenger Type")]
        public string PassengerType
        {
            get;
            set;
        }
    }
}