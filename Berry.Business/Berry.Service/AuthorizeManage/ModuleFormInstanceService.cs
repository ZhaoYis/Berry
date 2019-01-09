using System.Data;
using System.Diagnostics;
using Berry.Data.Repository;
using Berry.Entity.AuthorizeManage;
using Berry.Extension;
using Berry.IService.AuthorizeManage;
using Berry.Service.Base;

namespace Berry.Service.AuthorizeManage
{
    /// <summary>
    /// 系统表单实例
    /// </summary>
    public class ModuleFormInstanceService : BaseService<ModuleFormInstanceEntity>, IModuleFormInstanceService
    {
        #region 获取数据
        /// <summary>
        /// 获取一个实体类
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public ModuleFormInstanceEntity GetEntityByObjectId(string objectId)
        {
            ModuleFormInstanceEntity res = null;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "获取一个实体类-GetEntityByObjectId", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindEntity<ModuleFormInstanceEntity>(conn, t => t.ObjectId == objectId, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int SaveEntity(string keyValue, ModuleFormInstanceEntity entity)
        {
            int res = 0;
            IDbTransaction tran = null;
            this.Logger(this.GetType(), "获取所有功能按钮-GetModuleButtonList", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    if (string.IsNullOrEmpty(keyValue))
                    {
                        entity.Create();
                        res = this.BaseRepository().Insert(conn, entity, tran);
                    }
                    else
                    {
                        entity.Modify(keyValue);
                        res = this.BaseRepository().Update(conn, entity, tran);
                    }

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }
        #endregion
    }
}
