using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace DevDay.Infrastructure
{
    public static class BundlingExtensions
    {
        const string BundlesVirtualRoot = "~/bundles/";
        const string AngularAppsVirtualRoot = "~/Content/app/";

        public static Bundle IncludeAngularModule(this Bundle bundle, string directoryVirtualPath)
        {
            bundle.IncludeDirectory(directoryVirtualPath, "*.js", true);
            return bundle;
        }

        public static void AddAngularModule(this BundleCollection bundles, string angularAppUrl)
        {
            var url = string.Concat(BundlesVirtualRoot, angularAppUrl);

            try
            {
                var bundle = new ScriptBundle(url);
                bundle.IncludeDirectory(string.Concat(AngularAppsVirtualRoot, angularAppUrl), "*.js", true);

                bundles.Add(bundle);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Unable to add bundle: {0}", url), e);
            }
        }

        public static IHtmlString RenderAngularModuleScripts(this HtmlHelper helper, string angularAppUrl)
        {
            return Scripts.Render(string.Concat(BundlesVirtualRoot, angularAppUrl));
        }
    }
}