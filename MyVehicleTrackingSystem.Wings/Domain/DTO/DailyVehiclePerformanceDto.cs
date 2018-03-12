using Domain.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Trips
{
    public class DailyVehiclePerformanceDto
    {
        public string VoucherNumber
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
        public string DriverName
        {
            get;
            set;
        }
        public string VehicleNumber
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

        public ICollection<PackagesList> TripName
        {
            get;
            set;
        }
        public string Packages
        {
            get;
            set;
        }
        //public int MeterReadingInGap
        //{
        //    get;
        //    set;
        //}
        //public int MeterReadingOutGap
        //{
        //    get;
        //    set;
        //}
        //public int MeterReadingInGps
        //{
        //    get;
        //    set;
        //}

        //public int MeterReadingOutGps
        //{
        //    get;
        //    set;
        //}
        public int MeterReadingOut
        {
            get;
            set;
        }
        public int MeterReadingIn
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
        public string Remarks
        {
            get;
            set;
        }
        //public DateTime? TimeIn
        //{
        //    get;
        //    set;
        //}

        //public DateTime? TimeOut
        //{
        //    get;
        //    set;
        //}
        public decimal Amount
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
        public virtual ICollection<PackagesListDto> PackagesList
        {
            get;
            set;
        }
    }
}
