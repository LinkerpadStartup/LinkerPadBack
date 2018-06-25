using System.Web.Optimization;

namespace LinkerPad
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/site/library").Include(
                        "~/Scripts/main.js"));         
        }
    }
}
