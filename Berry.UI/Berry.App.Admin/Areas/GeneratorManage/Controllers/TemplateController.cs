using System.Web.Mvc;
using Berry.App.Admin.Handler;
using Berry.Code;

namespace Berry.App.Admin.Areas.GeneratorManage.Controllers
{
    /// <summary>
    /// 模板管理
    /// </summary>
    public class TemplateController : BaseController
    {
        /// <summary>
        /// 模板列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 单表生成器
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SingleTable()
        {
            return View();
        }
        /// <summary>
        /// 多表生成器
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MultiTable()
        {
            return View();
        }
    }
}
