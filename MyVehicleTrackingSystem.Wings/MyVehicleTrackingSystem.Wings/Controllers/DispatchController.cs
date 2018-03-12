using Application.Client;
using Application.DispatchNote;
using Application.Driver;
using Application.Helper;
using Application.Vehicles;
using AutoMapper;
using Domain.Client;
using Domain.DispatchNote;
using Domain.Driver;
using Domain.Helper;
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
    public class DispatchController : Controller
    {
        private readonly IDispatchNoteService _dispatchNoteService;
        private readonly IClientService _clientService;
        private readonly IDriverService _driverService;
        private readonly IHelperService _helperService;
        private readonly IVehicleService _vehicleService;

        public DispatchController(DispatchNoteService dispatchNoteService, ClientService clientService, DriverService driverService, HelperService helperService, VehicleService vehicleService)
        {
            if (dispatchNoteService == null)
            {
                throw new NullReferenceException("dispatchNoteService");
            }
            if (clientService == null)
            {
                throw new NullReferenceException("clientService");
            }
            if (driverService == null)
            {
                throw new NullReferenceException("driverService");
            }
            if (helperService == null)
            {
                throw new NullReferenceException("helperService");
            }
            if (vehicleService == null)
            {
                throw new NullReferenceException("vehicleService");
            }

            _dispatchNoteService = dispatchNoteService;
            _clientService = clientService;
            _driverService = driverService;
            _helperService = helperService;
            _vehicleService = vehicleService;
        }

        // GET: DispatchOpen
        [Authorize(Roles = "Business Owner, Dispatcher")]
        public ActionResult Open(string message, int? items)
        {
            if (message != null)
            {
                if (message.Equals("Success"))
                {
                    ModelState.AddModelError("", "Successfully deleted " + items + " dispatch(s)");
                }
                else
                {
                    ModelState.AddModelError("", "Please select Dispatch(s) to delete");
                }
            }

            IEnumerable<Domain.DispatchNote.DispatchNote> dispatchNotes = _dispatchNoteService.GetAllDispatchNote().Where(d => d.IsDeleted.Equals(false) && d.Status == "Open");
            IEnumerable<DispatchNoteViewModel> models = Mapper.Map<IEnumerable<DispatchNoteViewModel>>(dispatchNotes);
            return View(models);
        }

        //GET: DispatchClosed
        public ActionResult Closed()
        {
            IEnumerable<Domain.DispatchNote.DispatchNote> dispatchNotes = _dispatchNoteService.GetAllDispatchNote().Where(d => d.IsDeleted.Equals(false) && d.Status == "Closed");
            IEnumerable<DispatchNoteViewModel> models = Mapper.Map<IEnumerable<DispatchNoteViewModel>>(dispatchNotes);
            return View(models);
        }

        //Get: DispatchCancelled
        public ActionResult Cancelled()
        {
            IEnumerable<Domain.DispatchNote.DispatchNote> dispatchNotes = _dispatchNoteService.GetAllDispatchNote().Where(d => d.IsDeleted.Equals(false) && d.Status == "Cancelled");
            IEnumerable<DispatchNoteViewModel> models = Mapper.Map<IEnumerable<DispatchNoteViewModel>>(dispatchNotes);
            return View(models);
        }

        // GET: Dispatch/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //GET: Dispatch ClosedCancelledView
        [HttpGet]
        public ActionResult ClosedCancelledView(int id)
        {
            try
            {
                Domain.DispatchNote.DispatchNote dispatch = _dispatchNoteService.GetDispatchNoteById(id);
                DispatchNoteViewModel model = Mapper.Map<DispatchNoteViewModel>(dispatch);
                model.QuantityType = CustomDataHelper.DataHelper.GetQuentity();
                model.Client_OperationType = GetClients();
                model.DriverName_Grade = GetDrivers();
                model.HelperName = GetHelpers();
                model.VehiclePlateNumber = GetVehicles();
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        //POST: Dispatch/ClosedCancelledView
        [HttpPost]
        public ActionResult ClosedCancelledView()
        {
            return View();
        }

        // GET: Dispatch/ViewDispatch
        [HttpGet]
        public ActionResult ViewDispatch(int id)
        {
            try
            {
                Domain.DispatchNote.DispatchNote dispatch = _dispatchNoteService.GetDispatchNoteById(id);
                DispatchNoteViewModel model = Mapper.Map<DispatchNoteViewModel>(dispatch);
                model.QuantityType = CustomDataHelper.DataHelper.GetQuentity();
                model.Client_OperationType = GetClients();
                model.DriverName_Grade = GetDrivers();
                model.HelperName = GetHelpers();
                model.VehiclePlateNumber = GetVehicles();
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // POST: Dispatch/ViewDispatch
        [HttpPost]
        public ActionResult ViewDispatch(DispatchNoteViewModel model, string button)
        {
            try
            {
                DispatchNote dispatchNote = Mapper.Map<DispatchNote>(model);

                if (button.Equals("Close"))
                {
                    dispatchNote.Status = "Closed";
                }
                else
                {
                    dispatchNote.IsDispatchNoteReceived = false;
                    dispatchNote.IsGoodsDelivered = false;
                    dispatchNote.Remarks = null;
                    dispatchNote.Status = "Cancelled";
                }

                _dispatchNoteService.UpdateDispatchNoteStatus(dispatchNote);
                ModelState.Clear();
                ViewData["Success"] = "Successfully Updated.";
                return RedirectToAction("Open");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Dispatch/Create
        public ActionResult Create()
        {
            DispatchNoteViewModel model = new DispatchNoteViewModel();
            model.QuantityType = CustomDataHelper.DataHelper.GetQuentity();
            model.Client_OperationType = GetClients();
            model.DriverName_Grade = GetDrivers();
            model.HelperName = GetHelpers();
            model.VehiclePlateNumber = GetVehicles();
            return View(model);
        }

        // POST: Dispatch/Create
        [HttpPost]
        public ActionResult Create(DispatchNoteViewModel model, string button)
        {
            try
            {
                DispatchNote dispatchNote = Mapper.Map<DispatchNote>(model);
                dispatchNote.DispatchId = GenarateDispatchNumber();
                dispatchNote.Status = "Open";

                if (button.Equals("Print"))
                {
                    dispatchNote.IsPrinted = true;
                }

                Client clienFromDb = _clientService.GetClientById(Convert.ToInt32(model.Client));

                dispatchNote.Client = clienFromDb.CompanyName + " - " + clienFromDb.OperationType;
                dispatchNote.VehicleLicensePlateNumber = _vehicleService.GetVehicleDetailById(Convert.ToInt32(model.VehicleLicensePlateNumber)).VehicleNumber;

                _dispatchNoteService.SaveDispatchNote(dispatchNote);
                ModelState.Clear();
                ViewData["Success"] = "Successfully Added.";
                return RedirectToAction("Open");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Dispatch/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Domain.DispatchNote.DispatchNote dispatch = _dispatchNoteService.GetDispatchNoteById(id);
                DispatchNoteViewModel model = Mapper.Map<DispatchNoteViewModel>(dispatch);
                model.Client = GetClients().Where(c => c.Text == model.Client).Select(c => c.Value).FirstOrDefault();
                model.QuantityType = CustomDataHelper.DataHelper.GetQuentity();
                model.Client_OperationType = GetClients();
                model.DriverName_Grade = GetDrivers();
                model.HelperName = GetHelpers();
                model.VehiclePlateNumber = GetVehicles();
                model.VehicleLicensePlateNumber = GetVehicles().Where(v => v.Text == model.VehicleLicensePlateNumber).Select(c => c.Value).FirstOrDefault();
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // POST: Dispatch/Edit/5
        [HttpPost]
        public ActionResult Edit(DispatchNoteViewModel model, string button)
        {
            try
            {
                DispatchNote dispatchNote = Mapper.Map<DispatchNote>(model);
                dispatchNote.Status = "Open";

                if (button.Equals("Print"))
                {
                    dispatchNote.IsPrinted = true;
                }

                Client clienFromDb = _clientService.GetClientById(Convert.ToInt32(model.Client));

                dispatchNote.Client = clienFromDb.CompanyName + " - " + clienFromDb.OperationType;
                dispatchNote.VehicleLicensePlateNumber = _vehicleService.GetVehicleDetailById(Convert.ToInt32(model.VehicleLicensePlateNumber)).VehicleNumber;

                _dispatchNoteService.UpdateDispatchNote(dispatchNote);
                ModelState.Clear();
                ViewData["Success"] = "Successfully Updated.";
                return RedirectToAction("Open");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Dispatch/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dispatch/Delete/5
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

        public ActionResult Search(SearchModel criteria)
        {
            try
            {
                IEnumerable<DispatchNoteViewModel> rearchResultModels = new Collection<DispatchNoteViewModel>();
                IEnumerable<DispatchNote> searchResult = _dispatchNoteService.GetFilteredDispatchNote(criteria.From, criteria.To, criteria.Term);
                if (searchResult.Count() > 0)
                {
                    rearchResultModels = Mapper.Map<IEnumerable<DispatchNoteViewModel>>(searchResult);
                }
                return View("Open", rearchResultModels);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<SelectListItem> GetClients()
        {
            List<Client> client = _clientService.GetAllClients().ToList();

            List<SelectListItem> clientSelectList = client.Select(c => new SelectListItem
            {
                Value = c.ClientId.ToString(),
                Text = c.CompanyName + " - " + c.OperationType
            }).ToList();

            clientSelectList.Insert(0, new SelectListItem { Value = string.Empty, Text = "Please Select", Selected = true });
            return clientSelectList;
        }

        private List<SelectListItem> GetDrivers()
        {
            List<Driver> driver = _driverService.GetAllDrivers().ToList();

            List<SelectListItem> driverSelectList = driver.Select(d => new SelectListItem
            {
                Value = d.Name + " - " + d.DriverGrade,
                Text = d.Name + " - " + d.DriverGrade
            }).ToList();

            driverSelectList.Insert(0, new SelectListItem { Value = string.Empty, Text = "Please Select", Selected = true });
            return driverSelectList;
        }

        private List<SelectListItem> GetHelpers()
        {
            List<Helper> helper = _helperService.GetAllHelpers().ToList();

            List<SelectListItem> helperSelectList = helper.Select(h => new SelectListItem
            {
                Value = h.Name,
                Text = h.Name
            }).ToList();

            helperSelectList.Insert(0, new SelectListItem { Value = "0", Text = "Please Select", Selected = true });
            return helperSelectList;
        }

        private List<SelectListItem> GetVehicles()
        {
            List<Vehicle> vehicle = _vehicleService.GetAllVehicles().ToList();

            List<SelectListItem> vehicleSelectItem = vehicle.Select(v => new SelectListItem
            {
                Value = v.VehicleId.ToString(),
                Text = v.VehicleNumber
            }).ToList();

            vehicleSelectItem.Insert(0, new SelectListItem { Value = string.Empty, Text = "Please Select", Selected = true });
            return vehicleSelectItem;
        }

        [HttpGet]
        public JsonResult GetVehicleDetails(int id)
        {
            try
            {
                Vehicle vehicle = _vehicleService.GetVehicleDetailById(id);
                return Json(new { quantity = vehicle.Quantity, deliveryType = vehicle.VehicleDeliveryType }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public JsonResult GetClientDetails(int id)
        {
            try
            {
                Client client = _clientService.GetClientById(id);
                return Json(new { companyAddress = client.CompanyAddress, clientCommission = client.ClientRate, driverCommission = client.DriverCommissionRate, porterCommission = client.PorterCommissionRate }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GenarateDispatchNumber()
        {
            try
            {
                int Number = _dispatchNoteService.GenarateDispatchNumber();
                string DispatchNumber = Number.ToString().PadLeft(5, '0');
                return DispatchNumber;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
