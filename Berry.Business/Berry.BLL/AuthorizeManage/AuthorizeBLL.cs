using Berry.Code.Operator;
using Berry.Entity.AuthorizeManage;
using Berry.IBLL.AuthorizeManage;
using Berry.IService.AuthorizeManage;
using Berry.Service.AuthorizeManage;
using System.Collections.Generic;
using Berry.IService.BaseManage;
using Berry.Service.BaseManage;

namespace Berry.BLL.AuthorizeManage
{
    /// <summary>
    /// 授权数据
    /// </summary>
    public partial class AuthorizeBLL : IAuthorizeBLL
    {
        private IAuthorizeService authorizeService = new AuthorizeService();
        private IUserService userService = new UserService();

        /// <summary>
        /// 获得可读数据权限范围SQL
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public string GetDataAuthor(OperatorEntity operators, bool isWrite = false)
        {
            return authorizeService.GetDataAuthor(operators, isWrite);
        }

        /// <summary>
        /// 获得权限范围用户ID
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public string GetDataAuthorUserId(OperatorEntity operators, bool isWrite = false)
        {
            return userService.GetDataAuthorUserId(operators, isWrite);
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
            return authorizeService.ActionAuthorize(userId, moduleId, action);
        }

        /// <summary>
        /// 获取授权功能Url、操作Url
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeUrlModel> GetUrlList(string userId)
        {
            return authorizeService.GetUrlList(userId);
        }
    }
}