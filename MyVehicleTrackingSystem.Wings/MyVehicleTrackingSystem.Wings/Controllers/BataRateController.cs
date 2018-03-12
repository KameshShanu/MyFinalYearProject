using Application.BataRates;
using AutoMapper;
using Domain.BataRates;
using MyVehicleTrackingSystem.Wings.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Controllers
{
    public class BataRateController : Controller
    {

        private IBataRateService _bataRateService;

        public BataRateController(BataRateService bataRateService)
        {
            _bataRateService = bataRateService;
        }
        // GET: BataRate
        public ActionResult Index(string message, int? items)
        {
            if (message != null)
            {
                if (message.Equals("Success"))
                {
                    ModelState.AddModelError("", "Successfully deleted " + items + " bata rate(s)");
                }
                else
                {
                    ModelState.AddModelError("", "Please select  bata rate(s) to delete");
                }
            }
            IEnumerable<BataRateViewModel> model = new Collection<BataRateViewModel>();
            IEnumerable<BataRate> bata = _bataRateService.GetAllBataRates();
            model = Mapper.Map<IEnumerable<BataRateViewModel>>(bata);
            return View(model);
        }

        public ActionResult CreateBataRate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBataRate(BataRate model, string button)
        {
            try
            {
                _bataRateService.SaveBataRates(model);

                if (button.Equals("SAVE BATA"))
                {
                    return RedirectToAction("Index");
                }
                ModelState.Clear();
                ViewData["Success"] = "Successfully Added.";
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditBataRate(int id)
        {
            BataRateViewModel model = new BataRateViewModel();
            BataRate bata = _bataRateService.GetBataRateById(id);
            model = Mapper.Map<BataRateViewModel>(bata);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditBataRate(int id, BataRate models)
        {
            try
            {
                BataRateViewModel model = new BataRateViewModel();
                BataRate bata = _bataRateService.GetBataRateById(id);
                bata.Description = models.Description;
                bata.Amount = models.Amount;
                _bataRateService.SaveBataRates(bata);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult LoadBataAmountById(int bataId)
        {
            BataRate bata = _bataRateService.GetBataRateById(bataId);
            if (bata != null)
            {
                return Json(bata.Amount, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult MultipleBataRateDelete(IEnumerable<int> bataRateToDelete)
        {
            try
            {
                if (bataRateToDelete != null)
                {
                    _bataRateService.DeleteMultipleBataRates(bataRateToDelete);
                    return RedirectToAction("Index", "BataRate", new { message = "Success", items = bataRateToDelete.Count() });
                }
                else
                {
                    return RedirectToAction("Index", "BataRate", new { message = "Error" });
                }
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}
