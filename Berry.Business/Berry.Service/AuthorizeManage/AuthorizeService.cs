using Berry.Cache;
using Berry.Code.Operator;
using Berry.Entity.AuthorizeManage;
using Berry.Entity.BaseManage;
using Berry.Extension;
using Berry.IService.AuthorizeManage;
using Berry.Service.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Berry.Data.Extension;

namespace Berry.Service.AuthorizeManage
{
    /// <summary>
    /// 授权数据
    /// </summary>
    public class AuthorizeService : BaseService, IAuthorizeService
    {
        /// <summary>
        /// 获得可读数据权限范围SQL
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public string GetDataAuthor(OperatorEntity operators, bool isWrite = false)
        {
            //如果是系统管理员直接给所有数据权限
            if (operators.IsSystem)
            {
                return "";
            }

            string userId = operators.UserId;
            StringBuilder whereSb = new StringBuilder(" SELECT Id FROM Base_User WHERE 1=1 ");
            string strAuthorData = "";
            if (isWrite)
            {
                strAuthorData = @"   SELECT    *
                                        FROM      Base_AuthorizeData
                                        WHERE     IsRead = 0 AND
                                        ObjectId IN (
                                                SELECT  ObjectId
                                                FROM    Base_UserRelation
                                                WHERE   Id = @UserId)";
            }
            else
            {
                strAuthorData = @"   SELECT    *
                                        FROM      Base_AuthorizeData
                                        WHERE
                                        ObjectId IN (
                                                SELECT  ObjectId
                                                FROM    Base_UserRelation
                                                WHERE   Id = @UserId)";
            }

            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "UserId", userId, DbType.String)
            };
            whereSb.Append(string.Format("AND( Id ='{0}'", userId));

            IEnumerable<AuthorizeDataEntity> listAuthorizeData = this.BaseRepository().FindList<AuthorizeDataEntity>(strAuthorData, parameter);
            foreach (AuthorizeDataEntity item in listAuthorizeData)
            {
                switch (item.AuthorizeType)
                {
                    case 0://0代表最大权限
                        return "";

                    case 2://本人及下属
                        whereSb.Append("  OR ManagerId ='{0}'");
                        break;

                    case 3://所在部门
                        whereSb.Append(@"  OR DepartmentId = (SELECT DepartmentId FROM Base_User WHERE Id ='{0}')");
                        break;

                    case 4://所在公司
                        whereSb.Append(@"  OR OrganizeId = (SELECT OrganizeId  FROM Base_User WHERE Id ='{0}' )");
                        break;

                    //case 5:
                    //    whereSb.Append(string.Format(@"  OR DepartmentId = '{1}' OR OrganizeId = '{1}'", userId, item.ResourceId));
                    //    break;
                }
            }
            whereSb.Append(")");
            return whereSb.ToString();
        }

        /// <summary>
        /// 获得权限范围用户ID
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public string GetDataAuthorUserId(OperatorEntity operators, bool isWrite = false)
        {
            string authorSql = this.GetDataAuthor(operators, isWrite);
            if (string.IsNullOrEmpty(authorSql)) return "";

            List<UserEntity> userList = this.BaseRepository().FindList<UserEntity>(authorSql).ToList();
            StringBuilder user = new StringBuilder("");

            foreach (UserEntity item in userList)
            {
                user.Append(item.Id);
                user.Append(",");
            }

            return user.ToString();
        }

        /// <summary>
        /// Action执行权限认证
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="moduleId">模块Id</param>
        /// <param name="action">请求地址</param>
        /// <returns></returns>
        public bool ActionAuthorize(string userId, string moduleId, string action)
        {
            List<AuthorizeUrlModel> authorizeUrlList = CacheFactory.GetCacheInstance().GetCache<List<AuthorizeUrlModel>>("__ActionAuthorize_" + userId);
            if (authorizeUrlList == null || authorizeUrlList.Count == 0)
            {
                authorizeUrlList = this.GetUrlList(userId).ToList();
                CacheFactory.GetCacheInstance().WriteCache(authorizeUrlList, "__ActionAuthorize_" + userId, DateTime.Now.AddMinutes(30));
            }

            authorizeUrlList = authorizeUrlList.FindAll(a => a.ModuleId == moduleId);
            foreach (AuthorizeUrlModel item in authorizeUrlList)
            {
                if (!string.IsNullOrEmpty(item.UrlAddress))
                {
                    string[] url = item.UrlAddress.Split('?');
                    if (item.ModuleId == moduleId && url[0] == action)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 获取授权功能Url、操作Url
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeUrlModel> GetUrlList(string userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  ModuleId AS AuthorizeId ,
                                    ModuleId ,
                                    UrlAddress ,
                                    FullName
                            FROM    Base_Module
                            WHERE   ModuleId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 1
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     Id = @UserId ) )
                                            OR ObjectId = @UserId )
                                    AND EnabledMark = 1
                                    AND DeleteMark = 0
                                    AND IsMenu = 1
                                    AND UrlAddress IS NOT NULL
                            UNION
                            SELECT  ModuleButtonId AS AuthorizeId ,
                                    ModuleId ,
                                    ActionAddress AS UrlAddress ,
                                    FullName
                            FROM    Base_ModuleButton
                            WHERE   ModuleButtonId IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 2
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     Id = @UserId ) )
                                            OR ObjectId = @UserId )
                                    AND ActionAddress IS NOT NULL");

            DbParameter[] parameter =
            {
                DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "UserId", userId, DbType.String)
            };
            //string sql = strSql.ToString().Replace("@UserId", $"'{userId}'");

            DataTable data = this.BaseRepository().FindTable(strSql.ToString(), parameter);
            if (data.IsExistRows())
            {
                IEnumerable<AuthorizeUrlModel> res = data.DataTableToList<AuthorizeUrlModel>();

                return res;
            }

            return new List<AuthorizeUrlModel>();
        }
    }
}