using System;

namespace Berry.SignalRService.DTO
{
    /// <summary>
    /// 聊天记录
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
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}