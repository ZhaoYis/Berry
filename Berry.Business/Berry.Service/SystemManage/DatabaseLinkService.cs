using Berry.Entity.SystemManage;
using Berry.IService.SystemManage;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Berry.Service.Base;

namespace Berry.Service.SystemManage
{
    /// <summary>
    /// 数据库连接管理
    /// </summary>
    public class DataBaseLinkService : BaseService<DataBaseLinkEntity>, IDataBaseLinkService
    {
        #region 获取数据

        /// <summary>
        /// 库连接列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataBaseLinkEntity> GetList()
        {
            IEnumerable<DataBaseLinkEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetList-库连接列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindList<DataBaseLinkEntity>(conn, d => d.DeleteMark == false, tran).OrderBy(t => t.CreateDate).ToList();

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 库连接实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataBaseLinkEntity GetEntity(string keyValue)
        {
            DataBaseLinkEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetEntity-库连接实体", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().FindEntity<DataBaseLinkEntity>(conn, keyValue, tran);
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
        /// 删除库连接
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "RemoveForm-删除库连接", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    int res = this.BaseRepository().Delete<DataBaseLinkEntity>(conn, keyValue, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }

        /// <summary>
        /// 保存库连接表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="databaseLinkEntity">库连接实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, DataBaseLinkEntity databaseLinkEntity)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "SaveForm-保存库连接表单（新增、修改）", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        databaseLinkEntity.Modify(keyValue);
                        int res = this.BaseRepository().Update<DataBaseLinkEntity>(conn, databaseLinkEntity, tran);
                    }
                    else
                    {
                        databaseLinkEntity.Create();
                        int res = this.BaseRepository().Insert<DataBaseLinkEntity>(conn, databaseLinkEntity, tran);
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