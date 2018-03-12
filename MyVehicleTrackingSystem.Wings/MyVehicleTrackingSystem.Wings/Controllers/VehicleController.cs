using Application.Vehicles;
using Domain.Vehicles;
using MyVehicleTrackingSystem.Wings.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: Vehicle
        public ActionResult Index(string message, int? items)
        {
            if (message != null)
            {
                if (message.Equals("Success"))
                {
                    ModelState.AddModelError("", "Successfully deleted " + items + " vehicle(s)");
                }
                else
                {
                    ModelState.AddModelError("", "Please select vehicle(s) to delete");
                }
            }
            IEnumerable<VehicleListViewModel> models = new Collection<VehicleListViewModel>();
            IEnumerable<Vehicle> vehicle = _vehicleService.GetAllVehicles().Where(v => v.IsDeleted.Equals(false));
            if (vehicle != null)
            {
                models = AutoMapper.Mapper.Map<IEnumerable<VehicleListViewModel>>(vehicle);
            }
            return View(models);
        }

        // GET: Vehicle/Details/5
        public ActionResult Details(int id)
        {
            VehicleListViewModel models = new VehicleListViewModel();
            Vehicle vehicle = _vehicleService.GetVehicleDetailById(id);
            if (vehicle != null)
            {
                models = AutoMapper.Mapper.Map<VehicleListViewModel>(vehicle);
            }
            return View(models);
        }

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            VehicleListViewModel model = new VehicleListViewModel();
            model.VehicleDelivery = CustomDataHelper.DataHelper.GetVehicleDeliveryType();
            model.QuantityType = CustomDataHelper.DataHelper.GetQuentity();
            return View(model);
        }

        // POST: Vehicle/Create
        [HttpPost]
        public ActionResult Create(Vehicle model, string button)
        {
            try
            {
                VehicleListViewModel models = new VehicleListViewModel();
                models.VehicleDelivery = CustomDataHelper.DataHelper.GetVehicleDeliveryType();
                models.QuantityType = CustomDataHelper.DataHelper.GetQuentity();

                if (!_vehicleService.IsVehicleExists(model.VehicleNumber))
                {
                    if (!_vehicleService.IsVehicleExistsByLicenseNumber(model.LicenseNumber))
                    {
                        /*if (!_vehicleService.IsVehicleExistsByInsuranceNumber(model.InsuranceNumber))
                        {
                            if (!_vehicleService.IsVehicleExistsByGoodsNumber(model.GoodsNumber))
                            {*/
                                if (!_vehicleService.IsVehicleExistsByEngineNumber(model.EngineNumber))
                                {
                                    if (!_vehicleService.IsVehicleExistsByChassisNumber(model.ChassisNumber))
                                    {                                                                                
                                            model.VehicleNumber = VehicleNumberFormat(model.VehicleNumber);
                                            _vehicleService.SaveVehicle(model);
                                            if (button.Equals("SAVE VEHICLE"))
                                            {
                                                return RedirectToAction("Index");
                                            }
                                            ModelState.Clear();
                                            ViewData["Success"] = "Successfully Added.";                                        
                                    }
                                    else
                                    {
                                        ModelState.AddModelError("ChassisNumber", "Vehicle is already Exists");
                                        ModelState.AddModelError("ChassisNumber", "Chassis Number is already Exists");
                                    }
                                }
                                else
                                {
                                    ModelState.AddModelError("", "Vehicle is already Exists");
                                    ModelState.AddModelError("EngineNumber", "Engine Number is already Exists");
                                }
                            //}
                            //else
                            //{
                            //    ModelState.AddModelError("", "Vehicle is already Exists");
                            //    ModelState.AddModelError("GoodsNumber", "Goods in Transit License Number is already Exists");
                            //}

                        //}
                        //else
                        //{
                        //    ModelState.AddModelError("", "Vehicle is already Exists");
                        //    ModelState.AddModelError("InsuranceNumber", "Insurance Card Number is already Exists");
                        //}
                    }
                    else
                    {
                        ModelState.AddModelError("", "Vehicle is already Exists");
                        ModelState.AddModelError("LicenseNumber", "Revenue License Number is already Exists");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Vehicle is already Exists");
                    ModelState.AddModelError("VehicleNumber", "Vehicle License Plate Number is already Exists");
                }
                return View(models);
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }

        private static string VehicleNumberFormat(string vehiNum)
        {
            string number = vehiNum.Replace(" ", String.Empty).Replace(@"-", String.Empty);
            number = number.Reverse().Aggregate("", (s, c) => s + c);
            number = number.Insert(4, "-");
            number = number.Reverse().Aggregate("", (s, c) => s + c);
            return number;   //CAP-2547  
        }

        // GET: Vehicle/Edit/5
        public ActionResult Edit(int id)
        {
            VehicleListViewModel model = new VehicleListViewModel();
            Vehicle vehicle = _vehicleService.GetVehicleDetailById(id);
            if (vehicle != null)
            {
                model = AutoMapper.Mapper.Map<VehicleListViewModel>(vehicle);
            }
            model.VehicleDelivery = CustomDataHelper.DataHelper.GetVehicleDeliveryType();
            model.QuantityType = CustomDataHelper.DataHelper.GetQuentity();
            return View(model);
        }

        // POST: Vehicle/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Vehicle model)
        {
            try
            {
                _vehicleService.EditVehicle(id, model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehicle/Delete/5
        public ActionResult Delete(int id)
        {
            _vehicleService.DeleteVehicle(id);
            return RedirectToAction("Index");
        }

        // POST: Vehicle/Delete/5
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
        public ActionResult MultipleVehicleDelete(IEnumerable<int> vehiclesToDelete)
        {
            try
            {
                if (vehiclesToDelete != null)
                {
                    _vehicleService.DeleteMultipleVehicles(vehiclesToDelete);
                    return RedirectToAction("Index", "Vehicle", new { message = "Success", items = vehiclesToDelete.Count() });
                }
                else
                {
                    return RedirectToAction("Index", "Vehicle", new { message = "Error" });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        /// <summary>
        /// Vehicle gateway action
        /// </summary>
        /// <returns></returns>
        public ActionResult Gateway()
        {
            // Get vehicles expiry count
            int ExpiryVehiclesCount = _vehicleService.GetExpiryVehiclesCount();
            if (ExpiryVehiclesCount > 0)
            {
                // Set vehicles expiry count to viewbag
                ViewBag.ExpiryVehicleCount = ExpiryVehiclesCount;
            }
            return View();
        }

        /// <summary>
        /// Get Expiry Vehicle Details 
        /// </summary>
        /// <returns></returns>
        public ActionResult ExpiryDetails()
        {
            IEnumerable<VehicleListViewModel> models = new Collection<VehicleListViewModel>();
            IEnumerable<Vehicle> expiryVehicle = _vehicleService.GetExpiryVehicles();
            if (expiryVehicle != null)
            {
                models = AutoMapper.Mapper.Map<IEnumerable<VehicleListViewModel>>(expiryVehicle);
            }
            return View(models);
        }
    }
}
