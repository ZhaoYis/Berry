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
        /// 开始事务
        /// </summary>
        /// <returns></returns>
        IDatabase BeginTrans();

        /// <summary>
        /// 提交
        /// </summary>
        int Commit();

        /// <summary>
        /// 回滚
        /// </summary>
        void Rollback();

        /// <summary>
        /// 关闭
        /// </summary>
        void Close();

        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        int ExecuteBySql(string strSql);

        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <returns></returns>
        int ExecuteBySql(string strSql, params DbParameter[] dbParameter);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <returns></returns>
        int ExecuteByProc(string procName);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <returns></returns>
        int ExecuteByProc(string procName, DbParameter[] dbParameter);

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="entity">对象实体</param>
        /// <returns></returns>
        int Insert<T>(T entity) where T : class;

        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entity">对象实体集合</param>
        /// <returns></returns>
        int Insert<T>(IEnumerable<T> entity) where T : class;

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        int Delete<T>() where T : class;

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="entity">对象实体</param>
        /// <returns></returns>
        int Delete<T>(T entity) where T : class;

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entity">对象实体集合</param>
        /// <returns></returns>
        int Delete<T>(IEnumerable<T> entity) where T : class;

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        int Delete<T>(Expression<Func<T, bool>> condition) where T : class, new();

        /// <summary>
        /// 根据主键删除一条数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        int Delete<T>(object keyValue) where T : class;

        /// <summary>
        /// 根据主键批量删除一条数据
        /// </summary>
        /// <param name="keyValue">主键数组</param>
        /// <returns></returns>
        int Delete<T>(object[] keyValue) where T : class;

        /// <summary>
        /// 根据属性删除
        /// </summary>
        /// <param name="propertyValue">属性值</param>
        /// <param name="propertyName">属性名</param>
        /// <returns></returns>
        int Delete<T>(object propertyValue, string propertyName) where T : class;

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        int Update<T>(T entity) where T : class;

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entity">实体对象集合</param>
        /// <returns></returns>
        int Update<T>(IEnumerable<T> entity) where T : class;

        /// <summary>
        /// 根据条件更新
        /// </summary>
        /// <param name="modelModifyProps">要修改的列及修改后列的值集合</param>
        /// <param name="condition">修改的条件</param>
        /// <returns>返回受影响行数</returns>
        int Update<T>(T modelModifyProps, Expression<Func<T, bool>> condition) where T : class, new();

        /// <summary>
        /// 返回Object
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        object FindObject(string strSql);

        /// <summary>
        /// 返回Object
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <returns></returns>
        object FindObject(string strSql, DbParameter[] dbParameter);

        /// <summary>
        /// 根据主键获取一条数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        T FindEntity<T>(object keyValue) where T : class, new();

        /// <summary>
        /// 根据条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        T FindEntity<T>(Expression<Func<T, bool>> condition) where T : class, new();

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <returns></returns>
        IQueryable<T> IQueryable<T>() where T : class, new();

        /// <summary>
        /// 根据条件获取IQueryable对象
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IQueryable<T> IQueryable<T>(Expression<Func<T, bool>> condition) where T : class, new();

        /// <summary>
        /// 获取一条数据，返回对象集合
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindList<T>() where T : class, new();
        
        /// <summary>
        /// 根据条件获取一条数据，返回对象集合
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition) where T : class, new();

        /// <summary>
        /// 根据T-SQL语句获取一条数据，返回对象集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        IEnumerable<T> FindList<T>(string strSql) where T : class, new();

        /// <summary>
        /// 根据T-SQL语句获取一条数据，返回对象集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <returns></returns>
        IEnumerable<T> FindList<T>(string strSql, DbParameter[] dbParameter) where T : class, new();

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orderField">排序字段，多个用英文逗号隔开，类似：Id Asc,Name Desc</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="total">总记录数</param>
        /// <returns></returns>
        IEnumerable<T> FindList<T>(string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class, new();

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
        IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class, new();

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
        IEnumerable<T> FindList<T>(string strSql, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class, new();

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
        IEnumerable<T> FindList<T>(string strSql, DbParameter[] dbParameter, string orderField, bool isAsc, int pageSize, int pageIndex, out int total) where T : class, new();

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        DataTable FindTable(string strSql);

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <returns></returns>
        DataTable FindTable(string strSql, DbParameter[] dbParameter);

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
        DataTable FindTable(string strSql, string orderField, bool isAsc, int pageSize, int pageIndex, out int total);

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
        DataTable FindTable(string strSql, DbParameter[] dbParameter, string orderField, bool isAsc, int pageSize, int pageIndex, out int total);
    }
}