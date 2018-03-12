using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class SearchModel
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string Term { get; set; }
    }
}