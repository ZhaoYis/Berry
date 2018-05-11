using Berry.Code;
using Berry.Data.Extension;
using Berry.Log;
using Berry.Util;
using Berry.Util.CustomException;
using Dapper;
using SQLinq;
using SQLinq.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Berry.Data.Dapper
{
    /// <summary>
    /// 操作SqlServer数据库，Dapper实现
    /// </summary>
    public class MsSqlDatabase : IDatabase
    {
        #region 构造函数

        /// <summary>
        /// 构造方法
        /// </summary>
        public MsSqlDatabase(string connString)
        {
            SqlHelper.DbType = DatabaseType.SqlServer;
            ConnectionString = ConfigHelper.GetConnectionString(connString);//connString;
        }

        #endregion 构造函数

        #region 属性

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string ConnectionString { get; set; }

        /// <summary>
        /// 获取 数据库连接串
        /// </summary>
        private DbConnection Connection
        {
            get
            {
                DbConnection dbconnection = new SqlConnection(ConnectionString);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }
                return dbconnection;
            }
        }

        /// <summary>
        /// 事务对象
        /// </summary>
        private DbTransaction DbTransaction { get; set; }

        #endregion 属性

        #region 事务提交

        /// <summary>
        /// 事务开始
        /// </summary>
        /// <returns></returns>
        public IDatabase BeginTrans()
        {
            var conn = Connection;
            this.DbTransaction = conn.BeginTransaction();
            return this;
        }

        /// <summary>
        /// 提交当前操作的结果
        /// </summary>
        public int Commit()
        {
            try
            {
                if (DbTransaction != null)
                {
                    DbTransaction.Commit();
                    this.Close();
                }
                return 1;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException is SqlException)
                {
                    SqlException sqlEx = ex.InnerException.InnerException as SqlException;
                    string msg = ExceptionMessageHelper.GetSqlExceptionMessage(sqlEx.Number);
                    throw DataAccessException.ThrowDataAccessException(sqlEx, msg);
                }
                return 0;
            }
            finally
            {
                if (DbTransaction == null)
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 把当前操作回滚成未提交状态
        /// </summary>
        public void Rollback()
        {
            this.DbTransaction.Rollback();
            this.DbTransaction.Dispose();
            this.Close();
        }

        /// <summary>
        /// 关闭连接 内存回收
        /// </summary>
        public void Close()
        {
            DbConnection dbConnection = DbTransaction.Connection;
            if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
            {
                dbConnection.Close();
            }
        }

        #endregion 事务提交

        #region 执行 SQL 语句

        /// <summary>
        /// 执行 SQL 语句
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public int ExecuteBySql(string strSql)
        {
            if (DbTransaction == null)
            {
                using (var connection = Connection)
                {
                    return connection.Execute(strSql);
                }
            }
            else
            {
                DbTransaction.Connection.Execute(strSql, null, DbTransaction);
                return 0;
            }
        }

        /// <summary>
        /// 执行 SQL 语句
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="dbParameter"></param>
        /// <returns></returns>
        public int ExecuteBySql(string strSql, params DbParameter[] dbParameter)
        {
            int res = 0;
            Logger(this.GetType(), $"执行 SQL 语句-ExecuteBySql(string strSql, params DbParameter[] dbParameter)，参数：{strSql}", () =>
            {
                if (DbTransaction == null)
                {
                    using (var connection = Connection)
                    {
                        res = connection.Execute(strSql, dbParameter);
                    }
                }
                else
                {
                    DbTransaction.Connection.Execute(strSql, dbParameter, DbTransaction);
                    res = 0;
                }
            }, e =>
            {
                res = 0;
            });
            return res;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName"></param>
        /// <returns></returns>
        public int ExecuteByProc(string procName)
        {
            if (DbTransaction == null)
            {
                using (var connection = Connection)
                {
                    return connection.Execute(procName);
                }
            }
            else
            {
                DbTransaction.Connection.Execute(procName, null, DbTransaction);
                return 0;
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="dbParameter"></param>
        /// <returns></returns>
        public int ExecuteByProc(string procName, params DbParameter[] dbParameter)
        {
            if (DbTransaction == null)
            {
                using (var connection = Connection)
                {
                    return connection.Execute(procName, dbParameter);
                }
            }
            else
            {
                DbTransaction.Connection.Execute(procName, dbParameter, DbTransaction);
                return 0;
            }
        }

        #endregion 执行 SQL 语句

        #region 对象实体 添加、修改、删除，直接调用执行SQl方法

        /// <summary>
        /// 实体插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert<T>(T entity) where T : class
        {
            int res = 0;
            if (DbTransaction == null)
            {
                string sql = DatabaseCommon.InsertSql<T>(entity).ToString();
                //DbParameter[] parameter = DatabaseCommon.GetParameter<T>(entity);
                using (var connection = Connection)
                {
                    res = connection.Execute(sql, entity);
                }
            }
            else
            {
                string sql = DatabaseCommon.InsertSql<T>(entity).ToString();
                DbParameter[] parameter = DatabaseCommon.GetParameter<T>(entity);
                DbTransaction.Connection.Execute(sql, parameter, DbTransaction);
                return 0;
            }
            return res;
        }

        /// <summary>
        /// 实体插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Insert<T>(IEnumerable<T> entities) where T : class
        {
            if (DbTransaction == null)
            {
                BeginTrans();
                foreach (var item in entities)
                {
                    Insert<T>(item);
                }
                return Commit();
            }
            else
            {
                foreach (var item in entities)
                {
                    Insert<T>(item);
                }
                return 0;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public int Delete<T>() where T : class
        {
            return ExecuteBySql(DatabaseCommon.DeleteSql(EntityAttributeHelper.GetEntityTable<T>()).ToString());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Delete<T>(T entity) where T : class
        {
            int res = 0;
            if (DbTransaction == null)
            {
                string sql = DatabaseCommon.DeleteSql<T>(entity).ToString();
                //DbParameter[] parameter = DatabaseCommon.GetParameter<T>(entity);
                using (var connection = Connection)
                {
                    res = connection.Execute(sql, entity);
                }
            }
            else
            {
                string sql = DatabaseCommon.DeleteSql<T>(entity).ToString();
                DbParameter[] parameter = DatabaseCommon.GetParameter<T>(entity);
                DbTransaction.Connection.Execute(sql, parameter, DbTransaction);
                return 0;
            }
            return res;
            //return ExecuteBySql(DatabaseCommon.DeleteSql<T>(entity).ToString(), DatabaseCommon.GetParameter<T>(entity));
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Delete<T>(IEnumerable<T> entities) where T : class
        {
            if (DbTransaction == null)
            {
                BeginTrans();
                foreach (var item in entities)
                {
                    Delete<T>(item);
                }
                return Commit();
            }
            else
            {
                foreach (var item in entities)
                {
                    Delete<T>(item);
                }
                return 0;
            }
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public int Delete<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            bool isTrans = true;
            if (DbTransaction == null)
            {
                BeginTrans();
                isTrans = false;
            }

            string tableName = EntityAttributeHelper.GetEntityTable<T>();
            SQLinq<T> query = new SQLinq<T>(tableName).Where(condition);
            IEnumerable<T> entities = DbTransaction.Connection.Query<T>(query);

            Delete<T>(entities);
            if (!isTrans)
            {
                return Commit();
            }
            return 0;
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public int Delete<T>(object keyValue) where T : class
        {
            T entity = DbTransaction.Connection.Query<T>(string.Format("select * from {0} where {1}=@primarykey", EntityAttributeHelper.GetEntityTable<T>(), EntityAttributeHelper.GetEntityKey<T>()), new { primarykey = keyValue }).FirstOrDefault();
            return Delete<T>(entity);
        }

        /// <summary>
        /// 根据主键批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public int Delete<T>(object[] keyValue) where T : class
        {
            foreach (var item in keyValue)
            {
                Delete<T>(item);
            }
            return DbTransaction == null ? Commit() : 0;
        }

        /// <summary>
        /// 根据属性名称删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyValue"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public int Delete<T>(object propertyValue, string propertyName) where T : class
        {
            bool isTrans = true;
            if (DbTransaction == null)
            {
                BeginTrans();
                isTrans = false;
            }
            IEnumerable<T> entitys = DbTransaction.Connection.Query<T>(string.Format("select * from {0} where {1}=@propertyValue", propertyName, new { propertyValue = propertyValue }));
            foreach (var entity in entitys)
            {
                Delete<T>(entity);
            }
            if (!isTrans)
            {
                return Commit();
            }
            return 0;
        }

        /// <summary>
        ///更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update<T>(T entity) where T : class
        {
            return ExecuteBySql(DatabaseCommon.UpdateSql<T>(entity).ToString(), DatabaseCommon.GetParameter<T>(entity));
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Update<T>(IEnumerable<T> entities) where T : class
        {
            if (DbTransaction == null)
            {
                BeginTrans();
                foreach (var item in entities)
                {
                    Update<T>(item);
                }
                return Commit();
            }
            else
            {
                foreach (var item in entities)
                {
                    Update<T>(item);
                }
                return 0;
            }
        }

        /// <summary>
        /// 根据条件以及指定属性名称更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelModifyProps"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public int Update<T>(T modelModifyProps, Expression<Func<T, bool>> condition) where T : class, new()
        {
            throw new NotImplementedException();
        }

        #endregion 对象实体 添加、修改、删除Dapper下未作实现，直接调用执行SQl方法

        #region 对象实体 查询

        /// <summary>
        /// 根据主键查询一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public T FindEntity<T>(object keyValue) where T : class, new()
        {
            string tableName = EntityAttributeHelper.GetEntityTable<T>();
            using (var dbConnection = Connection)
            {
                var data = dbConnection.Query<T>($"select * from {tableName} where key=@key", new { key = keyValue });
                return data.FirstOrDefault();
            }
        }

        /// <summary>
        /// 根据条件查询一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public T FindEntity<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            using (var dbConnection = Connection)
            {
                var data = dbConnection.Query<T>(new SQLinq<T>().Where(condition));
                return data.FirstOrDefault();
            }
        }

        /// <summary>
        /// 获取IQueryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> IQueryable<T>() where T : class, new()
        {
            using (var dbConnection = Connection)
            {
                return (IQueryable<T>)dbConnection.Query<T>(new SQLinq<T>());
            }
        }

        /// <summary>
        /// 获取IQueryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IQueryable<T> IQueryable<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            using (var dbConnection = Connection)
            {
                return (IQueryable<T>)dbConnection.Query<T>(new SQLinq<T>().Where(condition));
            }
        }

        /// <summary>
        /// 得到一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>() where T : class, new()
        {
            using (var dbConnection = Connection)
            {
                return dbConnection.Query<T>(new SQLinq<T>()).ToList();
            }
        }

        /// <summary>
        /// 根据条件查询出一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            using (var dbConnection = Connection)
            {
                SQLinq<T> where = new SQLinq<T>().Where(condition);

                return dbConnection.Query<T>(where).ToList();
            }
        }

        /// <summary>
        /// 执行sql语句，得到一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string strSql) where T : class, new()
        {
            return FindList<T>(strSql, null);
        }

        /// <summary>
        /// 执行sql语句，得到一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strSql"></param>
        /// <param name="dbParameter"></param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string strSql, DbParameter[] dbParameter) where T : class, new()
        {
            using (var dbConnection = Connection)
            {
                return dbConnection.Query<T>(strSql, dbParameter);
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orderField"></param>
        /// <param name="isAsc"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class, new()
        {
            using (var dbConnection = Connection)
            {
                string[] orderIds = orderField.Split(',');
                var dataLinq = new SQLinq<T>();
                foreach (string item in orderIds)
                {
                    var parameter = Expression.Parameter(typeof(T), "t");
                    var property = typeof(T).GetProperty(item);
                    var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                    Expression<Func<T, object>> orderBy = t => propertyAccess;
                    dataLinq.OrderByExpressions.Add(new SQLinq<T>.OrderByExpression { Ascending = isAsc, Expression = orderBy });
                }
                var dataQuery = dbConnection.Query<T>(dataLinq);
                total = dataQuery.Count();
                var data = dataQuery.Skip<T>(pageSize * (pageIndex - 1)).Take<T>(pageSize).AsQueryable();
                return data.ToList();
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <param name="orderField"></param>
        /// <param name="isAsc"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class, new()
        {
            using (var dbConnection = Connection)
            {
                string[] fields = orderField.Split(',');
                var dataLinq = new SQLinq<T>().Where(condition);
                foreach (string item in fields)
                {
                    var parameter = Expression.Parameter(typeof(T), "t");
                    var property = typeof(T).GetProperty(item);
                    var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                    Expression<Func<T, object>> orderBy = t => propertyAccess;
                    dataLinq.OrderByExpressions.Add(new SQLinq<T>.OrderByExpression { Ascending = isAsc, Expression = orderBy });
                }
                var dataQuery = dbConnection.Query<T>(dataLinq);
                total = dataQuery.Count();
                var data = dataQuery.Skip<T>(pageSize * (pageIndex - 1)).Take<T>(pageSize).AsQueryable();
                return data.ToList();
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strSql"></param>
        /// <param name="orderField"></param>
        /// <param name="isAsc"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string strSql, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class, new()
        {
            return FindList<T>(strSql, null, orderField, isAsc, pageSize, pageIndex, out total);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strSql"></param>
        /// <param name="dbParameter"></param>
        /// <param name="orderField"></param>
        /// <param name="isAsc"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string strSql, DbParameter[] dbParameter, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class, new()
        {
            using (var dbConnection = Connection)
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

                total = SqlHelper.ExecuteNonQuery(dbConnection as SqlConnection, CommandType.Text, "Select Count(1) From (" + strSql + ") As t", DatabaseCommon.DbParameterToSqlParameter(dbParameter));

                SqlDataReader dataReader = SqlHelper.ExecuteReader(dbConnection as SqlConnection, CommandType.Text, sb.ToString(), DatabaseCommon.DbParameterToSqlParameter(dbParameter));

                return ConvertExtension.IDataReaderToList<T>(dataReader);
            }
        }

        #endregion 对象实体 查询

        #region 数据源查询

        /// <summary>
        /// 执行sql语句，获取一个DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataTable FindTable(string strSql)
        {
            return FindTable(strSql, null);
        }

        /// <summary>
        /// 执行sql语句，获取一个DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="dbParameter"></param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, DbParameter[] dbParameter)
        {
            using (var dbConnection = Connection)
            {
                var dataReader = SqlHelper.ExecuteReader(dbConnection as SqlConnection, CommandType.Text, strSql, DatabaseCommon.DbParameterToSqlParameter(dbParameter));

                return ConvertExtension.IDataReaderToDataTable(dataReader);
            }
        }

        /// <summary>
        /// 分页查询，返回一个DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="orderField"></param>
        /// <param name="isAsc"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, string orderField, bool isAsc, int pageSize, int pageIndex, out int total)
        {
            return FindTable(strSql, null, orderField, isAsc, pageSize, pageIndex, out total);
        }

        /// <summary>
        /// 分页查询，返回一个DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="dbParameter"></param>
        /// <param name="orderField"></param>
        /// <param name="isAsc"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, DbParameter[] dbParameter, string orderField, bool isAsc, int pageSize, int pageIndex, out int total)
        {
            using (var dbConnection = Connection)
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

                total = SqlHelper.ExecuteNonQuery(dbConnection as SqlConnection, CommandType.Text, "Select Count(1) From (" + strSql + ") As t", DatabaseCommon.DbParameterToSqlParameter(dbParameter));

                SqlDataReader dataReader = SqlHelper.ExecuteReader(dbConnection as SqlConnection, CommandType.Text, sb.ToString(), DatabaseCommon.DbParameterToSqlParameter(dbParameter));

                DataTable resultTable = ConvertExtension.IDataReaderToDataTable(dataReader);
                resultTable.Columns.Remove("rowNum");
                return resultTable;
            }
        }

        /// <summary>
        /// 根据sql语句，得到一个对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public object FindObject(string strSql)
        {
            return FindObject(strSql, null);
        }

        /// <summary>
        /// 根据sql语句，得到一个对象
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="dbParameter"></param>
        /// <returns></returns>
        public object FindObject(string strSql, DbParameter[] dbParameter)
        {
            using (var dbConnection = Connection)
            {
                return SqlHelper.ExecuteReader(dbConnection as SqlConnection, CommandType.Text, strSql, DatabaseCommon.DbParameterToSqlParameter(dbParameter)); //new DbHelper(dbConnection).ExecuteScalar(CommandType.Text, strSql, dbParameter);
            }
        }

        #endregion 数据源查询

        #region 日志

        /// <summary>
        /// 利用Action委托封装Log4net对日志的处理
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="desc">描述</param>
        /// <param name="errorHandel">异常处理方式</param>
        /// <param name="tryHandel">调试代码</param>
        /// <param name="catchHandel">异常处理方式</param>
        /// <param name="finallHandel">最终处理方式</param>
        public void Logger(Type type, string desc, Action tryHandel, Action<Exception> catchHandel = null, Action finallHandel = null, ErrorHandel errorHandel = ErrorHandel.Throw)
        {
            LogHelper.Logger(type, desc, ErrorHandel.Throw, tryHandel, catchHandel, finallHandel);
        }

        #endregion 日志
    }
}