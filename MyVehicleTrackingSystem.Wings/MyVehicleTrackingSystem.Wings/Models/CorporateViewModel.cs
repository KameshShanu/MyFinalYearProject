using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class CorporateViewModel
    {
        public int CorporateId
        {
            get;
            set;
        }
        [DisplayName("Corporate Name")]
        [Required]
        public string CorporateName
        {
            get;
            set;
        }
        [DisplayName("Corporate Details")]
        public string CorporateDetails
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
    }
}