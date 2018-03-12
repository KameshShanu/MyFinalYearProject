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
        [DisplayName("Vehicle Number")]
        [Required]
        public string VehicleNumber
        {
            get;
            set;
        }

        [DisplayName("Owner")]
        public string Owner
        {
            get;
            set;
        }

        [DisplayName("Ownership Status")]
        public string OwnershipStatus
        {
            get;
            set;
        }

        [DisplayName("Vehicle Type")]
        public string VehicleType
        {
            get;
            set;
        }

        [DisplayName("Vehicle Make")]
        [Required]
        public string VehicleMake
        {
            get;
            set;
        }

        [DisplayName("Vehicle Model")]
        [Required]
        public string VehicleModel
        {
            get;
            set;
        }

        [DisplayName("Year of Manufacture")]
        public string VehicleMFYear
        {
            get;
            set;
        }

        [DisplayName("Fuel Type")]
        public string FuelType
        {
            get;
            set;
        }

        [DisplayName("Engine Number")]
        public string EngineNumber
        {
            get;
            set;
        }

        [DisplayName("Chassis Number")]
        public string ChassisNumber
        {
            get;
            set;
        }

        [DisplayName("Purchase Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate
        {
            get;
            set;
        }

        [DisplayName("Vendor")]
        public string Vendor
        {
            get;
            set;
        }

        [DisplayName("Value")]
        public string Value
        {
            get;
            set;
        }

        [DisplayName("Warranty")]
        public string Warranty
        {
            get;
            set;
        }

        [DisplayName("Number Of Years")]
        public string NoOfYrWarranty
        {
            get;
            set;
        }

        [DisplayName("Expiry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime WarrantyExpiryDate
        {
            get;
            set;
        }

        [DisplayName("Lease Information")]
        public string LeaseInformation
        {
            get;
            set;
        }

        [DisplayName("Insurance")]
        public string Insurance
        {
            get;
            set;
        }

        [DisplayName("License")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime License
        {
            get;
            set;
        }

        [DisplayName("Emission Test")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EmissionTest
        {
            get;
            set;
        }

        public string CurrentMeterReading
        {
            get;
            set;
        }

        [DisplayName("Initial Meter Reading")]
        [Required]
        public int InitialMeterReading
        {
            get;
            set;
        }

        [DisplayName("Amount")]
        public string LeaseAmount
        {
            get;
            set;
        }

        [DisplayName("Rental")]
        public string LeaseRental
        {
            get;
            set;
        }

        [DisplayName("Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime LeaseDueDate
        {
            get;
            set;
        }

        [DisplayName("Insurance Company")]
        public string InsuranceCompany
        {
            get;
            set;
        }

        [DisplayName("PolicyNo")]
        public string InsurancePolicyNo
        {
            get;
            set;
        }

        [DisplayName("Premium")]
        public string InsurancePremium
        {
            get;
            set;
        }

        [DisplayName("Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime InsuranceDueDate
        {
            get;
            set;
        }

        [DisplayName("Other Information")]
        public string OtherInfo
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

        public List<SelectListItem> Fuel
        {
            get;
            set;
        }

        public List<SelectListItem> Ownership
        {
            get;
            set;
        }

        public string ErrorMessage
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

    }
}