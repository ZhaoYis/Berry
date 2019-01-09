using Berry.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace Berry.Data
{
    /// <summary>
    /// 操作数据库接口
    /// </summary>
    public interface IDatabase : ILogger
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// 获取基础数据库连接
        /// </summary>
        /// <returns></returns>
        IDbConnection GetBaseConnection();

        /// <summary>
        /// 执行 SQL 语句
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="strSql"></param>
        /// <returns></returns>
        int ExecuteBySql(IDbConnection connection, string strSql);

        /// <summary>
        /// 执行 SQL 语句
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        int ExecuteBySql(IDbConnection connection, string strSql, object parameters, IDbTransaction transaction = null, int? timeout = 0);

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
        IEnumerable<TR> ExecuteBySqlAndReturnList<TR>(IDbConnection connection, string strSql, object parameters, IDbTransaction transaction = null, int? timeout = 0);

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
        TR ExecuteBySqlAndReturnObject<TR>(IDbConnection connection, string strSql, object parameters, IDbTransaction transaction = null, int? timeout = 0);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="procName"></param>
        /// <returns></returns>
        int ExecuteByProc(IDbConnection connection, string procName);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="procName"></param>
        /// <param name="parameters"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        int ExecuteByProc(IDbConnection connection, string procName, object parameters, IDbTransaction transaction = null, int? timeout = 0);

        /// <summary>
        /// 执行存储过程，返回集合
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="connection"></param>
        /// <param name="procName"></param>
        /// <returns></returns>
        IEnumerable<TR> ExecuteByProc<TR>(IDbConnection connection, string procName);

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
        IEnumerable<TR> ExecuteByProc<TR>(IDbConnection connection, string procName, object parameters, IDbTransaction transaction = null, int? timeout = 0);

        /// <summary>
        /// 实体插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        int Insert<T>(IDbConnection connection, T entity, IDbTransaction transaction = null, int? timeout = 0) where T : class;

        /// <summary>
        /// 实体批量插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="entities"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        int Insert<T>(IDbConnection connection, List<T> entities, IDbTransaction transaction = null, int? timeout = 0) where T : class;

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        int Delete<T>(IDbConnection connection, IDbTransaction transaction = null, int? timeout = 0) where T : class;

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        int Delete<T>(IDbConnection connection, T entity, IDbTransaction transaction = null, int? timeout = 0) where T : class;

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="entities"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        int Delete<T>(IDbConnection connection, List<T> entities, IDbTransaction transaction = null, int? timeout = 0) where T : class;

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="condition"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        int Delete<T>(IDbConnection connection, Expression<Func<T, bool>> condition, IDbTransaction transaction = null, int? timeout = 0) where T : class;

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="keyValue"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        int Delete<T>(IDbConnection connection, object keyValue, IDbTransaction transaction = null, int? timeout = 0) where T : class;

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        int Update<T>(IDbConnection connection, T entity, IDbTransaction transaction = null, int? timeout = 0) where T : class;

        /// <summary>
        /// 根据条件以及指定属性名称更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="modelModifyProps"></param>
        /// <param name="condition"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        int Update<T>(IDbConnection connection, T modelModifyProps, Expression<Func<T, bool>> condition, IDbTransaction transaction = null, int? timeout = 0) where T : class;

        /// <summary>
        /// 根据主键查询一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="keyValue"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        T FindEntity<T>(IDbConnection connection, object keyValue, IDbTransaction transaction = null, int? timeout = 0) where T : class;

        /// <summary>
        /// 根据条件查询一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="condition"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        T FindEntity<T>(IDbConnection connection, Expression<Func<T, bool>> condition, IDbTransaction transaction = null, int? timeout = 0) where T : class;

        /// <summary>
        /// 获取IQueryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        IQueryable<T> IQueryable<T>(IDbConnection connection, IDbTransaction transaction = null, int? timeout = 0) where T : class;

        /// <summary>
        /// 获取IQueryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="condition"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        IQueryable<T> IQueryable<T>(IDbConnection connection, Expression<Func<T, bool>> condition, IDbTransaction transaction = null, int? timeout = 0) where T : class;

        /// <summary>
        /// 得到一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        IEnumerable<T> FindList<T>(IDbConnection connection, IDbTransaction transaction = null, int? timeout = 0) where T : class;

        /// <summary>
        /// 根据条件查询出一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="condition"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        IEnumerable<T> FindList<T>(IDbConnection connection, Expression<Func<T, bool>> condition, IDbTransaction transaction = null, int? timeout = 0) where T : class;

        /// <summary>
        /// 执行sql语句，得到一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="strSql"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        IEnumerable<T> FindList<T>(IDbConnection connection, string strSql, IDbTransaction transaction = null, int? timeout = 0) where T : class;

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
        IEnumerable<T> FindList<T>(IDbConnection connection, string strSql, object parameters, IDbTransaction transaction = null, int? timeout = 0) where T : class;

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
        Tuple<IEnumerable<T>, int> FindList<T>(IDbConnection connection, Expression<Func<T, bool>> condition, string orderField, bool isAsc, int pageSize, int pageIndex, IDbTransaction transaction = null, int? timeout = 0) where T : class;

        /// <summary>
        /// 根据条件查询一个DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="condition"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        DataTable FindTable<T>(IDbConnection connection, Expression<Func<T, bool>> condition, IDbTransaction transaction = null, int? timeout = 0) where T : class;

        /// <summary>
        /// 查询一个DataTable
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <param name="transaction"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        DataTable FindTable(IDbConnection connection, string strSql, object parameters, IDbTransaction transaction = null, int? timeout = 0);

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
        Tuple<DataTable, int> FindTable(IDbConnection connection, string strSql, string orderField, bool isAsc, int pageSize, int pageIndex, IDbTransaction transaction = null, int? timeout = 0);

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
        Tuple<DataTable, int> FindTable(IDbConnection connection, string strSql, object parameters, string orderField, bool isAsc, int pageSize, int pageIndex, IDbTransaction transaction = null, int? timeout = 0);
    }
}