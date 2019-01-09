using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Berry.Log;
using Berry.Util;
using Berry.Util.LambdaToSQL;
using Dapper;

namespace Berry.Data.Dapper
{
    /// <summary>
    /// 操作SqlServer数据库，Dapper实现
    /// </summary>
    public class MsSqlDatabase4Dapper : BaseLogger, IDatabase
    {
        #region 构造函数

        /// <summary>
        /// 对象锁🔒
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connStringName">连接字符串配置项名称</param>
        public MsSqlDatabase4Dapper(string connStringName)
        {
            lock (_lock)
            {
                ConnectionString = ConfigHelper.GetConnectionString(connStringName);
            }
        }

        #endregion 构造函数

        #region 属性

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 获取 数据库连接串
        /// </summary>
        private IDbConnection Connection
        {
            get
            {
                IDbConnection dbconnection = new SqlConnection(ConnectionString);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }
                return dbconnection;
            }
        }

        /// <summary>
        /// 超时时间
        /// </summary>
        private const int Timeout = 30;

        #endregion 属性

        /// <summary>
        /// 获取基础数据库连接
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetBaseConnection()
        {
            return Connection;
        }

        #region 执行 SQL 语句
        /// <summary>
        /// 执行 SQL 语句
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public int ExecuteBySql(IDbConnection connection, string strSql)
        {
            return this.ExecuteBySql(connection, strSql, null);
        }

