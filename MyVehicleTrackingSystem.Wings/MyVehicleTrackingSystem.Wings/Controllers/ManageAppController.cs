using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Controllers
{
    public class ManageAppController : Controller
    {
        public ManageAppController()
        {
        }

        // GET: ManageApp
        public ActionResult Index()
        {
            return View();
        }

        // GET: ManageApp/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManageApp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageApp/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageApp/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManageApp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageApp/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManageApp/Delete/5
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
