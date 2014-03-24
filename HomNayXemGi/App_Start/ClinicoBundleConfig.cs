using System.Web;
using System.Web.Optimization;

namespace HomNayXemGi
{
    public class ClinicoBundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/Clinco/css").Include(
                         "~/Content/Clinico/css/*.css",
                         "~/Content/Clinico/css/fullwidth/skin.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-other").Include(
                        "~/Scripts/jquery-ui.min.js",
                        "~/Scripts/jquery.migrate.min.js"));

            

            bundles.Add(new ScriptBundle("~/bundles/clinico").Include(
                        "~/Content/Clinico/js/*.js"));

            var bootstrapOrdering = new BundleFileSetOrdering("Hoang");

            bundles.FileSetOrderList.Add(bootstrapOrdering);

            bundles.IgnoreList.Clear();
        }
    }
}