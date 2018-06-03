using Berry.CodeGenerator.Model;
using Berry.Extension;
using Berry.Util;

namespace Berry.CodeGenerator
{
    /// <summary>
    /// 自动创建代码
    /// </summary>
    public class CreateCodeFile
    {
        /// <summary>
        /// 执行创建文件
        /// </summary>
        /// <param name="baseConfigModel">基本信息</param>
        /// <param name="strCode">生成代码内容</param>
        public static void CreateExecution(BaseConfigModel baseConfigModel, string strCode)
        {
            var strParam = strCode.TryToJObject();

            #region 实体类

            string entityCode = strParam["entityCode"].ToString();
            string entityPath = baseConfigModel.OutputEntity + "\\" + baseConfigModel.OutputAreas + "\\" + baseConfigModel.EntityClassName + ".cs";
            if (!System.IO.File.Exists(entityPath))
            {
                DirFileHelper.CreateFileContent(entityPath, entityCode);
            }

            #endregion 实体类

            #region 映射类

            string entitymapCode = strParam["entitymapCode"].ToString();
            string entitymapPath = baseConfigModel.OutputMap + "\\" + baseConfigModel.OutputAreas + "\\" + baseConfigModel.MapClassName + ".cs";
            if (!System.IO.File.Exists(entitymapPath))
            {
                DirFileHelper.CreateFileContent(entitymapPath, entitymapCode);
            }

            #endregion 映射类

            #region 服务类

            string serviceCode = strParam["serviceCode"].ToString();
            string servicePath = baseConfigModel.OutputService + "\\" + baseConfigModel.OutputAreas + "\\" + baseConfigModel.ServiceClassName + ".cs";
            if (!System.IO.File.Exists(servicePath))
            {
                DirFileHelper.CreateFileContent(servicePath, serviceCode);
            }

            #endregion 服务类

            #region 接口类

            string iserviceCode = strParam["iserviceCode"].ToString();
            string iservicePath = baseConfigModel.OutputIService + "\\" + baseConfigModel.OutputAreas + "\\" + baseConfigModel.IServiceClassName + ".cs";
            if (!System.IO.File.Exists(iservicePath))
            {
                DirFileHelper.CreateFileContent(iservicePath, iserviceCode);
            }

            #endregion 接口类

            #region 业务类

            string businesCode = strParam["businesCode"].ToString();
            string businesPath = baseConfigModel.OutputBusines + "\\" + baseConfigModel.OutputAreas + "\\" + baseConfigModel.BusinesClassName + ".cs";
            if (!System.IO.File.Exists(businesPath))
            {
                DirFileHelper.CreateFileContent(businesPath, businesCode);
            }

            #endregion 业务类

            #region 业务接口类

            string ibusinesCode = strParam["ibusinesCode"].ToString();
            string ibusinesPath = baseConfigModel.OutputIBusines + "\\" + baseConfigModel.OutputAreas + "\\I" + baseConfigModel.BusinesClassName + ".cs";
            if (!System.IO.File.Exists(ibusinesPath))
            {
                DirFileHelper.CreateFileContent(ibusinesPath, ibusinesCode);
            }

            #endregion 业务类

            #region 控制器

            string controllerCode = strParam["controllerCode"].ToString();
            string controllerPath = baseConfigModel.OutputController + "\\Areas\\" + baseConfigModel.OutputAreas + "\\Controllers\\" + baseConfigModel.ControllerName + ".cs";
            if (!System.IO.File.Exists(controllerPath))
            {
                DirFileHelper.CreateFileContent(controllerPath, controllerCode);
            }

            #endregion 控制器

            #region 列表页

            string indexCode = strParam["indexCode"].ToString();
            string indexPath = baseConfigModel.OutputController + "\\Areas\\" + baseConfigModel.OutputAreas + "\\Views\\" + StringHelper.DelLastLength(baseConfigModel.ControllerName, 10) + "\\" + baseConfigModel.IndexPageName + ".cshtml";
            if (!System.IO.File.Exists(indexPath))
            {
                DirFileHelper.CreateFileContent(indexPath, indexCode.Replace("★", "&nbsp;"));
            }

            #endregion 列表页

            #region 表单页

            string formCode = strParam["formCode"].ToString();
            string formPath = baseConfigModel.OutputController + "\\Areas\\" + baseConfigModel.OutputAreas + "\\Views\\" + StringHelper.DelLastLength(baseConfigModel.ControllerName, 10) + "\\" + baseConfigModel.FormPageName + ".cshtml";
            if (!System.IO.File.Exists(formPath))
            {
                DirFileHelper.CreateFileContent(formPath, formCode.Replace("★", "&nbsp;"));
            }

            #endregion 表单页
        }

