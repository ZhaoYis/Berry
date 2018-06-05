using Berry.Code;
using Berry.Entity.AuthorizeManage;
using Berry.Entity.BaseManage;
using Berry.IService.AuthorizeManage;
using Berry.Service.Base;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Berry.Service.AuthorizeManage
{
    /// <summary>
    /// 权限配置管理（角色、岗位、职位、用户组、用户）
    /// </summary>
    public class PermissionService : BaseService, IPermissionService
    {
        /// <summary>
        /// 获取成员列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<UserRelationEntity> GetMemberList(string objectId)
        {
            List<UserRelationEntity> res =
                this.BaseRepository().FindList<UserRelationEntity>(u => u.ObjectId == objectId)
                    .OrderByDescending(u => u.CreateDate)
                    .ToList();

            return res;
        }

        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<UserRelationEntity> GetObjectList(string userId)
        {
            List<UserRelationEntity> res =
                this.BaseRepository().FindList<UserRelationEntity>(u => u.UserId == userId)
                    .OrderByDescending(u => u.CreateDate)
                    .ToList();

            return res;
        }

        /// <summary>
        /// 获取对象特征字符串
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetObjectString(string userId)
        {
            StringBuilder sbId = new StringBuilder();
            List<UserRelationEntity> list = this.GetObjectList(userId).ToList();

            if (list.Count > 0)
            {
                foreach (UserRelationEntity item in list)
                {
                    sbId.Append(item.ObjectId + ",");
                }
                sbId.Append(userId);
            }
            else
            {
                sbId.Append(userId + ",");
            }
            return sbId.ToString();
        }

        /// <summary>
        /// 获取功能列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeEntity> GetModuleList(string objectId)
        {
            List<AuthorizeEntity> res =
                this.BaseRepository().FindList<AuthorizeEntity>(u => u.ObjectId == objectId && u.ItemType == 1)
                    .ToList();

            return res;
        }

        /// <summary>
        /// 获取按钮列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeEntity> GetModuleButtonList(string objectId)
        {
            List<AuthorizeEntity> res =
                this.BaseRepository().FindList<AuthorizeEntity>(u => u.ObjectId == objectId && u.ItemType == 2)
                    .ToList();

            return res;
        }

        /// <summary>
        /// 获取视图列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeEntity> GetModuleColumnList(string objectId)
        {
            List<AuthorizeEntity> res =
                this.BaseRepository().FindList<AuthorizeEntity>(u => u.ObjectId == objectId && u.ItemType == 3)
                    .ToList();

            return res;
        }

        /// <summary>
        /// 获取数据权限列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeDataEntity> GetAuthorizeDataList(string objectId)
        {
            List<AuthorizeDataEntity> res =
                this.BaseRepository().FindList<AuthorizeDataEntity>(u => u.ObjectId == objectId)
                    .OrderBy(u => u.SortCode)
                    .ToList();

            return res;
        }

        /// <summary>
        /// 添加成员
        /// </summary>
        /// <param name="authorizeType">权限分类</param>
        /// <param name="objectId">对象Id</param>
        /// <param name="userIds">成员Id</param>
        public void SaveMember(AuthorizeTypeEnum authorizeType, string objectId, string[] userIds)
        {
            //先清除历史用户关系数据
            int isSucc = this.BaseRepository().Delete<UserRelationEntity>(u => u.ObjectId == objectId && u.IsDefault == false);
            if (isSucc > 0)
            {
                //组装数据
                List<UserRelationEntity> list = new List<UserRelationEntity>();
                for (int i = 1; i <= userIds.Length; i++)
                {
                    UserRelationEntity userRelationEntity = new UserRelationEntity
                    {
                        Category = (int)authorizeType,
                        ObjectId = objectId,
                        UserId = userIds[i - 1],
                        SortCode = i
                    };
                    userRelationEntity.Create();

                    list.Add(userRelationEntity);
                }

                //批量保存
                int res = this.BaseRepository().Insert(list);
            }
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
            //先清除历史授权数据
            int isSucc = this.BaseRepository().Delete<AuthorizeDataEntity>(u => u.ObjectId == objectId);
            if (isSucc >= 0)
            {
                #region 功能

                List<AuthorizeEntity> authorizeMenuList = new List<AuthorizeEntity>();
                for (int i = 1; i <= moduleIds.Length; i++)
                {
                    AuthorizeEntity authorize = new AuthorizeEntity
                    {
                        Category = (int)authorizeType,
                        ObjectId = objectId,
                        ItemType = 1,
                        ItemId = moduleIds[i - 1],
                        SortCode = i
                    };
                    authorize.Create();

                    authorizeMenuList.Add(authorize);
                }
                //保存
                int res = this.BaseRepository().Insert(authorizeMenuList);

                #endregion 功能

                #region 按钮

                List<AuthorizeEntity> authorizeButtonList = new List<AuthorizeEntity>();
                for (int i = 1; i <= moduleButtonIds.Length; i++)
                {
                    AuthorizeEntity authorize = new AuthorizeEntity
                    {
                        Category = (int)authorizeType,
                        ObjectId = objectId,
                        ItemType = 2,
                        ItemId = moduleButtonIds[i - 1],
                        SortCode = i
                    };
                    authorize.Create();

                    authorizeButtonList.Add(authorize);
                }
                //保存
                res = this.BaseRepository().Insert(authorizeButtonList);

                #endregion 按钮

                #region 视图

                List<AuthorizeEntity> authorizeViewList = new List<AuthorizeEntity>();
                for (int i = 1; i <= moduleColumnIds.Length; i++)
                {
                    AuthorizeEntity authorize = new AuthorizeEntity
                    {
                        Category = (int)authorizeType,
                        ObjectId = objectId,
                        ItemType = 3,
                        ItemId = moduleColumnIds[i - 1],
                        SortCode = i
                    };
                    authorize.Create();

                    authorizeViewList.Add(authorize);
                }
                //保存
                res = this.BaseRepository().Insert(authorizeViewList);

                #endregion 视图

                #region 数据权限

                //清除数据权限
                isSucc = this
                    .BaseRepository().Delete<AuthorizeDataEntity>(u => u.ObjectId == objectId);
                int sortCode = 1;
                List<AuthorizeDataEntity> authorizeDataTempList = new List<AuthorizeDataEntity>();

                foreach (AuthorizeDataEntity authorizeData in authorizeDataList)
                {
                    authorizeData.Category = (int)authorizeType;
                    authorizeData.ObjectId = objectId;
                    authorizeData.SortCode = sortCode++;
                    authorizeData.Create();

                    authorizeDataTempList.Add(authorizeData);
                }
                //保存
                this.BaseRepository().Insert(authorizeDataTempList);

                #endregion 数据权限
            }
        }
    }
}