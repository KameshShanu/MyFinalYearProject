using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class BataRateViewModel
    {
        public int BataId
        {
            get;
            set;
        }
        [Display(Name = "Description")]
        [Required]
        public string Description
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
    }
}