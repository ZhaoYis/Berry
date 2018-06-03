using Berry.App.Admin.Handler;
using Berry.BLL.AuthorizeManage;
using Berry.Code.Operator;
using Berry.CodeGenerator;
using Berry.CodeGenerator.Model;
using Berry.CodeGenerator.Template;
using Berry.Entity.AuthorizeManage;
using Berry.Util;
using System.Web.Mvc;
using Berry.Extension;

namespace Berry.App.Admin.Areas.GeneratorManage.Controllers
{
    /// <summary>
    /// 生成器多表
    /// </summary>
    public class MultiTableController : BaseController
    {
        private ModuleBLL moduleBLL = new ModuleBLL();

        #region 视图功能

        /// <summary>
        /// 代码生成器
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CodeBuilder()
        {
            string OutputDirectory = Server.MapPath("~/Web.config"); ;
            for (int i = 0; i < 2; i++)
                OutputDirectory = OutputDirectory.Substring(0, OutputDirectory.LastIndexOf('\\'));
            ViewBag.OutputDirectory = OutputDirectory;
            ViewBag.UserName = OperatorProvider.Provider.Current().UserName;
            return View();
        }

        /// <summary>
        /// 编辑控件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditControl()
        {
            return View();
        }

        #endregion 视图功能

        #region 提交数据

        /// <summary>
        /// 查看代码
        /// </summary>
        /// <param name="baseInfoJson">基本信息配置</param>
        /// <param name="gridPrimaryFieldJson"></param>
        /// <param name="gridDetailsFieldJson"></param>
        /// <param name="formPrimaryFieldJson"></param>
        /// <param name="formDetailsFieldJson"></param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult LookCode(string baseInfoJson, string gridPrimaryFieldJson, string gridDetailsFieldJson, string formPrimaryFieldJson, string formDetailsFieldJson)
        {
            MultiTableConfigModel multiTableConfigModel = baseInfoJson.JsonToEntity<MultiTableConfigModel>();
            var gridPrimary = gridPrimaryFieldJson.JsonToList<GridColumnModel>();
            var gridDetails = gridDetailsFieldJson.JsonToList<GridColumnModel>();
            var formPrimary = formPrimaryFieldJson.JsonToList<GridColumnModel>();
            var formDetails = formDetailsFieldJson.JsonToList<GridColumnModel>();

            MultiTable multiTable = new MultiTable();

            string entitybuilder = multiTable.EntityBuilder(multiTableConfigModel, gridPrimary, false);//主表实体
            string childEntitybuilder = multiTable.EntityBuilder(multiTableConfigModel, gridDetails, true);//子表实体

            string entitymapbuilder = multiTable.EntityMapBuilder(multiTableConfigModel, false);//实体映射类
            string childEntitymapbuilder = multiTable.EntityMapBuilder(multiTableConfigModel, true);
            //服务类
            string servicebuilder = multiTable.ServiceBuilder(multiTableConfigModel);
            //服务接口类
            string iservicebuilder = multiTable.IServiceBuilder(multiTableConfigModel);
            //业务类
            string businesbuilder = multiTable.BusinesBuilder(multiTableConfigModel);
            //控制器
            string controllerbuilder = multiTable.ControllerBuilder(multiTableConfigModel);
            //主页面
            string indexbuilder = multiTable.IndexBuilder(multiTableConfigModel, gridPrimary, gridDetails);
            //表单页面
            string formbuilder = multiTable.FormBuilder(multiTableConfigModel, formPrimary, formDetails);

            var jsonData = new
            {
                entityCode = entitybuilder,
                entityChildCode = childEntitybuilder,
                entitymapCode = entitymapbuilder,
                entitymapChildCode = childEntitymapbuilder,
                serviceCode = servicebuilder,
                iserviceCode = iservicebuilder,
                businesCode = businesbuilder,
                controllerCode = controllerbuilder,
                indexCode = indexbuilder,
                formCode = formbuilder
            };
            return ToJsonResult(jsonData);
        }

        /// <summary>
        /// 创建代码（自动写入VS里面目录）
        /// </summary>
        /// <param name="baseInfoJson">基本信息配置Json</param>
        /// <param name="strCode">生成代码内容</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult CreateCode(string baseInfoJson, string strCode)
        {
            MultiTableConfigModel baseConfigModel = baseInfoJson.JsonToEntity<MultiTableConfigModel>();
            CreateCodeFile.CreateExecution(baseConfigModel, Server.UrlDecode(strCode));
            return Success("恭喜您，创建成功！");
        }

        /// <summary>
        /// 发布功能（自动创建导航菜单）
        /// </summary>
        /// <param name="baseInfoJson">基本信息配置Json</param>
        /// <param name="moduleEntity">功能实体</param>
        /// <param name="moduleButtonListJson">按钮实体列表</param>
        /// <param name="moduleColumnListJson">视图实体列表</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult PublishModule(string baseInfoJson, ModuleEntity moduleEntity, string moduleButtonListJson, string moduleColumnListJson)
        {
            MultiTableConfigModel baseConfigModel = baseInfoJson.JsonToEntity<MultiTableConfigModel>();
            var urlAddress = "/" + baseConfigModel.OutputAreas + "/" + StringHelper.DelLastLength(baseConfigModel.ControllerName, 10) + "/" + baseConfigModel.IndexPageName;

            moduleEntity.SortCode = moduleBLL.GetSortCode();
            moduleEntity.IsMenu = true;
            moduleEntity.EnabledMark = true;
            moduleEntity.Target = "iframe";
            moduleEntity.UrlAddress = urlAddress;
            moduleBLL.SaveForm("", moduleEntity, moduleButtonListJson, moduleColumnListJson);
            return Success("发布成功！");
        }

        #endregion 提交数据
    }
}