using System.Web.Mvc;
using Berry.App.Admin.Handler;
using Berry.Code;

namespace Berry.App.Admin
{
    /// <summary>
    /// FilterConfig
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// RegisterGlobalFilters
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandlerAuthorizeAttribute(PermissionMode.Enforce));
            filters.Add(new HandlerErrorAttribute());
        }
    }
}