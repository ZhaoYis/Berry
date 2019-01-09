using Berry.Entity.SystemManage;
using Berry.Extension;
using Berry.IService.SystemManage;
using Berry.Service.Base;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace Berry.Service.SystemManage
{
    /// <summary>
    /// 数据字典分类
    /// </summary>
    public class DataItemService : BaseService<DataItemEntity>, IDataItemService
    {
        /// <summary>
        /// 分类列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataItemEntity> GetDataItemList()
        {
            IEnumerable<DataItemEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetDataItemList-分类列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindList<DataItemEntity>(conn, d => d.DeleteMark == false && d.EnabledMark == true, tran).OrderBy(d => d.SortCode);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 分类实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataItemEntity GetEntityByKey(string keyValue)
        {
            DataItemEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetEntityByKey-分类实体", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().FindEntity<DataItemEntity>(conn, keyValue, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 根据分类编号获取实体对象
        /// </summary>
        /// <param name="itemCode">编号</param>
        /// <returns></returns>
        public DataItemEntity GetEntityByCode(string itemCode)
        {
            DataItemEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetMemberList-获取成员列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    var expression = LambdaExtension.True<DataItemEntity>();
                    if (!string.IsNullOrEmpty(itemCode))
                    {
                        expression = expression.And(t => t.ItemCode == itemCode);
                    }
                    expression = expression.And(d => d.DeleteMark == false && d.EnabledMark == true);

                    res = this.BaseRepository().FindEntity<DataItemEntity>(conn, expression, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 分类编号不能重复
        /// </summary>
        /// <param name="itemCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistItemCode(string itemCode, string keyValue)
        {
            bool res = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExistItemCode-分类编号不能重复", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    var expression = LambdaExtension.True<DataItemEntity>();
                    expression = expression.And(t => t.ItemCode == itemCode);
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        expression = expression.And(t => t.Id != keyValue);
                    }
                    res = this.BaseRepository().FindList<DataItemEntity>(conn, expression, tran).Any();

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 分类名称不能重复
        /// </summary>
        /// <param name="itemName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistItemName(string itemName, string keyValue)
        {
            bool res = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExistItemName-分类名称不能重复", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    var expression = LambdaExtension.True<DataItemEntity>();
                    expression = expression.And(t => t.ItemName == itemName);
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        expression = expression.And(t => t.Id != keyValue);
                    }
                    res = this.BaseRepository().FindList<DataItemEntity>(conn, expression, tran).Any();

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveDataItemByKey(string keyValue)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "RemoveDataItemByKey-删除分类", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    int res = this.BaseRepository().Delete<DataItemEntity>(conn, keyValue, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }

        /// <summary>
        /// 保存分类表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataItemEntity">分类实体</param>
        /// <returns></returns>
        public void SaveDataItem(string keyValue, DataItemEntity dataItemEntity)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "SaveDataItem-保存分类表单（新增、修改）", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        dataItemEntity.Modify(keyValue);
                        int res = this.BaseRepository().Update<DataItemEntity>(conn, dataItemEntity, tran);
                    }
                    else
                    {
                        dataItemEntity.Create();
                        int res = this.BaseRepository().Insert<DataItemEntity>(conn, dataItemEntity, tran);
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