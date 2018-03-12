using Application.Advertisements;
using Domain.Advertisements;
using MyVehicleTrackingSystem.Wings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Areas.Api.Controllers
{
    [AllowAnonymous]
    public class ServiceController : Controller
    {
        private readonly IAdvertisementCategoryService _advertisementService;

        public ServiceController(AdvertisementCategoryService advertisementService)
        {
            _advertisementService = advertisementService;
        }
        // GET: Api/Service
        public JsonResult Get()
        {
            try
            {
                IEnumerable<AdvertisementCategory> advertisement = _advertisementService.getAdvertisements();
                List<AdvertisementCategoryDTO> advertisementDto = AutoMapper.Mapper.Map<List<AdvertisementCategoryDTO>>(advertisement);
                return Json(advertisementDto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                AdvertisementCategoryDTO errorobj = new AdvertisementCategoryDTO()
                {
                    Error = "Error occurred"
                };
                return Json(errorobj, JsonRequestBehavior.AllowGet);
            }

        }
    }
}