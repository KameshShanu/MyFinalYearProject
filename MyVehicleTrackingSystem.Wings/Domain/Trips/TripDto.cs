using Domain.DTO;
using Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Trips
{
    public class TripDto
    {
        public int TripId
        {
            get;
            set;
        }
        public string PaymentType
        {
            get;
            set;
        }
        public string VehicleNumber
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
        public int MeterReadingIn
        {
            get;
            set;
        }

        public int MeterReadingOut
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


        public string PassengerType
        {
            get;
            set;
        }

        public DateTime TimeIn
        {
            get;
            set;
        }
        public DateTime TimeOut
        {
            get;
            set;
        }
        public DateTime PaymentDateTime
        {
            get;
            set;
        }

        public string Remarks
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

        public virtual ICollection<PackagesListDto> PackagesList
        {
            get;
            set;
        }
        public virtual ICollection<CustomBataDto> CustomBata
        {
            get;
            set;
        }
        public virtual ICollection<TripBataDto> TripBata
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

        public bool IsCustomPackage
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
        public string Packages
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public DateTime UpdatedDate
        {
            get;
            set;
        }
        public string VehicleType
        {
            get;
            set;
        }

        public string VehicleMake
        {
            get;
            set;
        }

        public string VehicleModel
        {
            get;
            set;
        }
        public string EmployeeNumber
        {
            get;
            set;
        }
        public string BataDescription
        {
            get;
            set;
        }
        public decimal BataAmount
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
        public bool IsOpen
        {
            get;
            set;
        }

        public bool IsRemoved
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public bool IsArchive
        {
            get;
            set;
        }
        public bool IsReopened
        {
            get;
            set;
        }
    }
}
