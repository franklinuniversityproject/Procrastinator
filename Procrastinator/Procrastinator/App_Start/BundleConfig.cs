using System.Web;
using System.Web.Optimization;

namespace Procrastinator
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.isotope.min.js",
                        "~/Scripts/wow.min.js",
                        "~/Scripts/functions.js",
                        "~/Scripts/fancybox/jquery.fancybox.pack.js",
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/font-awesome.css",
                        "~/Content/font-awesome.min.css",
                        "~/Content/isotope.css",
                        "~/Content/bootstrap.min.css",
                        "~/Scripts/fancybox/jquery.fancybox.css",
                        "~/Content/style.css"));
        }
    }
}
