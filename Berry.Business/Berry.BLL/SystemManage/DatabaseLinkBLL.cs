using Berry.Entity.SystemManage;
using Berry.IBLL.SystemManage;
using Berry.IService.SystemManage;
using Berry.Service.SystemManage;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace Berry.BLL.SystemManage
{
    /// <summary>
    /// 数据库连接管理
    /// </summary>
    public class DataBaseLinkBLL : IDataBaseLinkBLL
    {
        private IDataBaseLinkService service = new DataBaseLinkService();

        #region 获取数据

        /// <summary>
        /// 库连接列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataBaseLinkEntity> GetList()
        {
            return service.GetList();
        }

        /// <summary>
        /// 库连接实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataBaseLinkEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 删除库连接
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            service.RemoveForm(keyValue);
        }

        /// <summary>
        /// 保存库连接表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="databaseLinkEntity">库连接实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, DataBaseLinkEntity databaseLinkEntity)
        {
            #region 测试连接数据库

            DbConnection dbConnection = null;
            string serverAddress = "";
            switch (databaseLinkEntity.DbType)
            {
                case "SqlServer":
                    dbConnection = new SqlConnection(databaseLinkEntity.DbConnection);
                    serverAddress = dbConnection.DataSource;
                    break;

                default:
                    break;
            }
            if (dbConnection != null) dbConnection.Close();
            databaseLinkEntity.ServerAddress = serverAddress;

            #endregion 测试连接数据库

            service.SaveForm(keyValue, databaseLinkEntity);
        }

        #endregion 提交数据
    }
}