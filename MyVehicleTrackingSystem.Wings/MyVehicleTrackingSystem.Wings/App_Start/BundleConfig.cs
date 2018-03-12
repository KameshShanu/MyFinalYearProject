using System.Web;
using System.Web.Optimization;

namespace MyVehicleTrackingSystem.Wings
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/custom_script_create").Include(
                       "~/Scripts/user_js/trip_create_view_script.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom_script_edit").Include(
                    "~/Scripts/user_js/trip_edit_view_script.js"));

            bundles.Add(new ScriptBundle("~/bundles/sortable").Include(
                 "~/Scripts/Sortable.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.min.js",
                       "~/Scripts/moment.js",
                      "~/Scripts/moment.min.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/bootstrap-filestyle.js",
                      "~/Scripts/bootstrap-filestyle.min.js",
                      "~/Scripts/jquery.unobtrusive-ajax.min.js",
                      "~/Scripts/bootstrap-multiselect.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/jquery.loadingbar.js",
                      "~/Scripts/jm.spinner.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Site.css",
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/bootstrap-datetimepicker.min.css",
                      "~/Content/datepicker.css",
                      "~/Content/bootstrap-multiselect.css",
                      "~/Content/wingssite.css",
                      "~/Content/JQuery-UI-1.9.2.css",
                      "~/Content/PagedList.css",
                      "~/Content/loadingbar.css",
                      "~/Content/jm.spinner.css"));
        }
    }
}
