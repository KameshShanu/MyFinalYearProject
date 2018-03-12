using Application.Customers;
using AutoMapper;
using Domain.Customers;
using MyVehicleTrackingSystem.Wings.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVehicleTrackingSystem.Wings.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            if (customerService == null)
            {
                throw new NullReferenceException("customerService");
            }

            _customerService = customerService;
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel model)
        {
            try
            {
                
                if (_customerService.GetCustomerByPhoneNumber(model.PhoneNumber) == null )
                {
                    var currentUserId = User.Identity.GetUserId();
                    if (String.IsNullOrEmpty(currentUserId))
                    {
                        return Json(new { message = "Error is saving" });
                    }
                    Customer customer = new Customer();
                    customer = Mapper.Map<Customer>(model);
                    customer.UserId = currentUserId;
                    _customerService.SaveCustomer(customer);
                    return Json(new { message = "Customer succesfully added." });
                }
                else
                {
                    return Json(new { message = "This customer already exist." });
                }
                
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel model)
        {
            try
            {

                if (_customerService.GetCustomerByPhoneNumber(model.PhoneNumber) != null)
                {
                    if (String.IsNullOrEmpty(model.PhoneNumber))
                    {
                        return Json(new { message = "Plese Enter phone number." });
                    }
                    Customer customer = new Customer();
                    customer = Mapper.Map<Customer>(model);
                    _customerService.UpdateCustomer(customer);
                    return Json(new { message = "Customer succesfully updated." });
                }
                else
                {
                    return Json(new { message = "There is no customer for this phone number." });
                }

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        public JsonResult IsCustomerExistByPhonenumber(string phoneNumber)
        {
            try
            {
                Customer customer = _customerService.GetCustomerByPhoneNumber(phoneNumber);
                if (customer == null)
                {
                    return Json(new { isExist = false }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isExist = true, customer = customer }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception Ex)
            {

                throw Ex;
            }            
        }
    }
}