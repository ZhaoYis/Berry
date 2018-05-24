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
    /// 角色管理
    /// </summary>
    public class RoleService : BaseService, IRoleService
    {
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetRoleList()
        {
            IEnumerable<RoleEntity> res = this.BaseRepository().FindList<RoleEntity>(t => t.Category == 1 && t.EnabledMark == true && t.DeleteMark == false);
            res = res.OrderByDescending(r => r.CreateDate);

            return res;
        }

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetRolePageList(PaginationEntity pagination, string queryJson)
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
            expression = expression.And(t => t.Category == 1 && t.DeleteMark == false && t.EnabledMark == true);

            IEnumerable<RoleEntity> res = this.BaseRepository().FindList<RoleEntity>(expression, pagination);

            return res;
        }

        /// <summary>
        /// 角色列表all
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetAllRoleList()
        {
            IEnumerable<RoleEntity> res = this.BaseRepository().FindList<RoleEntity>(GetAllUserGroupSQL.ToString());

            return res;
        }

        /// <summary>
        /// 角色实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RoleEntity GetRoleEntity(string keyValue)
        {
            RoleEntity res = this.BaseRepository().FindEntity<RoleEntity>(keyValue);

            return res;
        }

        /// <summary>
        /// 角色编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            List<RoleEntity> data = this.BaseRepository().FindList<RoleEntity>(t => t.Category == 1 && t.DeleteMark == false && t.EnabledMark == true && t.EnCode == enCode).ToList();
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = data.Where(t => t.Id != keyValue).ToList();
            }

            bool hasExit = data.Count > 0;

            return hasExit;
        }

        /// <summary>
        /// 角色名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            List<RoleEntity> data = this.BaseRepository().FindList<RoleEntity>(t => t.Category == 1 && t.DeleteMark == false && t.EnabledMark == true && t.FullName == fullName).ToList();
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = data.Where(t => t.Id != keyValue).ToList();
            }

            bool hasExit = data.Count > 0;

            return hasExit;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveRoleByKey(string keyValue)
        {
            int res = this.BaseRepository().Delete<RoleEntity>(keyValue);
        }

        /// <summary>
        /// 保存角色表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="roleEntity">角色实体</param>
        /// <returns></returns>
        public void SaveRole(string keyValue, RoleEntity roleEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                roleEntity.Modify(keyValue);

                int res = this.BaseRepository().Update<RoleEntity>(roleEntity);
            }
            else
            {
                roleEntity.Create();
                roleEntity.Category = 1;

                int res = this.BaseRepository().Insert<RoleEntity>(roleEntity);
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
                                            WHERE o.FullName is not null and r.Category = 1 and r.EnabledMark = 1 and r.DeleteMark = 0
                                            ORDER BY o.FullName, r.SortCode";

        #endregion SQL语句
    }
}