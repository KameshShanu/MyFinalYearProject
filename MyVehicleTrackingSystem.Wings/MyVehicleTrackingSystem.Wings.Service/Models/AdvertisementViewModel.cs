using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class AdvertisementViewModel
    {
        public IEnumerable<AdvertisementCategoryViewModel> AdvertisementCategory { get; set; }
        public AdvertisementCategoryViewModel Category { get; set; }
        public AdvertisementItemViewModel Item { get; set; }

    }
}