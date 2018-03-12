using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class InvoiceViewModel
    {
        public int InvoiceId
        {
            get;
            set;
        }

        [Display(Name="Invoice Type")]
        public string InvoiceType
        {
            get;
            set;
        }

        [Display(Name = "SVAT No")]
        public string SVAT
        {
            get;
            set;
        }

        [Display(Name = "VAT No")]
        public string VAT
        {
            get;
            set;
        }

        [Display(Name = "Date")]
        public string InvoiceDate
        {
            get;
            set;
        }

        [Display(Name = "Invoice No")]
        public string InvoiceNumber
        {
            get;
            set;
        }

        [Display(Name = "Company Name")]
        public string CompanyName
        {
            get;
            set;
        }

        [Display(Name = "Address")]
        public string Address
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        [Display(Name = "Total Value")]
        public decimal TotalValue
        {
            get;
            set;
        }

        [Display(Name = "SVAT 12% (RS)")]
        public decimal SVATAmount
        {
            get;
            set;
        }

        [Display(Name = "VAT 12% (RS)")]
        public decimal VATAmount
        {
            get;
            set;
        }

        public string Status
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