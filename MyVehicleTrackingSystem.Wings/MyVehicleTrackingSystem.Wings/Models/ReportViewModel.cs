using Domain.Driver;
using Domain.DTO;
using Domain.Trips;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Models
{
    public class ReportViewModel
    {
        public List<DailyReportDto> ReportList { get; set; }

        public List<DailyReportDto> DispatcherClosedCash { get; set; }

        public List<DailyReportDto> DispatcherClosedCreditGuest { get; set; }

        public List<DailyReportDto> DispatcherClosedCreditStaff { get; set; }

        public List<DailyReportDto> DispatcherClosedCreditNoShow { get; set; }

        public List<DailyReportDto> DispatcherClosedCreditCorporate { get; set; }

        public List<DailyReportDto> DispatcherClosedCredit { get; set; }
        public List<DailyReportDto> DispatcherClosedNoShow { get; set; }

        public List<DailyReportDto> DispatcherClosedCreditCard { get; set; }

        public List<DailyReportDto> DispatcherClosedNonRevenue { get; set; }

        public List<DailyReportDto> DispatcherCancelled { get; set; }

        public IEnumerable<DailyDriverPerformanceDto> DriverReportList { get; set; }

        public IEnumerable<DailyVehiclePerformanceDto> VehicleReportList { get; set; }

        public ReportDto ReportDto { get; set; }

        public DateTime CurrentDate { get; set; }
        public IEnumerable<SelectListItem> Vehicle { get; set; }

        public IEnumerable<SelectListItem> HotelNameList { get; set; }

        public IEnumerable<SelectListItem> DispatcherList { get; set; }

        public IEnumerable<SelectListItem> Driver { get; set; }
        public IEnumerable<SelectListItem> VoucherStatus { get; set; }

        public IEnumerable<SelectListItem> Passenger { get; set; }

        public IEnumerable<SelectListItem> PaymentTypeList { get; set; }

        public IEnumerable<BataReportModel> BataList { get; set; }
        public IEnumerable<SelectListItem> Employee { get; set; }

    }
}