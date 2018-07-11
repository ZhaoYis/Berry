using System.Web;
using System.Web.Mvc;
using Berry.SOA.API.Attributes;

namespace Berry.SOA.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomHandlerError());
        }
    }
}
