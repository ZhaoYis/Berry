using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Berry.Entity.CommonEntity;
using Berry.Entity.PublicInfoManage;

namespace Berry.IBLL.PublicInfoManage
{
    /// <summary>
    /// 电子公告
    /// </summary>
    public interface INoticeBLL
    {
        #region 获取数据
        /// <summary>
        /// 公告列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<NewsEntity> GetPageList(PaginationEntity pagination, string queryJson);
        /// <summary>
        /// 公告实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        NewsEntity GetEntity(string keyValue);

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存公告表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="newsEntity">公告实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, NewsEntity newsEntity);
        #endregion
    }
}
