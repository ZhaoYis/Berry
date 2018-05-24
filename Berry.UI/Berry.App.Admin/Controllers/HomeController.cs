using Berry.App.Admin.Handler;
using Berry.Code;
using Berry.Code.Operator;
using Berry.Entity.SystemManage;
using Berry.Extension;
using System.Web.Mvc;
using Berry.BLL.SystemManage;
using Berry.Log;

namespace Berry.App.Admin.Controllers
{
    /// <summary>
    /// 后台首页
    /// </summary>
    [HandlerLogin(LoginMode.Enforce)]
    public class HomeController : BaseController
    {
        //private LogHelper logHelper = new LogHelper(typeof(HomeController));
        private LogBLL logBll = new LogBLL();
        
        #region 视图功能

        /// <summary>
        /// 后台框架页
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminDefault()
        {
            return View();
        }

        public ActionResult AdminDefaultDesktop()
        {
            return View();
        }
        
        #endregion 视图功能

        #region 提交数据

        /// <summary>
        /// 访问功能
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <param name="moduleName">功能模块</param>
        /// <param name="moduleUrl">访问路径</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult VisitModule(string moduleId, string moduleName, string moduleUrl)
        {
            LogEntity logEntity = new LogEntity
            {
                CategoryId = (int)CategoryType.Visit,
                OperateTypeId = ((int)OperationType.Visit).ToString(),
                OperateType = OperationType.Visit.GetEnumDescription(),
                OperateAccount = OperatorProvider.Provider.Current().Account,
                OperateUserId = OperatorProvider.Provider.Current().UserId,
                ModuleId = moduleId,
                Module = moduleName,
                ExecuteResult = 1,
                ExecuteResultJson = "访问地址：" + moduleUrl
            };
            logBll.WriteLog(logEntity);

            return Content(moduleId);
        }

        /// <summary>
        /// 离开功能
        /// </summary>
        /// <param name="moduleId">功能模块Id</param>
        /// <returns></returns>
        public ActionResult LeaveModule(string moduleId)
        {
            return null;
        }

        #endregion 提交数据
    }
}