using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class UserListViewModel
    {
        public IEnumerable<UserViewModel> UserList { get; set; }
    }
}