        /// <summary>
        /// 执行创建文件(多表)
        /// </summary>
        /// <param name="baseConfigModel"></param>
        /// <param name="strCode"></param>
        public static void CreateExecution(MultiTableConfigModel baseConfigModel, string strCode)
        {
            var strParam = strCode.TryToJObject();

            #region 实体类

            string entityCode = strParam["entityCode"].ToString();
            string entityPath = baseConfigModel.OutputEntity + "\\" + baseConfigModel.OutputAreas + "\\" + baseConfigModel.EntityClassName + ".cs";
            if (!System.IO.File.Exists(entityPath))
            {
                DirFileHelper.CreateFileContent(entityPath, entityCode);
            }

            #endregion 实体类

            #region 实体子类

            string entityChildCode = strParam["entityChildCode"].ToString();
            string entityChildPath = baseConfigModel.OutputEntity + "\\" + baseConfigModel.OutputAreas + "\\" + baseConfigModel.ChildTableName + "Entity.cs";
            if (!System.IO.File.Exists(entityChildPath))
            {
                DirFileHelper.CreateFileContent(entityChildPath, entityChildCode);
            }

            #endregion 实体子类

            #region 映射类

            string entitymapCode = strParam["entitymapCode"].ToString();
            string entitymapPath = baseConfigModel.OutputMap + "\\" + baseConfigModel.OutputAreas + "\\" + baseConfigModel.MapClassName + ".cs";
            if (!System.IO.File.Exists(entitymapPath))
            {
                DirFileHelper.CreateFileContent(entitymapPath, entitymapCode);
            }

            #endregion 映射类

            #region 映射子类

            string entitymapChildCode = strParam["entitymapChildCode"].ToString();
            string entitymapChildPath = baseConfigModel.OutputMap + "\\" + baseConfigModel.OutputAreas + "\\" + baseConfigModel.ChildTableName + "Map.cs";
            if (!System.IO.File.Exists(entitymapChildPath))
            {
                DirFileHelper.CreateFileContent(entitymapChildPath, entitymapChildCode);
            }

            #endregion 映射子类

            #region 服务类

            string serviceCode = strParam["serviceCode"].ToString();
            string servicePath = baseConfigModel.OutputService + "\\" + baseConfigModel.OutputAreas + "\\" + baseConfigModel.ServiceClassName + ".cs";
            if (!System.IO.File.Exists(servicePath))
            {
                DirFileHelper.CreateFileContent(servicePath, serviceCode);
            }

            #endregion 服务类

            #region 接口类

            string iserviceCode = strParam["iserviceCode"].ToString();
            string iservicePath = baseConfigModel.OutputIService + "\\" + baseConfigModel.OutputAreas + "\\" + baseConfigModel.IServiceClassName + ".cs";
            if (!System.IO.File.Exists(iservicePath))
            {
                DirFileHelper.CreateFileContent(iservicePath, iserviceCode);
            }

            #endregion 接口类

            #region 业务类

            string businesCode = strParam["businesCode"].ToString();
            string businesPath = baseConfigModel.OutputBusines + "\\" + baseConfigModel.OutputAreas + "\\" + baseConfigModel.BusinesClassName + ".cs";
            if (!System.IO.File.Exists(businesPath))
            {
                DirFileHelper.CreateFileContent(businesPath, businesCode);
            }

            #endregion 业务类

            #region 控制器

            string controllerCode = strParam["controllerCode"].ToString();
            string controllerPath = baseConfigModel.OutputController + "\\Areas\\" + baseConfigModel.OutputAreas + "\\Controllers\\" + baseConfigModel.ControllerName + ".cs";
            if (!System.IO.File.Exists(controllerPath))
            {
                DirFileHelper.CreateFileContent(controllerPath, controllerCode);
            }

            #endregion 控制器

            #region 列表页

            string indexCode = strParam["indexCode"].ToString();
            string indexPath = baseConfigModel.OutputController + "\\Areas\\" + baseConfigModel.OutputAreas + "\\Views\\" + StringHelper.DelLastLength(baseConfigModel.ControllerName, 10) + "\\" + baseConfigModel.IndexPageName + ".cshtml";
            if (!System.IO.File.Exists(indexPath))
            {
                DirFileHelper.CreateFileContent(indexPath, indexCode.Replace("★", "&nbsp;"));
            }

            #endregion 列表页

            #region 表单页

            string formCode = strParam["formCode"].ToString();
            string formPath = baseConfigModel.OutputController + "\\Areas\\" + baseConfigModel.OutputAreas + "\\Views\\" + StringHelper.DelLastLength(baseConfigModel.ControllerName, 10) + "\\" + baseConfigModel.FormPageName + ".cshtml";
            if (!System.IO.File.Exists(formPath))
            {
                DirFileHelper.CreateFileContent(formPath, formCode.Replace("★", "&nbsp;"));
            }

            #endregion 表单页
        }
    }
}