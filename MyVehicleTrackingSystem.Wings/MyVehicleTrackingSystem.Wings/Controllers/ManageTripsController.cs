using Application.BataRates;
using Application.Trips;
using AutoMapper;
using Domain.BataRates;
using Domain.Trips;
using MyVehicleTrackingSystem.Wings.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Controllers
{
    public class ManageTripsController : Controller
    {
        private IVehicleRateService _vehicleRateService;
        private IPreDefineTripService _preDefineTripService;
        private IBataRateService _bataRateService;

        public ManageTripsController(VehicleRateService vehicleRateService, PreDefineTripService preDefineTripService, BataRateService bataRateService)
        {
            if (vehicleRateService == null)
            {
                throw new NullReferenceException("vehicleRateService");
            }

            if (preDefineTripService == null)
            {
                throw new NullReferenceException("preDefineTripService");
            }

            _vehicleRateService = vehicleRateService;
            _preDefineTripService = preDefineTripService;
            _bataRateService = bataRateService;
        }

        // GET: ManageTrips
        public ActionResult Index(string message, int? items)
        {
            if (message != null)
            {
                if (message.Equals("Success"))
                {
                    ModelState.AddModelError("", "Successfully deleted " + items + " item(s)");
                }
                else
                {
                    ModelState.AddModelError("", "Please select package(s) or rate(s) to delete");
                }
            }
            TripPackageViewModel model = new TripPackageViewModel();
            IEnumerable<Domain.Trips.PreDefineTrip> preDefineTrips = _preDefineTripService.GetAllPreDefineTrip();
            IEnumerable<Domain.Trips.VehicleRate> vahicleRates = _vehicleRateService.GetAllVehicleRates();

            model.Packages = Mapper.Map<IEnumerable<PreDefineTripViewModel>>(preDefineTrips);
            model.FarePackages = Mapper.Map<IEnumerable<VehicleRateViewModel>>(vahicleRates);
            return View(model);
        }

        public ActionResult VehicleRates()
        {
            IEnumerable<VehicleRateViewModel> models = new Collection<VehicleRateViewModel>();
            IEnumerable<Domain.Trips.VehicleRate> vahicleRates = _vehicleRateService.GetAllVehicleRates();
            if (vahicleRates != null)
            {
                models = Mapper.Map<IEnumerable<VehicleRateViewModel>>(vahicleRates);
            }
            return View(models);
        }

        public ActionResult CreateVehicleRate()
        {
            VehicleRateViewModel model = new VehicleRateViewModel();
            model.Passenger = CustomDataHelper.DataHelper.GetGuestType();
            //ViewBag["PassengerTypeHide"] = "";

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateVehicleRate(VehicleRateViewModel newVehicle, string button)
        {
            try
            {
                VehicleRateViewModel model = new VehicleRateViewModel();
                model.Passenger = CustomDataHelper.DataHelper.GetGuestType();
                if (newVehicle.PassengerType.Equals("Hotel Staff"))
                {
                    newVehicle.VehicleType = "Car/SUV";
                }
                Domain.Trips.VehicleRate vehicleRateEntity = Mapper.Map<Domain.Trips.VehicleRate>(newVehicle);
                if (_vehicleRateService.VehicleExists(vehicleRateEntity.VehicleType))
                {
                    vehicleRateEntity.IsDeleted = false;
                    _vehicleRateService.SaveVehicleRate(vehicleRateEntity);

                    if (button.Equals("SAVE RATE"))
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.Clear();
                    ViewData["Success"] = "Successfully Added.";
                }
                else
                {
                    ModelState.AddModelError("", "This Vehicle Type Already Exists");
                    ViewBag.PassengerTypeHide = newVehicle.PassengerType;
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditVehicleRate(int id)
        {
            Domain.Trips.VehicleRate EntityToUpdate = _vehicleRateService.GetVehicleRateById(id);
            VehicleRateViewModel model = Mapper.Map<VehicleRateViewModel>(EntityToUpdate);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditVehicleRate(int id, VehicleRateViewModel updatedVehicle)
        {
            try
            {
                Domain.Trips.VehicleRate vehicleRateEntity = Mapper.Map<Domain.Trips.VehicleRate>(updatedVehicle);
                _vehicleRateService.UpdateVehicleRate(id, vehicleRateEntity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteVehicleRate(int id)
        {
            _vehicleRateService.DeleteVehicleRate(id);
            return RedirectToAction("Index");
        }

        public ActionResult PreDefineTrips()
        {
            IEnumerable<Domain.Trips.PreDefineTrip> preDefineTrips = _preDefineTripService.GetAllPreDefineTrip();
            IEnumerable<PreDefineTripViewModel> models = Mapper.Map<IEnumerable<PreDefineTripViewModel>>(preDefineTrips);
            return View(models);
        }

        public ActionResult CreateNewPreDefineTrip()
        {
            PreDefineTripViewModel model = new PreDefineTripViewModel();
            model.Vehicle = CustomDataHelper.DataHelper.GetVehicleType();
            model.Type = CustomDataHelper.DataHelper.GetPackageType();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateNewPreDefineTrip(PreDefineTripViewModel model, string button)
        {
            try
            {
                PreDefineTripViewModel models = new PreDefineTripViewModel();
                models.Vehicle = CustomDataHelper.DataHelper.GetVehicleType();
                Domain.Trips.PreDefineTrip trip = Mapper.Map<Domain.Trips.PreDefineTrip>(model);
                trip.IsDeleted = false;
                _preDefineTripService.SavePreDefineTrip(trip);

                if (button.Equals("SAVE PACKAGE"))
                {
                    return RedirectToAction("Index");
                }
                ModelState.Clear();
                ViewData["Success"] = "Successfully Added.";
                return View(models);
            }
            catch (Exception ex)
            {
                return Json(ex.ToString());
            }
        }
        public ActionResult CreateNewFare()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewFare(VehicleRateViewModel model)
        {
            try
            {
                Domain.Trips.PreDefineTrip trip = Mapper.Map<Domain.Trips.PreDefineTrip>(model);
                trip.IsDeleted = false;
                _preDefineTripService.SavePreDefineTrip(trip);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditPreDefineTrip(int id)
        {
            try
            {
                PreDefineTripViewModel model = new PreDefineTripViewModel();
                Domain.Trips.PreDefineTrip trip = _preDefineTripService.GetPreDefineTripById(id);

                model = Mapper.Map<PreDefineTripViewModel>(trip);
                model.Vehicle = CustomDataHelper.DataHelper.GetVehicleType();
                model.Type = CustomDataHelper.DataHelper.GetPackageType();
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult EditPreDefineTrip(int id, PreDefineTripViewModel model)
        {
            try
            {
                Domain.Trips.PreDefineTrip trip = _preDefineTripService.GetPreDefineTripById(id);

                trip.PreDefineTripName = model.PreDefineTripName;
                trip.Distance = model.Distance;
                trip.Rate = model.Rate;
                trip.VehicleType = model.VehicleType;
                trip.TripType = model.TripType;

                _preDefineTripService.SavePreDefineTrip(trip);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeletePreDefineTrip(int id)
        {
            _preDefineTripService.DeletePreDefineTrip(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ActionSelector(IEnumerable<int> packagesToDelete, IEnumerable<int> ratesToDelete)
        {
            if (Request.Form["packageDelete"] != null)
            {
                return DeleteMultiplePackages(packagesToDelete);
            }
            else if (Request.Form["rateDelete"] != null)
            {
                return DeleteMultipleRates(ratesToDelete);
            }
            return null;
        }

        public ActionResult DeleteMultiplePackages(IEnumerable<int> packagesToDelete)
        {
            try
            {
                if (packagesToDelete != null)
                {
                    _preDefineTripService.DeleteMultiplePackages(packagesToDelete);
                    return RedirectToAction("Index", "ManageTrips", new { message = "Success", items = packagesToDelete.Count() });
                }
                else
                {
                    return RedirectToAction("Index", "ManageTrips", new { message = "Error" });
                }
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public ActionResult DeleteMultipleRates(IEnumerable<int> ratesToDelete)
        {
            try
            {
                if (ratesToDelete != null)
                {
                    _vehicleRateService.DeleteMultipleRates(ratesToDelete);
                    return RedirectToAction("Index", "ManageTrips", new { message = "Success", items = ratesToDelete.Count() });
                }
                else
                {
                    return RedirectToAction("Index", "ManageTrips", new { message = "Error" });
                }
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}