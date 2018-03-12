using Domain.Customers;
using Domain.DTO;
using Domain.Trips;
using Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class TripViewModel
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

        public int CustomerId
        {
            get;
            set;
        }

        [DisplayName("Vehicle Reg. No.")]
        public string VehicleNumber
        {
            get;
            set;
        }

        public int VehicleId
        {
            get;
            set;
        }

        public int VehicleIdentification
        {
            get;
            set;
        }
        public int DriverIdentification
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> Vehicle
        {
            get;
            set;
        }

        [DisplayName("Driver Name")]
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

        [DisplayName("Driver Name")]
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
        [DisplayName("Meter Reading Start")]
        public int MeterReadingOut
        {
            get;
            set;
        }

        [DisplayName("Meter Reading End")]
        [Required]
        public int MeterReadingIn
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

        public IEnumerable<SelectListItem> Trips
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> PaymentTypeList
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> PaymentCategoryList
        {
            get;
            set;
        }

        public int TripTypeId
        {
            get;
            set;
        }
        public int TripMileage
        {
            get;
            set;
        }
        public string TripDuration
        {
            get;
            set;
        }
        public int MeterReadingInGap
        {
            get;
            set;
        }
        public int MeterReadingOutGap
        {
            get;
            set;
        }
        public int MeterReadingInGps
        {
            get;
            set;
        }

        public int MeterReadingOutGps
        {
            get;
            set;
        }

        public string MeterReadingStatus
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
        public DateTime TimeOut
        {
            get;
            set;

        }

        [DisplayName("Payment Date")]
        public DateTime PaymentDateTime
        {
            get;
            set;

        }
        [Required]
        [DisplayName("Payment Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        [DataType(DataType.DateTime)]
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

        [DisplayName("Additional KMs")]
        public string AdditionalKM
        {
            get;
            set;

        }

        [DisplayName("Waited Hours")]
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

        [DisplayName("Dispatched Hotel")]
        public string DispatchedHotel
        {
            get;
            set;
        }

        public VehicleDto VehicleList
        {
            get;
            set;
        }

        public DriverDto DriverList
        {
            get;
            set;
        }

        public int BataRateId
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> Bata
        {
            get;
            set;
        }

        public IEnumerable<VehicleRateDto> VehicleRates
        {
            get;
            set;
        }
        [DisplayName("Package(s)")]
        public virtual ICollection<PackagesListDto> PackagesList
        {
            get;
            set;
        }

        [DisplayName("Created")]
        public DateTime CreatedDate
        {
            get;
            set;
        }
        [DisplayName("Updated")]
        public DateTime UpdatedDate
        {
            get;
            set;
        }
        [DisplayName("Total Amount")]
        public decimal Amount
        {
            get;
            set;
        }

        public decimal PackageCost
        {
            get;
            set;
        }

        public decimal AdditionalKmCost
        {
            get;
            set;
        }

        public decimal WaitingHourCost
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> Passenger
        {
            get;
            set;
        }

        public int[] PackageIds
        {
            get;
            set;
        }
        public string BataRate
        {
            get;
            set;
        }
        public decimal AdditionalAmount
        {
            get;
            set;
        }
        public string Dispatcher
        {
            get;
            set;
        }
        public bool IsRemoved
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
        public virtual List<TripBataDto> TripBata
        {
            get;
            set;
        }
        public virtual List<CustomBataDto> CustomBata
        {
            get;
            set;
        }
        [DisplayName("Custom Package Amount")]
        public string CustomPackageAmount
        {
            get;
            set;
        }
        public bool IsCustomPackage
        {
            get;
            set;
        }
        public string PaymentCategory
        {
            get;
            set;
        }
        [DisplayName("Corporate Name")]
        public string CorporateName
        {
            get;
            set;
        }
        [DisplayName("Reservation No")]
        public string ReservationNo
        {
            get;
            set;
        }
        public bool IsReopened
        {
            get;
            set;
        }
        public int BataIdOld
        {
            get;
            set;
        }
        public CustomerViewModel Customer
        {
            get;
            set;
        }
    }
}