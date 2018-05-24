using System.Web.Optimization;

namespace Berry.App.Admin
{
    public class BundleConfig
    {
        /// <summary>
        /// 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            //JQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Content/scripts/jquery/jquery-1.10.2.min.js"));

            //Bootstrap组件
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                "~/Content/scripts/bootstrap/bootstrap.min.js"));
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                "~/Content/scripts/bootstrap/bootstrap.min.css"
                , "~/Content/styles/font-awesome.min.css"));

            //工具集
            bundles.Add(new ScriptBundle("~/bundles/utils").Include(
                "~/Content/scripts/plugins/cookie/jquery.cookie.js"
                , "~/Content/scripts/plugins/jquery.md5.js"
                , "~/Content/scripts/utils/berry-ajax.js"
                , "~/Content/scripts/utils/berry-ui.js"
                , "~/Content/scripts/utils/berry-form.js"
                , "~/Content/scripts/utils/utils.js"));

            //jqgrid
            bundles.Add(new ScriptBundle("~/bundles/jqgrid/js").Include(
                "~/Content/scripts/plugins/jqgrid/grid.locale-cn.js"
                , "~/Content/scripts/plugins/jqgrid/jqgrid.min.js"));
            bundles.Add(new StyleBundle("~/bundles/jqgrid/css").Include("~/Content/scripts/plugins/jqgrid/jqgrid.css"));

            //树形组件
            bundles.Add(new ScriptBundle("~/bundles/tree/js").Include("~/Content/scripts/plugins/tree/tree.js"));
            bundles.Add(new StyleBundle("~/bundles/tree/css").Include("~/Content/scripts/plugins/tree/tree.css"));
        }
    }
}