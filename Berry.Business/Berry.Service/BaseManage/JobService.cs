using Berry.Data.Repository;
using Berry.Entity.BaseManage;
using Berry.Extension;
using Berry.IService.BaseManage;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using Berry.Entity.CommonEntity;
using Berry.Service.Base;
using System.Data;
using System.Diagnostics;
using System;

namespace Berry.Service.BaseManage
{
    /// <summary>
    /// 职位管理
    /// </summary>
    public class JobService : BaseService<RoleEntity>, IJobService
    {
        #region 获取数据

        /// <summary>
        /// 职位列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetList()
        {
            IEnumerable<RoleEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetList-职位列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().FindList<RoleEntity>(conn, t => t.Category == 3 && t.EnabledMark == true && t.DeleteMark == false, tran).OrderByDescending(t => t.CreateDate).ToList();
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 职位列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetPageList(PaginationEntity pagination, string queryJson)
        {
            IEnumerable<RoleEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetPageList-职位列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    var expression = LambdaExtension.True<RoleEntity>();
                    JObject queryParam = queryJson.TryToJObject();
                    if (queryParam != null)
                    {
                        //机构主键
                        if (!queryParam["organizeId"].IsEmpty())
                        {
                            string organizeId = queryParam["organizeId"].ToString();
                            expression = expression.And(t => t.OrganizeId == organizeId);
                        }
                        //查询条件
                        if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
                        {
                            string condition = queryParam["condition"].ToString();
                            string keyword = queryParam["keyword"].ToString();
                            switch (condition)
                            {
                                case "EnCode":            //职位编号
                                    expression = expression.And(t => t.EnCode.Contains(keyword));
                                    break;

                                case "FullName":          //职位名称
                                    expression = expression.And(t => t.FullName.Contains(keyword));
                                    break;
                            }
                        }
                    }

                    expression = expression.And(t => t.Category == 3);
                    Tuple<IEnumerable<RoleEntity>, int> tuple = this.BaseRepository().FindList<RoleEntity>(conn, expression, pagination.sidx, pagination.sord.ToLower() == "asc", pagination.rows, pagination.page, tran);
                    pagination.records = tuple.Item2;
                    res = tuple.Item1;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 职位实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RoleEntity GetEntity(string keyValue)
        {
            RoleEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetEntity-职位实体", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().FindEntity<RoleEntity>(conn, keyValue, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        #endregion 获取数据

        #region 验证数据

        /// <summary>
        /// 职位编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            bool res = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExistEnCode-职位编号不能重复", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    var expression = LambdaExtension.True<RoleEntity>();
                    expression = expression.And(t => t.EnCode == enCode).And(t => t.Category == 3);
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        expression = expression.And(t => t.Id != keyValue);
                    }
                    res = !this.BaseRepository().FindList<RoleEntity>(conn, expression, tran).Any() ? true : false;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 职位名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            bool res = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExistFullName-职位名称不能重复", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    var expression = LambdaExtension.True<RoleEntity>();
                    expression = expression.And(t => t.FullName == fullName).And(t => t.Category == 3);
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        expression = expression.And(t => t.Id != keyValue);
                    }
                    res = !this.BaseRepository().FindList<RoleEntity>(conn, expression, tran).Any() ? true : false;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        #endregion 验证数据

        #region 提交数据

        /// <summary>
        /// 删除职位
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "RemoveForm-删除职位", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    int res = this.BaseRepository().Delete<RoleEntity>(conn, keyValue, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }

        /// <summary>
        /// 保存职位表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="jobEntity">职位实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, RoleEntity jobEntity)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "SaveForm-保存职位表单（新增、修改）", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        jobEntity.Modify(keyValue);
                        int res = this.BaseRepository().Update<RoleEntity>(conn, jobEntity, tran);
                    }
                    else
                    {
                        jobEntity.Create();
                        jobEntity.Category = 3;
                        int res = this.BaseRepository().Insert<RoleEntity>(conn, jobEntity, tran);
                    }

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }

        #endregion 提交数据
    }
}