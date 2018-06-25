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

        #region 公共推送消息方法

        /// <summary>
        /// 向所有客户端发送消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task Send(string message);
        /// <summary>
        /// 发送系统消息
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <returns></returns>
        Task SendSystemMsg(string message);
        /// <summary>
        /// 向指定用户发送消息
        /// </summary>
        /// <param name="connId">用户ID</param>
        /// <param name="message">消息体</param>
        /// <returns></returns>
        Task SendmMsgByUserId(string connId, string message);

        #endregion

        #region 任务控制
        /// <summary>
        /// 开启一个或多个任务
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="jobCode">任务编码</param>
        void OpenJob(string userId, string[] jobCode);
        /// <summary>
        /// 关闭一个或多个任务
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="jobCode">任务编码</param>
        void CloseJob(string userId, string[] jobCode);
        /// <summary>
        /// 重置一个或多个任务
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="jobCode">任务编码</param>
        void ResetJob(string userId, string[] jobCode);
        #endregion

        #region IM相关，客户端主动获取数据

        /// <summary>
        /// 获取与某用户的消息列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="sendId">发送人Id</param>
        /// <returns></returns>
        List<ChatMessageDTO> GetMsgList(PaginationEntity pagination, string sendId);
        /// <summary>
        /// 获取未读消息的条数
        /// </summary>
        /// <param name="code">0-未读 1-已读</param>
        /// <returns></returns>
        string GetMsgNumList(string code);
        /// <summary>
        /// 主动发起更新最近联系人列表
        /// </summary>
        /// <returns></returns>
        void ImSendLastUser();
        /// <summary>
        /// 给指定用户发生消息
        /// </summary>
        /// <param name="toUser">目标用户ID</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        void ImSendToOne(string toUser, string message);
        /// <summary>
        /// 更新消息状态
        /// </summary>
        /// <param name="sendId">用户ID</param>
        /// <returns></returns>
        void UpdateMessageStatus(string sendId);

        /// <summary>
        /// 创建用户组
        /// </summary>
        /// <param name="groupName">群组名称</param>
        /// <param name="userIdList">用户列表</param>
        /// <returns></returns>
        void CreateGroup(string groupName, List<UserInfoDTO> userIdList);
        /// <summary>
        /// 更新群名称
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        void UpdateGroupName(string groupId, string groupName);
        /// <summary>
        /// 加群
        /// </summary>
        /// <param name="groupId">群ID</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        void AddGroupUserId(string groupId, string userId);
        /// <summary>
        /// 移除群
        /// </summary>
        /// <param name="userGroupId">群Id</param>
        /// <returns></returns>
        void RemoveGroupUserId(string userGroupId);
        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="toUser">发送人Id</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        void ImSendToGroup(string toUser, string message);
        #endregion
    }
}