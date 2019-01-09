using Berry.Entity.SystemManage;
using Berry.IService.SystemManage;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Berry.Cache.Core.Base;
using Berry.Extension;
using Berry.Service.Base;

namespace Berry.Service.SystemManage
{
    /// <summary>
    /// 区域管理
    /// </summary>
    public class AreaService : BaseService<AreaEntity>, IAreaService
    {
        #region 获取数据

        /// <summary>
        /// 区域列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AreaEntity> GetList()
        {
            IEnumerable<AreaEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetList-区域列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindList<AreaEntity>(conn, t => t.DeleteMark == false && t.EnabledMark == true && t.Layer != 4, tran).OrderBy(t => t.CreateDate).ToList();

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 区域列表
        /// </summary>
        /// <param name="parentId">节点Id</param>
        /// <param name="keyword">关键字查询</param>
        /// <returns></returns>
        public IEnumerable<AreaEntity> GetList(string parentId, string keyword)
        {
            IEnumerable<AreaEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetList-区域列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    var expression = LambdaExtension.True<AreaEntity>();
                    if (!string.IsNullOrEmpty(parentId))
                    {
                        expression = expression.And(t => t.ParentId == parentId);
                    }
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        expression = expression.And(t => t.AreaCode.Contains(keyword));
                        expression = expression.Or(t => t.AreaName.Contains(keyword));
                    }
                    res = this.BaseRepository().FindList(conn, expression, tran).OrderBy(t => t.CreateDate).ToList();

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 区域实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public AreaEntity GetEntity(string keyValue)
        {
            AreaEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetEntity-区域实体", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().FindEntity<AreaEntity>(conn, keyValue, tran);
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
        /// 删除区域
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            CacheFactory.GetCache().Remove("__AreaCache");

            IDbTransaction tran = null;
            Logger(this.GetType(), "RemoveForm-删除区域", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    int res = this.BaseRepository().Delete<AreaEntity>(conn, keyValue, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }

        /// <summary>
        /// 保存区域表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="areaEntity">区域实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, AreaEntity areaEntity)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "SaveForm-保存区域表单（新增、修改）", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        areaEntity.Modify(keyValue);
                        int res = this.BaseRepository().Update<AreaEntity>(conn, areaEntity, tran);
                    }
                    else
                    {
                        areaEntity.Create();
                        int res = this.BaseRepository().Insert<AreaEntity>(conn, areaEntity, tran);
                    }

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });

            CacheFactory.GetCache().Remove("__AreaCache");
        }

        #endregion 提交数据
    }
}