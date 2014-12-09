using System.Web.Optimization;
using DevDay.Infrastructure;

namespace DevDay
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            SetupBundling(bundles);
            RegisterScriptBundles(bundles);
        }

        private static void SetupBundling(BundleCollection bundles)
        {
            var angularAppFileSetOrdering = new BundleFileSetOrdering("angular apps");
            angularAppFileSetOrdering.Files.Add("module.js");
            angularAppFileSetOrdering.Files.Add("config.js");
            bundles.FileSetOrderList.Insert(0, angularAppFileSetOrdering);
        }


        private static void RegisterScriptBundles(BundleCollection bundles)
        {
            bundles.AddAngularModule("common");
            bundles.AddAngularModule("retro");
        }
    }
}