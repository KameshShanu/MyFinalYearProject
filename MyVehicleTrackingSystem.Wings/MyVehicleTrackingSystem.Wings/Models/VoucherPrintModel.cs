using Domain.DTO;
using Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class VoucherPrintModel
    {
        public string VehicleNo
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
        public string MeterReadingOut
        {
            get;
            set;
        }
        public string TimeOut
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
        public virtual ICollection<PackagesDto> PackagesList
        {
            get;
            set;
        }

    }
}