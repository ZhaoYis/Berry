using Berry.Entity.SystemManage;
using Berry.Extension;
using Berry.IService.SystemManage;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Berry.Service.Base;

namespace Berry.Service.SystemManage
{
    /// <summary>
    /// 数据库备份
    /// </summary>
    public class DataBaseBackupService : BaseService<DataBaseBackupEntity>, IDataBaseBackupService
    {
        #region 获取数据

        /// <summary>
        /// 库备份列表
        /// </summary>
        /// <param name="dataBaseLinkId">连接库Id</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DataBaseBackupEntity> GetList(string dataBaseLinkId, string queryJson)
        {
            IEnumerable<DataBaseBackupEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetList-库备份列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    IEnumerable<DataBaseBackupEntity> list = this.BaseRepository().FindList<DataBaseBackupEntity>(conn, d => d.DeleteMark == false, tran);

                    if (!string.IsNullOrEmpty(dataBaseLinkId))
                    {
                        list = list.Where(t => t.DatabaseLinkId == dataBaseLinkId).ToList();
                    }

                    JObject queryParam = queryJson.TryToJObject();
                    if (queryParam != null)
                    {
                        //查询条件
                        if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
                        {
                            string condition = queryParam["condition"].ToString();
                            string keyword = queryParam["keyword"].ToString();
                            switch (condition)
                            {
                                case "EnCode":            //计划编号
                                    list = list.Where(t => t.EnCode.Contains(keyword)).ToList();
                                    break;
                                case "FullName":          //计划名称
                                    list = list.Where(t => t.FullName.Contains(keyword)).ToList();
                                    break;
                            }
                        }
                    }

                    res = list.OrderByDescending(t => t.CreateDate).ToList();

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 库备份文件路径列表
        /// </summary>
        /// <param name="databaseBackupId">计划Id</param>
        /// <returns></returns>
        public IEnumerable<DataBaseBackupEntity> GetPathList(string databaseBackupId)
        {
            IEnumerable<DataBaseBackupEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetPathList-库备份文件路径列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindList<DataBaseBackupEntity>(conn, t => t.ParentId == databaseBackupId, tran).OrderByDescending(t => t.CreateDate).ToList();

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 库备份实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataBaseBackupEntity GetEntity(string keyValue)
        {
            DataBaseBackupEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetEntity-库备份实体", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().FindEntity<DataBaseBackupEntity>(conn, keyValue, tran);
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
        /// 删除库备份
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "RemoveForm-删除库备份", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    int res = this.BaseRepository().Delete<DataBaseBackupEntity>(conn, keyValue, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }

        /// <summary>
        /// 保存库备份表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataBaseBackupEntity">库备份实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, DataBaseBackupEntity dataBaseBackupEntity)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "SaveForm-保存库备份表单（新增、修改）", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        dataBaseBackupEntity.Modify(keyValue);
                        int res = this.BaseRepository().Update<DataBaseBackupEntity>(conn, dataBaseBackupEntity, tran);
                    }
                    else
                    {
                        dataBaseBackupEntity.Create();
                        int res = this.BaseRepository().Insert<DataBaseBackupEntity>(conn, dataBaseBackupEntity, tran);
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