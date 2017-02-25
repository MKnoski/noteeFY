using System.Web.Optimization;

namespace NoteeFY
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles
                .Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery/jquery-{version}.js",
                         "~/Scripts/jquery/jquery-ui.js"));

            bundles
                .Add(new ScriptBundle("~/bundles/external")
                .Include("~/Scripts/external/autosize.min.js",
                         "~/Scripts/external/bootbox.min.js",
                         "~/Scripts/external/bootstrap.min.js",
                         "~/Scripts/external/colpick.js",
                         "~/Scripts/external/imagesloaded.pkgd.min.js",
                         "~/Scripts/external/masonry.pkgd.js",
                         "~/Scripts/external/moment-with-locales.min.js"));

            bundles
                .Add(new ScriptBundle("~/bundles/knockout")
                .Include("~/Scripts/knockout/knockout-{version}.debug.js",
                         "~/Scripts/knockout/knockout-{version}.js",
                         "~/Scripts/knockout/knockout-bootstrap.min.js",
                         "~/Scripts/knockout/knockout-sortable.min.js"));

            bundles
                .Add(new ScriptBundle("~/bundles/app")
                .Include("~/Scripts/models/note.js",
                         "~/Scripts/models/task.js",
                         "~/Scripts/models/user.js",
                         "~/Scripts/app.js"));

            bundles
                .Add(new StyleBundle("~/bundles/css")
                .Include("~/Styles/Content/bootstrap.css",
                         "~/Styles/font-awesome/css/font-awesome.min.css",
                         "~/Styles/colpick.css",
                         "~/Styles/app.css"));
        }
    }
}
