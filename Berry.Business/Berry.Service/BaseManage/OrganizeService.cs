using Berry.Entity.BaseManage;
using Berry.Extension;
using Berry.IService.BaseManage;
using Berry.Service.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace Berry.Service.BaseManage
{
    /// <summary>
    /// 机构管理
    /// </summary>
    public class OrganizeService : BaseService<OrganizeEntity>, IOrganizeService
    {
        /// <summary>
        /// 机构列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrganizeEntity> GetOrganizeList()
        {
            List<OrganizeEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetOrganizeList-机构列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindList<OrganizeEntity>(conn, or => or.DeleteMark == false, tran)
                       .OrderByDescending(or => or.SortCode).ToList();

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 机构实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public OrganizeEntity GetOrganizeEntity(string keyValue)
        {
            OrganizeEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetOrganizeEntity-机构实体", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().FindEntity<OrganizeEntity>(conn, keyValue, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 公司名称不能重复
        /// </summary>
        /// <param name="organizeName">公司名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string organizeName, string keyValue)
        {
            bool res = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExistFullName-公司名称不能重复", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    List<OrganizeEntity> data = this.BaseRepository().FindList<OrganizeEntity>(conn, t => t.FullName == organizeName, tran).ToList();
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        data = data.Where(t => t.Id != keyValue).ToList();
                    }
                    res = data.Count > 0;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 外文名称不能重复
        /// </summary>
        /// <param name="enCode">外文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            bool res = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExistEnCode-外文名称不能重复", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    List<OrganizeEntity> data = this.BaseRepository().FindList<OrganizeEntity>(conn, t => t.EnCode == enCode, tran).ToList();
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        data = data.Where(t => t.Id != keyValue).ToList();
                    }
                    res = data.Count > 0;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 中文名称不能重复
        /// </summary>
        /// <param name="shortName">中文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistShortName(string shortName, string keyValue)
        {
            bool res = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExistShortName-中文名称不能重复", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    List<OrganizeEntity> data = this.BaseRepository().FindList<OrganizeEntity>(conn, t => t.ShortName == shortName, tran).ToList();
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        data = data.Where(t => t.Id != keyValue).ToList();
                    }
                    res = data.Count > 0;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 删除机构
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveOrganizeByKey(string keyValue)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "RemoveOrganizeByKey-删除机构", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    int count = this.BaseRepository().FindList<OrganizeEntity>(conn, t => t.ParentId == keyValue, tran).Count();
                    if (count > 0)
                    {
                        throw new Exception("当前所选数据有子节点数据！");
                    }

                    int res = this.BaseRepository().Delete<OrganizeEntity>(conn, keyValue, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }

        /// <summary>
        /// 保存机构表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="organizeEntity">机构实体</param>
        /// <returns></returns>
        public void AddOrganize(string keyValue, OrganizeEntity organizeEntity)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "AddOrganize-保存机构表单（新增、修改）", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        organizeEntity.Modify(keyValue);
                        int res = this.BaseRepository().Update<OrganizeEntity>(conn, organizeEntity, tran);
                    }
                    else
                    {
                        organizeEntity.Create();
                        int res = this.BaseRepository().Insert<OrganizeEntity>(conn, organizeEntity, tran);
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