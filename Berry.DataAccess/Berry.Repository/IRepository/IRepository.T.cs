using Berry.Entity.CommonEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace Berry.Data.Repository
{
    /// <summary>
    /// 定义仓储模型中的数据标准操作接口
    /// </summary>
    /// <typeparam name="T">动态实体类型</typeparam>
    public interface IRepository<T> where T : class, new()
    {
        /// <summary>
        /// 开始事务
        /// </summary>
        /// <returns></returns>
        IRepository<T> BeginTrans();

        /// <summary>
        /// 提交
        /// </summary>
        void Commit();

        /// <summary>
        /// 回滚
        /// </summary>
        void Rollback();

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
        int ExecuteByProc(string procName, params DbParameter[] dbParameter);

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="entity">对象实体</param>
        /// <returns></returns>
        int Insert(T entity);

        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entity">对象实体集合</param>
        /// <returns></returns>
        int Insert(List<T> entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        int Delete();

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="entity">对象实体</param>
        /// <returns></returns>
        int Delete(T entity);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entity">对象实体集合</param>
        /// <returns></returns>
        int Delete(List<T> entity);

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        int Delete(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 根据主键删除一条数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        int Delete(object keyValue);

        /// <summary>
        /// 根据主键批量删除一条数据
        /// </summary>
        /// <param name="keyValue">主键数组</param>
        /// <returns></returns>
        int Delete(object[] keyValue);

        /// <summary>
        /// 根据属性删除
        /// </summary>
        /// <param name="propertyValue">属性值</param>
        /// <param name="propertyName">属性名</param>
        /// <returns></returns>
        int Delete(object propertyValue, string propertyName);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        int Update(T entity);

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entity">实体对象集合</param>
        /// <returns></returns>
        int Update(List<T> entity);
        
        /// <summary>
        /// 根据条件更新
        /// </summary>
        /// <param name="modelModifyProps">要修改的列及修改后列的值集合</param>
        /// <param name="condition">修改的条件</param>
        /// <returns>返回受影响行数</returns>
        int Update(T modelModifyProps, Expression<Func<T, bool>> condition);

        /// <summary>
        /// 根据主键获取一条数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        T FindEntity(object keyValue);

        /// <summary>
        /// 根据条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        T FindEntity(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <returns></returns>
        IQueryable<T> IQueryable();

        /// <summary>
        /// 根据条件获取IQueryable对象
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IQueryable<T> IQueryable(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 根据T-SQL语句获取一条数据，返回对象集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        IEnumerable<T> FindList(string strSql);

        /// <summary>
        /// 根据T-SQL语句获取一条数据，返回对象集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <returns></returns>
        IEnumerable<T> FindList(string strSql, DbParameter[] dbParameter);

        /// <summary>
        /// 根据分页参数获取一条数据，返回对象集合
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        IEnumerable<T> FindList(PaginationEntity pagination);

        /// <summary>
        /// 根据分页参数、条件获取一条数据，返回对象集合
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        IEnumerable<T> FindList(Expression<Func<T, bool>> condition, PaginationEntity pagination);

        /// <summary>
        /// 根据条件获取一条数据，返回对象集合
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        IEnumerable<T> FindList(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 根据分页参数获取一条数据，返回对象集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        IEnumerable<T> FindList(string strSql, PaginationEntity pagination);

        /// <summary>
        /// 根据分页参数获取一条数据，返回对象集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        IEnumerable<T> FindList(string strSql, DbParameter[] dbParameter, PaginationEntity pagination);

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
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        DataTable FindTable(string strSql, PaginationEntity pagination);

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        DataTable FindTable(string strSql, DbParameter[] dbParameter, PaginationEntity pagination);

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
    }
}