using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class DispatchNoteViewModel
    {
        public int DispatchNoteId
        {
            get;
            set;
        }

        [DisplayName("Driver")]
        [Required]
        public string Driver
        {
            get;
            set;
        }

        [DisplayName("Porter")]
        [Required]
        public string Helper
        {
            get;
            set;
        }

        [DisplayName("Client")]
        [Required]
        public string Client
        {
            get;
            set;
        }

        [DisplayName("Address")]
        [Required]
        public string CompanyAddress
        {
            get;
            set;
        }

        [DisplayName("Vehicle License Plate Number")]
        [Required]
        public string VehicleLicensePlateNumber
        {
            get;
            set;
        }

        [DisplayName("Quantity")]
        [Required]
        public string Quantity
        {
            get;
            set;
        }

        [DisplayName("Vehicle Delivery Type")]
        [Required]
        public string VehicleDeliveryType
        {
            get;
            set;
        }

        [DisplayFormat(DataFormatString = "{0:yyyy-MMMM-dd}")]
        [DisplayName("Date")]
        [Required]
        public DateTime DispatchDate
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        [DisplayName("Dispatch Number")]
        public string DispatchId
        {
            get;
            set;
        }

        public List<SelectListItem> Client_OperationType
        {
            get;
            set;
        }

        public List<SelectListItem> DriverName_Grade
        {
            get;
            set;
        }

        public List<SelectListItem> HelperName
        {
            get;
            set;
        }

        public List<SelectListItem> VehiclePlateNumber
        {
            get;
            set;
        }

        public List<SelectListItem> QuantityType
        {
            get;
            set;
        }

        public decimal ClientRate
        {
            get;
            set;
        }

        public decimal DriverCommissionRate
        {
            get;
            set;
        }

        public decimal PorterCommissionRate
        {
            get;
            set;
        }

        [DisplayName("Dispatch Note Received")]
        [Required]
        public bool IsDispatchNoteReceived
        {
            get;
            set;
        }

        [DisplayName("Goods Delivered")]
        [Required]
        public bool IsGoodsDelivered
        {
            get;
            set;
        }

        [DisplayName("Remarks")]        
        public string Remarks
        {
            get;
            set;
        }

        public bool IsPrinted
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