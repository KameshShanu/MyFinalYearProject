using Application.Trips;
using AutoMapper;
using Domain.Trips;
using MyVehicleTrackingSystem.Wings.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Controllers
{
    public class DataArchiveController : Controller
    {
        private readonly ITripService _tripService;
        private readonly IArchiveTripService _archiveTripService;

        public DataArchiveController(TripService tripService, ArchiveTripService archiveTripService)
        {
            _tripService = tripService;
            _archiveTripService = archiveTripService;
        }

        public ActionResult Menu()
        {
            return View();
        }

        // GET: DataArchive
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DateTime StartDate, DateTime EndDate)
        {
            try
            {
                IEnumerable<TripViewModel> models = new Collection<TripViewModel>();

                string status = _tripService.ArchiveTripsByDate(StartDate, EndDate);
                if (status == "Success")
                {
                    ModelState.AddModelError("", "Successfully Archived.");
                }
                else
                {
                    ModelState.AddModelError("", "Error occurred.");
                }
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult AchiveData(IEnumerable<int> tripsToAchive)
        {
            try
            {
                if (tripsToAchive != null)
                {
                    _tripService.ArchiveTrips(tripsToAchive);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult ArchiveTripIndex(string searchString, int? page = 1)
        {
            try
            {
                if (searchString != null)
                {
                    page = 1;
                    ViewBag.SearchData = searchString;
                }
                int pageSize = 20;
                int pageNumber = (page ?? 1);
                ArchiveTripCommonDTO archivedTrips = _archiveTripService.Retrieve(page, searchString);
                IEnumerable<ArchiveTripViewModel> models = null;
                ViewBag.Page = page;
                ViewBag.MaxPage = (archivedTrips.ItemCount / pageSize) - (archivedTrips.ItemCount % pageSize == 0 ? 1 : 0);
                if (archivedTrips != null)
                {
                    models = Mapper.Map<IEnumerable<ArchiveTripViewModel>>(archivedTrips.ArchivedTrips);
                }
                return View(models);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
