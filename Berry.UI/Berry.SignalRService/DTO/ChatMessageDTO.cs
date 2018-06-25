using System;

namespace Berry.SignalRService.DTO
{
    /// <summary>
    /// 消息体
    /// </summary>
    public class ChatMessageDTO
    {
        /// <summary>
        /// 发送人ID
        /// </summary>
        public string SendId { get; set; }
        /// <summary>
        /// 发送方姓名
        /// </summary>
        public string SendUserName { get; set; }
        /// <summary>
        /// 接收人ID
        /// </summary>
        public string ReceiveId { get; set; }
        /// <summary>
        /// 接收方姓名
        /// </summary>
        public string ReceiveName { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}