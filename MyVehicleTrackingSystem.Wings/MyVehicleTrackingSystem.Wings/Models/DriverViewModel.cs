using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class DriverViewModel
    {
        public int DriverId
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
        [Required]
        public DateTime DateOfBirth
        {
            get;
            set;
        }

        [DisplayName("Home Address")]
        public string HomeAddress
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
        [Required]
        public string ContactNumber1
        {
            get;
            set;
        }

        [DisplayName("Contact Number 2")]
        public string ContactNumber2
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

        [DisplayName("Driving License Number")]
        [Required]
        public string DLNumber
        {
            get;
            set;
        }

        [DisplayName("Date of Expiry of the License")]        
        [DisplayFormat(DataFormatString = "{0:dd/MMMM/yyyy}")]
        [Required]
        public DateTime DateOfExpiryLicense
        {
            get;
            set;
        }

        [DisplayName("Defensive Certificate Number")]
        public string DefensiveLicenseNumber
        {
            get;
            set;
        }

        [DisplayName("Defensive Certificate Expiry Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MMMM/yyyy}")]
        [Required]
        public DateTime DefensiveLicenseExpiryDate
        {
            get;
            set;
        }

        [DisplayName("Driver Grade")]
        public string DriverGrade
        {
            get;
            set;
        }

        [DisplayName("Start Date of Work")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MMMM/yyyy}")]      
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