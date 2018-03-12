using Application.Corporates;
using Application.Driver;
using Application.Trips;
using Application.Users;
using Application.Vehicles;
using AutoMapper;
using Domain.Corporates;
using Domain.Driver;
using Domain.DTO;
using Domain.Trips;
using Domain.Users;
using Domain.Vehicles;
using ExportService;
using MyVehicleTrackingSystem.Wings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Controllers
{
    public class ReportsController : Controller
    {
        private ITripService _tripService;
        private readonly IDriverService _driverService;
        private readonly IVehicleService _vehicleService;
        private readonly IUserService _userService;
        private ICorporateService _corporateService;

        private ExcelFileExport exportService = new ExcelFileExport();


        public ReportsController(TripService tripservice, DriverService driverService, VehicleService vehicleService, UserService userService, CorporateService corporateService)
        {
            if (tripservice == null)
            {
                throw new NullReferenceException("tripservice");
            }
            if (driverService == null)
            {
                throw new NullReferenceException("driverService");
            }
            if (vehicleService == null)
            {
                throw new NullReferenceException("vehicleService");
            }
            if (userService == null)
            {
                throw new NullReferenceException("userService");
            }
            if (corporateService == null)
            {
                throw new NullReferenceException("corporateService");
            }
            _corporateService = corporateService;
            _driverService = driverService;
            _vehicleService = vehicleService;
            _tripService = tripservice;
            _userService = userService;
        }
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GenerateReport()
        {
            try
            {
                ReportDto model = new ReportDto()
                {
                    StartDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate(),
                    EndDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate()
                };
                IEnumerable<TripDto> trips = new List<TripDto>();
                ReportViewModel models = new ReportViewModel()
                {

                    ReportList = Mapper.Map<List<DailyReportDto>>(trips).ToList(),
                    ReportDto = model,
                    CurrentDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate(),
                    HotelNameList = GetHotels(),
                    DispatcherList = GetDispatchers(),
                    Driver = GetDriverNames(),
                    Vehicle = GetVehicleNumbers(),
                    VoucherStatus = GetVoucherStatus(),
                    Passenger = GetGuestType(),
                    PaymentTypeList = GetPaymentTypes()

                };
                ViewBag.Content = false;
                return View(models);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult GenerateReport(ReportViewModel model)
        {
            try
            {
                IEnumerable<TripDto> trips = _tripService.GetAllTripsForReport(model.ReportDto).ToList().Where(a => a.IsReopened != true);
                var tripsforreport = _tripService.GetAllTripsForReport(model.ReportDto).GroupBy(a => a.IsReopened).Select(g => g.ToList()).ToList();

                ReportViewModel models = new ReportViewModel()
                {
                    ReportList = Mapper.Map<List<DailyReportDto>>(trips).ToList(),
                    CurrentDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate(),
                    HotelNameList = GetHotels(),
                    DispatcherList = GetDispatchers(),
                    Driver = GetDriverNames(),
                    Vehicle = GetVehicleNumbers(),
                    VoucherStatus = GetVoucherStatus(),
                    Passenger = GetGuestType(),
                    PaymentTypeList = GetPaymentTypes(),
                    ReportDto = model.ReportDto

                };
                TempData["TripReportTemp"] = models;
                ViewBag.Content = true;
                return View(models);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public ActionResult GenerateDriverReport()
        //{
        //    try
        //    {
        //        ReportDto model = new ReportDto()
        //        {
        //            StartDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate(),
        //            EndDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate()
        //        };
        //        IEnumerable<TripDto> trips = _tripService.GetAllTripsForReport(model).ToList();
        //        ReportViewModel models = new ReportViewModel()
        //        {
        //            DriverReportList = Mapper.Map<List<DailyDriverPerformanceDto>>(trips).ToList(),
        //            ReportDto = model,
        //            CurrentDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate(),
        //            Driver = GetDriverNames(),
        //            VoucherStatus = GetVoucherStatus()
        //        };
        //        ViewBag.Content = false;
        //        return View(models);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //[HttpPost]
        //public ActionResult GenerateDriverReport(ReportViewModel model)
        //{
        //    try
        //    {
        //        IEnumerable<TripDto> trips = _tripService.GetAllTripsForReport(model.ReportDto).Where(a => a.IsReopened != true).ToList();
        //        ReportViewModel models = new ReportViewModel()
        //        {
        //            DriverReportList = Mapper.Map<List<DailyDriverPerformanceDto>>(trips).ToList(),
        //            CurrentDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate(),
        //            Driver = GetDriverNames(),
        //            VoucherStatus = GetVoucherStatus(),
        //            ReportDto = model.ReportDto,
        //        };
        //        TempData["DriverReportTemp"] = models;
        //        ViewBag.Content = true;
        //        return View(models);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public ActionResult DriverWiseBataReport()
        {
            try
            {
                ReportDto model = new ReportDto()
                {
                    StartDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate(),
                    EndDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate()
                };
                ReportViewModel models = new ReportViewModel()
                {
                    BataList = new List<BataReportModel>(),
                    CurrentDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate(),
                    Driver = GetDriverNames(),
                    Vehicle = GetVehicleNumbers(),
                    ReportDto = model,
                };
                ViewBag.Content = false;
                return View(models);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult DriverWiseBataReport(ReportViewModel model)
        {
            try
            {
                DateTime startDate;
                DateTime EndDate;
                DateTime.TryParse(model.ReportDto.StartDate.ToLongDateString(), out startDate);
                DateTime.TryParse(model.ReportDto.EndDate.ToLongDateString(), out EndDate);
                model.ReportDto.StartDate = startDate.AddHours(6);
                model.ReportDto.EndDate = EndDate.AddHours(6);

                IEnumerable<TripDto> trips = _tripService.RetrieveDriverWiseBataDetails(model.ReportDto).Where(a => a.IsReopened != true).ToList();
                IEnumerable<BataReportModel> bata = trips.Where(a => a.CustomBata != null || a.TripBata != null).GroupBy(a => a.UpdatedDate.Date).Select(a => new BataReportModel
                {
                    Date = a.Key,
                    BataDetails = a.Select(x => new DailyDriverPerformanceDto
                    {
                        VoucherNumber = x.VoucherNumber,
                        DispatchedHotel = x.DispatchedHotel,
                        Createdby = x.Createdby,
                        Updatedby = x.Updatedby,
                        DriverName = x.DriverName,
                        VehicleNumber = x.VehicleNumber,
                        Packages = x.Packages,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate,
                        EmployeeNumber = x.EmployeeNumber,
                        BataAmount = x.TripBata == null ? 0 : x.TripBata.FirstOrDefault().Amount,
                        BataDescription = x.TripBata == null ? "" : x.TripBata.FirstOrDefault().Description,
                        CustomBataAmount = x.CustomBata == null ? 0 : x.CustomBata.FirstOrDefault().CustomAmount,
                    }).ToList()
                }).ToList();
                ReportViewModel models = new ReportViewModel()
                {
                    DriverReportList = Mapper.Map<List<DailyDriverPerformanceDto>>(trips).ToList(),
                    BataList = bata,
                    CurrentDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate(),
                    Driver = GetDriverNames(),
                    Vehicle = GetVehicleNumbers(),
                    Employee = GetEmployeeNumbers(),
                    ReportDto = model.ReportDto,
                };
                ViewBag.Content = true;
                TempData["DriverReportTemp"] = models;
                return View(models);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult GenerateVehicleReport()
        {
            try
            {
                ReportDto model = new ReportDto()
                {
                    StartDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate(),
                    EndDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate()
                };
                IEnumerable<TripDto> trips = _tripService.GetAllTripsForReport(model).ToList();
                ReportViewModel models = new ReportViewModel()
                {
                    VehicleReportList = Mapper.Map<List<DailyVehiclePerformanceDto>>(trips),
                    CurrentDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate(),
                    ReportDto = model,
                    Vehicle = GetVehicleNumbers(),
                    VoucherStatus = GetVoucherStatus()
                };
                ViewBag.Content = false;
                return View(models);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult GenerateVehicleReport(ReportViewModel model)
        {
            try
            {
                IEnumerable<TripDto> trips = _tripService.GetAllTripsForReport(model.ReportDto).Where(a => a.IsReopened != true).ToList();
                ReportViewModel models = new ReportViewModel()
                {
                    VehicleReportList = Mapper.Map<List<DailyVehiclePerformanceDto>>(trips),
                    CurrentDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate(),
                    Vehicle = GetVehicleNumbers(),
                    VoucherStatus = GetVoucherStatus(),
                    ReportDto = model.ReportDto
                };
                TempData["VehicleReportTemp"] = models;
                ViewBag.Content = true;
                return View(models);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DispatcherReport()
        {
            try
            {
                ReportDto model = new ReportDto()
                {
                    StartDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate(),
                    EndDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate()
                };
                ReportViewModel models = new ReportViewModel()
                {
                    DispatcherClosedCash = new List<DailyReportDto>(),
                    DispatcherClosedCreditGuest = new List<DailyReportDto>(),
                    DispatcherClosedCreditStaff = new List<DailyReportDto>(),
                    DispatcherClosedCreditNoShow = new List<DailyReportDto>(),
                    DispatcherClosedCreditCorporate = new List<DailyReportDto>(),
                    DispatcherClosedCreditCard = new List<DailyReportDto>(),
                    DispatcherClosedNonRevenue = new List<DailyReportDto>(),
                    DispatcherCancelled = new List<DailyReportDto>(),
                    DispatcherClosedCredit = new List<DailyReportDto>(),
                    DispatcherClosedNoShow = new List<DailyReportDto>(),
                    CurrentDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate(),
                    ReportDto = model

                };
                ViewBag.Content = false;
                return View(models);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult DispatcherReport(ReportDto model)
        {
            try
            {
                model.Dispatcher = System.Web.HttpContext.Current.User.Identity.Name;
                ReportViewModel models = new ReportViewModel();
                IEnumerable<TripDto> trips = _tripService.GetAllTripsForReport(model).Where(a => a.IsReopened != true).ToList();

                models.DispatcherClosedCash = Mapper.Map<List<DailyReportDto>>(trips.Where(a => a.Status.Equals("Closed") && a.PaymentType.Equals("Cash")));
                models.DispatcherClosedCreditGuest = Mapper.Map<List<DailyReportDto>>(trips.Where(a => a.Status.Equals("Closed") && a.PaymentType == "Credit" && a.PaymentCategory == "Hotel Billing Guest"));
                models.DispatcherClosedCreditStaff = Mapper.Map<List<DailyReportDto>>(trips.Where(a => a.Status.Equals("Closed") && a.PaymentType == "Credit" && a.PaymentCategory == "Hotel Billing Staff"));
                models.DispatcherClosedCreditNoShow = Mapper.Map<List<DailyReportDto>>(trips.Where(a => a.Status.Equals("Closed") && a.PaymentType == "Credit" && a.PaymentCategory == "No Show"));
                models.DispatcherClosedCreditCorporate = Mapper.Map<List<DailyReportDto>>(trips.Where(a => a.Status.Equals("Closed") && a.PaymentType == "Credit" && a.PaymentCategory == "Direct Credit Corporate"));
                models.DispatcherClosedCredit = Mapper.Map<List<DailyReportDto>>(trips.Where(a => a.Status.Equals("Closed") && a.PaymentType == "Credit" && a.PaymentCategory == null));
                models.DispatcherClosedNoShow = Mapper.Map<List<DailyReportDto>>(trips.Where(a => a.Status.Equals("Closed") && a.PaymentType == "No Show" && a.PaymentCategory == null));
                models.DispatcherClosedCreditCard = Mapper.Map<List<DailyReportDto>>(trips.Where(a => a.Status.Equals("Closed") && a.PaymentType == "Credit Card"));
                models.DispatcherClosedNonRevenue = Mapper.Map<List<DailyReportDto>>(trips.Where(a => a.Status.Equals("Closed") && a.PaymentType == "Non Revenue"));
                models.DispatcherCancelled = Mapper.Map<List<DailyReportDto>>(trips.Where(a => a.Status.Equals("Cancelled"))).ToList();

                models.ReportList = new List<DailyReportDto>();
                models.ReportList.AddRange(models.DispatcherClosedCash.ToList());
                models.ReportList.AddRange(models.DispatcherClosedCreditGuest.ToList());
                models.ReportList.AddRange(models.DispatcherClosedCreditStaff.ToList());
                models.ReportList.AddRange(models.DispatcherClosedCreditNoShow.ToList());
                models.ReportList.AddRange(models.DispatcherClosedCreditCorporate.ToList());
                models.ReportList.AddRange(models.DispatcherClosedCreditCard.ToList());
                models.ReportList.AddRange(models.DispatcherClosedNonRevenue.ToList());
                models.ReportList.AddRange(models.DispatcherClosedCredit.ToList());
                models.ReportList.AddRange(models.DispatcherClosedNoShow.ToList());
                models.ReportList.AddRange(models.DispatcherCancelled.ToList());

                models.CurrentDate = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate();
                models.ReportDto = model;
                TempData["TripReportTemp"] = models;
                ViewBag.Content = true;
                return View(models);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult GeneratePDF(string viewName)
        {
            //return new Rotativa.ActionAsPdf(viewName);
            return RedirectToAction(viewName);
        }

        public void ExportToExcel()
        {
            ReportViewDto report = Mapper.Map<ReportViewDto>(TempData["TripReportTemp"]);
            exportService.ExportTripReportToExcel(report, Response);
        }

        public void ExportToExcelDriverReport()
        {
            ReportViewDto report = Mapper.Map<ReportViewDto>(TempData["DriverReportTemp"]);
            exportService.ExportDriverReportToExcel(report, Response);
        }
        public void ExportToExcelVehicleReport()
        {
            ReportViewDto report = Mapper.Map<ReportViewDto>(TempData["VehicleReportTemp"]);
            exportService.ExportVehicleReportToExcel(report, Response);
        }

        [HttpGet]
        public JsonResult LoadDrivers()
        {
            return Json(GetDriverNames(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadVehicles()
        {
            return Json(GetVehicleNumbers(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadDispatchers()
        {
            return Json(GetDispatchers(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult loadCorporateList()
        {
            return Json(GetCorporateList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadSettlementCategory()
        {
            List<SelectListItem> category = CustomDataHelper.DataHelper.GetPaymentCategories();
            category.Insert(0, new SelectListItem { Value = String.Empty, Text = "All", Selected = true });
            return Json(category, JsonRequestBehavior.AllowGet);
        }
        private IEnumerable<SelectListItem> GetPaymentTypes()
        {
            List<SelectListItem> payment = CustomDataHelper.DataHelper.GetPaymentTypes();
            payment.Insert(0, new SelectListItem { Value = String.Empty, Text = "All", Selected = true });
            return payment;
        }
        private IEnumerable<SelectListItem> GetHotels()
        {
            List<SelectListItem> hotels = CustomDataHelper.DataHelper.GetHotels();
            hotels.Insert(0, new SelectListItem { Value = String.Empty, Text = "All", Selected = true });
            return hotels;
        }
        private IEnumerable<SelectListItem> GetVoucherStatus()
        {
            List<SelectListItem> vouchers = CustomDataHelper.DataHelper.GetVoucherStatus();
            vouchers.Insert(0, new SelectListItem { Value = String.Empty, Text = "All", Selected = true });
            return vouchers;
        }

        private IEnumerable<SelectListItem> GetGuestType()
        {
            List<SelectListItem> guest = CustomDataHelper.DataHelper.GetGuestType();
            guest.Insert(0, new SelectListItem { Value = String.Empty, Text = "Both", Selected = true });
            return guest;
        }
        private IEnumerable<SelectListItem> GetCorporateList()
        {
            IEnumerable<Corporate> corporates = _corporateService.RetrieveCorporate().Where(a => a.IsDeleted.Equals(false)).ToList();
            List<SelectListItem> corporateList = corporates.Select(x => new SelectListItem
            {
                Value = x.CorporateName.ToString(),
                Text = x.CorporateName.ToString()
            }).ToList();
            corporateList.Insert(0, new SelectListItem { Value = String.Empty, Text = "All", Selected = true });
            return new SelectList(corporateList, "Value", "Text");
        }
        private IEnumerable<SelectListItem> GetVehicleNumbers()
        {
            IEnumerable<Vehicle> vehicle = _vehicleService.GetAllVehicles();
            List<SelectListItem> vehi = vehicle.Select(x => new SelectListItem
            {
                Value = x.VehicleId.ToString(),
                Text = x.VehicleNumber.ToString()
            }).ToList();
            vehi.Insert(0, new SelectListItem { Value = "0", Text = "All Vehicles", Selected = true });
            return new SelectList(vehi, "Value", "Text");
        }

        private IEnumerable<SelectListItem> GetDriverNames()
        {
            IEnumerable<Driver> drivers = _driverService.GetAllDrivers();
            List<SelectListItem> driver = drivers.Select(x => new SelectListItem
            {
                Value = x.DriverId.ToString(),
                Text = x.Name,
            }).ToList();
            driver.Insert(0, new SelectListItem { Value = "0", Text = "All Drivers", Selected = true });
            return new SelectList(driver, "Value", "Text");
        }

        private IEnumerable<SelectListItem> GetDispatchers()
        {
            IEnumerable<User> user = _userService.GetAllUsers().Where(a => a.RoleId == 2);
            List<SelectListItem> dispatcher = user.Select(x => new SelectListItem
            {
                Value = (x.FirstName + " " + x.LastName).ToString(),
                Text = (x.FirstName + " " + x.LastName).ToString()
            }).ToList();
            dispatcher.Insert(0, new SelectListItem { Value = String.Empty, Text = "All Dispatchers", Selected = true });
            return new SelectList(dispatcher, "Value", "Text");
        }

        private IEnumerable<SelectListItem> GetEmployeeNumbers()
        {
            IEnumerable<Driver> drivers = _driverService.GetAllDrivers();
            List<SelectListItem> driver = drivers.Select(x => new SelectListItem
            {
                Value = x.EPFNumber.ToString(),
                Text = x.EPFNumber.ToString()
            }).ToList();
            driver.Insert(0, new SelectListItem { Value = String.Empty, Text = "All Employee Numbers", Selected = true });
            return new SelectList(driver, "Value", "Text");
        }
    }
}
