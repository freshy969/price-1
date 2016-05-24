using System.Web.Optimization;

namespace Web
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(new ScriptBundle("~/bundles/material").Include(
                      "~/Scripts/material.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-material").Include(
                      "~/Scripts/bower_components/angular/angular.js",
                      "~/Scripts/bower_components/angular-animate/angular-animate.js",
                      "~/Scripts/bower_components/angular-aria/angular-aria.js",
                      "~/Scripts/bower_components/angular-messages/angular-messages.js",
                      "~/Scripts/bower_components/angular-material/angular-material.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/material.min.css",
                      "~/Content/styles.css"));

            bundles.Add(new StyleBundle("~/Content/angular-css").Include(
                      "~/Scripts/bower_components/angular-material/angular-material.css",
                      "~/Content/styles-md.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
