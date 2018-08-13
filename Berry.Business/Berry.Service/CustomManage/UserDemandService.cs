using Berry.Entity.CustomManage;
using Berry.IService.CustomManage;
using Berry.Data.Repository;
using Berry.Entity.CommonEntity;
using System.Collections.Generic;
using System.Linq;
using Berry.Code.Operator;
using Berry.Extension;
using Newtonsoft.Json.Linq;

namespace Berry.Service.CustomManage
{
    /// <summary>
    /// 版 本：V1.0.0
    /// Copyright (c) 2017-2018
    /// 创 建：大师兄
    /// 日 期：2018-08-13 22:13
    /// 描 述：用户需求
    /// </summary>
    public class UserDemandService : RepositoryFactory, IUserDemandService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<UserDemandEntity> GetPageList(PaginationEntity pagination, string queryJson)
        {
            var expression = LambdaExtension.True<UserDemandEntity>();
            JObject queryParam = queryJson.TryToJObject();
            if (queryParam != null)
            {
                if (!queryParam["Title"].IsEmpty())
                {
                    string Title = queryParam["Title"].ToString();
                    expression = expression.And(t => t.Title.Contains(Title));
                }
                if (!queryParam["CategoryId"].IsEmpty())
                {
                    string CategoryId = queryParam["CategoryId"].ToString();
                    expression = expression.And(t => t.CategoryId == CategoryId);
                }
            }

            if (OperatorProvider.Provider.Current().IsSystem)
            {
                expression = expression.And(t => t.IsDelete == false);
            }
            else
            {
                expression = expression.And(t => t.IsDelete == false && t.CreateUserId == OperatorProvider.Provider.Current().UserId);
            }
            return this.BaseRepository().FindList<UserDemandEntity>(expression, pagination);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<UserDemandEntity> GetList(string queryJson)
        {
            var expression = LambdaExtension.True<UserDemandEntity>();
            JObject queryParam = queryJson.TryToJObject();
            if (queryParam != null)
            {
                if (!queryParam["Title"].IsEmpty())
                {
                    string Title = queryParam["Title"].ToString();
                    expression = expression.And(t => t.Title.Contains(Title));
                }
                if (!queryParam["CategoryId"].IsEmpty())
                {
                    string CategoryId = queryParam["CategoryId"].ToString();
                    expression = expression.And(t => t.CategoryId == CategoryId);
                }
            }

            if (OperatorProvider.Provider.Current().IsSystem)
            {
                expression = expression.And(t => t.IsDelete == false);
            }
            else
            {
                expression = expression.And(t => t.IsDelete == false && t.CreateUserId == OperatorProvider.Provider.Current().UserId);
            }
            return this.BaseRepository().FindList(expression);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public UserDemandEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity<UserDemandEntity>(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete<UserDemandEntity>(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, UserDemandEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update<UserDemandEntity>(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert<UserDemandEntity>(entity);
            }
        }
        #endregion
    }
}
