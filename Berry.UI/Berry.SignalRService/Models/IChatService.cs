using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using Berry.SignalRService.DTO;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hosting;

namespace Berry.SignalRService.Models
{
    public interface IChatService
    {
        #region 基础信息
        /// <summary>
        /// 前端自定义参数集合
        /// </summary>
        INameValueCollection ClientQueryString { get; }
        /// <summary>
        /// Cookie
        /// </summary>
        IDictionary<string, Cookie> ClientCookies { get; }
        /// <summary>
        /// 用户信息
        /// </summary>
        IPrincipal ClientContextUser { get; }
        /// <summary>
        /// SignalR上下文
        /// </summary>
        HttpContext HttpContext { get; }
        #endregion

        Task Send(string message);

        /// <summary>
        /// 获取与某用户的消息列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="sendId">发送人Id</param>
        /// <returns></returns>
        Task<ChatMessageDTO> GetMsgList(PaginationEntity pagination, string sendId);
        /// <summary>
        /// 获取未读消息的条数
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<ChatMessageDTO> GetMsgNumList(string code);
        /// <summary>
        /// 主动发起更新最近联系人列表
        /// </summary>
        /// <returns></returns>
        Task ImSendLastUser();
        /// <summary>
        /// 给指定用户发生消息
        /// </summary>
        /// <param name="toUser">目标用户ID</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        Task ImSendToOne(string toUser, string message);
        /// <summary>
        /// 更新消息状态
        /// </summary>
        /// <param name="sendId">用户ID</param>
        /// <returns></returns>
        Task UpdateMessageStatus(string sendId);

        /// <summary>
        /// 创建用户组
        /// </summary>
        /// <param name="groupName">群组名称</param>
        /// <param name="userIdList">用户列表</param>
        /// <returns></returns>
        Task CreateGroup(string groupName, List<UserInfoDTO> userIdList);
        /// <summary>
        /// 更新群名称
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        Task UpdateGroupName(string groupId, string groupName);
        /// <summary>
        /// 加群
        /// </summary>
        /// <param name="groupId">群ID</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        Task AddGroupUserId(string groupId, string userId);
        /// <summary>
        /// 移除群
        /// </summary>
        /// <param name="userGroupId">群Id</param>
        /// <returns></returns>
        Task RemoveGroupUserId(string userGroupId);
        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="toUser">发送人Id</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        Task ImSendToGroup(string toUser, string message);
    }
}