        /// <summary>
        /// 执行 SQL 语句
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public int ExecuteBySql(IDbConnection connection, string strSql, object parameters, IDbTransaction transaction = null, int? timeout = Timeout)
        {
            int res = 0;
            this.Logger(this.GetType(), "执行 SQL 语句-ExecuteBySql", () =>
            {
                res = connection.Execute(strSql, parameters, transaction, timeout);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {
            });
            return res;
        }

        /// <summary>
        /// 执行 SQL 语句返回集合
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="connection"></param>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public IEnumerable<TR> ExecuteBySqlAndReturnList<TR>(IDbConnection connection, string strSql, object parameters, IDbTransaction transaction = null, int? timeout = Timeout)
        {
            IEnumerable<TR> res = null;
            this.Logger(this.GetType(), "执行 SQL 语句-ExecuteBySqlAndReturnList", () =>
            {
                res = connection.Query<TR>(strSql, parameters, transaction, true, timeout, CommandType.Text);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {
            });
            return res;
        }

        /// <summary>
        /// 执行 SQL 语句返回对象
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="connection"></param>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public TR ExecuteBySqlAndReturnObject<TR>(IDbConnection connection, string strSql, object parameters, IDbTransaction transaction = null, int? timeout = Timeout)
        {
            TR res = default(TR);
            this.Logger(this.GetType(), "执行 SQL 语句返回对象-ExecuteBySqlAndReturnObject", () =>
            {
                res = connection.ExecuteScalar<TR>(strSql, parameters, transaction, timeout, CommandType.Text);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {
            });
            return res;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="procName"></param>
        /// <returns></returns>
        public int ExecuteByProc(IDbConnection connection, string procName)
        {
            return this.ExecuteByProc(connection, procName, null);
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="procName"></param>
        /// <param name="parameters"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public int ExecuteByProc(IDbConnection connection, string procName, object parameters, IDbTransaction transaction = null, int? timeout = Timeout)
        {
            int res = 0;
            this.Logger(this.GetType(), "执行存储过程-ExecuteByProc", () =>
            {
                res = connection.Execute(procName, parameters, transaction, timeout, CommandType.StoredProcedure);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {
            });
            return res;
        }

        /// <summary>
        /// 执行存储过程，返回集合
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="connection"></param>
        /// <param name="procName"></param>
        /// <returns></returns>
        public IEnumerable<TR> ExecuteByProc<TR>(IDbConnection connection, string procName)
        {
            return this.ExecuteByProc<TR>(connection, procName, null);
        }

        /// <summary>
        /// 执行存储过程，返回集合
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="connection"></param>
        /// <param name="procName"></param>
        /// <param name="parameters"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public IEnumerable<TR> ExecuteByProc<TR>(IDbConnection connection, string procName, object parameters, IDbTransaction transaction = null, int? timeout = Timeout)
        {
            List<TR> res = null;
            this.Logger(this.GetType(), "执行存储过程，返回集合-ExecuteByProc", () =>
            {
                //DynamicParameters param = new DynamicParameters();
                //foreach (DbParameter par in dbParameter)
                //{
                //    param.Add(par.ParameterName, par.Value, par.DbType, par.Direction, par.Size);
                //}
                res = connection.Query<TR>(procName, parameters, transaction, true, timeout, CommandType.StoredProcedure).ToList();
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {
            });
            return res;
        }

        #endregion 执行 SQL 语句

        #region 对象实体 添加、修改、删除

        /// <summary>
        /// 实体插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public int Insert<T>(IDbConnection connection, T entity, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            int res = 0;
            this.Logger(this.GetType(), "实体插入-Insert", () =>
            {
                string sql = DatabaseCommon.InsertSql<T>(entity).ToString();
                res = connection.Execute(sql, entity, transaction, timeout);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return res;
        }

        /// <summary>
        /// 实体批量插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="entities"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public int Insert<T>(IDbConnection connection, List<T> entities, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            int res = 0;
            this.Logger(this.GetType(), "实体批量插入-Insert", () =>
            {
                string sql = DatabaseCommon.InsertSql<T>(entities.FirstOrDefault()).ToString();
                res = connection.Execute(sql, entities, transaction, timeout);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return res;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public int Delete<T>(IDbConnection connection, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            int res = 0;
            this.Logger(this.GetType(), "删除-Delete", () =>
            {
                string tableName = EntityAttributeHelper.GetEntityTable<T>();
                string sql = DatabaseCommon.DeleteSql(tableName).ToString();
                res = connection.Execute(sql, null, transaction, timeout);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return res;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public int Delete<T>(IDbConnection connection, T entity, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            int res = 0;
            this.Logger(this.GetType(), "删除-Delete", () =>
            {
                string sql = DatabaseCommon.DeleteSql<T>(entity).ToString();
                res = connection.Execute(sql, entity, transaction, timeout);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return res;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="entities"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public int Delete<T>(IDbConnection connection, List<T> entities, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            int res = 0;
            this.Logger(this.GetType(), "批量删除-Delete", () =>
            {
                string sql = DatabaseCommon.DeleteSql<T>(entities.FirstOrDefault()).ToString();
                res = connection.Execute(sql, entities, transaction, timeout);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return res;
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="condition"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public int Delete<T>(IDbConnection connection, Expression<Func<T, bool>> condition, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            int res = 0;
            this.Logger(this.GetType(), "根据条件删除-Delete", () =>
            {
                LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
                lambda.AddAndWhere(condition);
                string where = lambda.Where();

                string sql = DatabaseCommon.DeleteSql<T>(where).ToString();
                res = connection.Execute(sql, null, transaction, timeout);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return res;
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="keyValue"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public int Delete<T>(IDbConnection connection, object keyValue, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            int res = 0;
            this.Logger(this.GetType(), "根据主键删除-Delete", () =>
            {
                Type type = keyValue.GetType();
                string key = EntityAttributeHelper.GetEntityKey<T>();
                string whereStr = " WHERE 1 = 1 ";
                whereStr = string.Format(type == typeof(int) ? " WHERE {0} = {1}" : " WHERE {0} = '{1}'", key, keyValue);

                string sql = DatabaseCommon.DeleteSql<T>(whereStr).ToString();
                res = connection.Execute(sql, null, transaction, timeout);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return res;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public int Update<T>(IDbConnection connection, T entity, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            int res = 0;
            this.Logger(this.GetType(), "更新-Update", () =>
            {
                string sql = DatabaseCommon.UpdateSql<T>(entity).ToString();
                res = connection.Execute(sql, entity, transaction, timeout);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return res;
        }

        /// <summary>
        /// 根据条件以及指定属性名称更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="entity"></param>
        /// <param name="condition"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public int Update<T>(IDbConnection connection, T entity, Expression<Func<T, bool>> condition, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            int res = 0;
            this.Logger(this.GetType(), "根据条件以及指定属性名称更新-Update", () =>
            {
                LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
                lambda.AddAndWhere(condition);
                string where = lambda.Where();

                string sql = DatabaseCommon.UpdateSql<T>(entity, "", where).ToString();
                res = connection.Execute(sql, entity, transaction, timeout);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return res;
        }

        #endregion 对象实体 添加、修改、删除

        #region 对象实体 查询

        /// <summary>
        /// 根据主键查询一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="keyValue"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public T FindEntity<T>(IDbConnection connection, object keyValue, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            T res = null;
            this.Logger(this.GetType(), "根据主键查询一个实体-FindEntity", () =>
            {
                Type type = keyValue.GetType();
                string key = EntityAttributeHelper.GetEntityKey<T>();
                string whereStr = " WHERE 1 = 1 ";
                whereStr = string.Format(type == typeof(int) ? " WHERE {0} = {1}" : " WHERE {0} = '{1}'", key, keyValue);

                string sql = DatabaseCommon.SelectSql<T>(whereStr, true).ToString();

                res = connection.Query<T>(sql, null, transaction, true, timeout).FirstOrDefault();
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return res;
        }

        /// <summary>
        /// 根据条件查询一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="condition"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public T FindEntity<T>(IDbConnection connection, Expression<Func<T, bool>> condition, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            T res = null;
            this.Logger(this.GetType(), "根据条件查询一个实体-FindEntity", () =>
            {
                LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
                lambda.AddAndWhere(condition);
                string where = lambda.Where();

                string sql = DatabaseCommon.SelectSql<T>(where, true).ToString();

                res = connection.Query<T>(sql, null, transaction, true, timeout).FirstOrDefault();
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return res;
        }

        /// <summary>
        /// 根据条件查询一个DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="condition"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public DataTable FindTable<T>(IDbConnection connection, Expression<Func<T, bool>> condition, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            DataTable res = null;
            this.Logger(this.GetType(), "根据条件查询一个DataTable-FindDataTable", () =>
            {
                LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
                lambda.AddAndWhere(condition);
                string where = lambda.Where();

                string sql = DatabaseCommon.SelectSql<T>(where, true).ToString();

                res = connection.ExecuteReader(sql, null, transaction, timeout, CommandType.Text).GetSchemaTable();
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return res;
        }

        /// <summary>
        /// 查询一个DataTable
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public DataTable FindTable(IDbConnection connection, string strSql, object parameters, IDbTransaction transaction = null, int? timeout = Timeout)
        {
            DataTable res = null;
            this.Logger(this.GetType(), "查询一个DataTable-FindDataTable", () =>
            {
                res = connection.ExecuteReader(strSql, parameters, transaction, timeout, CommandType.Text).GetSchemaTable();
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return res;
        }

        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public Tuple<DataTable, int> FindTable(IDbConnection connection, string strSql, string orderField, bool isAsc, int pageSize, int pageIndex, IDbTransaction transaction = null, int? timeout = Timeout)
        {
            return FindTable(connection, strSql, null, orderField, isAsc, pageSize, pageIndex, transaction, timeout);
        }

        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">DbCommand参数</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public Tuple<DataTable, int> FindTable(IDbConnection connection, string strSql, object parameters, string orderField, bool isAsc, int pageSize, int pageIndex, IDbTransaction transaction = null, int? timeout = Timeout)
        {
            int total = 0;
            DataTable res = null;
            this.Logger(this.GetType(), "获取分页DataTable-FindTable", () =>
            {
                StringBuilder sb = new StringBuilder();
                if (pageIndex == 0)
                {
                    pageIndex = 1;
                }
                int num = (pageIndex - 1) * pageSize;
                int num1 = (pageIndex) * pageSize;
                string orderBy = "";

                if (!string.IsNullOrEmpty(orderField))
                {
                    if (orderField.ToUpper().IndexOf("ASC", StringComparison.Ordinal) + orderField.ToUpper().IndexOf("DESC", StringComparison.Ordinal) > 0)
                    {
                        orderBy = "Order By " + orderField;
                    }
                    else
                    {
                        orderBy = "Order By " + orderField + " " + (isAsc ? "ASC" : "DESC");
                    }
                }
                else
                {
                    orderBy = "Order By (Select 0)";
                }
                sb.Append("Select * From (Select ROW_NUMBER() Over (" + orderBy + ")");
                sb.Append(" As rowNum, * From (" + strSql + ") As T ) As N Where rowNum > " + num + " And rowNum <= " + num1 + "");

                string selectCountSql = "Select Count(*) From (" + strSql + ") AS t";
                total = connection.ExecuteScalar<int>(selectCountSql, parameters, transaction, timeout);

                res = connection.ExecuteReader(sb.ToString(), null, transaction, timeout, CommandType.Text).GetSchemaTable();
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return new Tuple<DataTable, int>(res, total);
        }

        /// <summary>
        /// 获取IQueryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public IQueryable<T> IQueryable<T>(IDbConnection connection, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            IQueryable<T> res = null;
            this.Logger(this.GetType(), "获取IQueryable-IQueryable", () =>
            {
                string sql = DatabaseCommon.SelectSql<T>("").ToString();
                res = (IQueryable<T>)connection.Query<T>(sql, null, transaction, true, timeout);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return res;
        }

        /// <summary>
        /// 获取IQueryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="condition"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public IQueryable<T> IQueryable<T>(IDbConnection connection, Expression<Func<T, bool>> condition, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            IQueryable<T> res = null;
            this.Logger(this.GetType(), "获取IQueryable-IQueryable", () =>
            {
                LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
                lambda.AddAndWhere(condition);
                string where = lambda.Where();
                string sql = DatabaseCommon.SelectSql<T>(where).ToString();

                res = (IQueryable<T>)connection.Query<T>(sql, null, transaction, true, timeout);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return res;
        }

        /// <summary>
        /// 得到一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(IDbConnection connection, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            IEnumerable<T> res = null;
            this.Logger(this.GetType(), "得到一个集合-FindList", () =>
            {
                string sql = DatabaseCommon.SelectSql<T>("", true).ToString();
                res = connection.Query<T>(sql, null, transaction, true, timeout);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return res;
        }

        /// <summary>
        /// 根据条件查询出一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="condition"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(IDbConnection connection, Expression<Func<T, bool>> condition, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            IEnumerable<T> res = null;
            this.Logger(this.GetType(), "根据条件查询出一个集合-FindList", () =>
            {
                LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
                lambda.AddAndWhere(condition);
                string where = lambda.Where();
                string sql = DatabaseCommon.SelectSql<T>(where, true).ToString();

                res = connection.Query<T>(sql, null, transaction, true, timeout);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return res;
        }

        /// <summary>
        /// 执行sql语句，得到一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="strSql"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(IDbConnection connection, string strSql, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            return this.FindList<T>(connection, strSql, null, transaction, timeout);
        }

        /// <summary>
        /// 执行sql语句，得到一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(IDbConnection connection, string strSql, object parameters, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            IEnumerable<T> res = null;
            this.Logger(this.GetType(), "执行sql语句，得到一个集合-FindList", () =>
            {
                res = connection.Query<T>(strSql, parameters, transaction, true, timeout);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return res;
        }

        /// <summary>
        /// 根据条件获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="condition">条件</param>
        /// <param name="orderField">排序字段，多个用英文逗号隔开，类似：Id Asc,Name Desc</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public Tuple<IEnumerable<T>, int> FindList<T>(IDbConnection connection, Expression<Func<T, bool>> condition, string orderField, bool isAsc, int pageSize, int pageIndex, IDbTransaction transaction = null, int? timeout = Timeout) where T : class
        {
            IEnumerable<T> res = null;
            int temp = 0;
            this.Logger(this.GetType(), "根据条件获取分页数据-FindList", () =>
            {
                StringBuilder sb = new StringBuilder();
                if (pageIndex == 0)
                {
                    pageIndex = 1;
                }
                int num = (pageIndex - 1) * pageSize;
                int num1 = (pageIndex) * pageSize;
                string orderBy = "";

                LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
                lambda.AddAndWhere(condition);
                string where = lambda.Where();

                //表名
                string table = EntityAttributeHelper.GetEntityTable<T>();
                string strSql = DatabaseCommon.SelectSql<T>(where, true).ToString();

                if (!string.IsNullOrEmpty(orderField))
                {
                    if (orderField.ToUpper().IndexOf("ASC", StringComparison.Ordinal) + orderField.ToUpper().IndexOf("DESC", StringComparison.Ordinal) > 0)
                    {
                        orderBy = "Order By " + orderField;
                    }
                    else
                    {
                        orderBy = "Order By " + orderField + " " + (isAsc ? "ASC" : "DESC");
                    }
                }
                else
                {
                    orderBy = "Order By (Select 0)";
                }
                sb.Append("Select * From (Select ROW_NUMBER() Over (" + orderBy + ")");
                sb.Append(" As rowNum, * From (" + strSql + ") As T ) As N Where rowNum > " + num + " And rowNum <= " + num1 + "");

                string selectCountSql = "Select Count(*) From " + table + " WHERE 1 = 1";
                temp = (int)connection.ExecuteScalar(selectCountSql, null, transaction);

                res = connection.Query<T>(strSql, null, transaction, true, timeout);
            }, e =>
            {
                if (transaction != null) transaction.Rollback();

                connection.Close();
                connection.Dispose();
            }, () =>
            {

            });
            return new Tuple<IEnumerable<T>, int>(res, temp);
        }

        #endregion 对象实体 查询

    }
}