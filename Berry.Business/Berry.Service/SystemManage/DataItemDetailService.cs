using Berry.Entity.SystemManage;
using Berry.Entity.ViewModel;
using Berry.Extension;
using Berry.IService.SystemManage;
using Berry.Service.Base;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Berry.Service.SystemManage
{
    /// <summary>
    /// 数据字典明细
    /// </summary>
    public class DataItemDetailService : BaseService<DataItemDetailEntity>, IDataItemDetailService
    {
        /// <summary>
        /// 明细列表
        /// </summary>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        public IEnumerable<DataItemDetailEntity> GetDataItemDetailList(string itemId)
        {
            IEnumerable<DataItemDetailEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetDataItemDetailList-明细列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindList<DataItemDetailEntity>(conn, d => d.ItemId == itemId && d.DeleteMark == false && d.EnabledMark == true, tran).OrderBy(d => d.SortCode);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 明细实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataItemDetailEntity GetDataItemDetailEntity(string keyValue)
        {
            DataItemDetailEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetDataItemDetailEntity-明细实体", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().FindEntity<DataItemDetailEntity>(conn, keyValue, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 获取数据字典列表（给绑定下拉框提供的）
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataItemViewModel> GetDataItemList()
        {
            IEnumerable<DataItemViewModel> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetDataItemList-获取数据字典列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(@"SELECT  i.Id AS ItemId,
                                    i.ItemCode AS EnCode ,
                                    d.Id AS ItemDetailId,
                                    d.ParentId ,
                                    d.ItemCode ,
                                    d.ItemName ,
                                    d.ItemValue ,
                                    d.QuickQuery ,
                                    d.SimpleSpelling ,
                                    d.IsDefault ,
                                    d.SortCode ,
                                    d.EnabledMark
                            FROM    Base_DataItemDetail d
                                    LEFT JOIN Base_DataItem i ON i.Id = d.ItemId
                            WHERE   1 = 1
                                    AND d.EnabledMark = 1
                                    AND d.DeleteMark = 0
                            ORDER BY d.SortCode ASC");

                    res = this.BaseRepository().FindList<DataItemViewModel>(conn, strSql.ToString(), tran);

                    //DataTable data = this.BaseRepository().FindTable(conn, strSql.ToString(), null, tran);
                    //if (data.IsExistRows())
                    //{
                    //    res = data.DataTableToList<DataItemViewModel>();
                    //}

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 项目值不能重复
        /// </summary>
        /// <param name="itemValue">项目值</param>
        /// <param name="keyValue">主键</param>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        public bool ExistItemValue(string itemValue, string keyValue, string itemId)
        {
            bool res = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExistItemValue-项目值不能重复", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    List<DataItemDetailEntity> data = this.BaseRepository().FindList<DataItemDetailEntity>(conn, t => t.ItemValue == itemValue && t.ItemId == itemId, tran).ToList();
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        data = data.Where(t => t.Id != keyValue).ToList();
                    }
                    res = data.Count > 0;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 项目名不能重复
        /// </summary>
        /// <param name="itemName">项目名</param>
        /// <param name="keyValue">主键</param>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        public bool ExistItemName(string itemName, string keyValue, string itemId)
        {
            bool res = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExistItemName-项目名不能重复", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    List<DataItemDetailEntity> data = this.BaseRepository().FindList<DataItemDetailEntity>(conn, t => t.ItemName == itemName && t.ItemId == itemId, tran).ToList();
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        data = data.Where(t => t.Id != keyValue).ToList();
                    }
                    res = data.Count > 0;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveDataItemDetailByKey(string keyValue)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "RemoveDataItemDetailByKey-删除明细", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    int res = this.BaseRepository().Delete<DataItemDetailEntity>(conn, keyValue, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }

        /// <summary>
        /// 保存明细表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataItemDetailEntity">明细实体</param>
        /// <returns></returns>
        public void SaveDataItemDetail(string keyValue, DataItemDetailEntity dataItemDetailEntity)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "SaveDataItemDetail-保存明细表单（新增、修改）", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        dataItemDetailEntity.Modify(keyValue);
                        int res = this.BaseRepository().Update<DataItemDetailEntity>(conn, dataItemDetailEntity, tran);
                    }
                    else
                    {
                        dataItemDetailEntity.Create();
                        int res = this.BaseRepository().Insert<DataItemDetailEntity>(conn, dataItemDetailEntity, tran);
                    }

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }
    }
}