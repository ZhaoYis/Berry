using Berry.Entity.SystemManage;
using Berry.Extension;
using Berry.IService.SystemManage;
using Berry.Service.Base;
using System.Collections.Generic;
using System.Linq;

namespace Berry.Service.SystemManage
{
    /// <summary>
    /// 数据字典分类
    /// </summary>
    public class DataItemService : BaseService, IDataItemService
    {
        /// <summary>
        /// 分类列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataItemEntity> GetDataItemList()
        {
            IEnumerable<DataItemEntity> res = this.BaseRepository()
                .FindList<DataItemEntity>(d => d.DeleteMark == false && d.EnabledMark == true)
                .OrderBy(d => d.SortCode).ToList();

            return res;
        }

        /// <summary>
        /// 分类实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataItemEntity GetEntityByKey(string keyValue)
        {
            DataItemEntity res = this.BaseRepository().FindEntity<DataItemEntity>(keyValue);

            return res;
        }

        /// <summary>
        /// 根据分类编号获取实体对象
        /// </summary>
        /// <param name="itemCode">编号</param>
        /// <returns></returns>
        public DataItemEntity GetEntityByCode(string itemCode)
        {
            var expression = LambdaExtension.True<DataItemEntity>();
            if (!string.IsNullOrEmpty(itemCode))
            {
                expression = expression.And(t => t.ItemCode == itemCode);
            }

            expression = expression.And(d => d.DeleteMark == false && d.EnabledMark == true);

            DataItemEntity res = this.BaseRepository().FindEntity<DataItemEntity>(expression);

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
            var expression = LambdaExtension.True<DataItemEntity>();
            expression = expression.And(t => t.ItemCode == itemCode);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.Id != keyValue);
            }

            bool isExit = this.BaseRepository().FindList<DataItemEntity>(expression).Any();

            return isExit;
        }

        /// <summary>
        /// 分类名称不能重复
        /// </summary>
        /// <param name="itemName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistItemName(string itemName, string keyValue)
        {
            var expression = LambdaExtension.True<DataItemEntity>();
            expression = expression.And(t => t.ItemName == itemName);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.Id != keyValue);
            }

            bool isExit = this.BaseRepository().FindList<DataItemEntity>(expression).Any();

            return isExit;
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveDataItemByKey(string keyValue)
        {
            this.BaseRepository().Delete<DataItemEntity>(keyValue);
        }

        /// <summary>
        /// 保存分类表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataItemEntity">分类实体</param>
        /// <returns></returns>
        public void SaveDataItem(string keyValue, DataItemEntity dataItemEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                dataItemEntity.Modify(keyValue);
                this.BaseRepository().Update<DataItemEntity>(dataItemEntity);
            }
            else
            {
                dataItemEntity.Create();
                this.BaseRepository().Insert<DataItemEntity>(dataItemEntity);
            }
        }
    }
}