using Berry.Code;
using Berry.Data.Extension;
using Berry.Log;
using Berry.Util;
using Berry.Util.CustomException;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Berry.Util.LambdaToSQL;
using Dapper;

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
        /// 执行 SQL 语句
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int ExecuteBySql<T>(string strSql, T entity)
        {
            int res = 0;
            if (DbTransaction == null)
            {
                using (var connection = Connection)
                {
                    res = connection.Execute(strSql, entity);
                }
            }
            else
            {
                DbTransaction.Connection.Execute(strSql, entity, DbTransaction);
                res = 0;
            }
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
                    return connection.Execute(procName, null, null, 100, CommandType.StoredProcedure);
                }
            }
            else
            {
                DbTransaction.Connection.Execute(procName, null, DbTransaction, 100, CommandType.StoredProcedure);
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
                    return connection.Execute(procName, dbParameter, null, 100, CommandType.StoredProcedure);
                }
            }
            else
            {
                DbTransaction.Connection.Execute(procName, dbParameter, DbTransaction, 100, CommandType.StoredProcedure);
                return 0;
            }
        }

        /// <summary>
        /// 执行存储过程，返回集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName">存储过程名称</param>
        /// <returns></returns>
        public IEnumerable<T> ExecuteByProc<T>(string procName)
        {
            return ExecuteByProc<T>(procName, null);
        }

        /// <summary>
        /// 执行存储过程，返回集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName">存储过程名称</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <returns></returns>
        public IEnumerable<T> ExecuteByProc<T>(string procName, DbParameter[] dbParameter)
        {
            using (var dbConnection = Connection)
            {
                DynamicParameters parameters = new DynamicParameters();
                foreach (DbParameter par in dbParameter)
                {
                    parameters.Add(par.ParameterName, par.Value, par.DbType, par.Direction, par.Size);
                }

                return dbConnection.Query<T>(procName, parameters, null, true, 100, CommandType.StoredProcedure).ToList();
            }
        }

        #endregion 执行 SQL 语句

        #region 对象实体 添加、修改、删除

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
                res = DbTransaction.Connection.Execute(sql, parameter, DbTransaction);
            }
            return res;
        }

        /// <summary>
        /// 实体插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Insert<T>(List<T> entities) where T : class
        {
            int res = 0;
            if (entities.Count > 0)
            {
                string sql = DatabaseCommon.InsertSql<T>(entities.FirstOrDefault()).ToString();
                //DbParameter[] parameter = DatabaseCommon.GetParameter<T>(entity);
                using (var connection = Connection)
                {
                    res = connection.Execute(sql, entities);
                }
            }
            return res;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public int Delete<T>() where T : class
        {
            int res = 0;
            string tableName = EntityAttributeHelper.GetEntityTable<T>();
            string sql = DatabaseCommon.DeleteSql(tableName).ToString();
            res = ExecuteBySql(sql);

            return res;
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
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Delete<T>(List<T> entities) where T : class
        {
            int res = 0;
            if (entities.Count > 0)
            {
                string sql = DatabaseCommon.DeleteSql<T>(entities.FirstOrDefault()).ToString();
                using (var connection = Connection)
                {
                    res = connection.Execute(sql, entities);
                }
            }
            return res;
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public int Delete<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            int res = 0;

            LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
            lambda.AddAndWhere(condition);
            string where = lambda.Where();

            string sql = DatabaseCommon.DeleteSql<T>(where).ToString();
            using (var connection = Connection)
            {
                res = connection.Execute(sql);
            }
            return res;
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public int Delete<T>(object keyValue) where T : class
        {
            int res = 0;

            Type type = keyValue.GetType();
            string key = EntityAttributeHelper.GetEntityKey<T>();
            string where = " WHERE 1 = 1";
            if (type == typeof(int))
            {
                where = $" WHERE {key} = {keyValue}";
            }
            else
            {
                where = $" WHERE {key} = '{keyValue}'";
            }

            string sql = DatabaseCommon.DeleteSql<T>(where).ToString();
            using (var connection = Connection)
            {
                res = connection.Execute(sql);
            }
            return res;
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
            int res = 0;

            Type type = propertyValue.GetType();

            string where = " WHERE 1 = 1";
            if (type == typeof(int))
            {
                where = $" WHERE {propertyName} = {propertyValue}";
            }
            else
            {
                where = $" WHERE {propertyName} = '{propertyValue}'";
            }

            string sql = DatabaseCommon.DeleteSql<T>(where).ToString();
            using (var connection = Connection)
            {
                res = connection.Execute(sql);
            }
            return res;
        }

        /// <summary>
        ///更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update<T>(T entity) where T : class
        {
            string sql = DatabaseCommon.UpdateSql<T>(entity).ToString();
            //DbParameter[] parameter = DatabaseCommon.GetParameter<T>(entity);

            return ExecuteBySql(sql, entity);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Update<T>(List<T> entities) where T : class
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
            int res = 0;

            LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
            lambda.AddAndWhere(condition);
            string where = lambda.Where();

            string sql = DatabaseCommon.UpdateSql<T>(modelModifyProps, "", where).ToString();
            //DbParameter[] parameter = DatabaseCommon.GetParameter<T>(modelModifyProps);

            res = ExecuteBySql(sql, modelModifyProps);

            return res;
        }

        #endregion 对象实体 添加、修改、删除

        #region 对象实体 查询

        /// <summary>
        /// 根据主键查询一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public T FindEntity<T>(object keyValue) where T : class, new()
        {
            Type type = keyValue.GetType();
            string key = EntityAttributeHelper.GetEntityKey<T>();
            string where = " WHERE 1 = 1";
            if (type == typeof(int))
            {
                where = $" WHERE {key} = {keyValue}";
            }
            else
            {
                where = $" WHERE {key} = '{keyValue}'";
            }
            string sql = DatabaseCommon.SelectSql<T>(where).ToString();

            using (var dbConnection = Connection)
            {
                var data = dbConnection.Query<T>(sql);
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
            LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
            lambda.AddAndWhere(condition);
            string where = lambda.Where();
            string sql = DatabaseCommon.SelectSql<T>(where).ToString();

            using (var dbConnection = Connection)
            {
                var data = dbConnection.Query<T>(sql);
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
            string sql = DatabaseCommon.SelectSql<T>("").ToString();

            using (var dbConnection = Connection)
            {
                return (IQueryable<T>)dbConnection.Query<T>(sql);
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
            LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
            lambda.AddAndWhere(condition);
            string where = lambda.Where();
            string sql = DatabaseCommon.SelectSql<T>(where).ToString();

            using (var dbConnection = Connection)
            {
                return (IQueryable<T>)dbConnection.Query<T>(sql);
            }
        }

        /// <summary>
        /// 得到一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>() where T : class, new()
        {
            string sql = DatabaseCommon.SelectSql<T>("").ToString();
            using (var dbConnection = Connection)
            {
                return dbConnection.Query<T>(sql).ToList();
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
            LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
            lambda.AddAndWhere(condition);
            string where = lambda.Where();
            string sql = DatabaseCommon.SelectSql<T>(where).ToString();

            using (var dbConnection = Connection)
            {
                return dbConnection.Query<T>(sql).ToList();
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
                T t = dbParameter.DbParameterToObject<T>();
                return dbConnection.Query<T>(strSql, t);
            }
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orderField">排序字段，多个用英文逗号隔开，类似：Id Asc,Name Desc</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="total">总记录</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class, new()
        {
            StringBuilder sb = new StringBuilder();
            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
            int num = (pageIndex - 1) * pageSize;
            int num1 = (pageIndex) * pageSize;
            string orderBy = "";
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();
            string strSql = DatabaseCommon.SelectSql(table).ToString();

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

            using (var dbConnection = Connection)
            {
                string selectCountSql = "Select Count(*) From " + table + " WHERE 1 = 1";
                total = (int)dbConnection.ExecuteScalar(selectCountSql);

                IEnumerable<T> data = dbConnection.Query<T>(sb.ToString()).ToList();
                return data;
            }
        }

        /// <summary>
        /// 根据条件获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">条件</param>
        /// <param name="orderField">排序字段，多个用英文逗号隔开，类似：Id Asc,Name Desc</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="total">总记录</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class, new()
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

            using (var dbConnection = Connection)
            {
                string selectCountSql = "Select Count(*) From " + table + " WHERE 1 = 1";
                total = (int)dbConnection.ExecuteScalar(selectCountSql);

                IEnumerable<T> data = dbConnection.Query<T>(sb.ToString()).ToList();
                return data;
            }
        }

        /// <summary>
        /// 根据T-SQL获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="orderField">排序字段，多个用英文逗号隔开，类似：Id Asc,Name Desc</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="total">总记录</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string strSql, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class, new()
        {
            return FindList<T>(strSql, null, orderField, isAsc, pageSize, pageIndex, out total);
        }

        /// <summary>
        /// 根据T-SQL获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <param name="orderField">排序字段，多个用英文逗号隔开，类似：Id Asc,Name Desc</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="total">总记录</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string strSql, DbParameter[] dbParameter, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class, new()
        {
            StringBuilder sb = new StringBuilder();
            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
            int num = (pageIndex - 1) * pageSize;
            int num1 = (pageIndex) * pageSize;
            string orderBy = "";

            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();

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

            using (var dbConnection = Connection)
            {
                string selectCountSql = "Select Count(*) From " + table + " WHERE 1 = 1";
                total = (int)dbConnection.ExecuteScalar(selectCountSql);

                T t = dbParameter.DbParameterToObject<T>();
                IEnumerable<T> data = dbConnection.Query<T>(sb.ToString(), t).ToList();

                return data;
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

            Dictionary<string, object> dict = new Dictionary<string, object>();
            if (dbParameter.Length > 0)
            {
                foreach (DbParameter par in dbParameter)
                {
                    var name = par.ParameterName.Replace(DbParameters.CreateDbParmCharacter(), "");
                    var value = par.Value;
                    dict.Add(name, value);
                }
            }

            using (var dbConnection = Connection)
            {
                string selectCountSql = "Select Count(*) From (" + strSql + ") AS t";
                total = (int)dbConnection.ExecuteScalar(selectCountSql, dict);

                DataTable table = new DataTable("MyTable");
                IDataReader reader = dbConnection.ExecuteReader(sb.ToString(), dict);
                table.Load(reader);

                return table;
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
                return SqlHelper.ExecuteReader(dbConnection as SqlConnection, CommandType.Text, strSql, DatabaseCommon.DbParameterToSqlParameter(dbParameter));
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