using System.Collections.Generic;
using Berry.Entity.SystemManage;

namespace Berry.IBLL.SystemManage
{
    /// <summary>
    /// 数据库备份
    /// </summary>
    public interface IDataBaseBackupBLL
    {
        #region 获取数据
        /// <summary>
        /// 库备份列表
        /// </summary>
        /// <param name="dataBaseLinkId">连接库Id</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DataBaseBackupEntity> GetList(string dataBaseLinkId, string queryJson);
        /// <summary>
        /// 库备份文件路径列表
        /// </summary>
        /// <param name="databaseBackupId">计划Id</param>
        /// <returns></returns>
        IEnumerable<DataBaseBackupEntity> GetPathList(string databaseBackupId);
        /// <summary>
        /// 库备份实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        DataBaseBackupEntity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除库备份
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string keyValue);
        /// <summary>
        /// 保存库备份表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataBaseBackupEntity">库备份实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, DataBaseBackupEntity dataBaseBackupEntity);
        #endregion
    }
}
