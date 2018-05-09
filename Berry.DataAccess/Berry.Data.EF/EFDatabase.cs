using Berry.Code;
using Berry.Data.DbContext;
using Berry.Data.EF.Extension;
using Berry.Data.Extension;
using Berry.IOC;
using Berry.Log;
using Berry.Util;
using Berry.Util.CustomException;
using Microsoft.Practices.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Berry.Data.EF
{
    /// <summary>
    /// EF操作数据库
    /// </summary>
    public class EFDatabase : IDatabase
    {
        #region 构造函数

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connString">链接字符串</param>
        /// <param name="dbType">数据库类型</param>
        public EFDatabase(string connString, string dbType)
        {
            try
            {
                if (dbType == "")
                {
                    Dbcontext = (System.Data.Entity.DbContext)UnityIocHelper.DbInstance.GetService<IDbContext>(new ParameterOverride("connString", connString));
                }
                else
                {
                    Dbcontext = (System.Data.Entity.DbContext)UnityIocHelper.DbInstance.GetService<IDbContext>(dbType, new ParameterOverride("connString", connString));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #endregion 构造函数

        #region 属性

        /// <summary>
        /// 获取 当前使用的数据访问上下文对象
        /// </summary>
        public System.Data.Entity.DbContext Dbcontext { get; set; }

        /// <summary>
        /// 事务对象
        /// </summary>
        public DbTransaction DbTransaction { get; set; }

        #endregion 属性

        #region 事物提交

        /// <summary>
        /// 事务开始
        /// </summary>
        /// <returns></returns>
        public IDatabase BeginTrans()
        {
            DbConnection dbConnection = ((IObjectContextAdapter)Dbcontext).ObjectContext.Connection;
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }
            DbTransaction = dbConnection.BeginTransaction();
            return this;
        }

        /// <summary>
        /// 提交当前操作的结果
        /// </summary>
        public int Commit()
        {
            try
            {
                int returnValue = Dbcontext.SaveChanges();
                if (DbTransaction != null)
                {
                    DbTransaction.Commit();
                    this.Close();
                }
                return returnValue;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException is SqlException)
                {
                    SqlException sqlEx = ex.InnerException.InnerException as SqlException;
                    string msg = ExceptionMessageHelper.GetSqlExceptionMessage(sqlEx.Number);

                    throw DataAccessException.ThrowDataAccessException(sqlEx, msg);
                }

                throw;
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
            Dbcontext.Dispose();
        }

        #endregion 事物提交

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
                return Dbcontext.Database.ExecuteSqlCommand(strSql);
            }
            else
            {
                Dbcontext.Database.ExecuteSqlCommand(strSql);
                return DbTransaction == null ? this.Commit() : 0;
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
            if (DbTransaction == null)
            {
                return Dbcontext.Database.ExecuteSqlCommand(strSql, dbParameter);
            }
            else
            {
                Dbcontext.Database.ExecuteSqlCommand(strSql, dbParameter);
                return DbTransaction == null ? this.Commit() : 0;
            }
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
                return Dbcontext.Database.ExecuteSqlCommand(DbContextExtensions.BuilderProc(procName));
            }
            else
            {
                Dbcontext.Database.ExecuteSqlCommand(DbContextExtensions.BuilderProc(procName));
                return DbTransaction == null ? this.Commit() : 0;
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
                return Dbcontext.Database.ExecuteSqlCommand(DbContextExtensions.BuilderProc(procName, dbParameter), dbParameter);
            }
            else
            {
                Dbcontext.Database.ExecuteSqlCommand(DbContextExtensions.BuilderProc(procName, dbParameter), dbParameter);
                return DbTransaction == null ? this.Commit() : 0;
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
            Dbcontext.Entry<T>(entity).State = EntityState.Added;

            return DbTransaction == null ? this.Commit() : 0;
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Insert<T>(IEnumerable<T> entities) where T : class
        {
            foreach (var entity in entities)
            {
                Dbcontext.Entry<T>(entity).State = EntityState.Added;
            }
            return DbTransaction == null ? this.Commit() : 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public int Delete<T>() where T : class
        {
            EntitySet entitySet = DbContextExtensions.GetEntitySet<T>(Dbcontext);
            if (entitySet != null)
            {
                string tableName = entitySet.MetadataProperties.Contains("Table") && entitySet.MetadataProperties["Table"].Value != null
                               ? entitySet.MetadataProperties["Table"].Value.ToString()
                               : entitySet.Name;
                return this.ExecuteBySql(DbContextExtensions.DeleteSql(tableName));
            }
            return -1;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Delete<T>(T entity) where T : class
        {
            Dbcontext.Set<T>().Attach(entity);
            Dbcontext.Set<T>().Remove(entity);
            return DbTransaction == null ? this.Commit() : 0;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Delete<T>(IEnumerable<T> entities) where T : class
        {
            foreach (var entity in entities)
            {
                Dbcontext.Set<T>().Attach(entity);
                Dbcontext.Set<T>().Remove(entity);
            }
            return DbTransaction == null ? this.Commit() : 0;
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public int Delete<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            IEnumerable<T> entities = Dbcontext.Set<T>().Where(condition).ToList();
            return entities.Count() > 0 ? Delete(entities) : 0;
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public int Delete<T>(object keyValue) where T : class
        {
            EntitySet entitySet = DbContextExtensions.GetEntitySet<T>(Dbcontext);
            if (entitySet != null)
            {
                string tableName = entitySet.MetadataProperties.Contains("Table") && entitySet.MetadataProperties["Table"].Value != null
                               ? entitySet.MetadataProperties["Table"].Value.ToString()
                               : entitySet.Name;
                string keyFlied = entitySet.ElementType.KeyMembers[0].Name;
                return this.ExecuteBySql(DbContextExtensions.DeleteSql(tableName, keyFlied, keyValue));
            }
            return -1;
        }

        /// <summary>
        /// 根据主键批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public int Delete<T>(object[] keyValue) where T : class
        {
            EntitySet entitySet = DbContextExtensions.GetEntitySet<T>(Dbcontext);
            if (entitySet != null)
            {
                string tableName = entitySet.MetadataProperties.Contains("Table") && entitySet.MetadataProperties["Table"].Value != null
                               ? entitySet.MetadataProperties["Table"].Value.ToString()
                               : entitySet.Name;
                string keyFlied = entitySet.ElementType.KeyMembers[0].Name;
                return this.ExecuteBySql(DbContextExtensions.DeleteSql(tableName, keyFlied, keyValue));
            }
            return -1;
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
            EntitySet entitySet = DbContextExtensions.GetEntitySet<T>(Dbcontext);
            if (entitySet != null)
            {
                string tableName = entitySet.MetadataProperties.Contains("Table") && entitySet.MetadataProperties["Table"].Value != null
                               ? entitySet.MetadataProperties["Table"].Value.ToString()
                               : entitySet.Name;
                return this.ExecuteBySql(DbContextExtensions.DeleteSql(tableName, propertyName, propertyValue));
            }
            return -1;
        }

        /// <summary>
        ///更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update<T>(T entity) where T : class
        {
            Dbcontext.Set<T>().Attach(entity);
            Hashtable props = ConvertExtension.GetPropertyInfo<T>(entity);
            foreach (string item in props.Keys)
            {
                object value = Dbcontext.Entry(entity).Property(item).CurrentValue;
                if (value != null)
                {
                    if (value.ToString() == "&nbsp;")
                        Dbcontext.Entry(entity).Property(item).CurrentValue = null;
                    Dbcontext.Entry(entity).Property(item).IsModified = true;
                }
            }
            return DbTransaction == null ? this.Commit() : 0;
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Update<T>(IEnumerable<T> entities) where T : class
        {
            foreach (var entity in entities)
            {
                this.Update(entity);
            }
            return DbTransaction == null ? this.Commit() : 0;
        }

        /// <summary>
        /// 根据条件更新
        /// </summary>
        /// <param name="modelModifyProps">要修改的列及修改后列的值集合</param>
        /// <param name="where">修改的条件</param>
        /// <returns>返回受影响行数</returns>
        public int Update<T>(T modelModifyProps, Expression<Func<T, bool>> where) where T : class, new()
        {
            int req = -1;

            //获取符合条件的数据
            List<T> list = Dbcontext.Set<T>().Where(where).ToList();

            Type t = typeof(T);
            //得到实体类属性值
            List<PropertyInfo> propertyInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            //实体-属性集合字典
            Dictionary<string, PropertyInfo> dictionaryProps = new Dictionary<string, PropertyInfo>();

            //获取实体字段不为空的字段名
            string[] paramModifyStrings = new string[propertyInfos.Count];
            for (int i = 0; i < propertyInfos.Count; i++)
            {
                if (propertyInfos[i].GetValue(modelModifyProps, null) != null)
                {
                    paramModifyStrings[i] = propertyInfos[i].Name;
                }
            }

            //将实体属性重要修改属性，添加到集合中 Key-属性名 Value-属性对象
            propertyInfos.ForEach(p =>
            {
                if (paramModifyStrings.Contains(p.Name))
                {
                    dictionaryProps.Add(p.Name, p);
                }
            });

            //循环要修改的属性名
            foreach (string paramModifyString in paramModifyStrings)
            {
                //判断要修改的属性名是否在实体类的属性集合中
                if (!string.IsNullOrWhiteSpace(paramModifyString) && dictionaryProps.ContainsKey(paramModifyString))
                {
                    //如果存在则去除要修改属性对象
                    PropertyInfo info = dictionaryProps[paramModifyString];
                    //取出要修改的值
                    object newValue = info.GetValue(modelModifyProps, null);
                    //批量设置要修改的对象的属性
                    foreach (T n in list)
                    {
                        //为要修改的对象的要修改的属性设置新的值
                        info.SetValue(n, newValue, null);
                    }
                }
            }

            //req = dbcontext.SaveChanges();
            req = DbTransaction == null ? this.Commit() : 0;

            return req;
        }

        #endregion 对象实体 添加、修改、删除

        #region 对象实体 查询

        /// <summary>
        /// 根据主键查询一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public T FindEntity<T>(object keyValue) where T : class
        {
            return Dbcontext.Set<T>().Find(keyValue);
        }

        /// <summary>
        /// 根据条件查询一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public T FindEntity<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return Dbcontext.Set<T>().Where(condition).FirstOrDefault();
        }

        /// <summary>
        /// 获取IQueryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> IQueryable<T>() where T : class, new()
        {
            return Dbcontext.Set<T>();
        }

        /// <summary>
        /// 获取IQueryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IQueryable<T> IQueryable<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return Dbcontext.Set<T>().Where(condition);
        }

        /// <summary>
        /// 得到一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>() where T : class, new()
        {
            return Dbcontext.Set<T>().ToList();
        }

        /// <summary>
        /// 根据选择器查询出一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(Func<T, object> keySelector) where T : class, new()
        {
            return Dbcontext.Set<T>().OrderBy(keySelector).ToList();
        }

        /// <summary>
        /// 根据条件查询出一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return Dbcontext.Set<T>().Where(condition).ToList();
        }

        /// <summary>
        /// 执行sql语句，得到一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string strSql) where T : class
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
        public IEnumerable<T> FindList<T>(string strSql, DbParameter[] dbParameter) where T : class
        {
            using (var dbConnection = Dbcontext.Database.Connection)
            {
                var IDataReader = new DbHelper(dbConnection).ExecuteReader(CommandType.Text, strSql, dbParameter);
                return ConvertExtension.IDataReaderToList<T>(IDataReader);
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
            string[] _order = !string.IsNullOrEmpty(orderField) ? orderField.Split(',') : new[] { "" };
            MethodCallExpression resultExp = null;
            var tempData = Dbcontext.Set<T>().AsQueryable();
            try
            {
                if (!string.IsNullOrEmpty(_order[0]))
                {
                    foreach (string item in _order)
                    {
                        string _orderPart = item;
                        _orderPart = Regex.Replace(_orderPart, @"\s+", " ");
                        string[] _orderArry = _orderPart.Split(' ');
                        string _orderField = _orderArry[0];
                        bool sort = isAsc;
                        if (_orderArry.Length == 2)
                        {
                            isAsc = _orderArry[1].ToUpper() == "ASC" ? true : false;
                        }
                        var parameter = Expression.Parameter(typeof(T), "t");
                        var property = typeof(T).GetProperty(_orderField);
                        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                        var orderByExp = Expression.Lambda(propertyAccess, parameter);
                        resultExp = Expression.Call(typeof(Queryable), isAsc ? "OrderBy" : "OrderByDescending", new Type[] { typeof(T), property.PropertyType }, tempData.Expression, Expression.Quote(orderByExp));
                    }
                }
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
            MethodCallExpression resultExp = null;

            var tempData = Dbcontext.Set<T>().Where(condition);
            string[] _order = orderField.Split(',');
            foreach (string item in _order)
            {
                string _orderPart = item;
                _orderPart = Regex.Replace(_orderPart, @"\s+", " ");
                string[] _orderArry = _orderPart.Split(' ');
                string _orderField = _orderArry[0];
                bool sort = isAsc;
                if (_orderArry.Length == 2)
                {
                    isAsc = _orderArry[1].ToUpper() == "ASC" ? true : false;
                }
                var parameter = Expression.Parameter(typeof(T), "t");
                var property = typeof(T).GetProperty(_orderField);
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExp = Expression.Lambda(propertyAccess, parameter);
                resultExp = Expression.Call(typeof(Queryable), isAsc ? "OrderBy" : "OrderByDescending", new Type[] { typeof(T), property.PropertyType }, tempData.Expression, Expression.Quote(orderByExp));
            }
            tempData = tempData.Provider.CreateQuery<T>(resultExp);
            total = tempData.Count();
            tempData = tempData.Skip<T>(pageSize * (pageIndex - 1)).Take<T>(pageSize).AsQueryable();
            return tempData.ToList();
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
        public IEnumerable<T> FindList<T>(string strSql, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class
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
        public IEnumerable<T> FindList<T>(string strSql, DbParameter[] dbParameter, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class
        {
            using (var dbConnection = Dbcontext.Database.Connection)
            {
                StringBuilder sb = new StringBuilder();
                if (pageIndex == 0)
                {
                    pageIndex = 1;
                }
                int num = (pageIndex - 1) * pageSize;
                int num1 = (pageIndex) * pageSize;
                string OrderBy = "";

                if (!string.IsNullOrEmpty(orderField))
                {
                    if (orderField.ToUpper().IndexOf("ASC", StringComparison.Ordinal) + orderField.ToUpper().IndexOf("DESC", StringComparison.Ordinal) > 0)
                    {
                        OrderBy = "Order By " + orderField;
                    }
                    else
                    {
                        OrderBy = "Order By " + orderField + " " + (isAsc ? "ASC" : "DESC");
                    }
                }
                else
                {
                    OrderBy = "order by (select 0)";
                }
                sb.Append("Select * From (Select ROW_NUMBER() Over (" + OrderBy + ")");
                sb.Append(" As rowNum, * From (" + strSql + ") As T ) As N Where rowNum > " + num + " And rowNum <= " + num1 + "");
                total = Convert.ToInt32(new DbHelper(dbConnection).ExecuteScalar(CommandType.Text, "Select Count(1) From (" + strSql + ") As t", dbParameter));
                var IDataReader = new DbHelper(dbConnection).ExecuteReader(CommandType.Text, sb.ToString(), dbParameter);
                return ConvertExtension.IDataReaderToList<T>(IDataReader);
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
            using (var dbConnection = Dbcontext.Database.Connection)
            {
                var IDataReader = new DbHelper(dbConnection).ExecuteReader(CommandType.Text, strSql, dbParameter);
                return ConvertExtension.IDataReaderToDataTable(IDataReader);
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
            using (var dbConnection = Dbcontext.Database.Connection)
            {
                StringBuilder sb = new StringBuilder();
                if (pageIndex == 0)
                {
                    pageIndex = 1;
                }
                int num = (pageIndex - 1) * pageSize;
                int num1 = (pageIndex) * pageSize;
                string OrderBy = "";

                if (!string.IsNullOrEmpty(orderField))
                {
                    if (orderField.ToUpper().IndexOf("ASC", StringComparison.Ordinal) + orderField.ToUpper().IndexOf("DESC", StringComparison.Ordinal) > 0)
                    {
                        OrderBy = "Order By " + orderField;
                    }
                    else
                    {
                        OrderBy = "Order By " + orderField + " " + (isAsc ? "ASC" : "DESC");
                    }
                }
                else
                {
                    OrderBy = "order by (select 0)";
                }
                sb.Append("Select * From (Select ROW_NUMBER() Over (" + OrderBy + ")");
                sb.Append(" As rowNum, * From (" + strSql + ") As T ) As N Where rowNum > " + num + " And rowNum <= " + num1 + "");
                total = Convert.ToInt32(new DbHelper(dbConnection).ExecuteScalar(CommandType.Text, "Select Count(1) From (" + strSql + ") As t", dbParameter));
                var IDataReader = new DbHelper(dbConnection).ExecuteReader(CommandType.Text, sb.ToString(), dbParameter);
                DataTable resultTable = ConvertExtension.IDataReaderToDataTable(IDataReader);
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
            using (var dbConnection = Dbcontext.Database.Connection)
            {
                return new DbHelper(dbConnection).ExecuteScalar(CommandType.Text, strSql, dbParameter);
            }
        }

        public IDataReader FindDataReader(string strSql, CommandType commandType, DbParameter[] dbParameter)
        {
            using (var dbConnection = Dbcontext.Database.Connection)
            {
                return new DbHelper(dbConnection).ExecuteDataReader(commandType, strSql, dbParameter);
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