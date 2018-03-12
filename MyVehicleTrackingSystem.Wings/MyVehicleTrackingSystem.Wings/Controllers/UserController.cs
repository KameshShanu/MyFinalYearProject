using Application.Roles;
using Application.Users;
using AutoMapper;
using Domain.DTO;
using Domain.Roles;
using Domain.Users;
using MyVehicleTrackingSystem.Wings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyVehicleTrackingSystem.Wings.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(UserService userService, RoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return RedirectToAction("LogIn", "Account");           
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LogIn(UserViewModel user)
        {
            try
            {
                UserViewModel model = new UserViewModel()
                {
                    HotelNameList = GetHotels()
                };               
                User selectedUser = _userService.GetUserByEmail(user.Email);
                if (selectedUser != null)
                {
                    if (selectedUser.Password == user.Password)
                    {
                        HttpCookie RoleId = new HttpCookie("UserRole", selectedUser.RoleId.ToString());
                        FormsAuthentication.SetAuthCookie(selectedUser.FirstName + " " + selectedUser.LastName, true);
                        HttpCookie LoggedUser = new HttpCookie("LoggedUser", (selectedUser.FirstName + " " + selectedUser.LastName).ToString());
                        Session["CurrentUserName"] = (selectedUser.FirstName + " " + selectedUser.LastName);
                        Response.Cookies.Add(RoleId);
                        Response.Cookies.Add(LoggedUser);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Password is wrong");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "You are not registered");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult Register()
        {
            UserViewModel model = new UserViewModel();
            model.UserType = GetAllUserRoles().ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(User user, string button)
        {
            UserViewModel model = new UserViewModel();
            model.UserType = GetAllUserRoles().ToList();
            try
            {
                if (_userService.IsUserExists(user.Email))
                {
                    _userService.SaveUser(user);
                    ModelState.Clear();
                    ViewData["RegistrationSuccess"] = "Successfully added new user";
                }
                else
                {
                    ModelState.AddModelError("", "Email already Exists");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex;
                return RedirectToAction("Index", "Exception");
            }
        }

        public ActionResult UserIndex()
        {
            try
            {
                UserListViewModel userListViewModel = new UserListViewModel();
                IEnumerable<UserDto> userDtos = _userService.RetrieveAllUsersWithRole().Where(a => a.Role != "Business Owner");
                if (userDtos != null)
                {
                    userListViewModel.UserList = Mapper.Map<IEnumerable<UserViewModel>>(userDtos.Where(u => !string.IsNullOrEmpty(u.Role)));
                }
                return View(userListViewModel);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult LogOff()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            HttpCookie aCookie;
            string cookieName;
            int limit = Request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                cookieName = Request.Cookies[i].Name;
                aCookie = new HttpCookie(cookieName);
                aCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(aCookie);
            }

            HttpContext.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Response.AddHeader("Expires", "0");

            return RedirectToAction("LogIn", "Account");            
        }

        [HttpPost]
        public ActionResult DeleteUser(string userToDelete)
        {
            try
            {
                if (userToDelete != null)
                {
                    List<string> selectedUserId = new List<string>();
                    selectedUserId.Add(userToDelete);
                    _userService.DeleteMultipleUsers(selectedUserId);
                    return RedirectToAction("UserIndex", "User", new { message = "Success", items = userToDelete.Count() });
                }
                else
                {
                    return RedirectToAction("UserIndex", "User", new { message = "Error" });
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        private IEnumerable<SelectListItem> GetHotels()
        {
            List<SelectListItem> hotels = CustomDataHelper.DataHelper.GetHotels();
            hotels.Insert(0, new SelectListItem { Value = "0", Text = "Choose a Hotel", Selected = true });
            return hotels;
        }
        private IEnumerable<SelectListItem> GetAllUserRoles()
        {
            IEnumerable<Role> userRole = _roleService.getUserRoles().Where(a => !a.RoleId.Equals(5));
            IEnumerable<SelectListItem> role = userRole.Select(x => new SelectListItem
            {
                Value = x.RoleId.ToString(),
                Text = x.RoleName.ToString()
            });
            return new SelectList(role, "Value", "Text");
        }
    }
}