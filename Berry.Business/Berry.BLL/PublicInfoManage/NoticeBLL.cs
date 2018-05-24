using Berry.Entity.CommonEntity;
using Berry.Entity.PublicInfoManage;
using Berry.IBLL.PublicInfoManage;
using Berry.IService.PublicInfoManage;
using Berry.Service.PublicInfoManage;
using Berry.Util;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Berry.BLL.PublicInfoManage
{
    /// <summary>
    /// 电子公告
    /// </summary>
    public class NoticeBLL : INoticeBLL
    {
        private INoticeService service = new NoticeService();

        #region 获取数据

        /// <summary>
        /// 公告列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<NewsEntity> GetPageList(PaginationEntity pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }

        /// <summary>
        /// 公告实体
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
            return service.GetList(condition);
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            service.RemoveForm(keyValue);
        }

        /// <summary>
        /// 保存公告表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="newsEntity">公告实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, NewsEntity newsEntity)
        {
            newsEntity.NewsContent = StringHelper.HtmlEncode(newsEntity.NewsContent);
            service.SaveForm(keyValue, newsEntity);
        }

        #endregion 提交数据
    }
}