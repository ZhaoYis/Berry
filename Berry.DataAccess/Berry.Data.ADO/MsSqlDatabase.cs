using Berry.Code;
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
using System.Text;
using System.Text.RegularExpressions;
using Berry.Data.Extension;
using Berry.Extension;
using Berry.Util.LambdaToSQL;

namespace Berry.Data.ADO
{
    /// <summary>
    /// 操作SqlServer数据库，原生Ado.Net实现
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
            ConnectionString = ConfigHelper.GetConnectionString(connString);
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
        private SqlConnection Connection
        {
            get
            {
                SqlConnection dbconnection = new SqlConnection(ConnectionString);
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
        private SqlTransaction SqlTransaction { get; set; }

        #endregion 属性

        #region 事务提交

        /// <summary>
        /// 事务开始
        /// </summary>
        /// <returns></returns>
        public IDatabase BeginTrans()
        {
            SqlConnection conn = Connection;
            this.SqlTransaction = conn.BeginTransaction();
            return this;
        }

        /// <summary>
        /// 提交当前操作的结果
        /// </summary>
        public int Commit()
        {
            try
            {
                if (SqlTransaction != null)
                {
                    SqlTransaction.Commit();
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
                if (SqlTransaction == null)
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
            this.SqlTransaction.Rollback();
            this.SqlTransaction.Dispose();
            this.Close();
        }

        /// <summary>
        /// 关闭连接 内存回收
        /// </summary>
        public void Close()
        {
            SqlConnection dbConnection = SqlTransaction.Connection;
            if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
            {
                dbConnection.Close();
            }
        }

        #endregion 事务提交

        #region 执行 SQL 语句

        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        public int ExecuteBySql(string strSql)
        {
            using (var connection = Connection)
            {
                return SqlHelper.ExecuteNonQuery(connection, CommandType.Text, strSql, null);
            }
        }

        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <returns></returns>
        public int ExecuteBySql(string strSql, params DbParameter[] dbParameter)
        {
            using (var connection = Connection)
            {
                return SqlHelper.ExecuteNonQuery(connection, CommandType.Text, strSql, DatabaseCommon.DbParameterToSqlParameter(dbParameter));
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <returns></returns>
        public int ExecuteByProc(string procName)
        {
            using (var connection = Connection)
            {
                return SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, procName);
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <returns></returns>
        public int ExecuteByProc(string procName, DbParameter[] dbParameter)
        {
            using (var connection = Connection)
            {
                return SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, procName, DatabaseCommon.DbParameterToSqlParameter(dbParameter));
            }
        }

        #endregion 执行 SQL 语句

        #region 对象实体 添加、修改、删除，直接调用执行SQl方法

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="entity">对象实体</param>
        /// <returns></returns>
        public int Insert<T>(T entity) where T : class
        {
            int res = 0;
            if (SqlTransaction == null)
            {
                string sql = DatabaseCommon.InsertSql<T>(entity).ToString();
                DbParameter[] parameter = DatabaseCommon.GetParameter<T>(entity);
                using (var connection = Connection)
                {
                    res = SqlHelper.ExecuteNonQuery(connection, CommandType.Text, sql, DatabaseCommon.DbParameterToSqlParameter(parameter));
                }
            }
            else
            {
                string sql = DatabaseCommon.InsertSql<T>(entity).ToString();
                DbParameter[] parameter = DatabaseCommon.GetParameter<T>(entity);

                res = SqlHelper.ExecuteNonQuery(SqlTransaction, CommandType.Text, sql, DatabaseCommon.DbParameterToSqlParameter(parameter));

                //res = this.Commit();
            }
            return res;
        }

        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entity">对象实体集合</param>
        /// <returns></returns>
        public int Insert<T>(List<T> entity) where T : class
        {
            int res = 0;
            if (SqlTransaction == null)
            {
                this.BeginTrans();
                foreach (T t in entity)
                {
                    this.Insert(t);
                }
                res = this.Commit();
            }
            else
            {
                foreach (T t in entity)
                {
                    this.Insert(t);
                }
            }
            return res;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public int Delete<T>() where T : class
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="entity">对象实体</param>
        /// <returns></returns>
        public int Delete<T>(T entity) where T : class
        {
            int res = 0;
            if (SqlTransaction == null)
            {
                string sql = DatabaseCommon.DeleteSql<T>(entity).ToString();
                DbParameter[] parameter = DatabaseCommon.GetParameter<T>(entity);
                using (var connection = Connection)
                {
                    res = SqlHelper.ExecuteNonQuery(connection, CommandType.Text, sql, DatabaseCommon.DbParameterToSqlParameter(parameter));
                }
            }
            else
            {
                string sql = DatabaseCommon.DeleteSql<T>(entity).ToString();
                DbParameter[] parameter = DatabaseCommon.GetParameter<T>(entity);

                res = SqlHelper.ExecuteNonQuery(SqlTransaction, CommandType.Text, sql, DatabaseCommon.DbParameterToSqlParameter(parameter));

                //return this.Commit();
            }
            return res;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entity">对象实体集合</param>
        /// <returns></returns>
        public int Delete<T>(List<T> entity) where T : class
        {
            if (SqlTransaction == null)
            {
                BeginTrans();
                foreach (var item in entity)
                {
                    Delete<T>(item);
                }
                return this.Commit();
            }
            else
            {
                foreach (var item in entity)
                {
                    Delete<T>(item);
                }
                return 1;
            }
        }

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public int Delete<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            int res = 0;
            LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
            lambda.AddAndWhere(condition);
            string where = lambda.Where();
            string sql = DatabaseCommon.DeleteSql<T>(where).ToString();

            if (SqlTransaction == null)
            {
                using (var conn = Connection)
                {
                    res = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql);
                }
            }
            else
            {
                res = SqlHelper.ExecuteNonQuery(SqlTransaction, CommandType.Text, sql);

                //res = this.Commit();
            }
            return res;
        }

        /// <summary>
        /// 根据主键删除一条数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public int Delete<T>(object keyValue) where T : class
        {
            int res = 0;

            string keyField = EntityAttributeHelper.GetEntityKey<T>();
            string where = $"Where [{keyField}] = ";
            if (keyValue is int)
            {
                where += $"{keyValue}";
            }
            else if (keyValue is string)
            {
                where += $"'{keyValue}'";
            }
            string sql = DatabaseCommon.DeleteSql<T>(where).ToString();

            if (SqlTransaction == null)
            {
                using (var conn = Connection)
                {
                    res = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql);
                }
            }
            else
            {
                res = SqlHelper.ExecuteNonQuery(SqlTransaction, CommandType.Text, sql);

                //res = this.Commit();
            }
            return res;
        }

        /// <summary>
        /// 根据主键批量删除一条数据
        /// </summary>
        /// <param name="keyValue">主键数组</param>
        /// <returns></returns>
        public int Delete<T>(object[] keyValue) where T : class
        {
            int res = 0;
            if (SqlTransaction == null)
            {
                this.BeginTrans();
                foreach (object t in keyValue)
                {
                    this.Delete<T>(t);
                }
                res = this.Commit();
            }
            else
            {
                foreach (object t in keyValue)
                {
                    this.Delete<T>(t);
                }
            }
            return res;
        }

        /// <summary>
        /// 根据属性删除
        /// </summary>
        /// <param name="propertyValue">属性值</param>
        /// <param name="propertyName">属性名</param>
        /// <returns></returns>
        public int Delete<T>(object propertyValue, string propertyName) where T : class
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public int Update<T>(T entity) where T : class
        {
            int res = 0;
            if (SqlTransaction == null)
            {
                string sql = DatabaseCommon.UpdateSql<T>(entity).ToString();
                DbParameter[] parameter = DatabaseCommon.GetParameter<T>(entity);

                using (var conn = Connection)
                {
                    res = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql, DatabaseCommon.DbParameterToSqlParameter(parameter));
                }
            }
            else
            {
                string sql = DatabaseCommon.UpdateSql<T>(entity).ToString();
                DbParameter[] parameter = DatabaseCommon.GetParameter<T>(entity);

                res = SqlHelper.ExecuteNonQuery(SqlTransaction, CommandType.Text, sql, DatabaseCommon.DbParameterToSqlParameter(parameter));
            }
            return res;
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entity">实体对象集合</param>
        /// <returns></returns>
        public int Update<T>(List<T> entity) where T : class
        {
            int res = 0;
            if (SqlTransaction == null)
            {
                this.BeginTrans();
                foreach (T t in entity)
                {
                    this.Update<T>(t);
                }
                res = this.Commit();
            }
            else
            {
                foreach (T t in entity)
                {
                    this.Update<T>(t);
                }
            }
            return res;
        }

        /// <summary>
        /// 根据条件更新
        /// </summary>
        /// <param name="modelModifyProps">要修改的列及修改后列的值集合</param>
        /// <param name="condition">修改的条件</param>
        /// <returns>返回受影响行数</returns>
        public int Update<T>(T modelModifyProps, Expression<Func<T, bool>> condition) where T : class, new()
        {
            int res = 0;
            LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
            lambda.AddAndWhere(condition);
            string where = lambda.Where();
            string sql = DatabaseCommon.UpdateSql<T>(modelModifyProps, "", where).ToString();

            if (SqlTransaction == null)
            {
                using (var conn = Connection)
                {
                    res = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql);
                }
            }
            else
            {
                res = SqlHelper.ExecuteNonQuery(SqlTransaction, CommandType.Text, sql);

                //res = this.Commit();
            }
            return res;
        }
        #endregion

        /// <summary>
        /// 根据主键获取一条数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public T FindEntity<T>(object keyValue) where T : class, new()
        {
            T res = default(T);

            string keyField = EntityAttributeHelper.GetEntityKey<T>();
            string where = $"Where [{keyField}] = ";
            if (keyValue is int)
            {
                where += $"{keyValue}";
            }
            else if (keyValue is string)
            {
                where += $"'{keyValue}'";
            }
            string sql = DatabaseCommon.SelectSql<T>(where).ToString();

            using (var conn = Connection)
            {
                DataSet data = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);
                if (data.Tables[0].IsExistRows())
                {
                    DataTable table = data.Tables[0];
                    res = table.DataTableToObject<T>();
                }
            }

            return res;
        }

        /// <summary>
        /// 根据条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public T FindEntity<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            T res = default(T);

            LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
            lambda.AddAndWhere(condition);
            string where = lambda.Where();
            string sql = DatabaseCommon.SelectSql<T>(where).ToString();

            if (SqlTransaction == null)
            {
                using (var conn = Connection)
                {
                    DataSet data = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);
                    if (data.Tables[0].IsExistRows())
                    {
                        DataTable table = data.Tables[0];
                        res = table.DataTableToObject<T>();
                    }
                }
            }
            else
            {
                DataSet data = SqlHelper.ExecuteDataset(SqlTransaction, CommandType.Text, sql);
                if (data.Tables[0].IsExistRows())
                {
                    DataTable table = data.Tables[0];
                    res = table.DataTableToObject<T>();
                }
            }
            return res;
        }

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> IQueryable<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据条件获取IQueryable对象
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IQueryable<T> IQueryable<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取一条数据，返回对象集合
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据条件获取一条数据，返回对象集合
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            List<T> res = new List<T>();

            LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
            lambda.AddAndWhere(condition);
            string where = lambda.Where();
            string sql = DatabaseCommon.SelectSql<T>(where).ToString();

            if (SqlTransaction == null)
            {
                using (var conn = Connection)
                {
                    DataSet data = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);
                    if (data.Tables[0].IsExistRows())
                    {
                        DataTable table = data.Tables[0];
                        res = table.DataTableToList<T>();
                    }
                }
            }
            else
            {
                DataSet data = SqlHelper.ExecuteDataset(SqlTransaction, CommandType.Text, sql);
                if (data.Tables[0].IsExistRows())
                {
                    DataTable table = data.Tables[0];
                    res = table.DataTableToList<T>();
                }
            }
            return res;
        }

        /// <summary>
        /// 根据T-SQL语句获取一条数据，返回对象集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string strSql) where T : class, new()
        {
            return this.FindList<T>(strSql, null);
        }

        /// <summary>
        /// 根据T-SQL语句获取一条数据，返回对象集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string strSql, DbParameter[] dbParameter) where T : class, new()
        {
            List<T> res = new List<T>();

            using (var conn = Connection)
            {
                DataSet data = SqlHelper.ExecuteDataset(conn, CommandType.Text, strSql, DatabaseCommon.DbParameterToSqlParameter(dbParameter));
                if (data.Tables.Count > 0 && data.Tables[0].IsExistRows())
                {
                    DataTable table = data.Tables[0];
                    res = table.DataTableToList<T>();
                }
            }
            return res;
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
            IQueryable<T> tempData = this.FindList<T>().AsQueryable();
            string[] order = !string.IsNullOrEmpty(orderField) ? orderField.Split(',') : new[] { "" };
            MethodCallExpression resultExp = null;
            try
            {
                if (!string.IsNullOrEmpty(order[0]))
                {
                    foreach (string item in order)
                    {
                        string orderPart = item;
                        orderPart = Regex.Replace(orderPart, @"\s+", " ");
                        string[] orderArry = orderPart.Split(' ');

                        bool sort = isAsc;
                        if (orderArry.Length == 2)
                        {
                            sort = orderArry[1].ToUpper() == "ASC" ? true : false;
                        }
                        var parameter = Expression.Parameter(typeof(T), "t");
                        var property = typeof(T).GetProperty(orderArry[0]);
                        if (property != null)
                        {
                            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                            var orderByExp = Expression.Lambda(propertyAccess, parameter);
                            resultExp = Expression.Call(typeof(Queryable), sort ? "OrderBy" : "OrderByDescending", new Type[] { typeof(T), property.PropertyType }, tempData.Expression, Expression.Quote(orderByExp));
                        }
                    }
                }
                if (resultExp != null)
                    tempData = tempData.Provider.CreateQuery<T>(resultExp);
                tempData = tempData.Skip<T>(pageSize * (pageIndex - 1)).Take<T>(pageSize).AsQueryable();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            total = tempData.Count();
            return tempData.ToList();
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
            MethodCallExpression resultExp = null;

            var tempData = this.FindList<T>(condition).AsQueryable();

            string[] order = orderField.Split(',');
            foreach (string item in order)
            {
                string orderPart = item;
                orderPart = Regex.Replace(orderPart, @"\s+", " ");
                string[] orderArry = orderPart.Split(' ');

                bool sort = isAsc;
                if (orderArry.Length == 2)
                {
                    sort = orderArry[1].ToUpper() == "ASC" ? true : false;
                }
                var parameter = Expression.Parameter(typeof(T), "t");
                var property = typeof(T).GetProperty(orderArry[0]);
                if (property != null)
                {
                    var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                    var orderByExp = Expression.Lambda(propertyAccess, parameter);
                    resultExp = Expression.Call(typeof(Queryable), sort ? "OrderBy" : "OrderByDescending", new Type[] { typeof(T), property.PropertyType }, tempData.Expression, Expression.Quote(orderByExp));
                }
            }
            if (resultExp != null)
                tempData = tempData.Provider.CreateQuery<T>(resultExp);
            total = tempData.Count();
            tempData = tempData.Skip<T>(pageSize * (pageIndex - 1)).Take<T>(pageSize).AsQueryable();

            return tempData.ToList();
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

                total = Convert.ToInt32(SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, "Select Count(1) From (" + strSql + ") As t", dbParameter));
                var dataReader = SqlHelper.ExecuteReader(dbConnection, CommandType.Text, sb.ToString(), dbParameter);

                return ConvertExtension.IDataReaderToList<T>(dataReader);
            }
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql)
        {
            return FindTable(strSql, null);
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, DbParameter[] dbParameter)
        {
            DataTable res = new DataTable();

            using (var conn = Connection)
            {
                DataSet data = SqlHelper.ExecuteDataset(conn, CommandType.Text, strSql, DatabaseCommon.DbParameterToSqlParameter(dbParameter));
                if (data.Tables[0].IsExistRows())
                {
                    res = data.Tables[0];
                }
            }
            return res;
        }

        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="total">总记录</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, string orderField, bool isAsc, int pageSize, int pageIndex, out int total)
        {
            return FindTable(strSql, null, orderField, isAsc, pageSize, pageIndex, out total);
        }

        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="total">总记录</param>
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

                total = Convert.ToInt32(SqlHelper.ExecuteScalar(dbConnection, CommandType.Text, "Select Count(1) From (" + strSql + ") As t", dbParameter));

                DataSet dataSet = SqlHelper.ExecuteDataset(dbConnection, CommandType.Text, sb.ToString(), DatabaseCommon.DbParameterToSqlParameter(dbParameter));
                DataTable table = new DataTable();
                if (dataSet.Tables.Count > 0)
                {
                    if (dataSet.Tables[0].IsExistRows())
                    {
                        table = dataSet.Tables[0];
                    }
                }
                return table;
            }
        }

        /// <summary>
        /// 返回Object
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        public object FindObject(string strSql)
        {
            using (var conn = Connection)
            {
                return SqlHelper.ExecuteScalar(conn, CommandType.Text, strSql);
            }
        }

        /// <summary>
        /// 返回Object
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <returns></returns>
        public object FindObject(string strSql, DbParameter[] dbParameter)
        {
            using (var conn = Connection)
            {
                return SqlHelper.ExecuteScalar(conn, CommandType.Text, strSql, DatabaseCommon.DbParameterToSqlParameter(dbParameter));
            }
        }

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