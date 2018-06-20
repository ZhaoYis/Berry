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
        #region 用于测试
        /// <summary>
        /// 测试方法
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendMessage(ChatMessageDTO message);
        #endregion

        /// <summary>
        /// 更新联系人列表
        /// </summary>
        /// <param name="userAllList">所有用户列表</param>
        /// <param name="onLineUserList">在线用户列表</param>
        /// <returns></returns>
        Task IMUpdateUserList(List<UserInfoDTO> userAllList, List<UserInfoDTO> onLineUserList);

        /// <summary>
        /// 刷新最近的联系人
        /// </summary>
        /// <param name="lastUserList">最近联系人列表</param>
        /// <returns></returns>
        Task IMUpdateLastUser(List<UserInfoDTO> lastUserList);

        /// <summary>
        /// 刷新用户在线状态
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="isOnLine">是否在线</param>
        /// <returns></returns>
        Task IMUpdateUserStatus(string userId, int isOnLine);

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="formUser">目标用户ID</param>
        /// <param name="message">消息内容</param>
        /// <param name="dateTime">发送时间，格式：yyyy-MM-dd HH:mm:ss，也可以是类似3分钟前的描述</param>
        /// <returns></returns>
        Task RevMessage(string formUser, string message, string dateTime);

        /// <summary>
        /// 接收群消息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="toGroup">群ID</param>
        /// <param name="message">消息内容</param>
        /// <param name="dateTime">发送时间，格式：yyyy-MM-dd HH:mm:ss，也可以是类似3分钟前的描述</param>
        /// <returns></returns>
        Task RevGroupMessage(string userId, string toGroup, string message, string dateTime);
    }
}