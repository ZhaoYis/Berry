using Berry.Code;
using Berry.Entity.AuthorizeManage;
using Berry.Entity.BaseManage;
using Berry.IBLL.AuthorizeManage;
using Berry.IService.AuthorizeManage;
using Berry.Service.AuthorizeManage;
using System.Collections.Generic;

namespace Berry.BLL.AuthorizeManage
{
    /// <summary>
    /// 权限配置管理（角色、岗位、职位、用户组、用户）
    /// </summary>
    public class PermissionBLL : IPermissionBLL
    {
        private IPermissionService permissionService = new PermissionService();

        /// <summary>
        /// 获取成员列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<UserRelationEntity> GetMemberList(string objectId)
        {
            return permissionService.GetMemberList(objectId);
        }

        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<UserRelationEntity> GetObjectList(string userId)
        {
            return permissionService.GetObjectList(userId);
        }

        /// <summary>
        /// 获取对象特征字符串
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetObjectString(string userId)
        {
            return permissionService.GetObjectString(userId);
        }

        /// <summary>
        /// 获取功能列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeEntity> GetModuleList(string objectId)
        {
            return permissionService.GetModuleList(objectId);
        }

        /// <summary>
        /// 获取按钮列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeEntity> GetModuleButtonList(string objectId)
        {
            return permissionService.GetModuleButtonList(objectId);
        }

        /// <summary>
        /// 获取视图列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeEntity> GetModuleColumnList(string objectId)
        {
            return permissionService.GetModuleColumnList(objectId);
        }

        /// <summary>
        /// 获取数据权限列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeDataEntity> GetAuthorizeDataList(string objectId)
        {
            return permissionService.GetAuthorizeDataList(objectId);
        }

        /// <summary>
        /// 添加成员
        /// </summary>
        /// <param name="authorizeType">权限分类</param>
        /// <param name="objectId">对象Id</param>
        /// <param name="userIds">成员Id</param>
        public void SaveMember(AuthorizeTypeEnum authorizeType, string objectId, string[] userIds)
        {
            permissionService.SaveMember(authorizeType, objectId, userIds);
        }

        /// <summary>
        /// 添加授权
        /// </summary>
        /// <param name="authorizeType">权限分类</param>
        /// <param name="objectId">对象Id</param>
        /// <param name="moduleIds">功能Id</param>
        /// <param name="moduleButtonIds">按钮Id</param>
        /// <param name="moduleColumnIds">视图Id</param>
        /// <param name="authorizeDataList">数据权限</param>
        public void SaveAuthorize(AuthorizeTypeEnum authorizeType, string objectId, string[] moduleIds, string[] moduleButtonIds,
            string[] moduleColumnIds, IEnumerable<AuthorizeDataEntity> authorizeDataList)
        {
            permissionService.SaveAuthorize(authorizeType, objectId, moduleIds, moduleButtonIds, moduleColumnIds, authorizeDataList);
        }
    }
}