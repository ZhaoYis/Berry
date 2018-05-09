using Berry.Entity.SystemManage;
using Berry.Entity.ViewModel;
using Berry.Extension;
using Berry.IService.SystemManage;
using Berry.Service.Base;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Berry.Service.SystemManage
{
    /// <summary>
    /// 数据字典明细
    /// </summary>
    public class DataItemDetailService : BaseService, IDataItemDetailService
    {
        /// <summary>
        /// 明细列表
        /// </summary>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        public IEnumerable<DataItemDetailEntity> GetDataItemDetailList(string itemId)
        {
            IEnumerable<DataItemDetailEntity> res = this.BaseRepository()
                .FindList<DataItemDetailEntity>(d => d.ItemId.Equals(itemId) && d.DeleteMark == false && d.EnabledMark == true).OrderBy(d => d.SortCode);

            return res;
        }

        /// <summary>
        /// 明细实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataItemDetailEntity GetDataItemDetailEntity(string keyValue)
        {
            DataItemDetailEntity res = this.BaseRepository().FindEntity<DataItemDetailEntity>(keyValue);

            return res;
        }

        /// <summary>
        /// 获取数据字典列表（给绑定下拉框提供的）
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataItemViewModel> GetDataItemList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  i.ItemId ,
                                    i.ItemCode AS EnCode ,
                                    d.ItemDetailId ,
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
                                    LEFT JOIN Base_DataItem i ON i.ItemId = d.ItemId
                            WHERE   1 = 1
                                    AND d.EnabledMark = 1
                                    AND d.DeleteMark = 0
                            ORDER BY d.SortCode ASC");

            DataTable data = this.BaseRepository().FindTable(strSql.ToString());
            if (data.IsExistRows())
            {
                IEnumerable<DataItemViewModel> res = data.DataTableToList<DataItemViewModel>();

                return res;
            }

            return new List<DataItemViewModel>();
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
            var expression = LambdaExtension.True<DataItemDetailEntity>();
            expression = expression.And(t => t.ItemValue == itemValue).And(t => t.ItemId == itemId);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.Id != keyValue);
            }

            bool hasExit = this.BaseRepository().IQueryable(expression).Any();

            return hasExit;
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
            var expression = LambdaExtension.True<DataItemDetailEntity>();
            expression = expression.And(t => t.ItemName == itemName).And(t => t.ItemId == itemId);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.Id != keyValue);
            }

            bool hasExit = this.BaseRepository().IQueryable(expression).Any();

            return hasExit;
        }

        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveDataItemDetailByKey(string keyValue)
        {
            int res = this.BaseRepository().Delete(keyValue);
        }

        /// <summary>
        /// 保存明细表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataItemDetailEntity">明细实体</param>
        /// <returns></returns>
        public void SaveDataItemDetail(string keyValue, DataItemDetailEntity dataItemDetailEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                dataItemDetailEntity.Modify(keyValue);
                int res = this.BaseRepository().Update(dataItemDetailEntity);
            }
            else
            {
                dataItemDetailEntity.Create();
                int res = this.BaseRepository().Insert(dataItemDetailEntity);
            }
        }
    }
}