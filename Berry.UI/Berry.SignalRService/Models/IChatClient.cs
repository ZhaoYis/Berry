using System.Collections.Generic;
using System.Threading.Tasks;
using Berry.SignalRService.DTO;

namespace Berry.SignalRService.Models
{
    /// <summary>
    /// 客户端方法
    /// </summary>
    public interface IChatClient
    {
        #region 公共推送消息方法
        /// <summary>
        /// 向所有客户端发送消息
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <returns></returns>
        Task BroadcastMessageFormAllOnlineUser(ChatMessageDTO message);
        /// <summary>
        /// 发送系统消息
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="title">标题</param>
        /// <returns></returns>
        Task BroadcastSystemMessage(string message, string title);
        /// <summary>
        /// 接受指定用户发来的消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task BroadcastMessageByUserId(string message);
        #endregion

        #region 任务管理
        /// <summary>
        /// 向客户端广播开启任务
        /// </summary>
        /// <param name="jobCode">任务编码</param>
        void BroadcastJobOpened(string jobCode);
        /// <summary>
        /// 向客户端广播关闭任务
        /// </summary>
        /// <param name="jobCode">任务编码</param>
        void BroadcastJobClosed(string jobCode);
        /// <summary>
        /// 向客户端广播重置任务
        /// </summary>
        /// <param name="jobCode">任务编码</param>
        void BroadcastJobReset(string jobCode);
        #endregion

        #region 服务端推送数据

        /// <summary>
        /// 广播系统数据
        /// </summary>
        /// <param name="data"></param>
        void BroadcastSysData(string data);//TODO 根据实际情况调整返回到前端的数据类型

        #endregion

        #region IM相关实时数据，服务端需要自动推送数据

        /// <summary>
        /// 更新联系人列表
        /// </summary>
        /// <param name="userAllList">所有用户列表</param>
        /// <param name="onLineUserList">在线用户列表</param>
        /// <returns></returns>
        void IMUpdateUserList(List<UserInfoDTO> userAllList, List<UserInfoDTO> onLineUserList);

        ///// <summary>
        ///// 刷新最近的联系人
        ///// </summary>
        ///// <param name="lastUserList">最近联系人列表</param>
        ///// <returns></returns>
        //Task IMUpdateLastUser(List<UserInfoDTO> lastUserList);

        ///// <summary>
        ///// 刷新用户在线状态
        ///// </summary>
        ///// <param name="userId">用户ID</param>
        ///// <param name="isOnLine">是否在线</param>
        ///// <returns></returns>
        //Task IMUpdateUserStatus(string userId, int isOnLine);

        ///// <summary>
        ///// 接收消息
        ///// </summary>
        ///// <param name="formUser">目标用户ID</param>
        ///// <param name="message">消息内容</param>
        ///// <param name="dateTime">发送时间，格式：yyyy-MM-dd HH:mm:ss，也可以是类似3分钟前的描述</param>
        ///// <returns></returns>
        //Task IMRevMessage(string formUser, string message, string dateTime);

        ///// <summary>
        ///// 接收群消息
        ///// </summary>
        ///// <param name="userId">用户ID</param>
        ///// <param name="toGroup">群ID</param>
        ///// <param name="message">消息内容</param>
        ///// <param name="dateTime">发送时间，格式：yyyy-MM-dd HH:mm:ss，也可以是类似3分钟前的描述</param>
        ///// <returns></returns>
        //Task IMvGroupMessage(string userId, string toGroup, string message, string dateTime); 
        #endregion
    }
}