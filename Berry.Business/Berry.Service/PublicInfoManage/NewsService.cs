using Berry.Data.Repository;
using Berry.Entity.CommonEntity;
using Berry.Entity.PublicInfoManage;
using Berry.Extension;
using Berry.IService.PublicInfoManage;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Berry.Service.PublicInfoManage
{
    /// <summary>
    /// 新闻中心
    /// </summary>
    public class NewsService : RepositoryFactory, INewsService
    {
        #region 获取数据

        /// <summary>
        /// 新闻列表
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
                if (!string.IsNullOrEmpty(queryParam["CategoryId"].ToString()))
                {
                    string CategoryId = queryParam["CategoryId"].ToString();
                    expression = expression.And(t => t.CategoryId == CategoryId);
                }
            }

            expression = expression.And(t => t.TypeId == 1);
            return this.BaseRepository().FindList(expression, pagination);
        }

        /// <summary>
        /// 新闻实体
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
        /// 删除新闻
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete<NewsEntity>(keyValue);
        }

        /// <summary>
        /// 保存新闻表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="newsEntity">新闻实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, NewsEntity newsEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                newsEntity.Modify(keyValue);
                newsEntity.TypeId = 1;
                this.BaseRepository().Update<NewsEntity>(newsEntity);
            }
            else
            {
                newsEntity.Create();
                newsEntity.TypeId = 1;
                this.BaseRepository().Insert<NewsEntity>(newsEntity);
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="newsEntity">新闻实体</param>
        /// <returns></returns>
        public void UpdateForm(NewsEntity newsEntity)
        {
            newsEntity.TypeId = 1;
            newsEntity.Modify(newsEntity.Id);
            this.BaseRepository().Update<NewsEntity>(newsEntity);
        }

        #endregion 提交数据
    }
}