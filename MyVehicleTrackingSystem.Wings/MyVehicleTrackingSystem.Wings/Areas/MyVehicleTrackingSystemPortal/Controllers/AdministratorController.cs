using Application.Driver;
using Application.Trips;
using Application.Vehicles;
using Domain.Driver;
using Domain.Trips;
using Domain.Vehicles;
using MyVehicleTrackingSystem.Wings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Areas.HypercentPortal.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private IDriverService _driverService;
        private readonly ITripService _tripService;

        public AdministratorController(VehicleService vehicleService, DriverService driverService, TripService tripService)
        {
            _vehicleService = vehicleService;
            _driverService = driverService;
            _tripService = tripService;
        }
        // GET: HypercentPortal/Administrator
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageVehicles(string message, int? items)
        {
            try
            {
                if (message != null)
                {
                    if (message.Equals("Success"))
                    {
                        ModelState.AddModelError("", "Successfully updated " + items + " vehicle(s)");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please select vehicle(s) to update");
                    }
                }
                IEnumerable<Vehicle> vehicle = _vehicleService.GetAllVehicles().Where(v => v.IsDeleted.Equals(false));
                VehicleViewModel model = new VehicleViewModel()
                {
                    VehicleAvailableList = AutoMapper.Mapper.Map<IEnumerable<VehicleListViewModel>>(vehicle).Where(a => a.IsAvailable.Equals(false)),
                    VehicleUnAvailableList = AutoMapper.Mapper.Map<IEnumerable<VehicleListViewModel>>(vehicle).Where(a => a.IsAvailable.Equals(true))
                };
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult UpdateVehicleAvailable(IEnumerable<int> vehiclesToUpdate)
        {
            try
            {
                if (vehiclesToUpdate != null)
                {
                    _vehicleService.UpdateVehicleAvailable(vehiclesToUpdate);
                    return RedirectToAction("ManageVehicles", "Administrator", new { message = "Success", items = vehiclesToUpdate.Count() });
                }
                else
                {
                    return RedirectToAction("ManageVehicles", "Administrator", new { message = "Error" });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public ActionResult UpdateVehicleUnAvailable(IEnumerable<int> vehiclesToUpdate)
        {
            try
            {
                if (vehiclesToUpdate != null)
                {
                    _vehicleService.UpdateVehicleUnAvailable(vehiclesToUpdate);
                    return RedirectToAction("ManageVehicles", "Administrator", new { message = "Success", items = vehiclesToUpdate.Count() });
                }
                else
                {
                    return RedirectToAction("ManageVehicles", "Administrator", new { message = "Error" });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public ActionResult ManageDrivers(string message, int? items)
        {
            try
            {
                if (message != null)
                {
                    if (message.Equals("Success"))
                    {
                        ModelState.AddModelError("", "Successfully updated " + items + " driver(s)");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please select driver(s) to update");
                    }
                }
                IEnumerable<Driver> vehicle = _driverService.GetAllDrivers().Where(v => v.IsDeleted.Equals(false));
                DriverCommonViewModel model = new DriverCommonViewModel()
                {
                    DriverAvailableList = AutoMapper.Mapper.Map<IEnumerable<DriverViewModel>>(vehicle).Where(a => a.IsAvailable.Equals(false)),
                    DriverUnAvailableList = AutoMapper.Mapper.Map<IEnumerable<DriverViewModel>>(vehicle).Where(a => a.IsAvailable.Equals(true))
                };
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult UpdateDriverAvailable(IEnumerable<int> driversToUpdate)
        {
            try
            {
                if (driversToUpdate != null)
                {
                    _driverService.UpdateDriverAvailable(driversToUpdate);
                    return RedirectToAction("ManageDrivers", "Administrator", new { message = "Success", items = driversToUpdate.Count() });
                }
                else
                {
                    return RedirectToAction("ManageDrivers", "Administrator", new { message = "Error" });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public ActionResult UpdateDriverUnAvailable(IEnumerable<int> driversToUpdate)
        {
            try
            {
                if (driversToUpdate != null)
                {
                    _driverService.UpdateDriverUnAvailable(driversToUpdate);
                    return RedirectToAction("ManageDrivers", "Administrator", new { message = "Success", items = driversToUpdate.Count() });
                }
                else
                {
                    return RedirectToAction("ManageDrivers", "Administrator", new { message = "Error" });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult ManageTrips(string message, int? items)
        {
            try
            {
                if (message != null)
                {
                    if (message.Equals("Success"))
                    {
                        ModelState.AddModelError("", "Successfully updated " + items + " trip(s)");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please select trip(s) to update");
                    }
                }
                IEnumerable<TripDto> trips = _tripService.RetrieveTrips(null, null, false, null, null, null);
                TripCommonViewModel model = new TripCommonViewModel()
                {
                    ClosedTrips = trips.Where(a => a.IsOpen.Equals(false)).OrderByDescending(a => a.TripId).Take(100),
                    OpenTrips = trips.Where(a => a.IsOpen.Equals(true)).OrderByDescending(a => a.TripId).Take(100),
                    CancelledTrips = trips.Where(a => a.IsRemoved.Equals(true)).OrderByDescending(a => a.TripId).Take(100)
                };
                return View(model);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult UpdateTrips(IEnumerable<int> tripsToUpdate)
        {
            try
            {
                if (tripsToUpdate != null)
                {
                    _tripService.UpdateTripClosed(tripsToUpdate);
                    return RedirectToAction("ManageTrips", "Administrator", new { message = "Success", items = tripsToUpdate.Count() });
                }
                else
                {
                    return RedirectToAction("ManageTrips", "Administrator", new { message = "Error" });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult TripsWithVehicleAndDriver()
        {
            try
            {
                IEnumerable<Vehicle> vehicles = _vehicleService.RetrieveTripsWithVehicle();
                IEnumerable<Driver> drivers = _driverService.RetrieveTripsWithDriver();
                TripCommonViewModel model = new TripCommonViewModel()
                {
                    DriverList = drivers,
                    VehicleList = vehicles
                };
                return View(model);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

    }
}