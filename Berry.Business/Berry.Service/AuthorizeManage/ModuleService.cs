using System;
using Berry.Entity.AuthorizeManage;
using Berry.IService.AuthorizeManage;
using Berry.Service.Base;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Berry.Data.Extension;
using Berry.Extension;
using Berry.Util;

namespace Berry.Service.AuthorizeManage
{
    /// <summary>
    /// 系统功能
    /// </summary>
    public class ModuleService : BaseService, IModuleService
    {
        /// <summary>
        /// 获取授权功能
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetModuleList(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  *
                            FROM    Base_Module
                            WHERE   Id IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 1
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     Id = @Id ) )
                                            OR ObjectId = @Id )
                            AND EnabledMark = 1  AND DeleteMark = 0 Order By SortCode");

            DbParameter[] parameter =
            {
                //new SqlParameter("@Id",SqlDbType.NVarChar,36)
                DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "Id", userId, DbType.String)
            };

            IEnumerable<ModuleEntity> res = this.BaseRepository().FindList<ModuleEntity>(strSql.ToString(), parameter).ToList();

            return res;
        }

        /// <summary>
        /// 获取所有授权功能
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetModuleList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT * FROM Base_Module AS m WHERE EnabledMark = 1 AND DeleteMark = 0 Order By SortCode");

            IEnumerable<ModuleEntity> res = this.BaseRepository().FindList<ModuleEntity>(strSql.ToString());

            return res;
        }

        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        public int GetSortCode()
        {
            int sortCode = this.BaseRepository().FindList<ModuleEntity>(m=>m.DeleteMark == false).Max(t => t.SortCode).ToInt();
            if (!string.IsNullOrEmpty(sortCode.ToString()))
            {
                return sortCode + 1;
            }
            return 100001;
        }

        /// <summary>
        /// 功能列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetList(string parentId)
        {
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(parentId))
            {
                parentId = StringHelper.SqlFilters(parentId);
                strSql.Append("SELECT * FROM Base_Module Where ParentId ='" + parentId + "' Order By SortCode");
            }
            else
            {
                strSql.Append("SELECT * FROM Base_Module Order By SortCode");
            }
            return this.BaseRepository().FindList<ModuleEntity>(strSql.ToString());
        }

        /// <summary>
        /// 功能实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity<ModuleEntity>(keyValue);
        }

        /// <summary>
        /// 功能编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            var expression = LambdaExtension.True<ModuleEntity>();
            expression = expression.And(t => t.EnCode == enCode);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.Id != keyValue);
            }
            return this.BaseRepository().FindList<ModuleEntity>(expression).ToList().Count == 0;
        }

        /// <summary>
        /// 功能名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            var expression = LambdaExtension.True<ModuleEntity>();
            expression = expression.And(t => t.FullName == fullName);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.Id != keyValue);
            }
            return this.BaseRepository().FindList<ModuleEntity>(expression).ToList().Count == 0;
        }

        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            int count = this.BaseRepository().FindList<ModuleEntity>(t => t.ParentId == keyValue).Count();
            if (count > 0)
            {
                throw new Exception("当前所选数据有子节点数据！");
            }
            //删除模块
            this.BaseRepository().Delete<ModuleEntity>(keyValue);
            //删除按钮
            this.BaseRepository().Delete<ModuleButtonEntity>(t => t.ModuleId == keyValue);
            //删除视图
            this.BaseRepository().Delete<ModuleColumnEntity>(t => t.ModuleId == keyValue);
        }

        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="moduleEntity">功能实体</param>
        /// <param name="moduleButtonList">按钮实体列表</param>
        /// <param name="moduleColumnList">视图实体列表</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, ModuleEntity moduleEntity, List<ModuleButtonEntity> moduleButtonList, List<ModuleColumnEntity> moduleColumnList)
        {
            int res = -1;
            if (!string.IsNullOrEmpty(keyValue))
            {
                moduleEntity.Modify(keyValue);
                res = this.BaseRepository().Update<ModuleEntity>(moduleEntity);
            }
            else
            {
                moduleEntity.Create();
                res = this.BaseRepository().Insert(moduleEntity);
            }

            res = this.BaseRepository().Delete<ModuleButtonEntity>(t => t.ModuleId == keyValue);
            if (moduleButtonList != null)
            {
                List<ModuleButtonEntity> temp = new List<ModuleButtonEntity>();
                foreach (ModuleButtonEntity buttonEntity in moduleButtonList)
                {
                    buttonEntity.Create();
                    temp.Add(buttonEntity);
                }
                res = this.BaseRepository().Insert<ModuleButtonEntity>(temp);
            }

            res = this.BaseRepository().Delete<ModuleColumnEntity>(t => t.ModuleId == keyValue);
            if (moduleColumnList != null)
            {
                List<ModuleColumnEntity> temp = new List<ModuleColumnEntity>();
                foreach (ModuleColumnEntity columnEntity in moduleColumnList)
                {
                    columnEntity.Create();
                    temp.Add(columnEntity);
                }
                res = this.BaseRepository().Insert<ModuleColumnEntity>(temp);
            }
        }
    }
}