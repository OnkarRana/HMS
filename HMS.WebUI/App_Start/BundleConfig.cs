using System.Web;
using System.Web.Optimization;

namespace HMS.WebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/bootstrap.min.js",
                    "~/Scripts/Chart.js"
                    ));
            bundles.Add(new ScriptBundle("~/adminlte/js").Include(
                    "~/Content/adminlte/js/adminlte.min.js",
                    "~/Content/adminlte/plugins/summernote/summernote-bs4.min.js"
    ));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/adminlte/fontawesome-free/css/all.min.css",
                     "~/Content/adminlte/css/adminlte.min.css","~/Content/Chart.css",
                     "~/Content/site.css"
             ));
        }
    }
}
