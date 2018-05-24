using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Berry.Data.Extension;
using Berry.Data.Repository;
using Berry.Entity.AuthorizeManage;
using Berry.Entity.CommonEntity;
using Berry.Extension;
using Berry.IService.AuthorizeManage;
using Newtonsoft.Json.Linq;

namespace Berry.Service.AuthorizeManage
{
    /// <summary>
    /// 系统表单
    /// </summary>
    public class ModuleFormService : RepositoryFactory, IModuleFormService
    {
        #region 获取数据
        /// <summary>
        /// 获取分页数据(管理页面调用)
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetPageList(PaginationEntity pagination, string queryJson)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"SELECT
	                                m.Id,
	                                m.ModuleId,
	                                m1.FullName as ModuleName,
	                                m.EnCode,
	                                m.FullName,
	                                m.SortCode,
	                                m.DeleteMark,
	                                m.EnabledMark,
	                                m.Description,
	                                m.CreateDate,
	                                m.CreateUserId,
	                                m.CreateUserName,
	                                m.ModifyDate,
	                                m.ModifyUserId,
	                                m.ModifyUserName
                                FROM
	                                Base_ModuleForm m
                                LEFT JOIN Base_Module m1 ON m1.Id = m.ModuleId
                                WHERE m.DeleteMark = 0");

            List<DbParameter> parameter = new List<DbParameter>();
            JObject queryParam = queryJson.TryToJObject();
            if (queryParam != null)
            {
                if (!string.IsNullOrEmpty(queryParam["Keyword"].ToString()))//关键字查询
                {
                    string keyord = queryParam["Keyword"].ToString();
                    strSql.Append(@" AND ( m1.FullName LIKE @keyword 
                                        or m.FullName LIKE @keyword 
                                        or m.CreateUserName LIKE @keyword )");

                    parameter.Add(DbParameters.CreateDbParameter("@keyword", '%' + keyord + '%'));
                }
            }

            return this.BaseRepository().FindTable(strSql.ToString(), parameter.ToArray(), pagination);
        }
        /// <summary>
        /// 获取一个实体类
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ModuleFormEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity<ModuleFormEntity>(keyValue);
        }
        /// <summary>
        /// 通过模块Id获取系统表单
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public ModuleFormEntity GetEntityByModuleId(string moduleId)
        {
            var expression = LambdaExtension.True<ModuleFormEntity>();
            expression = expression.And(t => t.ModuleId == moduleId);
            return this.BaseRepository().FindEntity<ModuleFormEntity>(expression);
        }
        /// <summary>
        /// 判断模块是否已经有系统表单
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public bool IsExistModuleId(string keyValue,string moduleId)
        {
            var expression = LambdaExtension.True<ModuleFormEntity>();
            if(string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.ModuleId == moduleId);
            }
            else
            {
                expression = expression.And(t => t.ModuleId == moduleId && t.Id != keyValue);
            }
            ModuleFormEntity entity = this.BaseRepository().FindEntity<ModuleFormEntity>(expression);
            return entity != null;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int SaveEntity(string keyValue, ModuleFormEntity entity)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                entity.Create();
                return this.BaseRepository().Insert(entity);
            }
            else
            {
                entity.Modify(keyValue);
                return this.BaseRepository().Update(entity);
            }
        }
        /// <summary>
        /// 虚拟删除一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public int VirtualDelete(string keyValue)
        {
            ModuleFormEntity entity = this.BaseRepository().FindEntity<ModuleFormEntity>(keyValue);
            if (entity != null)
            {
                entity.DeleteMark = true;
                return this.BaseRepository().Update(entity);
            }
            else
            {
                throw new Exception("没有该记录无法删除");
            }
        }
        #endregion
    }
}
