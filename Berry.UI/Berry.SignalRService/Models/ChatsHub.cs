using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Berry.Cache.Core.Base;
using Berry.Cache.Core.Runtime;
using Berry.SignalRService.DTO;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hosting;
using Microsoft.AspNet.SignalR.Hubs;

namespace Berry.SignalRService.Models
{
    [HubName("ChatsHub")]
    public class ChatsHub : Hub<IChatClient>, IChatService
    {
        #region 构造
        private readonly SignalrServerToClient _serverToClient;

        public ChatsHub() : this(SignalrServerToClient.Instance)
        {

        }

        public ChatsHub(SignalrServerToClient serverToClient)
        {
            _serverToClient = serverToClient;
        }
        #endregion

        #region 基础信息
        /// <summary>
        /// 连接数
        /// </summary>
        private static int _connections = 0;

        /// <summary>
        /// 系统缓存
        /// </summary>
        private readonly ICacheService _cache = RuntimeCacheService.GetCacheInstance();
        /// <summary>
        /// 用户列表，userId-connId 
        /// userId带有前缀，其中：S-服务器用户 U-登陆用户 T-访客用户（未登录）
        /// </summary>
        private static readonly Dictionary<string, string> UserIdDict = new Dictionary<string, string>();
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetAllUserListDict()
        {
            return UserIdDict;
        }

        #region 基础信息

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

        #endregion

        #region 公共推送消息方法

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
                string connId = "";//Context.ConnectionId;
                UserIdDict.TryGetValue(userId, out connId);
                connId = string.IsNullOrEmpty(connId) ? Context.ConnectionId : connId;

