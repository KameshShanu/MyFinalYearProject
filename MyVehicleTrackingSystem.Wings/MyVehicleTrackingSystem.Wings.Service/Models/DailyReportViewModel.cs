using Domain.Trips;
using Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class DailyReportViewModel
    {
        public int TripId
        {
            get;
            set;
        }

        [DisplayName("Package Type")]
        public string PackageName
        {
            get;
            set;
        }

        public int PackageId
        {
            get;
            set;
        }

        [DisplayName("Payment Type")]
        public string PaymentType
        {
            get;
            set;
        }
        [DisplayName("Vehi No")]
        public string VehicleNo
        {
            get;
            set;
        }

        public string VehicleId
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> Vehicle
        {
            get;
            set;
        }

        [DisplayName("Driver")]
        public string DriverName
        {
            get;
            set;
        }

        public int DriverId
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> Driver
        {
            get;
            set;
        }

        [DisplayName("Passenger Name")]
        public string GuestName
        {
            get;
            set;
        }

        public string PassengerTypeList
        {
            get;
            set;
        }

        [DisplayName("Room No.")]
        public string RoomNumber
        {
            get;
            set;
        }

        public string MeterReadingOut
        {
            get;
            set;
        }

        [DisplayName("Meter Reading In")]
        public string MeterReadingIn
        {
            get;
            set;

        }

        [DisplayName("Fare Type")]
        public string FareType
        {
            get;
            set;
        }

        [DisplayName("Passenger Type")]
        public string PassengerType
        {
            get;
            set;

        }

        [DisplayName("Hotel")]
        public string Hotel
        {
            get;
            set;

        }

        public IEnumerable<SelectListItem> Trips
        {
            get;
            set;
        }

        public int TripTypeId
        {
            get;
            set;
        }

        [DisplayName("Total Milage")]
        public string TotalMilage
        {
            get;
            set;

        }
        [DisplayName("Time In")]
        public DateTime TimeIn
        {
            get;
            set;
        }

        [DisplayName("Time Out")]
        public string TimeOut
        {
            get;
            set;

        }

        [DisplayName("Payment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime PaymentDate
        {
            get;
            set;

        }
        [Required]
        [DisplayName("Payment Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        [DataType(DataType.Time)]
        public DateTime PaymentTime
        {
            get;
            set;

        }

        [DisplayName("Remarks")]
        public string Remarks
        {
            get;
            set;

        }

        [DisplayName("Cashier's Name")]
        public string CashierName
        {
            get;
            set;

        }

        [DisplayName("Supervisor's Name")]
        public string SupervisorName
        {
            get;
            set;

        }

        [DisplayName("Add KMs")]
        public string AdditionalKM
        {
            get;
            set;

        }

        [DisplayName("Waited Hr")]
        public string WaitedHrs
        {
            get;
            set;

        }

        [DisplayName("Voucher Number")]
        public string VoucherNumber
        {
            get;
            set;
        }


        public bool IsOpen
        {
            get;
            set;
        }

        public bool RemovedByDispatcher
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public bool Paid
        {
            get;
            set;
        }

        public Vehicle VehicleList
        {
            get;
            set;
        }

        public Domain.Driver.Driver DriverList
        {
            get;
            set;
        }

        public int BataId
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> Bata
        {
            get;
            set;
        }

        public IEnumerable<PreDefineTrip> Packages
        {
            get;
            set;
        }

        public IEnumerable<VehicleRate> VehicleRates
        {
            get;
            set;
        }

        public virtual ICollection<PackagesList> PackagesList
        {
            get;
            set;
        }

        [DisplayName("Date and Time")]
        public DateTime Created
        {
            get;
            set;
        }

        [DisplayName("Total")]
        public decimal Amount
        {
            get;
            set;
        }

        [DisplayName("Package")]
        public decimal PackageCost
        {
            get;
            set;
        }

        [DisplayName("Add Km")]
        public decimal AdditionalKmCost
        {
            get;
            set;
        }
        [DisplayName("Waiting")]
        public decimal WaitingHourCost
        {
            get;
            set;
        }

        public List<SelectListItem> Passenger
        {
            get;
            set;
        }

        public int[] PackageIds
        {
            get;
            set;
        }

        [DisplayName("Dispatcher")]
        public string Dispatcher
        {
            get;
            set;
        }

        public string DispatchedHotel
        {
            get;
            set;
        }
        public virtual ICollection<TripBata> TripBata
        {
            get;
            set;
        }
        [DisplayName("Created by")]
        public string Createdby
        {
            get;
            set;
        }

        [DisplayName("Updated by")]
        public string Updatedby
        {
            get;
            set;
        }
    }
}