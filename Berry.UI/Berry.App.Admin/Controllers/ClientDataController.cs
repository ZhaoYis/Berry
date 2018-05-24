using Berry.App.Admin.Handler;
using Berry.App.Cache;
using Berry.BLL.AuthorizeManage;
using Berry.Code.Operator;
using Berry.Entity.AuthorizeManage;
using Berry.Entity.BaseManage;
using Berry.Entity.ViewModel;
using Berry.Util;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Berry.App.Admin.Controllers
{
    /// <summary>
    /// 客户端数据
    /// </summary>
    public class ClientDataController : BaseController
    {
        private DataItemCache dataItemCache = new DataItemCache();
        private OrganizeCache organizeCache = new OrganizeCache();
        private DepartmentCache departmentCache = new DepartmentCache();
        private PostCache postCache = new PostCache();
        private RoleCache roleCache = new RoleCache();
        private UserGroupCache userGroupCache = new UserGroupCache();
        private UserCache userCache = new UserCache();
        //private AuthorizeBLL authorizeBLL = new AuthorizeBLL();
        private ModuleBLL moduleBll = new ModuleBLL();
        private ModuleButtonBLL moduleButtonBll = new ModuleButtonBLL();
        private ModuleColumnBLL moduleColumnBll = new ModuleColumnBLL();

        #region 获取数据

        /// <summary>
        /// 批量加载数据给客户端（把常用数据全部加载到浏览器中 这样能够减少数据库交互）
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult GetClientDataJson()
        {
            var jsonData = new
            {
                organize = this.GetOrganizeData(),              //机构
                department = this.GetDepartmentData(),          //部门
                post = this.GetPostData(),                      //岗位
                role = this.GetRoleData(),                      //角色
                userGroup = this.GetUserGroupData(),            //用户组
                user = this.GetUserData(),                      //用户
                dataItem = this.GetDataItem(),                  //字典
                authorizeMenu = this.GetModuleData(),           //导航菜单
                authorizeButton = this.GetModuleButtonData(),   //功能按钮
                authorizeColumn = this.GetModuleColumnData(),   //功能视图
            };
            return ToJsonResult(jsonData);
        }

        #endregion 获取数据

        #region 处理基础数据

        /// <summary>
        /// 获取机构数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetOrganizeData()
        {
            var data = organizeCache.GetOrganizList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (OrganizeEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    FullName = item.FullName
                };
                dictionary.Add(item.Id, fieldItem);
            }
            return dictionary;
        }

        /// <summary>
        /// 获取部门数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetDepartmentData()
        {
            var data = departmentCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (DepartmentEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    FullName = item.FullName,
                    OrganizeId = item.OrganizeId
                };
                dictionary.Add(item.Id, fieldItem);
            }
            return dictionary;
        }

        /// <summary>
        /// 获取岗位数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetUserGroupData()
        {
            var data = userGroupCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (RoleEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    FullName = item.FullName
                };
                dictionary.Add(item.Id, fieldItem);
            }
            return dictionary;
        }

        /// <summary>
        /// 获取岗位数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetPostData()
        {
            var data = postCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (RoleEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    FullName = item.FullName
                };
                dictionary.Add(item.Id, fieldItem);
            }
            return dictionary;
        }

        /// <summary>
        /// 获取角色数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetRoleData()
        {
            var data = roleCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (RoleEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    FullName = item.FullName
                };
                dictionary.Add(item.Id, fieldItem);
            }
            return dictionary;
        }

        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetUserData()
        {
            var data = userCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (UserEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    Account = item.Account,
                    RealName = item.RealName,
                    OrganizeId = item.OrganizeId,
                    DepartmentId = item.DepartmentId
                };
                dictionary.Add(item.Id, fieldItem);
            }
            return dictionary;
        }

        /// <summary>
        /// 获取数据字典
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetDataItem()
        {
            var dataList = dataItemCache.GetDataItemList().ToList();
            var dataSort = dataList.Distinct(new ComparintTools<DataItemViewModel>("EnCode"));
            Dictionary<string, object> dictionarySort = new Dictionary<string, object>();

            foreach (DataItemViewModel itemSort in dataSort)
            {
                var dataItemList = dataList.Where(t => t.EnCode == itemSort.EnCode).ToList();
                Dictionary<string, string> dictionaryItemList = new Dictionary<string, string>();

                foreach (DataItemViewModel itemList in dataItemList)
                {
                    dictionaryItemList.Add(itemList.ItemValue, itemList.ItemName);
                }

                foreach (DataItemViewModel itemList in dataItemList)
                {
                    dictionaryItemList.Add(itemList.ItemDetailId, itemList.ItemName);
                }
                dictionarySort.Add(itemSort.EnCode, dictionaryItemList);
            }
            return dictionarySort;
        }

        #endregion 处理基础数据

        #region 处理授权数据

        /// <summary>
        /// 获取功能数据
        /// </summary>
        /// <returns></returns>
        private object GetModuleData()
        {
            string userId = OperatorProvider.Provider.Current().UserId;
            return moduleBll.GetModuleList(userId);
        }

        /// <summary>
        /// 获取功能按钮数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetModuleButtonData()
        {
            string userId = OperatorProvider.Provider.Current().UserId;
            var data = moduleButtonBll.GetModuleButtonList(userId).ToList();

            var dataModule = data.Distinct(new ComparintTools<ModuleButtonEntity>("ModuleId")).ToList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            foreach (ModuleButtonEntity item in dataModule)
            {
                var buttonList = data.Where(t => t.ModuleId == item.ModuleId);
                dictionary.Add(item.ModuleId, buttonList);
            }
            return dictionary;
        }

        /// <summary>
        /// 获取功能视图数据
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetModuleColumnData()
        {
            string userId = OperatorProvider.Provider.Current().UserId;
            var data = moduleColumnBll.GetModuleColumnList(userId).ToList();

            var dataModule = data.Distinct(new ComparintTools<ModuleColumnEntity>("ModuleId")).ToList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            foreach (ModuleColumnEntity item in dataModule)
            {
                var columnList = data.Where(t => t.ModuleId == item.ModuleId);
                dictionary.Add(item.ModuleId, columnList);
            }
            return dictionary;
        }

        #endregion 处理授权数据
    }
}