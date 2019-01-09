using Berry.Entity.CommonEntity;
using Berry.Entity.PublicInfoManage;
using Berry.IService.PublicInfoManage;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;
using Berry.Extension;
using Berry.Service.Base;

namespace Berry.Service.PublicInfoManage
{
    /// <summary>
    /// 电子公告
    /// </summary>
    public class NoticeService : BaseService<NewsEntity>, INoticeService
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
            IEnumerable<NewsEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetPageList -公告列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    var expression = LambdaExtension.True<NewsEntity>();
                    JObject queryParam = queryJson.TryToJObject();
                    if (queryParam != null)
                    {
                        if (!queryParam["FullHead"].IsEmpty())
                        {
                            string FullHead = queryParam["FullHead"].ToString();
                            expression = expression.And(t => t.FullHead.Contains(FullHead));
                        }
                        if (!queryParam["Category"].IsEmpty())
                        {
                            string Category = queryParam["Category"].ToString();
                            expression = expression.And(t => t.Category == Category);
                        }
                        if (!queryParam["CategoryId"].IsEmpty())
                        {
                            string CategoryId = queryParam["CategoryId"].ToString();
                            expression = expression.And(t => t.CategoryId == CategoryId);
                        }
                    }

                    expression = expression.And(t => t.TypeId == 2);
                    Tuple<IEnumerable<NewsEntity>, int> tuple = this.BaseRepository().FindList<NewsEntity>(conn, expression, pagination.sidx, pagination.sord.ToLower() == "asc", pagination.rows, pagination.page, tran);
                    pagination.records = tuple.Item2;
                    res = tuple.Item1;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 公告实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public NewsEntity GetEntity(string keyValue)
        {
            NewsEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetEntity-公告实体", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().FindEntity<NewsEntity>(conn, keyValue, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<NewsEntity> GetList(Expression<Func<NewsEntity, bool>> condition)
        {
            IEnumerable<NewsEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetList-获取所有数据", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindList<NewsEntity>(conn, condition, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "RemoveForm-删除公告", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    int res = this.BaseRepository().Delete<NewsEntity>(conn, keyValue, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }

        /// <summary>
        /// 保存公告表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="newsEntity">公告实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, NewsEntity newsEntity)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "SaveForm-保存公告表单（新增、修改）", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        newsEntity.Modify(keyValue);
                        newsEntity.TypeId = 2;

                        int res = this.BaseRepository().Update<NewsEntity>(conn, newsEntity, tran);
                    }
                    else
                    {
                        newsEntity.Create();
                        newsEntity.TypeId = 2;

                        int res = this.BaseRepository().Insert<NewsEntity>(conn, newsEntity, tran);
                    }

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }

        #endregion 提交数据
    }
}