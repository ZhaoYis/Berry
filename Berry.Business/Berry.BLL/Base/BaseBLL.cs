using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using Berry.Entity.CommonEntity;
using Berry.IBLL.Base;
using Berry.IService.Base;
using Berry.Service.Base;

namespace Berry.BLL.Base
{
    /// <summary>
    /// 基类BLL
    /// </summary>
    public class BaseBLL<T> : IBaseBLL<T> where T : class
    {
        /// <summary>
        /// 通用操作
        /// </summary>
        private static readonly IBaseService<T> baseService = new BaseService<T>();

        #region 公共操作方法

        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Add(T entity)
        {
            return baseService.Add(entity);
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public virtual int AddList(List<T> entitys)
        {
            return baseService.AddList(entitys);
        }

        /// <summary>
        /// 根据条件获取一条记录
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public virtual T GetEntity(Expression<Func<T, bool>> condition)
        {
            return baseService.GetEntity(condition);
        }

        /// <summary>
        /// 根据条件获取多条记录
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public virtual List<T> GetList(Expression<Func<T, bool>> condition)
        {
            return baseService.GetList(condition);
        }


        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public virtual int Delete(Expression<Func<T, bool>> condition)
        {
            return baseService.Delete(condition);
        }

        /// <summary>
        /// 删除表所有数据
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            return baseService.Delete();
        }

        /// <summary>
        /// 根据条件更新
        /// </summary>
        /// <param name="modelModifyProps">要修改的列及修改后列的值集合</param>
        /// <param name="condition">修改的条件</param>
        /// <returns>返回受影响行数</returns>
        public virtual int Update(T modelModifyProps, Expression<Func<T, bool>> condition)
        {
            return baseService.Update(modelModifyProps, condition);
        }

        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns></returns>
        public virtual int ExecuteBySql(string strSql)
        {
            return baseService.ExecuteBySql(strSql);
        }

        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public virtual int ExecuteBySql(string strSql, object param)
        {
            return baseService.ExecuteBySql(strSql, param);
        }

        /// <summary>
        /// 执行T-SQL并返回集合
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public virtual List<TR> ExecuteBySqlAndReturnList<TR>(string strSql, object param)
        {
            return baseService.ExecuteBySqlAndReturnList<TR>(strSql, param);
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
            return baseService.ExecuteBySqlAndReturnObject<TR>(strSql, param);
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <returns></returns>
        public virtual int ExecuteByProc(string procName)
        {
            return baseService.ExecuteBySql(procName);
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public virtual int ExecuteByProc(string procName, object param)
        {
            return baseService.ExecuteBySql(procName, param);
        }

        /// <summary>
        /// 执行存储过程，返回集合
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="procName">存储过程名称</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public List<TR> ExecuteByProc<TR>(string procName, object param)
        {
            return baseService.ExecuteByProc<TR>(procName, param);
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
            return baseService.FindList<TR>(condition, pagination);
        }

        /// <summary>
        /// 根据条件查询一个DataTable
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable FindTable<TR>(Expression<Func<T, bool>> condition)
        {
            return baseService.FindTable<TR>(condition);
        }

        /// <summary>
        /// 查询一个DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, object parameters)
        {
            return baseService.FindTable(strSql, parameters);
        }

        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public Tuple<DataTable, int> FindTable(string strSql, PaginationEntity pagination)
        {
            return baseService.FindTable(strSql, pagination);
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
            return baseService.FindTable(strSql, parameters, pagination);
        }

        #endregion
    }
}