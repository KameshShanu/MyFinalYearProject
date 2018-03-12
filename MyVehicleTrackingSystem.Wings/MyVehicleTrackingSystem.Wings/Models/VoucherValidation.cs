using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class VoucherValidation
    {
        public VoucherDataDto VoucherData { get; set; }
        public string Error { get; set; }
    }
}