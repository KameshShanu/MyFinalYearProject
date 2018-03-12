using Application.Driver;
using MyVehicleTrackingSystem.Wings.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using System.IO;
using Domain.Driver;

namespace MyVehicleTrackingSystem.Wings.Controllers
{
    public class DriverController : Controller
    {
        private IDriverService _driverService;

        public DriverController(DriverService driverService)
        {
            if (driverService == null)
            {
                throw new NullReferenceException("driverService");
            }

            _driverService = driverService;
        }

        // GET: Driver
        public ActionResult Index(string message, int? items)
        {
            if (message != null)
            {
                if (message.Equals("Success"))
                {
                    ModelState.AddModelError("", "Successfully deleted " + items + " driver(s)");
                }
                else
                {
                    ModelState.AddModelError("", "Please select driver(s) to delete");
                }
            }
            IEnumerable<Domain.Driver.Driver> drivers = _driverService.GetAllDrivers().Where(d => d.IsDeleted.Equals(false));
            IEnumerable<DriverViewModel> models = Mapper.Map<IEnumerable<DriverViewModel>>(drivers);
            return View(models);
        }

        // GET: Driver/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Driver/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Driver/Create
        [HttpPost]
        public ActionResult Create(DriverViewModel model, string button)
        {
            try
            {
                if (_driverService.IsDriverExists(model.EPFNumber, model.NIC))
                {
                    Driver driver = new Driver();
                    driver = Mapper.Map<Driver>(model);
                    _driverService.SaveDriver(driver);

                    if (button.Equals("SAVE DRIVER"))
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.Clear();
                    ViewData["Success"] = "Successfully Added.";
                }
                else
                {
                    ModelState.AddModelError("", "Driver employee Id or NIC number already exists");
                }
                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Driver/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Domain.Driver.Driver driver = _driverService.GetDriverById(id);
                DriverViewModel model = Mapper.Map<DriverViewModel>(driver);
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // POST: Driver/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DriverViewModel model)
        {
            try
            {
                Domain.Driver.Driver driver = _driverService.GetDriverById(id);
                driver.Name = model.Name;               
                driver.NIC = model.NIC;
                driver.DateOfBirth = model.DateOfBirth;                
                driver.ResidentAddress = model.ResidentAddress;
                driver.ContactNumber1 = model.ContactNumber1;
                driver.ContactNumber2 = model.ContactNumber2;
                driver.EPFNumber = model.EPFNumber;
                driver.DLNumber = model.DLNumber;
                driver.DateOfExpiryLicense = model.DateOfExpiryLicense;
                driver.DefensiveLicenseNumber = model.DefensiveLicenseNumber;
                driver.DefensiveLicenseExpiryDate = model.DefensiveLicenseExpiryDate;
                driver.DriverGrade = model.DriverGrade;
                driver.StartDateOfWork = model.StartDateOfWork;
                driver.PeriodOfService = model.PeriodOfService;
                driver.BasicSalary = model.BasicSalary;
                driver.MinimumSalary = model.MinimumSalary;
                driver.PoliceReportExpiryDate = model.PoliceReportExpiryDate;
                _driverService.SaveDriver(driver);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Driver/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _driverService.DeleteDriver(id);
                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: Driver/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult MultipleDriverDelete(IEnumerable<int> driversToDelete)
        {
            try
            {
                if (driversToDelete != null)
                {
                    _driverService.DeleteMultipleTrips(driversToDelete);
                    return RedirectToAction("Index", "Driver", new { message = "Success", items = driversToDelete.Count() });
                }
                else
                {
                    return RedirectToAction("Index", "Driver", new { message = "Error" });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}