using Application.Helper;
using MyVehicleTrackingSystem.Wings.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using System.IO;
using Domain.Helper;

namespace MyVehicleTrackingSystem.Wings.Controllers
{
    public class HelperController : Controller
    {
        private IHelperService _helperService;

        public HelperController(HelperService helperService)
        {
            if (helperService == null)
            {
                throw new NullReferenceException("helperService");
            }

            _helperService = helperService;
        }

        // GET: Helper
        public ActionResult Index(string message, int? items)
        {
            if (message != null)
            {
                if (message.Equals("Success"))
                {
                    ModelState.AddModelError("", "Successfully deleted " + items + " porter(s)");
                }
                else
                {
                    ModelState.AddModelError("", "Please select porter(s) to delete");
                }
            }
            IEnumerable<Domain.Helper.Helper> helpers = _helperService.GetAllHelpers().Where(d => d.IsDeleted.Equals(false));
            IEnumerable<HelperViewModel> models = Mapper.Map<IEnumerable<HelperViewModel>>(helpers);
            return View(models);
        }

        // GET: Helper/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Helper/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Helper/Create
        [HttpPost]
        public ActionResult Create(HelperViewModel model, string button)
        {
            try
            {
                if (_helperService.IsHelperExists(model.EPFNumber, model.NIC))
                {
                    Helper helper = new Helper();
                    helper = Mapper.Map<Helper>(model);
                    _helperService.SaveHelper(helper);

                    if (button.Equals("SAVE PORTER"))
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.Clear();
                    ViewData["Success"] = "Successfully Added.";
                }
                else
                {
                    ModelState.AddModelError("", "Porter EPF Number or NIC Number already exists");
                }
                return View();
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Helper/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Domain.Helper.Helper helper = _helperService.GetHelperById(id);
                HelperViewModel model = Mapper.Map<HelperViewModel>(helper);
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // POST: Helper/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HelperViewModel model)
        {
            try
            {
                Domain.Helper.Helper helper = _helperService.GetHelperById(id);
                helper = Mapper.Map<Helper>(model);
                _helperService.EditHelper(id,helper);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Helper/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _helperService.DeleteHelper(id);
                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: Helper/Delete/5
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
        public ActionResult MultiplePorterDelete(IEnumerable<int> portersToDelete)
        {
            try
            {
                if (portersToDelete != null)
                {
                    _helperService.DeleteMultipleHelpers(portersToDelete);
                    return RedirectToAction("Index", "Helper", new { message = "Success", items = portersToDelete.Count() });
                }
                else
                {
                    return RedirectToAction("Index", "Helper", new { message = "Error" });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
