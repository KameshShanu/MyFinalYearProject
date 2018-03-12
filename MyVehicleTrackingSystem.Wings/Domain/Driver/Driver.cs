using Domain.Vehicles;
using Domin.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Driver
{
    public class Driver : BaseEntity
    {
        public int DriverId
        {
            get;
            protected set;
        }

        public string Name
        {
            get;
            set;
        }

        public string NIC
        {
            get;
            set;
        }

        public DateTime DateOfBirth
        {
            get;
            set;
        }        

        public string ResidentAddress
        {
            get;
            set;
        }

        public string ContactNumber1
        {
            get;
            set;
        }

        public string ContactNumber2
        {
            get;
            set;
        }

        public string EPFNumber
        {
            get;
            set;
        }

        public string DLNumber
        {
            get;
            set;
        }

        public DateTime DateOfExpiryLicense
        {
            get;
            set;
        }

        public string DefensiveLicenseNumber
        {
            get;
            set;
        }

        public DateTime DefensiveLicenseExpiryDate
        {
            get;
            set;
        }

        public string DriverGrade
        {
            get;
            set;
        }

        public DateTime StartDateOfWork
        {
            get;
            set;
        }

        public string PeriodOfService
        {
            get;
            set;
        }
        public decimal BasicSalary
        {
            get;
            set;
        }

        public decimal MinimumSalary
        {
            get;
            set;
        }

        public DateTime PoliceReportExpiryDate
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public bool IsAvailable
        {
            get;
            set;
        }
        public override bool IsTransient()
        {
            return DriverId == 0;
        }
    }
}
