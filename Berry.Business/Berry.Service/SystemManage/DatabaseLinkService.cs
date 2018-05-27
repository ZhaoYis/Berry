﻿using Berry.Data.Repository;
using Berry.Entity.SystemManage;
using Berry.IService.SystemManage;
using System.Collections.Generic;
using System.Linq;

namespace Berry.Service.SystemManage
{
    /// <summary>
    /// 数据库连接管理
    /// </summary>
    public class DataBaseLinkService : RepositoryFactory<DataBaseLinkEntity>, IDataBaseLinkService
    {
        #region 获取数据

        /// <summary>
        /// 库连接列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataBaseLinkEntity> GetList()
        {
            return this.BaseRepository().FindList(d => d.DeleteMark == false).OrderBy(t => t.CreateDate).ToList();
        }

        /// <summary>
        /// 库连接实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataBaseLinkEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 删除库连接
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }

        /// <summary>
        /// 保存库连接表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="databaseLinkEntity">库连接实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, DataBaseLinkEntity databaseLinkEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                databaseLinkEntity.Modify(keyValue);
                this.BaseRepository().Update(databaseLinkEntity);
            }
            else
            {
                databaseLinkEntity.Create();
                this.BaseRepository().Insert(databaseLinkEntity);
            }
        }

        #endregion 提交数据
    }
}