﻿using Berry.Data.Repository;
using Berry.Entity.SystemManage;
using Berry.Extension;
using Berry.IService.SystemManage;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Berry.Service.SystemManage
{
    /// <summary>
    /// 数据库备份
    /// </summary>
    public class DataBaseBackupService : RepositoryFactory<DataBaseBackupEntity>, IDataBaseBackupService
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
            //var expression = LinqExtensions.True<DataBaseBackupEntity>();

            var list = this.BaseRepository().FindList(d => d.DeleteMark == false);

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

            return list.OrderByDescending(t => t.CreateDate).ToList();
        }

        /// <summary>
        /// 库备份文件路径列表
        /// </summary>
        /// <param name="databaseBackupId">计划Id</param>
        /// <returns></returns>
        public IEnumerable<DataBaseBackupEntity> GetPathList(string databaseBackupId)
        {
            return this.BaseRepository().FindList(t => t.ParentId == databaseBackupId).OrderByDescending(t => t.CreateDate).ToList();
        }

        /// <summary>
        /// 库备份实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataBaseBackupEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 删除库备份
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }

        /// <summary>
        /// 保存库备份表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataBaseBackupEntity">库备份实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, DataBaseBackupEntity dataBaseBackupEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                dataBaseBackupEntity.Modify(keyValue);
                this.BaseRepository().Update(dataBaseBackupEntity);
            }
            else
            {
                dataBaseBackupEntity.Create();
                this.BaseRepository().Insert(dataBaseBackupEntity);
            }
        }

        #endregion 提交数据
    }
}