using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class HelperViewModel
    {
        public int HelperId
        {
            get;
            protected set;
        }

        [DisplayName("Name")]
        [Required]
        public string Name
        {
            get;
            set;
        }       
        [DisplayName("NIC")]
        [Required]
        public string NIC
        {
            get;
            set;
        }
        [DisplayFormat(DataFormatString = "{0:dd/MMMM/yyyy}")]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth
        {
            get;
            set;
        }

        [DisplayName("Resident Address")]
        public string ResidentAddress
        {
            get;
            set;
        }

        [DisplayName("Contact Number 1")]
        public string PhoneNumber1
        {
            get;
            set;
        }

        [DisplayName("Contact Number 2")]
        public string PhoneNumber2
        {
            get;
            set;
        }

        [DisplayName("EPF Number")]
        [Required]
        public string EPFNumber
        {
            get;
            set;
        }

        [DisplayFormat(DataFormatString = "{0:dd/MMMM/yyyy}")]
        [DisplayName("Start Date of Work")]
        [Required]
        public DateTime StartDateOfWork
        {
            get;
            set;
        }

        [DisplayName("Period of Service")]        
        public string PeriodOfService
        {
            get;
            set;
        }
        [DisplayName("Basic Salary")]
        public decimal BasicSalary
        {
            get;
            set;
        }

        [DisplayName("Minimum Salary")]
        public decimal MinimumSalary
        {
            get;
            set;
        }

        [DisplayName("Police Report Expiry Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MMMM/yyyy}")]
        public DateTime PoliceReportExpiryDate
        {
            get;
            set;
        }

        public bool IsAvailable
        {
            get;
            set;
        }
        public DateTime Modified
        {
            get;
            set;
        }
    }
}