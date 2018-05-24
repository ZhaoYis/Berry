using Berry.Entity.BaseManage;
using Berry.Entity.CommonEntity;
using Berry.Extension;
using Berry.IService.BaseManage;
using Berry.Service.Base;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Berry.Service.BaseManage
{
    /// <summary>
    /// 用户组管理
    /// </summary>
    public class UserGroupService : BaseService, IUserGroupService
    {
        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetUserGroupList()
        {
            IEnumerable<RoleEntity> res = this.BaseRepository().FindList<RoleEntity>(r => r.Category == 4 && r.DeleteMark == false && r.EnabledMark == true);

            return res;
        }

        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetPageList(PaginationEntity pagination, string queryJson)
        {
            var expression = LambdaExtension.True<RoleEntity>();
            JObject queryParam = queryJson.TryToJObject();
            if (queryParam != null)
            {
                string enCode = queryParam["EnCode"].ToString();
                string fullName = queryParam["FullName"].ToString();

                if (!string.IsNullOrEmpty(enCode))
                {
                    expression = expression.And(t => t.EnCode.Contains(enCode));
                }

                if (!string.IsNullOrEmpty(fullName))
                {
                    expression = expression.And(t => t.FullName.Contains(fullName));
                }
            }
            expression = expression.And(t => t.Category == 4 && t.DeleteMark == false && t.EnabledMark == true);

            IEnumerable<RoleEntity> res = this.BaseRepository().FindList<RoleEntity>(expression, pagination);

            return res;
        }

        /// <summary>
        /// 用户组列表(ALL)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetAllUserGroupList()
        {
            IEnumerable<RoleEntity> res = this.BaseRepository().FindList<RoleEntity>(GetAllUserGroupSQL.ToString());

            return res;
        }

        /// <summary>
        /// 用户组实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RoleEntity GetUserGroupEntity(string keyValue)
        {
            RoleEntity res = this.BaseRepository().FindEntity<RoleEntity>(keyValue);

            return res;
        }

        /// <summary>
        /// 组编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            List<RoleEntity> data = this.BaseRepository().FindList<RoleEntity>(t => t.Category == 4 && t.DeleteMark == false && t.EnabledMark == true && t.EnCode == enCode).ToList();
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = data.Where(t => t.Id != keyValue).ToList();
            }

            bool hasExit = data.Count > 0;

            return hasExit;
        }

        /// <summary>
        /// 组名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            List<RoleEntity> data = this.BaseRepository().FindList<RoleEntity>(t => t.Category == 4 && t.DeleteMark == false && t.EnabledMark == true && t.FullName == fullName).ToList();
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = data.Where(t => t.Id != keyValue).ToList();
            }

            bool hasExit = data.Count > 0;

            return hasExit;
        }

        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveUserGroupByKey(string keyValue)
        {
            int res = this.BaseRepository().Delete<RoleEntity>(keyValue);
        }

        /// <summary>
        /// 保存用户组表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="userGroupEntity">用户组实体</param>
        /// <returns></returns>
        public void SaveUserGroup(string keyValue, RoleEntity userGroupEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                userGroupEntity.Modify(keyValue);

                int res = this.BaseRepository().Update<RoleEntity>(userGroupEntity);
            }
            else
            {
                userGroupEntity.Create();
                userGroupEntity.Category = 4;

                int res = this.BaseRepository().Insert<RoleEntity>(userGroupEntity);
            }
        }

        #region SQL语句

        /// <summary>
        /// 用户组列表
        /// </summary>
        private const string GetAllUserGroupSQL = @"SELECT  r.Id ,
				                                            o.FullName AS OrganizeId ,
				                                            r.Category ,
				                                            r.EnCode ,
				                                            r.FullName ,
				                                            r.SortCode ,
				                                            r.EnabledMark ,
				                                            r.Description ,
				                                            r.CreateDate,
                                                            r.DeleteMark
                                            FROM    Base_Role r
				                                            LEFT JOIN Base_Organize o ON o.Id = r.OrganizeId
                                            WHERE o.FullName is not null and r.Category = 4 and r.EnabledMark = 1 and r.DeleteMark = 0
                                            ORDER BY o.FullName, r.SortCode";

        #endregion SQL语句
    }
}