namespace Berry.Util.SMS.ZST
{
    /// <summary>
    /// 请求结果实体
    /// </summary>
    public class ZSTSMSResultModel
    {
        /// <summary>
        /// 提交状态  (1：成功 ； -1：失败 其它参考 ZSTSMSErrorCode)
        /// </summary>
        public ZSTSMSErrorCode Status { get; set; }
        /// <summary>
        /// 发送结果服务器端返回的发送信息编号。
        /// </summary>
        public string MsgId { get; set; }
        /// <summary>
        /// 状态描述
        /// </summary>
        public string Description { get; set; }
    }
}