using System.ComponentModel;

namespace Berry.Util.SMS.ZST
{
    /// <summary>
    /// 掌上通短信错误码定义
    /// </summary>
    public enum ZSTSMSErrorCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 1,
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Fail = -1,
        /// <summary>
        /// 系统错误
        /// </summary>
        [Description("系统错误")]
        SystemError = -99,
        /// <summary>
        /// 账户不存在
        /// </summary>
        [Description("账户不存在")]
        E_1003 = 1003,
        /// <summary>
        /// 连接密码错误
        /// </summary>
        [Description("连接密码错误")]
        E_1004 = 1004,
        /// <summary>
        /// 禁止接入
        /// </summary>
        [Description("禁止接入")]
        E_1006 = 1006,
        /// <summary>
        /// IP绑定验证失败
        /// </summary>
        [Description("IP绑定验证失败")]
        E_1007 = 1007,
        /// <summary>
        /// 发送失败
        /// </summary>
        [Description("发送失败")]
        E_3000 = 3000,
        /// <summary>
        /// 当前时间不允许发送
        /// </summary>
        [Description("当前时间不允许发送")]
        E_3001,
        /// <summary>
        /// 内容超出最大长度
        /// </summary>
        [Description("内容超出最大长度")]
        E_3002,
        /// <summary>
        /// 扩展号码错误
        /// </summary>
        [Description("扩展号码错误")]
        E_3003,
        /// <summary>
        /// 重复的手机号码
        /// </summary>
        [Description("重复的手机号码")]
        E_3004,
        /// <summary>
        /// 客户端拒收
        /// </summary>
        [Description("客户端拒收")]
        E_3005,
        /// <summary>
        /// 接收号码不能为空
        /// </summary>
        [Description("接收号码不能为空")]
        E_3011 = 3011,
        /// <summary>
        /// 接收号码文件解压失败
        /// </summary>
        [Description("接收号码文件解压失败")]
        E_3012,
        /// <summary>
        /// 系统黑名单号码
        /// </summary>
        [Description("系统黑名单号码")]
        E_3013,
        /// <summary>
        /// 未配置通道
        /// </summary>
        [Description("未配置通道")]
        E_3014,
        /// <summary>
        /// 用户黑名单号码
        /// </summary>
        [Description("用户黑名单号码")]
        E_3015,
        /// <summary>
        /// 资源格式错误
        /// </summary>
        [Description("资源格式错误")]
        E_3016,
        /// <summary>
        /// 资源不存在
        /// </summary>
        [Description("资源不存在")]
        E_3017,
        /// <summary>
        /// 资源保存失败
        /// </summary>
        [Description("资源保存失败")]
        E_3018,
        /// <summary>
        /// 超出最多帧数
        /// </summary>
        [Description("超出最多帧数")]
        E_3019,
        /// <summary>
        /// 必须加签名
        /// </summary>
        [Description("必须加签名")]
        E_3021 = 3021,
        /// <summary>
        /// 错误的手机号码
        /// </summary>
        [Description("错误的手机号码")]
        E_3032 = 3032,
        /// <summary>
        /// 存在敏感词汇
        /// </summary>
        [Description("存在敏感词汇")]
        E_3042 = 3042,
        /// <summary>
        /// 等待审核
        /// </summary>
        [Description("等待审核")]
        E_3050 = 3050,
        /// <summary>
        /// 模版数据格式错误
        /// </summary>
        [Description("模版数据格式错误")]
        E_3072 = 3072,
        /// <summary>
        /// 提交参数冲突
        /// </summary>
        [Description("提交参数冲突")]
        E_3075 = 3075,
        /// <summary>
        /// 存量不足
        /// </summary>
        [Description("存量不足")]
        E_3091 = 3091,
        /// <summary>
        /// 提交参数错误
        /// </summary>
        [Description("提交参数错误")]
        E_4004 = 4004
    }
}