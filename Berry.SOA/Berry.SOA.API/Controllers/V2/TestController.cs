using System.Net.Http;
using System.Web.Http;
using Berry.Code;
using Berry.Entity;
using Berry.Extension;
using Berry.SOA.API.Controllers.Base;
using Berry.SOA.API.ParameterModel;

namespace Berry.SOA.API.Controllers
{
    /// <summary>
    /// API测试控制器，版本：V2.0
    /// </summary>
    public partial class TestController : BaseApiController
    {
        [HttpGet]
        public string GetIndex()
        {
            return "这是v2版本的Index";
        }
    }
}
