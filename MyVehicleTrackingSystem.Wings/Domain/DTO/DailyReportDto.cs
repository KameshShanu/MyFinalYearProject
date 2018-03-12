using Domain.Trips;
using Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class DailyReportDto
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
        public string CreatedDate
        {
            get;
            set;
        }
        public string UpdatedDate
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
        public string DispatchedHotel
        {
            get;
            set;
        }
        public string Packages
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
        public decimal Amount
        {
            get;
            set;
        }
        public string PaymentType
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
        public string Status
        {
            get;
            set;
        }
        //public string ReservationNo
        //{
        //    get;
        //    set;
        //}
        public virtual ICollection<PackagesList> PackagesList
        {
            get;
            set;
        }
        //public virtual string IsCustomPackage
        //{
        //    get;
        //    set;
        //}
    }
}
