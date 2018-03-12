using Application.BataRates;
using Application.Corporates;
using Application.Driver;
using Application.Trips;
using Application.UserLog;
using Application.Vehicles;
using DBStorage.GPS;
using Domain.BataRates;
using Domain.Corporates;
using Domain.Driver;
using Domain.DTO;
using Domain.GPS;
using Domain.Trips;
using Domain.UserLog;
using Domain.Vehicles;
using MyVehicleTrackingSystem.Wings.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;
using Application.Customers;

namespace MyVehicleTrackingSystem.Wings.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService _tripService;
        private readonly IDriverService _driverService;
        private readonly IVehicleService _vehicleService;
        private readonly IVehicleRateService _vehicleRateService;
        private readonly IPreDefineTripService _preDefineTripService;
        private readonly IBataRateService _bataRateService;
        private readonly IPackageListService _packageListService;
        private readonly ITripBataService _tripBataService;
        private readonly IUserLogService _logUserService;
        private readonly ICorporateService _corporateService;
        private readonly ICustomBataService _custombataService;
        private readonly ICustomerService _customerService;

        protected IGpsRepository _gpsClientService = new GpsRepository();
        public TripsController(TripService tripService, DriverService driverService, VehicleService vehicleService, VehicleRateService vehicleRateService, PreDefineTripService preDefineTripService, BataRateService bataRateService, PackageListService packageListService, TripBataService tripBataService, UserLogService logUserService, CorporateService corporateService, CustomBataService custombataService, CustomerService customerService)
        {
            _tripService = tripService;
            _driverService = driverService;
            _vehicleService = vehicleService;
            _vehicleRateService = vehicleRateService;
            _preDefineTripService = preDefineTripService;
            _bataRateService = bataRateService;
            _packageListService = packageListService;
            _tripBataService = tripBataService;
            _logUserService = logUserService;
            _corporateService = corporateService;
            _custombataService = custombataService;
            _customerService = customerService;
        }
        // GET: Trips
        public ActionResult Index(string searchString)
        {
            try
            {
                IEnumerable<TripViewModel> models = new Collection<TripViewModel>();
                IEnumerable<TripDto> trips = _tripService.RetrieveTrips(true, null, false, null, null, searchString);
                if (trips != null)
                {
                    models = AutoMapper.Mapper.Map<IEnumerable<TripViewModel>>(trips);
                }
                return View(models);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ClosedIndex(string searchString, int? page = 1)
        {
            try
            {
                if (searchString != null)
                {
                    page = 1;
                    this.ViewBag.SearchData = searchString;
                }
                int pageSize = 20;
                int pageNumber = (page ?? 1);
                var trips = _tripService.RetrieveTripPage(false, false, false, page, searchString, false);
                IEnumerable<TripViewModel> models = null;
                this.ViewBag.Page = page;
                this.ViewBag.MaxPage = (trips.ItemCount / pageSize) - (trips.ItemCount % pageSize == 0 ? 1 : 0);
                if (trips != null)
                {
                    models = AutoMapper.Mapper.Map<IEnumerable<TripViewModel>>(trips.trips).OrderByDescending(t => t.UpdatedDate).Where(a => a.IsReopened != true);
                }
                return View(models);
                // PagedList<TripViewModel> models = null;
                //var trips = _tripService.RetrieveTrips(hotelName, false, false, false, null, null, searchString).OrderByDescending(t => t.UpdatedDate).Take(pageSize).ToList();

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public ActionResult RemovedIndex(string searchString, int? page = 1)
        {
            try
            {
                if (searchString != null)
                {
                    page = 1;
                    this.ViewBag.SearchData = searchString;
                }
                int pageSize = 20;
                int pageNumber = (page ?? 1);
                var trips = _tripService.RetrieveTripPage(false, true, false, page, searchString, false);
                IEnumerable<TripViewModel> models = null;
                this.ViewBag.Page = page;
                this.ViewBag.MaxPage = (trips.ItemCount / pageSize) - (trips.ItemCount % pageSize == 0 ? 1 : 0);
                if (trips != null)
                {
                    models = AutoMapper.Mapper.Map<IEnumerable<TripViewModel>>(trips.trips).OrderByDescending(t => t.UpdatedDate);
                }
                return View(models);
                //PagedList<TripViewModel> models = null;
                //var trips = _tripService.RetrieveTrips(hotelName, false, true, false, null, null, searchString).OrderByDescending(t => t.UpdatedDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetPackageFee(int packageId)
        {
            PreDefineTrip package = _preDefineTripService.GetPreDefineTripById(packageId);
            return Json(package.Rate, JsonRequestBehavior.AllowGet);
        }

        // GET: Trips/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                TripViewModel models = new TripViewModel();
                Trip trip = _tripService.GetAllTripDetailsById(id);
                if (trip != null)
                {
                    models = AutoMapper.Mapper.Map<TripViewModel>(trip);
                }
                return View(models);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Trips/Create
        public ActionResult Create()
        {
            try
            {
                TripViewModel models = new TripViewModel();
                models.Driver = GetDriverNames();
                models.Vehicle = GetVehicleNumbers();
                // models.Trips = GetPreDefined();
                models.PaymentTypeList = CustomDataHelper.DataHelper.GetPaymentTypes();
                return View(models);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Trips/Create
        [HttpPost]
        public async Task<ActionResult> Create(TripViewModel TripData)
        {
            try
            {
                string DispatcherName = System.Web.HttpContext.Current.User.Identity.Name;
                string message = "";
                int insertedTripId = 0;
                string VoucherNumber = "";
                Trip trip = new Trip();
                if (TripData.VehicleId != 0)
                {
                    if (TripData.DriverId != 0)
                    {
                        if (_tripService.VehicleAvailability(TripData.VehicleId))
                        {
                            if (_tripService.DriverAvailability(TripData.DriverId))
                            {
                                int customerId = TripData.Customer != null ? _customerService.GetCustomerId(TripData.Customer.PhoneNumber) : 0;
                                TripData.Customer = null;
                                if (customerId != 0)
                                {
                                    TripData.CustomerId = customerId;
                                    if (TripData != null)
                                    {
                                        trip = AutoMapper.Mapper.Map<Trip>(TripData);
                                        trip.IsOpen = true;
                                        //trip.DispatchedHotel = Session["SelectedHotel"].ToString();
                                        trip.Createdby = DispatcherName;
                                        trip.PaymentDateTime = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate();
                                        trip.TimeIn = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate();
                                        trip.TimeOut = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate();
                                        trip.VoucherNumber = GenarateVoucherNumber();
                                        VoucherNumber = trip.VoucherNumber;
                                    }

                                    //upadte vehicle mete readings
                                    await Task.Run(() => _vehicleService.UpdateMeterReading(trip.VehicleId, Convert.ToInt32(TripData.MeterReadingOut)));

                                    //update vehicle is unavailable
                                    List<int> vehicle = new List<int>()
                              {
                                 trip.VehicleId
                              };
                                    await Task.Run(() => _vehicleService.UpdateVehicleUnAvailable(vehicle));

                                    //update driver is unavailable
                                    List<int> driver = new List<int>()
                               {
                                 trip.DriverId
                               };
                                    await Task.Run(() => _driverService.UpdateDriverUnAvailable(driver));


                                    if (trip != null)
                                    {
                                        //gps data collection
                                        if (TripData.VehicleNumber != null)
                                        {
                                            GpsVehicleDetailsDto gpsDetails = await _gpsClientService.GpsMeterReading(TripData.VehicleNumber);
                                            if (gpsDetails != null)
                                            {
                                                trip.MeterReadingInGps = Convert.ToInt32(!string.IsNullOrEmpty(gpsDetails.meter_reading));
                                                trip.MeterReadingInStatus = gpsDetails.error;
                                                trip.MeterReadingInGap = (trip.MeterReadingInGps - trip.MeterReadingIn);
                                            }
                                        }
                                        //save trip details
                                        insertedTripId = await Task.Run(() => _tripService.SaveTripDetails(trip));
                                    }

                                    if (TripData.PackageIds != null)
                                    {
                                        foreach (int id in TripData.PackageIds)
                                        {
                                            PreDefineTrip predefTrip = _preDefineTripService.GetPreDefineTripById(id);
                                            if (predefTrip != null)
                                            {
                                                PackagesList package = new PackagesList();
                                                package.TripId = insertedTripId;
                                                package.PreDefineTripName = predefTrip.PreDefineTripName;
                                                package.Rate = predefTrip.Rate;

                                                await Task.Run(() => _packageListService.SavePackage(package));
                                                await Task.Run(() => _tripService.UpdatePackageCost(insertedTripId, predefTrip.Rate));
                                            }
                                        }
                                    }
                                    message = "Trip successfully created.";
                                }
                                else
                                {
                                    message = "Invalid customer(Save, if new customer.)";
                                }
                            }
                            else
                            {
                                message = "Driver is already assigned to another trip";
                            }
                        }
                        else
                        {
                            message = "Vehicle is already assigned to another trip";
                        }
                    }
                    else
                    {
                        message = "Driver cannot be null";
                    }
                }
                else
                {
                    message = "Vehicle cannot be null";
                }

                return Json(new { VoucherNumber, message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Create", "Trips");
            }
        }


        public void LogUser(int tripid, DateTime created, DateTime modified)
        {
            string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
            //string[] computer_name = System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_ADDR"]).HostName.Split(new Char[] { '.' });

            string user = System.Web.HttpContext.Current.User.Identity.Name;
            string browser = System.Web.HttpContext.Current.Request.Browser.Browser;
            string machine = Environment.MachineName;
            string version = Environment.OSVersion.VersionString.ToString();
            UserLog log = new UserLog()
            {
                LoggedMachineName = ip,
                LoggedUser = user,
                Version = browser,
                TripId = tripid,
                Created = created,
                Modified = modified
            };
            _logUserService.LogUserEvent(log);
        }
        public JsonResult GetVoucherData(string voucherNo)
        {
            try
            {
                Trip newTrip = _tripService.GetTripDetailsToVoucher(voucherNo);
                VoucherPrintModel models = new VoucherPrintModel();
                if (newTrip != null)
                {
                    models = AutoMapper.Mapper.Map<VoucherPrintModel>(newTrip);
                }
                models.DriverName = newTrip.DriverList.Name;
                models.VehicleNo = newTrip.VehicleList.VehicleNumber;
                models.TimeOut = newTrip.TimeOut.ToString(); //h:mm tt
                return Json(models, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Trips/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                TripViewModel models = new TripViewModel();
                DateTime now = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate();

                Trip trip = _tripService.GetAllTripDetailsById(id);
                if (trip != null)
                {
                    models = AutoMapper.Mapper.Map<TripViewModel>(trip);
                }
                models.TimeIn = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate();
                TimeSpan span = (now - models.TimeOut);
                String.Format("{0} days, {1} hours, {2} minutes", span.Days, span.Hours, span.Minutes);
                models.TripDuration = span.Days.ToString() + " d " + span.Hours.ToString() + " h " + span.Minutes.ToString() + " m ";
                //models.Trips = GetPreDefined();
                models.Passenger = GetGuestType();
                models.PaymentTypeList = CustomDataHelper.DataHelper.GetPaymentTypes();
                models.PaymentCategoryList = CustomDataHelper.DataHelper.GetPaymentCategories();
                models.VehicleRates = AutoMapper.Mapper.Map<IEnumerable<VehicleRateDto>>(_vehicleRateService.GetAllVehicleRates());
                return View(models);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: Trips/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(TripViewModel model)
        {
            try
            {
                string DispatcherName = System.Web.HttpContext.Current.User.Identity.Name;
                string message = "";
                Trip trip = new Trip();
                if (model.VehicleId != 0)
                {
                    if (model.DriverId != 0)
                    {
                        if (model.MeterReadingIn > 0)
                        {
                            if (model.BataRateId != 0)
                            {
                                BataRate bataRate = _bataRateService.GetBataRateById(model.BataRateId);
                                if (bataRate != null)
                                {
                                    TripBata bataDetails = new TripBata();
                                    bataDetails.TripId = model.TripId;
                                    bataDetails.Description = bataRate.Description;
                                    bataDetails.Amount = bataRate.Amount;
                                    if (_tripBataService.IsBattaNotExists(model.TripId))
                                    {
                                        _tripBataService.SaveBataData(bataDetails);
                                    }
                                }
                            }

                            //update vehicle is available
                            List<int> vehicle = new List<int>()
                               {
                                 model.VehicleId
                               };
                            await Task.Run(() => _vehicleService.UpdateVehicleAvailable(vehicle));

                            //update driver is available
                            List<int> driver = new List<int>()
                              {
                                model.DriverId
                              };
                            await Task.Run(() => _driverService.UpdateDriverAvailable(driver));

                            if (model != null)
                            {
                                trip = AutoMapper.Mapper.Map<Trip>(model);
                                trip.Updatedby = DispatcherName;
                                trip.TripMileage = (trip.MeterReadingIn - trip.MeterReadingOut);

                                if (model.PackageIds != null && model.PackageIds.Count() > 0)
                                {
                                    foreach (int pid in model.PackageIds)
                                    {
                                        PreDefineTrip predefTrip = _preDefineTripService.GetPreDefineTripById(pid);
                                        if (predefTrip != null)
                                        {
                                            PackagesList package = new PackagesList();
                                            package.TripId = model.TripId;
                                            package.PreDefineTripName = predefTrip.PreDefineTripName;
                                            package.Rate = predefTrip.Rate;
                                            if (_packageListService.IsPackageExists(model.TripId, predefTrip.PreDefineTripName))
                                            {
                                                await Task.Run(() => _packageListService.SavePackage(package));
                                            }
                                        }
                                    }
                                }
                                //gps data collection
                                if (model.VehicleNumber != null)
                                {
                                    GpsVehicleDetailsDto gpsDetails = await _gpsClientService.GpsMeterReading(model.VehicleNumber);
                                    if (gpsDetails != null)
                                    {
                                        trip.MeterReadingInGps = Convert.ToInt32(!string.IsNullOrEmpty(gpsDetails.meter_reading));
                                        trip.MeterReadingInStatus = gpsDetails.error;
                                        trip.MeterReadingInGap = (trip.MeterReadingInGps - trip.MeterReadingIn);
                                    }
                                }

                                //update vehicle meter reading
                                await Task.Run(() => _vehicleService.UpdateMeterReading(model.VehicleId, Convert.ToInt32(model.MeterReadingIn)));
                                //save trip details
                                await Task.Run(() => _tripService.EditTrip(model.TripId, trip));

                                await Task.Run(() => _tripService.ArchiveTripById(model.TripId));
                            }
                        }
                        else
                        {
                            message = "Error in meter reading in";
                        }
                    }
                    else
                    {
                        message = "Driver cannot be null";
                    }
                }
                else
                {
                    message = "Vehicle cannot be null";
                }
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult DeletePackageById(int packageId)
        {
            try
            {
                PackagesList package = _packageListService.DeletePackageById(packageId);
                _tripService.DeletePackageCost(package.TripId, package.Rate);
                return Json(package.Rate, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
        public async Task<JsonResult> RemoveVoucher(int id, string remarks)
        {
            try
            {
                string dispatcherName = System.Web.HttpContext.Current.User.Identity.Name;
                string message = "";
                if (id != 0)
                {
                    Trip removedTrip = await Task.Run(() => _tripService.RemoveVoucher(id, remarks, dispatcherName));

                    //update vehicle is available
                    List<int> vehicle = new List<int>()
                  {
                    removedTrip.VehicleId
                  };
                    await Task.Run(() => _vehicleService.UpdateVehicleAvailable(vehicle));

                    //update driver is available
                    List<int> driver = new List<int>()
                  {
                    removedTrip.DriverId
                  };
                    await Task.Run(() => _driverService.UpdateDriverAvailable(driver));
                }
                else
                {
                    message = "Voucher number cannot be null";
                }
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<JsonResult> SyncGps(string vehiNum)
        {
            try
            {
                var gpsMeterReading = await _gpsClientService.GpsMeterReading(vehiNum);
                return Json(gpsMeterReading, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult BataEditorTripIndex(string searchString, int? page = 1)
        {
            try
            {
                if (searchString != null)
                {
                    page = 1;
                    this.ViewBag.SearchData = searchString;
                }
                int pageSize = 20;
                int pageNumber = (page ?? 1);
                var trips = _tripService.RetrieveTripPage(false, false, false, page, searchString, false);
                IEnumerable<TripViewModel> models = null;
                this.ViewBag.Page = page;
                this.ViewBag.MaxPage = (trips.ItemCount / pageSize) - (trips.ItemCount % pageSize == 0 ? 1 : 0);
                if (trips != null)
                {
                    models = AutoMapper.Mapper.Map<IEnumerable<TripViewModel>>(trips.trips).OrderByDescending(t => t.UpdatedDate);
                }
                return View(models);
                // PagedList<TripViewModel> models = null;
                //var trips = _tripService.RetrieveTrips(hotelName, false, false, false, null, null, searchString).OrderByDescending(t => t.UpdatedDate).Take(pageSize).ToList();

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public ActionResult BataEditorUpdate(int id)
        {
            try
            {
                TripViewModel models = new TripViewModel();
                Trip trip = _tripService.GetAllTripDetailsById(id);
                if (trip != null)
                {
                    models = AutoMapper.Mapper.Map<TripViewModel>(trip);
                }
                models.Bata = GetBataData();

                if (models.TripBata.Count > 0)
                {
                    TripBataDto tripBata = models.TripBata.Where(a => a.IsDeleted.Equals(false)).LastOrDefault();
                    if (tripBata != null)
                    {
                        BataRate bata = _bataRateService.GetAllBataRates().Where(a => a.Description == tripBata.Description).LastOrDefault();
                        if (bata != null)
                        {
                            models.BataRateId = bata.BataId;
                            models.BataRate = bata.Amount.ToString();
                        }
                    }
                }
                if (models.CustomBata.Count > 0)
                {
                    CustomBataDto customBata = models.CustomBata.Where(a => a.IsDeleted.Equals(false)).FirstOrDefault();
                    if (customBata != null)
                    {
                        models.AdditionalAmount = customBata.CustomAmount;
                    }
                }
                return View(models);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult BataEditorUpdate(TripViewModel model)
        {
            try
            {
                if (model.AdditionalAmount != 0)
                {
                    CustomBata retrieveBata = _custombataService.RetrieveCustomBataByTripId(model.TripId);
                    if (retrieveBata != null)
                    {
                        retrieveBata.TripId = model.TripId;
                        retrieveBata.CustomAmount = model.AdditionalAmount;
                        retrieveBata.IsDeleted = false;
                        _custombataService.SaveCustomBataData(retrieveBata);
                    }
                    else
                    {
                        CustomBata customBata = new CustomBata()
                        {
                            TripId = model.TripId,
                            CustomAmount = model.AdditionalAmount
                        };
                        _custombataService.SaveCustomBataData(customBata);
                    }
                }
                if (model.BataRateId != 0)
                {
                    if (model.BataIdOld != model.BataRateId)
                    {
                        if (!_tripBataService.IsBattaNotExists(model.TripId))
                        {
                            _tripBataService.RemoveBata(model.TripId);

                            BataRate bataRate = _bataRateService.GetBataRateById(model.BataRateId);
                            if (bataRate != null)
                            {
                                TripBata bataDetails = new TripBata()
                                {
                                    TripId = model.TripId,
                                    Description = bataRate.Description,
                                    Amount = bataRate.Amount,
                                    IsDeleted = false
                                };
                                _tripBataService.SaveBataData(bataDetails);
                            }
                        }
                        else
                        {
                            BataRate bataRate = _bataRateService.GetBataRateById(model.BataRateId);
                            if (bataRate != null)
                            {
                                TripBata bataDetails = new TripBata()
                                {
                                    TripId = model.TripId,
                                    Description = bataRate.Description,
                                    Amount = bataRate.Amount,
                                    IsDeleted = false
                                };
                                _tripBataService.SaveBataData(bataDetails);
                            }
                        }
                    }
                }
                else
                {
                    if (!_tripBataService.IsBattaNotExists(model.TripId))
                    {
                        _tripBataService.RemoveBata(model.TripId);
                    }
                }
                _tripService.UpdatePendingTrip(model.TripId);
                return RedirectToAction("BataEditorTripIndex", "Trips");
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult BataAdminTripIndex(string searchString, int? page = 1)
        {
            try
            {
                if (searchString != null)
                {
                    page = 1;
                    this.ViewBag.SearchData = searchString;
                }
                int pageSize = 20;
                int pageNumber = (page ?? 1);
                var trips = _tripService.RetrieveTripPage(false, false, false, page, searchString, true);
                IEnumerable<TripViewModel> models = null;
                this.ViewBag.Page = page;
                this.ViewBag.MaxPage = (trips.ItemCount / pageSize) - (trips.ItemCount % pageSize == 0 ? 1 : 0);
                if (trips != null)
                {
                    models = AutoMapper.Mapper.Map<IEnumerable<TripViewModel>>(trips.trips).OrderByDescending(t => t.UpdatedDate);
                }
                return View(models);
                // PagedList<TripViewModel> models = null;
                //var trips = _tripService.RetrieveTrips(hotelName, false, false, false, null, null, searchString).OrderByDescending(t => t.UpdatedDate).Take(pageSize).ToList();

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public ActionResult BataAdministratorUpdate(int id)
        {
            try
            {
                TripViewModel models = new TripViewModel();
                Trip trip = _tripService.GetAllTripDetailsById(id);
                if (trip != null)
                {
                    models = AutoMapper.Mapper.Map<TripViewModel>(trip);
                }
                models.Bata = GetBataData();

                if (models.TripBata.Count > 0)
                {
                    if (models.TripBata.LastOrDefault().IsDeleted.Equals(false))
                    {
                        BataRate bata = _bataRateService.GetAllBataRates().Where(a => a.Description == models.TripBata.LastOrDefault().Description).LastOrDefault();
                        if (bata != null)
                        {
                            models.BataRateId = bata.BataId;
                            models.BataRate = bata.Amount.ToString();
                        }
                    }
                }
                return View(models);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ApproveBata(int id)
        {
            try
            {
                _tripService.UpdateBataApproved(id);
                return RedirectToAction("BataAdminTripIndex", "Trips");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult RejectBata(int id)
        {
            try
            {
                TripBata bataDetails = _tripBataService.RetrieveLastDeletedBataById(id);
                if (bataDetails != null)
                {
                    //remove all trip bata
                    _tripBataService.RemoveBata(id);
                    //revert to old package
                    _tripBataService.RevertToOldBata(bataDetails.BataRateId);
                }
                CustomBata custombataDetails = _custombataService.RetrieveCustomBataByTripId(id);
                if (custombataDetails != null)
                {
                    //remove custom bata details
                    _custombataService.RemoveCustomBata(id);
                }
                _tripService.UpdateBataRejected(id);
                return RedirectToAction("BataAdminTripIndex", "Trips");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public JsonResult LoadPackages(string data)
        {
            return Json(GetPreDefined(data), JsonRequestBehavior.AllowGet);
        }

        public string GenarateVoucherNumber()
        {
            try
            {
                int Number = _tripService.GenarateVoucherNumber();
                //string VoucherNumber = Session["SelectedHotel"].ToString() + "-V" + Number.ToString().PadLeft(9, '0');
                string VoucherNumber = "LR" + "-V" + Number.ToString().PadLeft(9, '0');
                return VoucherNumber;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public JsonResult LoadVehicleDataByNo(int vehiId)
        {
            try
            {
                Vehicle vehicle = _vehicleService.GetVehicleDetailById(vehiId);
                return Json(vehicle, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        public JsonResult LoadDriverDataByNo(int driverId)
        {
            try
            {
                Driver driver = _driverService.GetDriverById(driverId);
                return Json(driver, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public JsonResult LoadVehicleModels(string vehi)
        {
            try
            {
                Vehicle vehicle = _vehicleService.GetVehicleModels(vehi);
                return Json(vehicle, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public JsonResult LoadBataRates()
        {
            return Json(GetBataData(), JsonRequestBehavior.AllowGet);
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
        public JsonResult LoadSettlementCategory()
        {
            return Json(GetSettlementCategory(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult loadCorporateList()
        {
            return Json(GetCorporateList(), JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<SelectListItem> GetSettlementCategory()
        {
            List<SelectListItem> settlementCategory = CustomDataHelper.DataHelper.GetPaymentCategories();
            settlementCategory.Insert(0, new SelectListItem { Value = "0", Text = "Please Select", Selected = true });
            return settlementCategory;
        }
        private IEnumerable<SelectListItem> GetGuestType()
        {
            List<SelectListItem> payment = CustomDataHelper.DataHelper.GetGuestType();
            payment.Insert(0, new SelectListItem { Value = "0", Text = "Please Select", Selected = true });
            return payment;
        }

        private IEnumerable<SelectListItem> GetCorporateList()
        {
            List<Corporate> corporates = _corporateService.RetrieveCorporate().Where(a => a.IsDeleted.Equals(false)).ToList();
            List<SelectListItem> corporateList = corporates.Select(x => new SelectListItem
            {
                Value = x.CorporateName.ToString(),
                Text = x.CorporateName.ToString()
            }).ToList();
            corporateList.Insert(0, new SelectListItem { Value = "0", Text = "Please Select", Selected = true });
            return new SelectList(corporateList, "Value", "Text");
        }
        private IEnumerable<SelectListItem> GetDriverNames()
        {
            List<Driver> drivers = _driverService.GetAllDrivers().Where(a => a.IsAvailable.Equals(false)).ToList();
            List<SelectListItem> driver = drivers.Select(x => new SelectListItem
            {
                Value = x.DriverId.ToString(),
                Text = x.Name,
            }).ToList();
            driver.Insert(0, new SelectListItem { Value = "0", Text = "Please Select", Selected = true });
            return new SelectList(driver, "Value", "Text");
        }

        private IEnumerable<SelectListItem> GetVehicleNumbers()
        {
            List<Vehicle> vehicle = _vehicleService.GetAllVehicles().Where(a => a.IsAvailable.Equals(false)).ToList();
            List<SelectListItem> vehi = vehicle.Select(x => new SelectListItem
            {
                Value = x.VehicleId.ToString(),
                Text = x.VehicleNumber.Replace("-", " ").ToString()
            }).ToList();
            vehi.Insert(0, new SelectListItem { Value = "0", Text = "Please Select", Selected = true });
            return new SelectList(vehi, "Value", "Text");
        }

        private IEnumerable<SelectListItem> GetPerKMPackage()
        {
            List<VehicleRate> vehicle = _vehicleRateService.GetAllVehicleRates().ToList();
            IEnumerable<SelectListItem> vehi = vehicle.Select(x => new SelectListItem
            {
                Value = x.VehicleRateId.ToString(),
                //Text = (x.DistanceType + "(" + x.VehicleType + "-" + x.Rate + ")").ToString()
            });
            return new SelectList(vehi, "Value", "Text");
        }

        private IEnumerable<SelectListItem> GetPreDefined(string type)
        {
            List<PreDefineTrip> vehicle = _preDefineTripService.GetAllPreDefineTrip().Where(a => a.TripType.Equals(type)).ToList();
            IEnumerable<SelectListItem> vehi = vehicle.Select(x => new SelectListItem
            {
                Value = x.PreDefineTripId.ToString(),
                Text = x.PreDefineTripName.ToString()
            });
            return new SelectList(vehi, "Value", "Text");
        }

        private IEnumerable<SelectListItem> GetBataData()
        {
            List<BataRate> bata = _bataRateService.GetAllBataRates().ToList();
            List<SelectListItem> b = bata.Select(x => new SelectListItem
            {
                Value = x.BataId.ToString(),
                Text = x.Description.ToString()
            }).ToList();
            b.Insert(0, new SelectListItem { Value = "0", Text = " ", Selected = true });
            return new SelectList(b, "Value", "Text");
        }
        public ActionResult InvoicePrint(string voucherNo)
        {
            int y = 225;
            Trip newTrip = _tripService.GetTripDetailsToVoucher(voucherNo);
            TripViewModel models = new TripViewModel();
            if (newTrip != null)
            {
                models = AutoMapper.Mapper.Map<TripViewModel>(newTrip);
            }
            PrintDocument pd = new PrintDocument();
            PaperSize paperSize = new PaperSize();
            pd.PrintPage += (sender, args) =>
            {
                args.Graphics.DrawString(models.VoucherNumber, new System.Drawing.Font("ronnia", 9), Brushes.Black, 600, 28);
                args.Graphics.DrawString(models.VehicleList.VehicleNumber, new System.Drawing.Font("ronnia", 9), Brushes.Black, 600, 80);
                args.Graphics.DrawString(models.DriverList.FirstName + " " + models.DriverList.LastName, new System.Drawing.Font("ronnia", 9), Brushes.Black, 600, 103);
                args.Graphics.DrawString(models.GuestName, new System.Drawing.Font("ronnia", 9), Brushes.Black, 150, 145);
                args.Graphics.DrawString(models.DispatchedHotel, new System.Drawing.Font("ronnia", 9), Brushes.Black, 150, 176);
                args.Graphics.DrawString(models.RoomNumber, new System.Drawing.Font("ronnia", 9), Brushes.Black, 150, 203);
                foreach (var item in models.PackagesList)
                {
                    args.Graphics.DrawString(item.PreDefineTripName, new System.Drawing.Font("ronnia", 9), Brushes.Black, 150, y);
                    y = y + 15;
                }
                args.Graphics.DrawString(models.VehicleList.CurrentMeterReading.ToString(), new System.Drawing.Font("ronnia", 9), Brushes.Black, 500, 177);
                args.Graphics.DrawString(models.TimeOut.ToString("h:mm tt"), new System.Drawing.Font("ronnia", 9), Brushes.Black, 660, 177);
            };
            pd.Print();
            pd.Dispose();
            return RedirectToAction("Index");
        }

    }
}
