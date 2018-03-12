using System;
using System.Web;
using static CustomDataHelper.DataHelper;

namespace MyVehicleTrackingSystem.Wings.Common.Models
{
    public class DriverModel
    {
        public int DriverId { get; set; }
        public string ApplicationUserId { get; set; }
        public string EmpNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PixURL { get; set; }
        public HttpPostedFileBase PixFile { get; set; }
        public string NIC { get; set; }
        public string ResidentAddress { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string PhoneNumber3 { get; set; }
        public string DLNumber { get; set; }
        public string EPFNumber { get; set; }
        public EmploymentStatusType EmpStatus { get; set; }
        public MaritalStatusType MaritalStatus { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime Modified { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
