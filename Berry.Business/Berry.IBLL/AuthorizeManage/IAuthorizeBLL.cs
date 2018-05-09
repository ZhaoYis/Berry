using Berry.Code.Operator;
using Berry.Entity.AuthorizeManage;
using System.Collections.Generic;

namespace Berry.IBLL.AuthorizeManage
{
    /// <summary>
    /// 授权数据
    /// </summary>
    public partial interface IAuthorizeBLL
    {
        /// <summary>
        /// 获得可读数据权限范围SQL
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        string GetDataAuthor(OperatorEntity operators, bool isWrite = false);

        /// <summary>
        /// 获得权限范围用户ID
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        string GetDataAuthorUserId(OperatorEntity operators, bool isWrite = false);

        /// <summary>
        /// Action执行权限认证
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="moduleId">模块Id</param>
        /// <param name="action">请求地址</param>
        /// <returns></returns>
        bool ActionAuthorize(string userId, string moduleId, string action);

        /// <summary>
        /// 获取授权功能Url、操作Url
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<AuthorizeUrlModel> GetUrlList(string userId);
    }
}