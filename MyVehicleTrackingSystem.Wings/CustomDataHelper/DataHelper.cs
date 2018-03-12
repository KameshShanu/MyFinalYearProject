using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.Mvc;

namespace CustomDataHelper
{
    public class DataHelper
    {
        public enum EmploymentStatusType
        {
            [Display(Name = "Contract")]
            Contract,
            [Display(Name = "Probation")]
            Probation,
            [Display(Name = "Permenant")]
            Permenant,
            [Display(Name = "Temporary")]
            Temporary
        }

        public enum MaritalStatusType
        {
            [Display(Name = "Single")]
            Single,
            [Display(Name = "Married")]
            Married,
        }

        public enum GuestType
        {
            [Description("CG Resident")]
            [Display(Name = "CG Resident")]
            CGResident,
            [Description("CL Resident")]
            [Display(Name = "CL Resident")]
            CLResident,
            [Description("Walk In Guest")]
            [Display(Name = "Walk In Guest")]
            WalkInGuest,
            [Description("Corporate Client")]
            [Display(Name = "Corporate Client")]
            CorporateClient,
            [Description("Airline Crew")]
            [Display(Name = "Airline Crew")]
            AirlineCrew,
            [Description("Other")]
            [Display(Name = "Other")]
            Other
        }

        public static List<SelectListItem> GetQuentity()
        {
            var items = new List<SelectListItem>
                        {
                            new SelectListItem
                                {Text = "Please Select", Value = ""},
                            new SelectListItem
                                {Text = "13200L,Thirteen Thousand Two Hundred Liters", Value = "13200L,Thirteen Thousand Two Hundred Liters"},
                            new SelectListItem
                                {Text = "19800L,Nineteen Thousand Eight Hundred Liters", Value = "19800L,Nineteen Thousand Eight Hundred Liters"},
                        };

            return items;
        }

        public static List<SelectListItem> GetFuelType()
        {
            var items = new List<SelectListItem>
                        {
                            new SelectListItem
                                {Text = "Please Select", Value = ""},
                            new SelectListItem
                                {Text = "Petrol", Value = "Petrol"},
                            new SelectListItem
                                {Text = "Diesel", Value = "Diesel"},
                            new SelectListItem
                                {Text = "Electric", Value = "Electric"},
                            new SelectListItem
                                {Text = "Hybrid", Value = "Hybrid"},
                            new SelectListItem
                                {Text = "Other", Value = "Other"}
                        };
            return items;
        }
        public static List<SelectListItem> GetVehicleDeliveryType()
        {
            var items = new List<SelectListItem>
                        {
                            new SelectListItem
                                {Text = "Please Select", Value = ""},
                            new SelectListItem
                                {Text = "Diesel", Value = "Diesel"},
                            new SelectListItem
                                {Text = "Furnace Oil", Value = "Furnace Oil"},
                            new SelectListItem
                                {Text = "Water", Value = "Water"},
                            new SelectListItem
                                {Text = "Waste Oil", Value = "Waste Oil"},
                            new SelectListItem
                                {Text = "Other", Value = "Other"},
                        };

            return items;
        }
        public static List<SelectListItem> GetVehicleType()
        {
            var items = new List<SelectListItem>
                        {
                            new SelectListItem
                                {Text = "Please Select", Value = ""},
                            new SelectListItem
                                {Text = "Car", Value = "Car"},
                            new SelectListItem
                                {Text = "SUV", Value = "SUV"},
                             new SelectListItem
                                {Text = "Van", Value = "Van"},
                            new SelectListItem
                                {Text = "Bus", Value = "Bus"},
                        };

            return items;
        }
        public static List<SelectListItem> GetOwnershipStatus()
        {
            var items = new List<SelectListItem>
                        {
                            new SelectListItem
                                {Text = "Please Select", Value = ""},
                            new SelectListItem
                                {Text = "Own", Value = "Own"},
                            new SelectListItem
                                {Text = "Hired", Value = "Hired"},
                            new SelectListItem
                                {Text = "Lease", Value = "Lease"},
                            new SelectListItem
                                {Text = "Other", Value = "Other"}
                        };
            return items;
        }
        public static List<SelectListItem> GetGuestType()
        {
            var items = new List<SelectListItem>
                        {
                            new SelectListItem
                                {Text = "Guest", Value = "Guest"},
                            new SelectListItem
                                {Text = "Staff", Value = "Staff"},
                        };
            return items;
        }

        public static List<SelectListItem> GetPaymentTypes()
        {
            var items = new List<SelectListItem>
                        {
                            new SelectListItem
                                {Text = "Cash", Value = "Cash"},
                             new SelectListItem
                                {Text = "Credit", Value = "Credit"},
                            new SelectListItem
                                {Text = "Credit Card", Value = "Credit Card"},
                            new SelectListItem
                                {Text = "Non Revenue", Value = "Non Revenue"}
                            //   new SelectListItem
                            //    {Text = "No Show", Value = "No Show"}
                        };
            return items;
        }
        public static List<SelectListItem> GetPaymentCategories()
        {
            var items = new List<SelectListItem>
                        {
                            new SelectListItem
                                {Text = "Hotel Billing Guest", Value = "Hotel Billing Guest"},
                             new SelectListItem
                                {Text = "Hotel Billing Staff", Value = "Hotel Billing Staff"},
                            new SelectListItem
                                {Text = "No Show", Value = "No Show"},
                            new SelectListItem
                                {Text = "Direct Credit Corporate", Value = "Direct Credit Corporate"}
                        };
            return items;
        }
        public static List<SelectListItem> GetHotels()
        {
            var items = new List<SelectListItem>
                        {
                            new SelectListItem
                                {Text = "Cinnamon Grand", Value = "CGH"},
                            new SelectListItem
                                {Text = "Cinnamon Lakeside", Value = "CLH"}
                        };
            return items;
        }

        public static List<SelectListItem> GetVoucherStatus()
        {
            var items = new List<SelectListItem>
                        {
                            new SelectListItem
                                {Text = "Open", Value = "Open"},
                            new SelectListItem
                                {Text = "Closed", Value = "Closed"},
                             new SelectListItem
                                {Text = "Cancelled", Value = "Cancelled"}
                        };
            return items;
        }

        public static List<SelectListItem> GetPackageType()
        {
            var items = new List<SelectListItem>
                        {
                            new SelectListItem
                                {Text = "Please Select", Value = "0"},
                            new SelectListItem
                                {Text = "Revenue", Value = "Revenue"},
                            new SelectListItem
                                {Text = "Non Revenue", Value = "Non Revenue"}
                        };
            return items;
        }
    }
}
