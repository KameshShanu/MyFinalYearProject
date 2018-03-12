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
        public string ApplicationUserId
        {
            get;
            set;
        }
        [DisplayName("Employee Number")]
        [Required]
        public string EmpNumber
        {
            get;
            set;
        }

        [DisplayName("First Name")]
        [Required]
        public string FirstName
        {
            get;
            set;
        }
        [DisplayName("Last Name")]
        [Required]
        public string LastName
        {
            get;
            set;
        }
        [DisplayName("Picture")]
        public string PixURL
        {
            get;
            set;
        }

        [DisplayName("Picture")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase PixFile { get; set; }

        [DisplayName("NIC")]
        [Required]
        public string NIC
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

        [DisplayName("Contact Number 3")]
        public string PhoneNumber3
        {
            get;
            set;
        }

        [DisplayName("DL Number")]
        public string DLNumber
        {
            get;
            set;
        }

        [DisplayName("EPF Number")]
        public string EPFNumber
        {
            get;
            set;
        }

        [DisplayName("Employee Status")]
        public CustomDataHelper.DataHelper.EmploymentStatusType EmpStatus
        {
            get;
            set;
        }
        [DisplayName("Marital Status")]
        public CustomDataHelper.DataHelper.MaritalStatusType MaritalStatus
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
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email
        {
            get;
            set;
        }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password
        {
            get;
            set;
        }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword
        {
            get;
            set;
        }
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword
        {
            get;
            set;
        }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation new password do not match.")]
        public string ConfirmNewPassword
        {
            get;
            set;
        }
    }
}