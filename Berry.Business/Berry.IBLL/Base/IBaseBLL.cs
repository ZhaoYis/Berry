using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using Berry.Entity.CommonEntity;

namespace Berry.IBLL.Base
{
    /// <summary>
    /// 基类IBLL
    /// </summary>
    public interface IBaseBLL<T>
    {
        #region 公共操作方法
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Add(T entity);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        int AddList(List<T> entitys);

        /// <summary>
        /// 根据条件获取一条记录
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        T GetEntity(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 根据条件获取多条记录
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        List<T> GetList(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        int Delete(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 删除表所有数据
        /// </summary>
        /// <returns></returns>
        int Delete();

        /// <summary>
        /// 根据条件更新
        /// </summary>
        /// <param name="modelModifyProps">要修改的列及修改后列的值集合</param>
        /// <param name="condition">修改的条件</param>
        /// <returns>返回受影响行数</returns>
        int Update(T modelModifyProps, Expression<Func<T, bool>> condition);

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
        /// <param name="param">参数</param>
        /// <returns></returns>
        int ExecuteBySql(string strSql, object param);

        /// <summary>
        /// 执行T-SQL并返回集合
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        List<TR> ExecuteBySqlAndReturnList<TR>(string strSql, object param);

        /// <summary>
        /// 执行 SQL 语句返回对象
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="strSql">sql语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        TR ExecuteBySqlAndReturnObject<TR>(string strSql, object param);

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
        /// <param name="param">参数</param>
        /// <returns></returns>
        int ExecuteByProc(string procName, object param);

        /// <summary>
        /// 执行存储过程，返回集合
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="procName">存储过程名称</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        List<TR> ExecuteByProc<TR>(string procName, object param);
        
        /// <summary>
        /// 根据条件获取分页数据
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="condition">条件</param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        Tuple<IEnumerable<T>, int> FindList<TR>(Expression<Func<T, bool>> condition, PaginationEntity pagination);

        /// <summary>
        /// 根据条件查询一个DataTable
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        DataTable FindTable<TR>(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 查询一个DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        DataTable FindTable(string strSql, object parameters);

        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        Tuple<DataTable, int> FindTable(string strSql, PaginationEntity pagination);

        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">DbCommand参数</param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        Tuple<DataTable, int> FindTable(string strSql, object parameters, PaginationEntity pagination);
        #endregion
    }
}