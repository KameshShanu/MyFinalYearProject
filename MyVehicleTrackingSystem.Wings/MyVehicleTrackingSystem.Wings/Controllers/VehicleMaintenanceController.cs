using Application.VehicleMaintenance;
using MyVehicleTrackingSystem.Wings.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using System.IO;
using Domain.VehicleMaintenance;
using Application.Vehicles;
using Domain.Vehicles;

namespace MyVehicleTrackingSystem.Wings.Controllers
{
    public class VehicleMaintenanceController : Controller
    {
        private IVehicleMaintenanceService _vehiclemaintenanceService;
        private readonly IVehicleService _vehicleService;

        public VehicleMaintenanceController(VehicleMaintenanceService vehiclemaintenanceService, VehicleService vehicleService)
        {
            if (vehiclemaintenanceService == null)
            {
                throw new NullReferenceException("vehiclemaintenanceService");
            }
            if (vehicleService == null)
            {
                throw new NullReferenceException("vehicleService");
            }

            _vehiclemaintenanceService = vehiclemaintenanceService;
            _vehicleService = vehicleService;
        }


        // GET: VehicleMaintenance
        public ActionResult Index(string message, int? items)
        {
            if (message != null)
            {
                if (message.Equals("Success"))
                {
                    ModelState.AddModelError("", "Successfully deleted " + items + " Vehicle Maintenance Record(s)");
                }
                else
                {
                    ModelState.AddModelError("", "Please select Vehicle Maintenance Record(s) to delete");
                }
            }
            VehicleMaintenanceListViewModel listViewModel = new VehicleMaintenanceListViewModel();
            listViewModel.VehicleNumbers = GetAllVehicleNumbers().ToList();
            if (listViewModel.VehicleNumbers != null)
            {
                return View(listViewModel);
            }
            return View();
        }

        private IEnumerable<SelectListItem> GetAllVehicleNumbers()
        {
            IEnumerable<Vehicle> vehicle = _vehicleService.GetAllVehicles().Where(v => v.IsDeleted.Equals(false));
            IEnumerable<SelectListItem> plateNumber = vehicle.Select(x => new SelectListItem
            {
                Value = x.VehicleId.ToString(),
                Text = x.VehicleNumber
            });
            return new SelectList(plateNumber, "Value", "Text");
        }

        // GET: VehicleMaintenance/Create
        public ActionResult Create()
        {
            VehicleMaintenanceViewModel model = new VehicleMaintenanceViewModel();
            model.VehicleNumbers = GetAllVehicleNumbers().ToList();
            return View(model);
        }

        // POST: VehicleMaintenance/Create
        [HttpPost]
        public ActionResult Create(VehicleMaintenanceViewModel model, string button)
        {
            try
            {
                //model.VehicleNumber = GetAllVehicleNumbers().Where(v => v.Value == model.VehicleId.ToString()).Select(t => t.Text).ToString();
                VehicleMaintenance vehiclemaintenance = new VehicleMaintenance();
                vehiclemaintenance = Mapper.Map<VehicleMaintenance>(model);
                _vehiclemaintenanceService.SaveVehicleMaintenance(vehiclemaintenance);

                if (button.Equals("SAVE RECORD"))
                {
                    return RedirectToAction("Index");
                }
                ModelState.Clear();
                ViewData["Success"] = "Successfully Added.";

                return RedirectToAction("Create");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: VehicleMaintenance/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Domain.VehicleMaintenance.VehicleMaintenance vehiclemaintenance = _vehiclemaintenanceService.GetVehicleMaintenanceById(id);
                VehicleMaintenanceViewModel model = Mapper.Map<VehicleMaintenanceViewModel>(vehiclemaintenance);
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // POST: VehicleMaintenance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VehicleMaintenanceViewModel model)
        {
            try
            {
                Domain.VehicleMaintenance.VehicleMaintenance vechicle = _vehiclemaintenanceService.GetVehicleMaintenanceById(id);
                vechicle = Mapper.Map<VehicleMaintenance>(model);
                _vehiclemaintenanceService.EditVehicleMaintenance(id,vechicle);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult MultipleVehicleMaintenanceDelete(IEnumerable<int> vehiclemaintancesToDelete)
        {
            try
            {
                if (vehiclemaintancesToDelete != null)
                {
                    _vehiclemaintenanceService.DeleteMultipleVehicleMaintenances(vehiclemaintancesToDelete);
                    return RedirectToAction("Index", "VehicleMaintenance", new { message = "Success", items = vehiclemaintancesToDelete.Count() });
                }
                else
                {
                    return RedirectToAction("Index", "VehicleMaintenance", new { message = "Error" });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public JsonResult GetMaintenanceDataByVehicleId(int vehicleId)
        {
            try
            {
                IEnumerable<VehicleMaintenance> maintenanceData = _vehiclemaintenanceService.GetVehicleMaintenancesByVehicleId(vehicleId);
                if (maintenanceData.Count() > 0)
                {
                    IEnumerable<VehicleMaintenanceViewModel> maintenanceDataModel = Mapper.Map<IEnumerable<VehicleMaintenanceViewModel>>(maintenanceData);
                    return Json(new { maintenanceData = maintenanceDataModel, IsDataAvailable = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Message = "No maintenance records found for vehicle number", IsDataAvailable = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}