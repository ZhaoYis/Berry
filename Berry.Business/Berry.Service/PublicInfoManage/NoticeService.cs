using Berry.Data.Repository;
using Berry.Entity.CommonEntity;
using Berry.Entity.PublicInfoManage;
using Berry.IService.PublicInfoManage;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Berry.Extension;

namespace Berry.Service.PublicInfoManage
{
    /// <summary>
    /// 电子公告
    /// </summary>
    public class NoticeService : RepositoryFactory, INoticeService
    {
        #region 获取数据

        /// <summary>
        /// 公告列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<NewsEntity> GetPageList(PaginationEntity pagination, string queryJson)
        {
            var expression = LambdaExtension.True<NewsEntity>();
            JObject queryParam = queryJson.TryToJObject();
            if (queryParam != null)
            {
                if (!string.IsNullOrEmpty(queryParam["FullHead"].ToString()))
                {
                    string FullHead = queryParam["FullHead"].ToString();
                    expression = expression.And(t => t.FullHead.Contains(FullHead));
                }
                if (!string.IsNullOrEmpty(queryParam["Category"].ToString()))
                {
                    string Category = queryParam["Category"].ToString();
                    expression = expression.And(t => t.Category == Category);
                }
            }

            expression = expression.And(t => t.TypeId == 2);
            return this.BaseRepository().FindList<NewsEntity>(expression, pagination);
        }

        /// <summary>
        /// 公告实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public NewsEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity<NewsEntity>(keyValue);
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<NewsEntity> GetList(Expression<Func<NewsEntity, bool>> condition)
        {
            return this.BaseRepository().FindList<NewsEntity>(condition);
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete<NewsEntity>(keyValue);
        }

        /// <summary>
        /// 保存公告表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="newsEntity">公告实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, NewsEntity newsEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                newsEntity.Modify(keyValue);
                newsEntity.TypeId = 2;
                this.BaseRepository().Update<NewsEntity>(newsEntity);
            }
            else
            {
                newsEntity.Create();
                newsEntity.TypeId = 2;
                this.BaseRepository().Insert<NewsEntity>(newsEntity);
            }
        }

        #endregion 提交数据
    }
}