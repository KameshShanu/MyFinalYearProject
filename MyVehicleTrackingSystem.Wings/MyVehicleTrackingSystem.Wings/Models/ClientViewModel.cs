using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class ClientViewModel
    {
        public int ClientId
        {
            get;
            protected set;
        }

        [DisplayName("Company Name")]
        [Required]
        public string CompanyName
        {
            get;
            set;
        }

        [DisplayName("Company Address")]
        [Required]
        public string CompanyAddress
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

        [DisplayName("VAT")]
        [Required]
        public string VAT
        {
            get;
            set;
        }

        [DisplayName("SVAT")]
        public string SVAT
        {
            get;
            set;
        }

        [DisplayName("Client Rate")]
        [Required]
        public decimal? ClientRate
        {
            get;
            set;
        }

        [DisplayName("Driver Commission Rate")]
        public decimal? DriverCommissionRate
        {
            get;
            set;
        }

        [DisplayName("Porter Commission Rate")]
        public decimal? PorterCommissionRate
        {
            get;
            set;
        }

        [DisplayName("Operation Types Available?")]
        public bool IsOperationType
        {
            get;
            set;
        }

        [DisplayName("Operation Type")]
        public string OperationType
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

        public DateTime Modified
        {
            get;
            set;
        }
    }
}