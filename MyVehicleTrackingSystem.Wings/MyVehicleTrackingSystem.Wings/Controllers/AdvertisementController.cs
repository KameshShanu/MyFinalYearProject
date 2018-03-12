using Application.Advertisements;
using Domain.Advertisements;
using MyVehicleTrackingSystem.Wings.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementCategoryService _advertisementCategoryService;
        private readonly IAdvertisementItemService _advertisementItemService;

        public AdvertisementController(AdvertisementCategoryService advertisementCategoryService, AdvertisementItemService advertisementItemService)
        {
            _advertisementCategoryService = advertisementCategoryService;
            _advertisementItemService = advertisementItemService;
        }
        public ActionResult Index(string message)
        {
            try
            {
                if (message != null)
                {
                    ModelState.AddModelError("", message);
                }

                IEnumerable<AdvertisementCategory> advertisement = _advertisementCategoryService.getAdvertisements();
                AdvertisementViewModel model = new AdvertisementViewModel()
                {
                    AdvertisementCategory = AutoMapper.Mapper.Map<IEnumerable<AdvertisementCategoryViewModel>>(advertisement),
                };
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult CreateAdvertisementCategory(AdvertisementViewModel model)
        {
            try
            {
                string statusmessage = "";
                string dateNow = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate().ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
                AdvertisementCategory advertisement = new AdvertisementCategory()
                {
                    FileType = "Image",
                    CategoryName = model.Category.CategoryName,
                    CreatedDate = dateNow
                };
                if (model.Category.UploadFile != null && model.Category.UploadFile.ContentLength > 0)
                {
                    if (CheckPostedFileType(model.Category.UploadFile, "Image"))
                    {
                        //string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/');
                        var uploadDir = "/Content/Advertisement/AdvertisementImage/";
                        string extension = Path.GetExtension(model.Category.UploadFile.FileName);
                        string uniqueFileName = Guid.NewGuid().ToString();
                        var imagePath = Path.Combine(Server.MapPath(uploadDir), uniqueFileName + extension);
                        var imageUrl = Path.Combine(uploadDir, uniqueFileName + extension);
                        model.Category.UploadFile.SaveAs(imagePath);
                        advertisement.FileURL = imageUrl;
                        _advertisementCategoryService.SaveAdvertisementCategory(advertisement);
                    }
                    else
                    {
                        statusmessage = "Image File should be .png/.jpeg/.jpg format";
                    }
                }
                return RedirectToAction("Index", "Advertisement", new { message = statusmessage });
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        [HttpPost]
        public ActionResult EditAdvertisementCategory(AdvertisementViewModel model)
        {
            try
            {
                string statusmessage = "";
                string dateNow = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate().ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
                AdvertisementCategory advertisement = new AdvertisementCategory()
                {
                    CategoryId = model.Category.CategoryId,
                    FileURL = model.Category.FileURL,
                    FileType = "Image",
                    CategoryName = model.Category.CategoryName,
                    ModifiedDate = dateNow
                };
                if (model.Category.UploadFile != null && model.Category.UploadFile.ContentLength > 0)
                {
                    if (CheckPostedFileType(model.Category.UploadFile, "Image"))
                    {
                        //string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/');
                        var uploadDir = "/Content/Advertisement/AdvertisementImage/";
                        string extension = Path.GetExtension(model.Category.UploadFile.FileName);
                        string uniqueFileName = Guid.NewGuid().ToString();
                        var imagePath = Path.Combine(Server.MapPath(uploadDir), uniqueFileName + extension);
                        var imageUrl = Path.Combine(uploadDir, uniqueFileName + extension);
                        model.Category.UploadFile.SaveAs(imagePath);

                        AdvertisementCategory advertisementget = _advertisementCategoryService.GetAdvertisementCategoryById(model.Category.CategoryId);
                        if (!string.IsNullOrEmpty(advertisementget.FileURL))
                        {
                            if (System.IO.File.Exists(Server.MapPath(advertisementget.FileURL)))
                            {
                                System.IO.File.Delete(Server.MapPath(advertisementget.FileURL));
                            }
                            advertisement.FileURL = imageUrl;
                        }
                    }
                    else
                    {
                        statusmessage = "Image File should be .png/.jpeg/.jpg format";
                    }
                }
                _advertisementCategoryService.UpdateAdvertisementCategory(advertisement);
                return RedirectToAction("Index", "Advertisement", new { message = statusmessage });
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        [HttpPost]
        public ActionResult CreateAdvertisementItem(AdvertisementViewModel model)
        {
            try
            {
                string statusmessage = "";
                string dateNow = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate().ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
                AdvertisementItem advertisement = new AdvertisementItem()
                {
                    FileType = "Video",
                    ItemName = model.Item.ItemName,
                    CategoryId = model.Item.CategoryId,
                    CreatedDate = dateNow
                };
                if (model.Item.UploadFile != null && model.Item.UploadFile.ContentLength > 0)
                {
                    if (CheckPostedFileType(model.Item.UploadFile, "Video"))
                    {
                        if (CheckPostedFileLength(model.Item.UploadFile, "Video"))
                        {
                            //string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/');
                            var uploadDir = "/Content/Advertisement/AdvertisementVideo/";
                            string extension = Path.GetExtension(model.Item.UploadFile.FileName);
                            string uniqueFileName = Guid.NewGuid().ToString();
                            var videoPath = Path.Combine(Server.MapPath(uploadDir), uniqueFileName + extension);
                            var videoUrl = Path.Combine(uploadDir, uniqueFileName + extension);
                            model.Item.UploadFile.SaveAs(videoPath);
                            advertisement.FileURL = videoUrl;
                            _advertisementItemService.SaveAdvertisementItem(advertisement);
                        }
                        else
                        {
                            statusmessage = "Video File should be less than 10MB";
                        }
                    }
                    else
                    {
                        statusmessage = "Video File should be .mp4 format";
                    }
                  
                }
                return RedirectToAction("Index", "Advertisement", new { message = statusmessage });
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        [HttpPost]
        public ActionResult EditAdvertisementItem(AdvertisementViewModel model)
        {
            try
            {
                string statusmessage = "";
                string dateNow = CustomDataHelper.CurrentDateTimeSL.GetCurrentDate().ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
                AdvertisementItem advertisement = new AdvertisementItem()
                {
                    ItemId = model.Item.ItemId,
                    ItemName = model.Item.ItemName,
                    FileURL = model.Item.FileURL,
                    ModifiedDate = dateNow
                };
                if (model.Item.UploadFile != null && model.Item.UploadFile.ContentLength > 0)
                {
                    if (CheckPostedFileType(model.Item.UploadFile, "Video"))
                    {
                        if (CheckPostedFileLength(model.Item.UploadFile, "Video"))
                        {
                            //string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/');
                            var uploadDir = "/Content/Advertisement/AdvertisementVideo/";
                            string extension = Path.GetExtension(model.Item.UploadFile.FileName);
                            string uniqueFileName = Guid.NewGuid().ToString();
                            var videoPath = Path.Combine(Server.MapPath(uploadDir), uniqueFileName + extension);
                            var videoUrl = Path.Combine(uploadDir, uniqueFileName + extension);
                            model.Item.UploadFile.SaveAs(videoPath);

                            AdvertisementItem advertisementget = _advertisementItemService.GetAdvertisementItemById(model.Item.ItemId);
                            if (!string.IsNullOrEmpty(advertisementget.FileURL))
                            {
                                if (System.IO.File.Exists(Server.MapPath(advertisementget.FileURL)))
                                {
                                    System.IO.File.Delete(Server.MapPath(advertisementget.FileURL));
                                }
                            }
                            advertisement.FileURL = videoUrl;
                        }
                        else
                        {
                            statusmessage = "Video File should be less than 10MB";
                        }
                    }
                    else
                    {
                        statusmessage = "Video File should be .mp4 format";
                    }
                }
                _advertisementItemService.UpdateAdvertisementItem(advertisement);
                return RedirectToAction("Index", "Advertisement", new { message = statusmessage });
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        public ActionResult DeleteAdvertisementCategory(int id)
        {
            try
            {
                string statusmessage = "";
                AdvertisementCategory advertisementget = _advertisementCategoryService.GetAdvertisementCategoryById(id);
                if (!string.IsNullOrEmpty(advertisementget.FileURL))
                {
                    if (System.IO.File.Exists(Server.MapPath(advertisementget.FileURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(advertisementget.FileURL));
                    }
                }
                if (advertisementget.AdvertisementItem != null)
                {
                    foreach (var add in advertisementget.AdvertisementItem)
                    {
                        if (System.IO.File.Exists(Server.MapPath(add.FileURL)))
                        {
                            System.IO.File.Delete(Server.MapPath(add.FileURL));
                        }
                        _advertisementItemService.DeleteAdvertisementItem(add.ItemId);
                    }
                }
                _advertisementCategoryService.DeleteAdvertisementCategory(id);
                return RedirectToAction("Index", "Advertisement", new { message = statusmessage });
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        public ActionResult DeleteAdvertisementItem(int id)
        {
            try
            {
                string statusmessage = "";
                AdvertisementItem advertisementget = _advertisementItemService.GetAdvertisementItemById(id);
                if (!string.IsNullOrEmpty(advertisementget.FileURL))
                {
                    if (System.IO.File.Exists(Server.MapPath(advertisementget.FileURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(advertisementget.FileURL));
                    }
                }
                _advertisementItemService.DeleteAdvertisementItem(id);
                return RedirectToAction("Index", "Advertisement", new { message = statusmessage });
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        public JsonResult SortAdvertisementCategories(List<int> items)
        {
            _advertisementCategoryService.SortAdvertisementCategories(items);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        public JsonResult SortAdvertisementItems(List<int> items)
        {

            _advertisementItemService.SortAdvertisementItems(items);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditItems(int id)
        {
            AdvertisementItemViewModel advertisement = AutoMapper.Mapper.Map<AdvertisementItemViewModel>(_advertisementItemService.GetAdvertisementItemById(id));
            return Json(advertisement, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditCategories(int id)
        {
            AdvertisementCategoryViewModel advertisement = AutoMapper.Mapper.Map<AdvertisementCategoryViewModel>(_advertisementCategoryService.GetAdvertisementCategoryById(id));
            return Json(advertisement, JsonRequestBehavior.AllowGet);
        }
        public static bool CheckPostedFileType(HttpPostedFileBase postedFile, string fileType)
        {
            bool status = false;
            if (fileType == "Image")
            {
                if (Path.GetExtension(postedFile.FileName).ToLower() == ".jpg" || Path.GetExtension(postedFile.FileName).ToLower() == ".png" || Path.GetExtension(postedFile.FileName).ToLower() == ".jpeg")
                {
                    status = true;
                }
            }
            else
            {
                if (Path.GetExtension(postedFile.FileName).ToLower() == ".mp4")
                {
                    status = true;
                }
            }
            return status;
        }
        public static bool CheckPostedFileLength(HttpPostedFileBase postedFile, string fileType)
        {
            var videoLength = System.Configuration.ConfigurationManager.AppSettings["videoLength"];
            bool status = true;
            if (fileType == "Video")
            {
                if (postedFile.ContentLength > Convert.ToInt32(videoLength))
                {
                    status = false;
                }
            }
            return status;
        }


        //using (BinaryReader br = new BinaryReader(model.Category.UploadFile.InputStream))
        //{
        //advertisement.CategoryName = model.Category.CategoryName;
        //Byte[] bytes = br.ReadBytes((Int32)model.Category.UploadFile.InputStream.Length);
        //advertisement.CategoryImageHash = Convert.ToBase64String(bytes, 0, bytes.Length);
        //}
    }
}
