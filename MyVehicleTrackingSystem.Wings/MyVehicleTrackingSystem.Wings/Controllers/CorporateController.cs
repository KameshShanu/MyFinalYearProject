using Application.Corporates;
using AutoMapper;
using Domain.Corporates;
using MyVehicleTrackingSystem.Wings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Controllers
{
    public class CorporateController : Controller
    {
        private ICorporateService _corporateService;

        public CorporateController(CorporateService corporateService)
        {
            if (corporateService == null)
            {
                throw new NullReferenceException("corporateService");
            }
            _corporateService = corporateService;
        }
        // GET: Corporate 
        public ActionResult Index(string message, int? items)
        {
            if (message != null)
            {
                if (message.Equals("Success"))
                {
                    ModelState.AddModelError("", "Successfully deleted " + items + " corporate(s)");
                }
                else
                {
                    ModelState.AddModelError("", "Please select corporate(s) to delete");
                }
            }
            IEnumerable<Corporate> corporateList = _corporateService.RetrieveCorporate();
            IEnumerable<CorporateViewModel> models = Mapper.Map<IEnumerable<CorporateViewModel>>(corporateList);
            return View(models);
        }

        // GET: Corporate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Corporate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Corporate/Create
        [HttpPost]
        public ActionResult Create(Corporate model, string button)
        {
            try
            {
                _corporateService.SaveCorporate(model);
                if (button.Equals("SAVE CORPORATE"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.Clear();
                    ViewData["Success"] = "Successfully Added.";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Corporate/Edit/5
        public ActionResult Edit(int id)
        {
            Corporate corporate = _corporateService.RetrieveCorporateById(id);
            CorporateViewModel models = Mapper.Map<CorporateViewModel>(corporate);
            return View(models);
        }

        // POST: Corporate/Edit/5
        [HttpPost]
        public ActionResult Edit(Corporate model)
        {
            try
            {
                _corporateService.UpdateCorporate(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult MultipleCorporateDelete(IEnumerable<int> corporatesToDelete)
        {
            try
            {
                if (corporatesToDelete != null)
                {
                    _corporateService.DeleteMultipleCorporates(corporatesToDelete);
                    return RedirectToAction("Index", "Corporate", new { message = "Success", items = corporatesToDelete.Count() });
                }
                else
                {
                    return RedirectToAction("Index", "Corporate", new { message = "Error" });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        // GET: Corporate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Corporate/Delete/5
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
    }
}
