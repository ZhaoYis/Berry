using System.Web.Mvc;

namespace Berry.App.Admin.Areas.CustomManage
{
    public class CustomManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CustomManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                this.AreaName + "_default",
                this.AreaName + "/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}