using Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Trips
{
    public class TripReportDto
    {
        public int TripId
        {
            get;
            set;
        }

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

        public string PaymentType
        {
            get;
            set;
        }

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

        public int VehicleIdentification
        {
            get;
            set;
        }


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

        public string MeterReadingIn
        {
            get;
            set;

        }

        public string FareType
        {
            get;
            set;
        }

        public string PassengerType
        {
            get;
            set;

        }

        public string Hotel
        {
            get;
            set;

        }


        public int TripTypeId
        {
            get;
            set;
        }

        public string TotalMilage
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

        public DateTime PaymentDate
        {
            get;
            set;

        }
        public DateTime PaymentTime
        {
            get;
            set;

        }

        public string Remarks
        {
            get;
            set;

        }

        public string CashierName
        {
            get;
            set;

        }

        public string SupervisorName
        {
            get;
            set;

        }

        public string AdditionalKM
        {
            get;
            set;

        }
        public string WaitedHrs
        {
            get;
            set;

        }

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

        public string DispatchedHotel
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

        public int BataRateId
        {
            get;
            set;
        }

        public Domain.BataRates.BataRate BattaList
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

        public DateTime Created
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
    }
}
