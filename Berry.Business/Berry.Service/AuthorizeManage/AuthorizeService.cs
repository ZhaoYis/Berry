using Berry.Cache.Core.Base;
using Berry.Code.Operator;
using Berry.Entity.AuthorizeManage;
using Berry.Extension;
using Berry.IService.AuthorizeManage;
using Berry.Service.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Berry.Service.AuthorizeManage
{
    /// <summary>
    /// 授权数据
    /// </summary>
    public class AuthorizeService : BaseService<AuthorizeDataEntity>, IAuthorizeService
    {
        /// <summary>
        /// 获得可读数据权限范围SQL
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public string GetDataAuthor(OperatorEntity operators, bool isWrite = false)
        {
            string res = string.Empty;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetMemberList-获取成员列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    //如果是系统管理员直接给所有数据权限
                    if (operators.IsSystem)
                    {
                        res = "";
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
                                                WHERE   UserId = @Id)";
                    }
                    else
                    {
                        strAuthorData = @"   SELECT    *
                                        FROM      Base_AuthorizeData
                                        WHERE
                                        ObjectId IN (
                                                SELECT  ObjectId
                                                FROM    Base_UserRelation
                                                WHERE   UserId = @Id)";
                    }
                    whereSb.Append(string.Format("AND ( Id ='{0}'", userId));

                    IEnumerable<AuthorizeDataEntity> listAuthorizeData = this.BaseRepository().FindList<AuthorizeDataEntity>(conn, strAuthorData, new { Id = userId }, tran);
                    foreach (AuthorizeDataEntity item in listAuthorizeData)
                    {
                        switch (item.AuthorizeType)
                        {
                            case 0://0代表最大权限

                                break;
                            case -2://本人及下属
                                whereSb.Append("  OR ManagerId ='{0}'");
                                break;

                            case -3://所在部门
                                whereSb.Append(@"  OR DepartmentId = (SELECT DepartmentId FROM Base_User WHERE Id ='{0}')");
                                break;

                            case -4://所在公司
                                whereSb.Append(@"  OR OrganizeId = (SELECT OrganizeId  FROM Base_User WHERE Id ='{0}' )");
                                break;

                            case -5:
                                whereSb.Append(string.Format(@"  OR DepartmentId = '{1}' OR OrganizeId = '{1}'", userId, item.ResourceId));
                                break;
                        }
                    }
                    whereSb.Append(")");
                    res = whereSb.ToString();

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
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
            List<AuthorizeUrlModel> authorizeUrlList = CacheFactory.GetCache().Get<List<AuthorizeUrlModel>>("__ActionAuthorize_" + userId);
            if (authorizeUrlList == null || authorizeUrlList.Count == 0)
            {
                authorizeUrlList = this.GetUrlList(userId).ToList();
                CacheFactory.GetCache().Add("__ActionAuthorize_" + userId, authorizeUrlList, TimeSpan.FromMinutes(30));
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
            IEnumerable<AuthorizeUrlModel> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetUrlList-获取授权功能Url、操作Url", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(@"SELECT  Id AS AuthorizeId ,
                                    Id AS ModuleId,
                                    UrlAddress ,
                                    FullName
                            FROM    Base_Module
                            WHERE   Id IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 1
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @Id ) )
                                            OR ObjectId = @Id )
                                    AND EnabledMark = 1
                                    AND DeleteMark = 0
                                    AND IsMenu = 1
                                    AND UrlAddress IS NOT NULL
                            UNION
                            SELECT  Id AS AuthorizeId ,
                                    ModuleId ,
                                    ActionAddress AS UrlAddress ,
                                    FullName
                            FROM    Base_ModuleButton
                            WHERE   Id IN (
                                    SELECT  ItemId
                                    FROM    Base_Authorize
                                    WHERE   ItemType = 2
                                            AND ( ObjectId IN (
                                                  SELECT    ObjectId
                                                  FROM      Base_UserRelation
                                                  WHERE     UserId = @Id ) )
                                            OR ObjectId = @Id )
                                    AND ActionAddress IS NOT NULL");

                    //DbParameter[] parameter =
                    //{
                    //    DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + "Id", userId, DbType.String)
                    //};

                    DataTable data = this.BaseRepository().FindTable(conn, strSql.ToString(), new { Id = userId }, tran);
                    if (data.IsExistRows())
                    {
                        res = data.DataTableToList<AuthorizeUrlModel>();
                    }

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }
    }
}