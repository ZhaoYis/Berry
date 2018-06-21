using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Berry.SignalRService.DTO;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hosting;
using Microsoft.AspNet.SignalR.Hubs;

namespace Berry.SignalRService.Models
{
    [HubName("ChatsHub")]
    public class ChatsHub : Hub<IChatClient>, IChatService
    {
        #region 基础信息
        /// <summary>
        /// 连接数
        /// </summary>
        private static int _connections = 0;

        /// <summary>
        /// 前端自定义参数集合
        /// </summary>
        public INameValueCollection ClientQueryString
        {
            get { return Context.QueryString; }
        }

        /// <summary>
        /// Cookie
        /// </summary>
        public IDictionary<string, Cookie> ClientCookies
        {
            get { return Context.RequestCookies; }
        }

        /// <summary>
        /// 用户信息
        /// </summary>
        public IPrincipal ClientContextUser
        {
            get { return Context.User; }
        }

        /// <summary>
        /// SignalR上下文
        /// </summary>
        public HttpContext HttpContext
        {
            get { return HttpContext.Current; }
        }

        #endregion

        #region 测试代码

        /// <summary>
        /// 向所有客户端发送消息
        /// </summary>
        /// <param name="message"></param>
        public async Task Send(string message)
        {
            try
            {
                //当前发送消息的用户ID，前端自定义
                string userId = ClientQueryString["userId"];
                //当前连接ID
                string connId = Context.ConnectionId;

                // 调用所有客户端的SendMessage方法
                ChatMessageDTO msg = new ChatMessageDTO
                {
                    SendId = connId,
                    SendUserName = "",
                    Content = message,
                    CreateDate = DateTime.Now
                };
                await Clients.All.SendMessage(msg);
            }
            catch (Exception e)
            {
                throw new HubException("发送消息发生异常.", new { userName = ClientContextUser.Identity.Name, message = e.Message });
            }
        }

        #endregion

        #region 聊天相关方法
        
        /// <summary>
        /// 获取与某用户的消息列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="sendId">发送人Id</param>
        /// <returns></returns>
        public Task<ChatMessageDTO> GetMsgList(PaginationEntity pagination, string sendId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取未读消息的条数
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<ChatMessageDTO> GetMsgNumList(string code)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 主动发起更新最近联系人列表
        /// </summary>
        /// <returns></returns>
        public Task ImSendLastUser()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 给指定用户发生消息
        /// </summary>
        /// <param name="toUser">目标用户ID</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public Task ImSendToOne(string toUser, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新消息状态
        /// </summary>
        /// <param name="sendId">用户ID</param>
        /// <returns></returns>
        public Task UpdateMessageStatus(string sendId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建用户组
        /// </summary>
        /// <param name="groupName">群组名称</param>
        /// <param name="userIdList">用户列表</param>
        /// <returns></returns>
        public Task CreateGroup(string groupName, List<UserInfoDTO> userIdList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新群名称
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public Task UpdateGroupName(string groupId, string groupName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 加群
        /// </summary>
        /// <param name="groupId">群ID</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public Task AddGroupUserId(string groupId, string userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 移除群
        /// </summary>
        /// <param name="userGroupId">群Id</param>
        /// <returns></returns>
        public Task RemoveGroupUserId(string userGroupId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="toUser">发送人Id</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public Task ImSendToGroup(string toUser, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 指定发生给用户
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="message"></param>
        public void SendByUserId(string userId, string message)
        {
            var chatHub = GlobalHost.ConnectionManager.GetHubContext<ChatsHub>();
            chatHub.Clients.Client(userId).sendMessage(message);

            //Clients.Client(userId).sendMessage(message);
        }

        #endregion

        #region 默认事件

        /// <summary>
        /// 客户端连接的时候调用
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            //string userId = ClientQueryString["userId"];
            Interlocked.Increment(ref _connections);

            System.Diagnostics.Trace.WriteLine("=====================================");
            System.Diagnostics.Trace.WriteLine("新的连接加入，连接ID：" + Context.ConnectionId + ",已有连接数：" + _connections);

            return base.OnConnected();
        }

        /// <summary>
        /// 客户端断开连接的时候调用
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            System.Diagnostics.Trace.WriteLine(Context.ConnectionId + "退出连接，已有连接数：" + _connections);

            Interlocked.Decrement(ref _connections);

            return base.OnDisconnected(true);
        }

        /// <summary>
        /// 客户端重新连接的时候调用
        /// </summary>
        /// <returns></returns>
        public override Task OnReconnected()
        {
            Trace.WriteLine($"客户端[{Context.ConnectionId}]正在重新连接");

            return base.OnReconnected();
        }
        #endregion
    }
}