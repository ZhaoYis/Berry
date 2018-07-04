using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Berry.SignalRService.DTO;

namespace Berry.SignalRService.Models
{
    /// <summary>
    /// 自定义广播消息，服务端方法
    /// </summary>
    public interface IBroadcastService
    {
        #region 系统主动推送消息消息
        /// <summary>
        /// 向所有在线用户广播消息
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <returns></returns>
        Task SendMessageFormAllOnlineUser(ChatMessageDTO message);

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
        /// <param name="connId">用户连接（客户端）ID</param>
        /// <param name="message">消息体</param>
        /// <returns></returns>
        Task SendMessageByUserId(string connId, string message);
        #endregion

        #region 任务控制
        /// <summary>
        /// 开启一个或多个任务
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="connId">用户ID-连接ID</param>
        /// <param name="jobCode">任务编码</param>
        void OpenJob(string userId, Dictionary<string, string> connId, string[] jobCode);
        /// <summary>
        /// 关闭一个或多个任务
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="connId">用户ID-连接ID</param>
        /// <param name="jobCode">任务编码</param>
        void CloseJob(string userId, Dictionary<string, string> connId, string[] jobCode);
        /// <summary>
        /// 重置一个或多个任务
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="connId">用户ID-连接ID</param>
        /// <param name="jobCode">任务编码</param>
        void ResetJob(string userId, Dictionary<string, string> connId, string[] jobCode);
        #endregion

        #region IM相关，服务端主动推送数据

        /// <summary>
        /// 更新联系人列表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        void UpdateUserList(string userId);

        ///// <summary>
        ///// 刷新最近的联系人
        ///// </summary>
        ///// <param name="lastUserList">最近联系人列表</param>
        ///// <returns></returns>
        //Task UpdateLastUser(List<UserInfoDTO> lastUserList);

        ///// <summary>
        ///// 刷新用户在线状态
        ///// </summary>
        ///// <param name="userId">用户ID</param>
        ///// <param name="isOnLine">是否在线</param>
        ///// <returns></returns>
        //Task UpdateUserStatus(string userId, int isOnLine);

        ///// <summary>
        ///// 接收消息
        ///// </summary>
        ///// <param name="formUser">目标用户ID</param>
        ///// <param name="message">消息内容</param>
        ///// <param name="dateTime">发送时间，格式：yyyy-MM-dd HH:mm:ss，也可以是类似3分钟前的描述</param>
        ///// <returns></returns>
        //Task RevMessage(string formUser, string message, string dateTime);

        ///// <summary>
        ///// 接收群消息
        ///// </summary>
        ///// <param name="userId">用户ID</param>
        ///// <param name="toGroup">群ID</param>
        ///// <param name="message">消息内容</param>
        ///// <param name="dateTime">发送时间，格式：yyyy-MM-dd HH:mm:ss，也可以是类似3分钟前的描述</param>
        ///// <returns></returns>
        //Task RevGroupMessage(string userId, string toGroup, string message, string dateTime);
        #endregion
    }
}