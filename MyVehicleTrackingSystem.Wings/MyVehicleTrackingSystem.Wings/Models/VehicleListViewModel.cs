using Domain.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class VehicleListViewModel
    {
        public int VehicleId
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Vehicle License Plate Number")]
        public string VehicleNumber
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Revenue License Number")]
        public string LicenseNumber
        {
            get;
            set;
        }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Revenue License Expiry Date")]
        public DateTime? LicenseExpDate
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Insurance Card Number")]
        public string InsuranceNumber
        {
            get;
            set;
        }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Insurance Card Expiry Date")]
        public DateTime? InsuranceExpDate
        {
            get;
            set;
        }

        [Required]
        [DisplayName("GIT Policy Number")]
        public string GoodsNumber
        {
            get;
            set;
        }

        [Required]
        [DisplayName("GIT Policy Expiry Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? GoodsExpDate
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Year of Manufacture")]
        public string VehicleMFYear
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Engine Number")]
        public string EngineNumber
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Chassis Number")]
        public string ChassisNumber
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Vehicle Make")]
        public string VehicleMake
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Vehicle Model")]
        public string VehicleModel
        {
            get;
            set;
        }

        [Required]
        [DisplayName("First Registration Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FirstRegistrationDate
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Fire Report Expiry Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FireReportExpDate
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Calibration Report Expiry Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CalibrationReportExpDate
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Emission Test Expiry Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? EmissionTestExpDate
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Vehicle Fitness Expiry Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? VehicleFitnessExpDate
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Dangerous Goods in Transportation License Expiry Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DangerousLicenseExpDate
        {
            get;
            set;
        }

        [DisplayName("High Security Pass Expiry Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? HighSecurityPassExpiryDate
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Vehicle Delivery Type")]
        public string VehicleDeliveryType
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Description")]
        public string Description
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Quantity")]
        public string Quantity
        {
            get;
            set;
        }

        public List<SelectListItem> QuantityType
        {
            get;
            set;
        }

        public bool IsAvailable
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public DateTime Modified
        {
            get;
            set;
        }

        public string ErrorMessage
        {
            get;
            set;
        }

        public virtual ICollection<Driver> Drivers
        {
            get;
            set;
        }

        public List<SelectListItem> Vehicle
        {
            get;
            set;
        }

        public List<SelectListItem> VehicleDelivery
        {
            get;
            set;
        }
    }
}