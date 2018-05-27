using System.Collections.Generic;
using System.Data;
using Berry.Entity.CommonEntity;
using Lottomat.Application.Entity.SystemManage;

namespace Berry.IBLL.SystemManage
{
    /// <summary>
    /// 数据表管理
    /// </summary>
    public interface IDataBaseTableBLL
    {
        #region 获取数据
        /// <summary>
        /// 数据表列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns></returns>
        DataTable GetTableList(string dataBaseLinkId, string tableName);
        /// <summary>
        /// 数据表字段列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns></returns>
        IEnumerable<DataBaseTableFieldEntity> GetTableFiledList(string dataBaseLinkId, string tableName);
        /// <summary>
        /// 数据库表数据列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接</param>
        /// <param name="tableName">表明</param>
        /// <param name="switchWhere">条件</param>
        /// <param name="logic">逻辑</param>
        /// <param name="keyword">关键字</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        DataTable GetTableDataList(string dataBaseLinkId, string tableName, string switchWhere, string logic, string keyword, PaginationEntity pagination);
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存数据库表表单（新增、修改）
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param>
        /// <param name="tableDescription">表说明</param>
        /// <param name="fieldListJson">字段列表</param>
        void SaveForm(string dataBaseLinkId, string tableName, string tableDescription, string fieldListJson);
        #endregion
    }
}
