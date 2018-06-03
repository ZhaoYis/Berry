using Berry.App.Admin.Handler;
using Berry.BLL.AuthorizeManage;
using Berry.BLL.SystemManage;
using Berry.Code.Operator;
using Berry.CodeGenerator;
using Berry.CodeGenerator.Model;
using Berry.CodeGenerator.Template;
using Berry.Entity.AuthorizeManage;
using Berry.Extension;
using Berry.Util;
using Lottomat.Application.Entity.SystemManage;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Berry.App.Admin.Areas.GeneratorManage.Controllers
{
    /// <summary>
    /// 生成器单表
    /// </summary>
    public class SingleTableController : BaseController
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
            for (int i = 0; i < 3; i++)
                OutputDirectory = OutputDirectory.Substring(0, OutputDirectory.LastIndexOf('\\'));
            ViewBag.OutputDirectory = OutputDirectory;
            ViewBag.UserName = OperatorProvider.Provider.Current().UserName;
            return View();
        }

        /// <summary>
        /// 编辑表格
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditGrid()
        {
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
        /// <param name="baseInfoJson">基本信息配置Json</param>
        /// <param name="gridInfoJson">表格信息Json</param>
        /// <param name="gridColumnJson">表格字段信息Json</param>
        /// <param name="formInfoJson">表单信息Json</param>
        /// <param name="formFieldJson">表单字段信息Json</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult LookCode(string baseInfoJson, string gridInfoJson, string gridColumnJson, string formInfoJson, string formFieldJson)
        {
            SingleTable default_Template = new SingleTable();
            BaseConfigModel baseConfigModel = baseInfoJson.JsonToEntity<BaseConfigModel>();
            baseConfigModel.gridModel = gridInfoJson.JsonToEntity<GridModel>();
            baseConfigModel.gridColumnModel = gridColumnJson.JsonToList<GridColumnModel>();
            baseConfigModel.formModel = formInfoJson.JsonToEntity<FormModel>();
            baseConfigModel.formFieldModel = formFieldJson.JsonToList<FormFieldModel>();

            var tableFiled = new DataBaseTableBLL().GetTableFiledList(baseConfigModel.Id, baseConfigModel.DataBaseTableName);

            string entitybuilder = default_Template.EntityBuilder(baseConfigModel, tableFiled.ToList().ListToDataTable<DataBaseTableFieldEntity>());
            string entitymapbuilder = default_Template.EntityMapBuilder(baseConfigModel);

            string servicebuilder = default_Template.ServiceBuilder(baseConfigModel);
            string iservicebuilder = default_Template.IServiceBuilder(baseConfigModel);

            string businesbuilder = default_Template.BusinesBuilder(baseConfigModel);
            string ibusinesbuilder = default_Template.IBusinesBuilder(baseConfigModel);

            string controllerbuilder = default_Template.ControllerBuilder(baseConfigModel);

            string indexbuilder = default_Template.IndexBuilder(baseConfigModel);
            string formbuilder = default_Template.FormBuilder(baseConfigModel);
            var jsonData = new
            {
                entityCode = entitybuilder,
                entitymapCode = entitymapbuilder,
                serviceCode = servicebuilder,
                iserviceCode = iservicebuilder,
                businesCode = businesbuilder,
                ibusinesCode = ibusinesbuilder,
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
            BaseConfigModel baseConfigModel = baseInfoJson.JsonToEntity<BaseConfigModel>();
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
            BaseConfigModel baseConfigModel = baseInfoJson.JsonToEntity<BaseConfigModel>();
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

        #region 处理数据

        /// <summary>
        /// 加载模板数据
        /// </summary>
        /// <param name="templateId">模板Id</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTemplateData(string templateId)
        {
            string filepath = Server.MapPath("~/Areas/SystemManage/Views/CodeGenerator/template/" + templateId + ".txt");
            FileStream fs = new System.IO.FileStream(filepath, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
            return Content(sr.ReadToEnd().ToString());
        }

        #endregion 处理数据
    }
}