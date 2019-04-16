using System.Web;
using System.Web.Optimization;

namespace StreetEats
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
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/streeteats").Include(
                      "~/Scripts/streeteats-1.0.js",
                      "~/Scripts/baguetteBox.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/jquery.ui.css",
                      "~/Content/contact.css",
                      "~/Content/animate.css",
                      "~/Content/fluid-gallery.css",
                      "~/Content/baguetteBox.min.css"));
            bundles.Add(new StyleBundle("~/bundle/css/wedding").Include(
                "~/Content/wedding.css"));
            bundles.Add(new StyleBundle("~/bundle/css/corporate").Include(
                "~/Content/corporate.css"));
            bundles.Add(new StyleBundle("~/bundle/css/testimonies").Include(
                "~/Content/testimony.css"));
            bundles.Add(new StyleBundle("~/bundle/css/home").Include(
                "~/Content/home.css"));
            bundles.Add(new StyleBundle("~/bundle/css/news").Include(
                "~/Content/news.css"));
            bundles.Add(new StyleBundle("~/bundle/css/gallery").Include(
                "~/Content/gallery.css"));
            bundles.Add(new StyleBundle("~/bundle/css/about").Include(
                "~/Content/about.css"));
        }
    }
}
