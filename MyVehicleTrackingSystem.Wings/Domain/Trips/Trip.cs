using Domain.Vehicles;
using Domain.Driver;
using Domin.Common;
using System;
using System.Collections.Generic;
using Domain.BataRates;
using Domain.Customers;

namespace Domain.Trips
{
    public class Trip : BaseEntity
    {
        public int TripId
        {
            get;
            set;
        }

        public int PackageId
        {
            get;
            set;
        }

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

        public int VehicleId
        {
            get;
            set;
        }
        public string VehicleNumber
        {
            get;
            set;
        }

        public int DriverId
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
        public bool IsReopened
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

        public string TripDuration
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

        public int AdditionalKM
        {
            get;
            set;

        }

        public int WaitedHrs
        {
            get;
            set;

        }

        public string VoucherNumber
        {
            get;
            set;
        }

        public virtual Vehicle VehicleList
        {
            get;
            set;
        }

        public virtual Domain.Driver.Driver DriverList
        {
            get;
            set;
        }

        public string DispatchedHotel
        {
            get;
            set;
        }

        public virtual ICollection<PackagesList> PackagesList
        {
            get;
            set;
        }
        public virtual List<TripBata> TripBata
        {
            get;
            set;
        }
        public virtual List<CustomBata> CustomBata
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
        public bool IsCustomPackage
        {
            get;
            set;
        }
        public bool IsArchive
        {
            get;
            set;
        }

        public virtual Customer Customer
        {
            get;
            set;
        }

        public override bool IsTransient()
        {
            return TripId == 0;
        }
    }
}





