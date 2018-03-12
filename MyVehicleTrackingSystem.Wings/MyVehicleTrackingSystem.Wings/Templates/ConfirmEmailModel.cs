using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Templates
{
    public class ConfirmEmailModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CallBackURL { get; set; }
        public static string ConfirmEmailName = "ConfirmEmailTemplate";
    }
}