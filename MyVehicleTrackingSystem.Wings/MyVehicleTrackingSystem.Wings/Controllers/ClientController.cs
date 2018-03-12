using Application.Client;
using MyVehicleTrackingSystem.Wings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Domain.Client;

namespace MyVehicleTrackingSystem.Wings.Controllers
{
    public class ClientController : Controller
    {
        private IClientService _clientService;

        public ClientController(ClientService clientService)
        {
            if (clientService == null)
            {
                throw new NullReferenceException("clientService");
            }
            _clientService = clientService;
        }

        // GET: Client
        public ActionResult Index(string message, int? items)
        {
            if (message != null)
            {
                if (message.Equals("Success"))
                {
                    ModelState.AddModelError("", "Successfully deleted " + items + " client(s)");
                }
                else
                {
                    ModelState.AddModelError("", "Please select client(s) to delete");
                }
            }
            IEnumerable<Domain.Client.Client> clients = _clientService.GetAllClients();
            IEnumerable<ClientViewModel> models = Mapper.Map<IEnumerable<ClientViewModel>>(clients);
            return View(models);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(ClientViewModel model, string button)
        {
            try
            {
                    Client client = new Client();
                    client = Mapper.Map<Client>(model);
                    _clientService.SaveClient(client);

                    if (button.Equals("SAVE CLIENT"))
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.Clear();
                    ViewData["Success"] = "Successfully Added.";
                
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Domain.Client.Client client = _clientService.GetClientById(id);
                ClientViewModel model = Mapper.Map<ClientViewModel>(client);
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ClientViewModel model)
        {
            try
            {
                Domain.Client.Client client = _clientService.GetClientById(id);
                client = Mapper.Map<Client>(model);
                _clientService.EditClient(id, client);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Client/Delete/5
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
        public ActionResult MultipleClientDelete(IEnumerable<int> clientsToDelete)
        {
            try
            {
                if (clientsToDelete != null)
                {
                    _clientService.DeleteMultipleClients(clientsToDelete);
                    return RedirectToAction("Index", "Client", new { message = "Success", items = clientsToDelete.Count() });
                }
                else
                {
                    return RedirectToAction("Index", "Client", new { message = "Error" });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult Menu()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AutocompleteName(string prefix)
        {
            IEnumerable<Domain.Client.Client> clients = _clientService.GetAllClients().Distinct();

            IEnumerable<ClientViewModel> result = (from client in clients
                                                   where client.CompanyName.StartsWith(prefix, true, null)
                                                   group client by client.CompanyName into grp
                                                   select new ClientViewModel() { CompanyName = grp.Key }).Distinct();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AutocompleteAddress(string prefix)
        {
            IEnumerable<Domain.Client.Client> clients = _clientService.GetAllClients().Where(c => c.CompanyAddress != null);

            IEnumerable<ClientViewModel> result = (from client in clients
                                                   where client.CompanyAddress.StartsWith(prefix, true, null)
                                                   group client by client.CompanyAddress into grp
                                                   select new ClientViewModel() { CompanyAddress = grp.Key }).Distinct();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AutocompletePhoneNumber1(string prefix)
        {
            IEnumerable<Domain.Client.Client> clients = _clientService.GetAllClients().Where(c => c.PhoneNumber1 != null);

            IEnumerable<ClientViewModel> result = (from client in clients
                                                   where client.PhoneNumber1.StartsWith(prefix, true, null)
                                                   group client by client.PhoneNumber1 into grp
                                                   select new ClientViewModel() { PhoneNumber1 = grp.Key }).Distinct();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AutocompletePhoneNumber2(string prefix)
        {
            IEnumerable<Domain.Client.Client> clients = _clientService.GetAllClients().Where(c => c.PhoneNumber2 != null);

            IEnumerable<ClientViewModel> result = (from client in clients
                                                   where client.PhoneNumber2.StartsWith(prefix, true, null)
                                                   group client by client.PhoneNumber2 into grp
                                                   select new ClientViewModel() { PhoneNumber2 = grp.Key }).Distinct();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AutocompleteVAT(string prefix)
        {
            IEnumerable<Domain.Client.Client> clients = _clientService.GetAllClients().Where(c => c.VAT != null);

            IEnumerable<ClientViewModel> result = (from client in clients
                                                   where client.VAT.StartsWith(prefix, true, null)
                                                   group client by client.VAT into grp
                                                   select new ClientViewModel() { VAT = grp.Key }).Distinct();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AutocompleteSVAT(string prefix)
        {
            IEnumerable<Domain.Client.Client> clients = _clientService.GetAllClients().Where(c => c.SVAT != null);

            IEnumerable<ClientViewModel> result = (from client in clients
                                                   where client.SVAT.StartsWith(prefix, true, null)
                                                   group client by client.SVAT into grp
                                                   select new ClientViewModel() { SVAT = grp.Key }).Distinct();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}