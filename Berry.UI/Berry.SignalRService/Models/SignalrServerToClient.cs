using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace Berry.SignalRService.Models
{
    /// <summary>
    /// 服务端主动推送消息到客户端
    /// </summary>
    public class SignalrServerToClient : IBroadcastService
    {
        static readonly IHubContext HubContext = GlobalHost.ConnectionManager.GetHubContext<ChatsHub>();

        /// <summary>
        /// 广播系统消息，广播给所有用户
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task SendSystemMessage(string message, string title = "系统消息")
        {
            await HubContext.Clients.All.BroadcastSystemMessage(title, message);
        }

        /// <summary>
        /// 发送消息给指定用户
        /// </summary>
        /// <param name="userId">用户（客户端）ID</param>
        /// <param name="message">消息体</param>
        /// <returns></returns>
        public async Task SendMessageByUserId(string userId, string message)
        {
            await HubContext.Clients.Client(userId).BroadcastMessageByUserId(message);
        }
    }
}