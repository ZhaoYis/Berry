using Berry.Entity.CommonEntity;
using Berry.Entity.PublicInfoManage;
using Berry.IBLL.PublicInfoManage;
using Berry.IService.PublicInfoManage;
using Berry.Service.PublicInfoManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Berry.Util;

namespace Berry.BLL.PublicInfoManage
{
    /// <summary>
    /// 新闻中心
    /// </summary>
    public class NewsBLL : INewsBLL
    {
        private INewsService service = new NewsService();

        #region 获取数据

        /// <summary>
        /// 新闻列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<NewsEntity> GetPageList(PaginationEntity pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }

        /// <summary>
        /// 新闻实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public NewsEntity GetEntity(string keyValue)
        {
            NewsEntity newsEntity = service.GetEntity(keyValue);
            newsEntity.NewsContent = StringHelper.HtmlDecode(newsEntity.NewsContent);
            return newsEntity;
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<NewsEntity> GetList(Expression<Func<NewsEntity, bool>> condition)
        {
            return service.GetList(condition).ToList();
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            service.RemoveForm(keyValue);
        }

        /// <summary>
        /// 保存新闻表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="newsEntity">新闻实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, NewsEntity newsEntity)
        {
            newsEntity.NewsContent = StringHelper.HtmlEncode(newsEntity.NewsContent);
            service.SaveForm(keyValue, newsEntity);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="newsEntity">新闻实体</param>
        /// <returns></returns>
        public void UpdateForm(NewsEntity newsEntity)
        {
            service.UpdateForm(newsEntity);
        }

        #endregion 提交数据

    }
}