using DBStorage.Common;
using ProjectX.App_Start;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace MyVehicleTrackingSystem.Wings
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();

            //Database.SetInitializer(new WingsSeeder());

#if !DEBUG
    BundleTable.EnableOptimizations = true;
#endif
        }

        public class ProvideDirectAccessAttribute : Attribute
        {
        }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class NoDirectAccessAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var requestedUrl = HttpContext.Current.Request.Url.AbsolutePath;
                if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(ProvideDirectAccessAttribute), false).Any())
                {
                    return;
                }
                if (filterContext.HttpContext.Request.UrlReferrer == null || filterContext.HttpContext.Request.Url.Host != filterContext.HttpContext.Request.UrlReferrer.Host || HttpContext.Current.Session["CurrentUserName"] == null)
                //if (HttpContext.Current.Session["CurrentUserName"] == null)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "User", action = "LogIn", returnUrl = requestedUrl }));
                }
            }
        }

        public class DisableUserSessionAttribute : Attribute
        {
        }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
        public class CheckUserSessionAttribute : ActionFilterAttribute
        {

            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                HttpSessionStateBase session = filterContext.HttpContext.Session;
                var user = session["CurrentUserName"];

                if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(DisableUserSessionAttribute), false).Any())
                {
                    return;
                }
                else if (((user == null) && (!session.IsNewSession)) || (session.IsNewSession))
                {
                    //send them off to the login page
                    var url = new UrlHelper(filterContext.RequestContext);
                    var loginUrl = url.Content("~/User/LogIn");
                    session.RemoveAll();
                    session.Clear();
                    session.Abandon();
                    filterContext.HttpContext.Response.Redirect(loginUrl, true);
                }
            }
        }

        public class AuthorizationFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                   || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
                {
                    return;
                }
                if (HttpContext.Current.Session["CurrentUserName"] == null)
                {
                    filterContext.Result = filterContext.Result = new HttpUnauthorizedResult();
                }
                base.OnActionExecuting(filterContext);
            }
        }
    }
}
