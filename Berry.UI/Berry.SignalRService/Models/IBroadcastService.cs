using System.Threading.Tasks;

namespace Berry.SignalRService.Models
{
    /// <summary>
    /// 自定义广播消息，服务端方法
    /// </summary>
    public interface IBroadcastService
    {
        #region 系统主动推送消息消息
        /// <summary>
        /// 广播系统消息，所有用户
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="title">标题</param>
        /// <returns></returns>
        Task SendSystemMessage(string message, string title);

        /// <summary>
        /// 发送消息给指定用户
        /// </summary>
        /// <param name="userId">用户（客户端）ID</param>
        /// <param name="message">消息体</param>
        /// <returns></returns>
        Task SendMessageByUserId(string userId, string message);
        #endregion
    }
}