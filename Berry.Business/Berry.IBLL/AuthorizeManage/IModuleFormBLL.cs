﻿using System.Data;
using Berry.Entity.AuthorizeManage;
using Berry.Entity.CommonEntity;

namespace Berry.IBLL.AuthorizeManage
{
    /// <summary>
    /// 系统表单
    /// </summary>
    public interface IModuleFormBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        DataTable GetPageList(PaginationEntity pagination, string queryJson);
        /// <summary>
        /// 获取一个实体类
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        ModuleFormEntity GetEntity(string keyValue);
        /// <summary>
        /// 通过模块Id获取系统表单
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        ModuleFormEntity GetEntityByModuleId(string moduleId);
         /// <summary>
        /// 判断模块是否已经有系统表单
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        bool IsExistModuleId(string keyValue, string moduleId);
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        int SaveEntity(string keyValue, ModuleFormEntity entity);
        /// <summary>
        /// 虚拟删除一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        int VirtualDelete(string keyValue);
        #endregion
    }
}
