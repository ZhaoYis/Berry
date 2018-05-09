using Berry.Code.Operator;
using Berry.Util;

namespace Berry.Code
{
    /// <summary>
    /// 系统基础信息
    /// </summary>
    public class SystemInfo
    {
        /// <summary>
        /// 当前Tab页面模块Id
        /// </summary>
        public static string CurrentModuleId
        {
            get
            {
                return CookieHelper.GetCookie("currentmoduleId");
            }
        }

        /// <summary>
        /// 当前登录用户Id
        /// </summary>
        public static string CurrentUserId
        {
            get
            {
                return OperatorProvider.Provider.Current().UserId;
            }
        }
    }
}