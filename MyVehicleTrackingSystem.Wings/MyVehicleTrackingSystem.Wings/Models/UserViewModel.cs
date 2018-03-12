using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class UserViewModel
    {
        public int UserId { get; protected set; }
        public string IdentityUserId { get; set; }

        [Required(ErrorMessage = "Please enter a valid email")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string NewConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string PasswordSalt { get; set; }

        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        public int RoleId { get; set; }

        public string Role { get; set; }

        [Display(Name = "User Type")]
        public List<SelectListItem> UserType { get; set; }

        public IEnumerable<SelectListItem> HotelNameList { get; set; }

        public string HotelName { get; set; }

        public bool IsDeleted { get; set; }
    }
}