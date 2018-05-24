using Berry.Data.Repository;
using Berry.Entity.BaseManage;
using Berry.Extension;
using Berry.IService.BaseManage;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using Berry.Entity.CommonEntity;

namespace Berry.Service.BaseManage
{
    /// <summary>
    /// 职位管理
    /// </summary>
    public class JobService : RepositoryFactory, IJobService
    {
        #region 获取数据

        /// <summary>
        /// 职位列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetList()
        {
            return this.BaseRepository().FindList<RoleEntity>(t => t.Category == 3 && t.EnabledMark == true && t.DeleteMark == false).OrderByDescending(t => t.CreateDate).ToList();
        }

        /// <summary>
        /// 职位列表
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
                //机构主键
                if (!queryParam["organizeId"].IsEmpty())
                {
                    string organizeId = queryParam["organizeId"].ToString();
                    expression = expression.And(t => t.OrganizeId == organizeId);
                }
                //查询条件
                if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
                {
                    string condition = queryParam["condition"].ToString();
                    string keyword = queryParam["keyword"].ToString();
                    switch (condition)
                    {
                        case "EnCode":            //职位编号
                            expression = expression.And(t => t.EnCode.Contains(keyword));
                            break;

                        case "FullName":          //职位名称
                            expression = expression.And(t => t.FullName.Contains(keyword));
                            break;

                        default:
                            break;
                    }
                }
            }

            expression = expression.And(t => t.Category == 3);
            return this.BaseRepository().FindList(expression, pagination);
        }

        /// <summary>
        /// 职位实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RoleEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity<RoleEntity>(keyValue);
        }

        #endregion 获取数据

        #region 验证数据

        /// <summary>
        /// 职位编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            var expression = LambdaExtension.True<RoleEntity>();
            expression = expression.And(t => t.EnCode == enCode).And(t => t.Category == 3);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.Id != keyValue);
            }
            return !this.BaseRepository().FindList<RoleEntity>(expression).Any() ? true : false;
        }

        /// <summary>
        /// 职位名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            var expression = LambdaExtension.True<RoleEntity>();
            expression = expression.And(t => t.FullName == fullName).And(t => t.Category == 3);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.Id != keyValue);
            }
            return !this.BaseRepository().FindList<RoleEntity>(expression).Any() ? true : false;
        }

        #endregion 验证数据

        #region 提交数据

        /// <summary>
        /// 删除职位
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }

        /// <summary>
        /// 保存职位表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="jobEntity">职位实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, RoleEntity jobEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                jobEntity.Modify(keyValue);
                this.BaseRepository().Update(jobEntity);
            }
            else
            {
                jobEntity.Create();
                jobEntity.Category = 3;
                this.BaseRepository().Insert(jobEntity);
            }
        }

        #endregion 提交数据
    }
}