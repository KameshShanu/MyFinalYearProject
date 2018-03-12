using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class ArchiveTripViewModel
    {
        public int ArchiveTripId
        {
            get;
            set;
        }

        public int TripId
        {
            get;
            set;
        }

        public int? PackageId
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

        public string PaymentType
        {
            get;
            set;
        }
        public int? VehicleId
        {
            get;
            set;
        }
        public string VehicleNumber
        {
            get;
            set;
        }

        public int? DriverId
        {
            get;
            set;
        }
        public string DriverName
        {
            get;
            set;
        }
        public string GuestName
        {
            get;
            set;
        }

        public string RoomNumber
        {
            get;
            set;
        }
        public int? MeterReadingIn
        {
            get;
            set;
        }

        public int? MeterReadingOut
        {
            get;
            set;
        }
        public int? MeterReadingInGps
        {
            get;
            set;
        }

        public int? MeterReadingOutGps
        {
            get;
            set;
        }
        public string MeterReadingInStatus
        {
            get;
            set;
        }
        public string MeterReadingOutStatus
        {
            get;
            set;
        }
        public decimal? Amount
        {
            get;
            set;
        }

        public decimal? PackageCost
        {
            get;
            set;
        }

        public decimal? AdditionalKmCost
        {
            get;
            set;
        }

        public decimal? WaitingHourCost
        {
            get;
            set;
        }

        public bool? IsOpen
        {
            get;
            set;
        }

        public bool? IsRemoved
        {
            get;
            set;
        }

        public bool? IsDeleted
        {
            get;
            set;
        }

        public string PassengerType
        {
            get;
            set;

        }

        public string PassengerTypeList
        {
            get;
            set;
        }

        public DateTime? TimeIn
        {
            get;
            set;
        }
        public DateTime? TimeOut
        {
            get;
            set;
        }

        public string TripDuration
        {
            get;
            set;
        }
        public DateTime? PaymentDateTime
        {
            get;
            set;
        }

        public string Remarks
        {
            get;
            set;

        }

        public int? AdditionalKM
        {
            get;
            set;

        }

        public int? WaitedHrs
        {
            get;
            set;

        }

        public string VoucherNumber
        {
            get;
            set;
        }
        public string DispatchedHotel
        {
            get;
            set;
        }

        public string Createdby
        {
            get;
            set;
        }

        public string Updatedby
        {
            get;
            set;
        }
        public int TripMileage
        {
            get;
            set;
        }
        public int? MeterReadingInGap
        {
            get;
            set;
        }
        public int? MeterReadingOutGap
        {
            get;
            set;
        }
        public string PaymentCategory
        {
            get;
            set;
        }
        public string CorporateName
        {
            get;
            set;
        }

        public string ReservationNo
        {
            get;
            set;
        }
        public bool? IsCustomPackage
        {
            get;
            set;
        }
        public bool? IsArchive
        {
            get;
            set;
        }
    }
}