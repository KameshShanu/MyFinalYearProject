using Domain.DTO;
using Domain.Trips;
using System;
using System.Collections.Generic;

namespace Domain.Driver
{
    public class DailyDriverPerformanceDto
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
        public string EmployeeNumber
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
        public string Packages
        {
            get;
            set;
        }
        public string DispatchedHotel
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
        public decimal CustomBataAmount
        {
            get;
            set;
        }
        public virtual ICollection<PackagesListDto> PackagesList
        {
            get;
            set;
        }
        public ICollection<PackagesListDto> TripName
        {
            get;
            set;
        }
        public List<TripBataDto> TripBata
        {
            get;
            set;
        }
        public List<CustomBataDto> CustomBata
        {
            get;
            set;
        }
    }
}
