using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using Berry.Data.Repository;
using Berry.Entity.CommonEntity;
using Berry.IService.Base;

namespace Berry.Service.Base
{
    /// <summary>
    /// 基类
    /// </summary>
    public class BaseService<T> : DatabaseFactory, IBaseService<T> where T : class
    {
        #region 公共操作方法

        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Add(T entity)
        {
            int res = 0;
            IDbTransaction tran = null;
            Logger(this.GetType(), "Add-添加一条记录", () =>
            {
                if (entity != null)
                {
                    using (var conn = this.BaseRepository().GetBaseConnection())
                    {
                        tran = conn.BeginTransaction();
                        res = this.BaseRepository().Insert<T>(conn, entity, tran);
                        tran.Commit();
                    }
                }
            }, e =>
            {

                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public virtual int AddList(List<T> entitys)
        {
            int res = 0;
            IDbTransaction tran = null;
            Logger(this.GetType(), "AddList-批量添加", () =>
            {
                if (entitys != null && entitys.Count > 0)
                {
                    using (var conn = this.BaseRepository().GetBaseConnection())
                    {
                        tran = conn.BeginTransaction();
                        res = this.BaseRepository().Insert<T>(conn, entitys, tran);
                        tran.Commit();
                    }
                }
            }, e =>
            {

                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 根据条件获取一条记录
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public virtual T GetEntity(Expression<Func<T, bool>> condition)
        {
            T res = default(T);
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetEntity-根据条件获取一条记录", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().FindEntity<T>(conn, condition, tran);
                    tran.Commit();
                }
            }, e =>
            {

                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 根据条件获取多条记录
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public virtual List<T> GetList(Expression<Func<T, bool>> condition)
        {
            List<T> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetList-根据条件获取多条记录", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().FindList<T>(conn, condition, tran).ToList();
                    tran.Commit();
                }
            }, e =>
            {

                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 删除表所有数据
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            int res = 0;
            IDbTransaction tran = null;
            Logger(this.GetType(), "Delete-删除表所有数据", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().Delete<T>(conn, tran);
                    tran.Commit();
                }
            }, e =>
            {

                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public virtual int Delete(Expression<Func<T, bool>> condition)
        {
            int res = 0;
            IDbTransaction tran = null;
            Logger(this.GetType(), "Delete-根据条件删除数据", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().Delete<T>(conn, condition, tran);
                    tran.Commit();
                }
            }, e =>
            {

                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 根据条件更新
        /// </summary>
        /// <param name="modelModifyProps">要修改的列及修改后列的值集合</param>
        /// <param name="condition">修改的条件</param>
        /// <returns>返回受影响行数</returns>
        public virtual int Update(T modelModifyProps, Expression<Func<T, bool>> condition)
        {
            int res = 0;
            IDbTransaction tran = null;
            Logger(this.GetType(), "Update-根据条件更新", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().Update<T>(conn, modelModifyProps, condition, tran);
                    tran.Commit();
                }
            }, e =>
            {

                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        public virtual int ExecuteBySql(string strSql)
        {
            int res = 0;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExecuteBySql-执行T-SQL", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().ExecuteBySql(conn, strSql, null, tran);
                    tran.Commit();
                }
            }, e =>
            {

                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public virtual int ExecuteBySql(string strSql, object param)
        {
            int res = 0;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExecuteBySql-执行T-SQL", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().ExecuteBySql(conn, strSql, param, tran);
                    tran.Commit();
                }
            }, e =>
            {

                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 执行T-SQL并返回集合
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public virtual List<TR> ExecuteBySqlAndReturnList<TR>(string strSql, object param)
        {
            IEnumerable<TR> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExecuteBySqlAndReturnList-执行T-SQL并返回集合", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().ExecuteBySqlAndReturnList<TR>(conn, strSql, param, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res.ToList();
        }

        /// <summary>
        /// 执行 SQL 语句返回对象
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="strSql">sql语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public virtual TR ExecuteBySqlAndReturnObject<TR>(string strSql, object param)
        {
            TR res = default(TR);
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExecuteBySqlAndReturnObject-执行T-SQL并返回对象", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().ExecuteBySqlAndReturnObject<TR>(conn, strSql, param, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <returns></returns>
        public virtual int ExecuteByProc(string procName)
        {
            int res = 0;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExecuteByProc-执行存储过程", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().ExecuteByProc(conn, procName, null, tran);
                    tran.Commit();
                }
            }, e =>
            {

                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public virtual int ExecuteByProc(string procName, object param)
        {
            int res = 0;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExecuteByProc-执行存储过程", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().ExecuteByProc(conn, procName, param, tran);
                    tran.Commit();
                }
            }, e =>
            {

                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 执行存储过程，返回集合
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="procName">存储过程名称</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public virtual List<TR> ExecuteByProc<TR>(string procName, object param)
        {
            List<TR> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExecuteByProc-执行存储过程，返回集合", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().ExecuteByProc<TR>(conn, procName, param, tran).ToList();
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 根据条件获取分页数据
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="condition">条件</param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public Tuple<IEnumerable<T>, int> FindList<TR>(Expression<Func<T, bool>> condition, PaginationEntity pagination)
        {
            Tuple<IEnumerable<T>, int> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "根据条件获取分页数据-FindList", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindList<T>(conn, condition, pagination.sidx, pagination.sord.ToLower() == "asc", pagination.rows, pagination.page, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 根据条件查询一个DataTable
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable FindTable<TR>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查询一个DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, object parameters)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public Tuple<DataTable, int> FindTable(string strSql, PaginationEntity pagination)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">DbCommand参数</param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public Tuple<DataTable, int> FindTable(string strSql, object parameters, PaginationEntity pagination)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}