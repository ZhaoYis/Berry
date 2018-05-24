using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Berry.Entity.CommonEntity;
using Berry.Entity.PublicInfoManage;

namespace Berry.IBLL.PublicInfoManage
{
    /// <summary>
    /// 新闻中心
    /// </summary>
    public interface INewsBLL
    {
        #region 获取数据
        /// <summary>
        /// 新闻列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<NewsEntity> GetPageList(PaginationEntity pagination, string queryJson);
        /// <summary>
        /// 新闻实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        NewsEntity GetEntity(string keyValue);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IEnumerable<NewsEntity> GetList(Expression<Func<NewsEntity, bool>> condition);

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存新闻表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="newsEntity">新闻实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, NewsEntity newsEntity);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="newsEntity">新闻实体</param>
        /// <returns></returns>
        void UpdateForm(NewsEntity newsEntity);
        #endregion
    }
}