                // 调用所有客户端的SendMessage方法
                ChatMessageDTO msg = new ChatMessageDTO
                {
                    SendId = connId,
                    Content = message,
                    CreateDate = DateTime.Now
                };
                await _serverToClient.SendMessageByUserId(connId, $"服务器收到了[{connId}]发送的消息，准备广播给所有在线用户。");
                await _serverToClient.SendMessageFormAllOnlineUser(msg);
            }
            catch (Exception e)
            {
                throw new HubException("发送消息发生异常.", new { userName = ClientContextUser.Identity.Name, message = e.Message });
            }
        }

        /// <summary>
        /// 发送系统消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendSystemMsg(string message)
        {
            await _serverToClient.SendSystemMessage(message, "系统消息");
        }

        /// <summary>
        /// 向指定用户发送消息
        /// </summary>
        /// <param name="connId">用户ID</param>
        /// <param name="message">消息体</param>
        /// <returns></returns>
        public async Task SendmMsgByUserId(string connId, string message)
        {
            await _serverToClient.SendMessageByUserId(connId, $"服务器准备用户[{connId}]广播消息。");

            await _serverToClient.SendMessageByUserId(connId, message);
        }

        #endregion

        #region 任务控制

        /// <summary>
        /// 开启一个或多个任务
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="jobCode">任务编码</param>
        public void OpenJob(string userId, string[] jobCode)
        {
            string connId;
            UserIdDict.TryGetValue(userId, out connId);
            if (!string.IsNullOrEmpty(connId))
                _serverToClient.OpenJob(userId, UserIdDict, jobCode);
        }

        /// <summary>
        /// 关闭一个或多个任务
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="jobCode">任务编码</param>
        public void CloseJob(string userId, string[] jobCode)
        {
            string connId;
            UserIdDict.TryGetValue(userId, out connId);
            if (!string.IsNullOrEmpty(connId))
                _serverToClient.CloseJob(userId, UserIdDict, jobCode);
        }

        /// <summary>
        /// 重置一个或多个任务
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="jobCode">任务编码</param>
        public void ResetJob(string userId, string[] jobCode)
        {
            string connId;
            UserIdDict.TryGetValue(userId, out connId);
            if (!string.IsNullOrEmpty(connId))
                _serverToClient.ResetJob(userId, UserIdDict, jobCode);
        }

        #endregion

        #region 聊天相关方法

        /// <summary>
        /// 获取与某用户的消息列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="sendId">发送人Id</param>
        /// <returns></returns>
        public List<ChatMessageDTO> GetMsgList(PaginationEntity pagination, string sendId)
        {
            //业务系统用户ID
            string userId = ClientQueryString["userId"];
            //TODO 查询数据库，获取消息列表并返回，无需推送数据，前端主动获取

            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取未读消息的条数
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetMsgNumList(string code)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 主动发起更新最近联系人列表
        /// </summary>
        /// <returns></returns>
        public void ImSendLastUser()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 给指定用户发生消息
        /// </summary>
        /// <param name="toUser">目标用户ID</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public void ImSendToOne(string toUser, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新消息状态
        /// </summary>
        /// <param name="sendId">用户ID</param>
        /// <returns></returns>
        public void UpdateMessageStatus(string sendId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建用户组
        /// </summary>
        /// <param name="groupName">群组名称</param>
        /// <param name="userIdList">用户列表</param>
        /// <returns></returns>
        public void CreateGroup(string groupName, List<UserInfoDTO> userIdList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新群名称
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public void UpdateGroupName(string groupId, string groupName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 加群
        /// </summary>
        /// <param name="groupId">群ID</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public void AddGroupUserId(string groupId, string userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 移除群
        /// </summary>
        /// <param name="userGroupId">群Id</param>
        /// <returns></returns>
        public void RemoveGroupUserId(string userGroupId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="toUser">发送人Id</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public void ImSendToGroup(string toUser, string message)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 默认事件

        /// <summary>
        /// 客户端连接的时候调用
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            Interlocked.Increment(ref _connections);
            //业务系统用户ID
            string userId = ClientQueryString["userId"];
            //当前用户连接Id
            string connId = Context.ConnectionId;

            this.AddOrUpDateUserList(userId, connId, false);

            //通知该用户
            _serverToClient.SendMessageByUserId(connId, "连接成功！您的ID为：" + connId).Wait();

            Trace.WriteLine("=====================================");
            Trace.WriteLine("新的连接加入，连接ID：" + connId + ",已有连接数：" + _connections);

            return base.OnConnected();
        }

        /// <summary>
        /// 客户端断开连接的时候调用
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            Interlocked.Decrement(ref _connections);
            //业务系统用户ID
            string userId = ClientQueryString["userId"];
            //当前用户连接Id
            string connId = Context.ConnectionId;

            this.AddOrUpDateUserList(userId, connId, true);

            Trace.WriteLine(connId + "退出连接，已有连接数：" + _connections);
            return base.OnDisconnected(true);
        }

        /// <summary>
        /// 客户端重新连接的时候调用
        /// </summary>
        /// <returns></returns>
        public override Task OnReconnected()
        {
            //业务系统用户ID
            string userId = ClientQueryString["userId"];
            //当前用户连接Id
            string connId = Context.ConnectionId;

            this.AddOrUpDateUserList(userId, connId, false);

            Trace.WriteLine($"客户端[{connId}]正在重新连接");

            return base.OnReconnected();
        }

        /// <summary>
        /// 新增或者更新用户列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="connId"></param>
        /// <param name="stopCalled"></param>
        private void AddOrUpDateUserList(string userId, string connId, bool stopCalled = false)
        {
            if (!stopCalled)
            {
                if (!UserIdDict.ContainsKey(userId))
                {
                    UserIdDict.Add(userId, connId);
                }
                else
                {
                    //string oldVal;
                    //UserIdDict.TryGetValue(userId, out oldVal);
                    //UserIdDict.TryUpdate(userId, connId, oldVal);
                    UserIdDict[userId] = connId;
                }
            }
            else
            {
                if (UserIdDict.ContainsKey(userId))
                {
                    UserIdDict.Remove(userId);
                }
            }

            _cache.Add("__ConnectionUserCacheKey", UserIdDict);
        }

        #endregion
    }
}