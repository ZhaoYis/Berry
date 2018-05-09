using System.ComponentModel;

namespace Berry.Code
{
    #region ===========全局通用状态枚举===========

    /// <summary>
    /// 全局通用状态枚举
    /// </summary>
    public enum JsonObjectStatus
    {
        #region 系统

        /// <summary>
        /// 默认，无实际意义。
        /// </summary>
        Default = -1,

        /// <summary>
        /// 请求(或处理)成功
        /// </summary>
        [Description("请求(或处理)成功")]
        Success = 2000,

        /// <summary>
        /// 内部请求出错
        /// </summary>
        [Description("内部请求出错")]
        Error = 2001,

        /// <summary>
        /// 操作失败
        /// </summary>
        [Description("操作失败")]
        Fail = 2002,

        /// <summary>
        /// 服务器异常
        /// </summary>
        [Description("服务器异常")]
        Exception = 2003,

        #endregion 系统

        #region Http请求

        /// <summary>
        /// 请求授权信息参数不完整或不正确
        /// </summary>
        [Description("请求授权信息参数不完整或不正确")]
        ParameterError = 3001,

        /// <summary>
        /// 未授权
        /// </summary>
        [Description("未授权")]
        Unauthorized = 3002,

        /// <summary>
        /// 请求Token授权信息参数【用户编号】不存在
        /// </summary>
        [Description("请求Token授权信息参数【用户编号】不存在")]
        ParameterStaffIdNotExist = 3003,

        /// <summary>
        /// 请求TOKEN失效
        /// </summary>
        [Description("请求TOKEN失效")]
        TokenInvalid = 3004,

        /// <summary>
        /// HTTP请求类型不合法
        /// </summary>
        [Description("HTTP请求类型不合法")]
        HttpMehtodError = 3005,

        /// <summary>
        /// HTTP请求不合法,请求参数可能被篡改
        /// </summary>
        [Description("HTTP请求不合法，请求参数可能被篡改")]
        HttpRequestError = 3006,

        /// <summary>
        /// 该URL已经失效或请求时间戳失效
        /// </summary>
        [Description("该URL已经失效或请求时间戳失效")]
        UrlExpireError = 3007,

        #endregion Http请求

        #region 登录验证

        /// <summary>
        /// 账号错误
        /// </summary>
        [Description("账号错误")]
        AccountErr = 4001,

        /// <summary>
        /// 密码错误
        /// </summary>
        [Description("密码错误")]
        PasswordErr = 4002,

        /// <summary>
        /// 验证码错误
        /// </summary>
        [Description("验证码错误")]
        ValidateCodeErr = 4003,

        /// <summary>
        /// 用户不存在
        /// </summary>
        [Description("用户不存在")]
        UserNotExist = 4004,

        /// <summary>
        /// 记录已经存在
        /// </summary>
        [Description("记录已经存在")]
        RecordAlreadyExists = 4005,

        /// <summary>
        /// 记录不存在
        /// </summary>
        [Description("记录不存在")]
        RecordNotExists = 4006,

        #endregion 登录验证

        #region 账号状态

        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        AccountNormal = 4007,

        /// <summary>
        /// 账号被锁定
        /// </summary>
        [Description("账号被锁定")]
        AccountLock = 4008,

        /// <summary>
        /// 账号被禁用
        /// </summary>
        [Description("账号被禁用")]
        AccountDisable = 4009,

        /// <summary>
        /// 未启用
        /// </summary>
        [Description("未启用")]
        AccountNotEnabled = 4010,

        #endregion 账号状态
    }

    #endregion ===========全局通用状态枚举===========
}