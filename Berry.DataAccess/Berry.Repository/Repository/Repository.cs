﻿using Berry.Entity.CommonEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace Berry.Data.Repository
{
    /// <summary>
    /// 定义仓储模型中的数据标准操作
    /// </summary>
    public class Repository : IRepository
    {
        #region 构造

        public IDatabase db;

        /// <summary>
        /// 仓储模型
        /// </summary>
        /// <param name="idatabase"></param>
        public Repository(IDatabase idatabase)
        {
            this.db = idatabase;
        }

        #endregion 构造

        #region 事务提交

        /// <summary>
        /// 开始事务
        /// </summary>
        /// <returns></returns>
        public IRepository BeginTrans()
        {
            db.BeginTrans();
            return this;
        }

        /// <summary>
        /// 提交
        /// </summary>
        public void Commit()
        {
            db.Commit();
        }

        /// <summary>
        /// 回滚
        /// </summary>
        public void Rollback()
        {
            db.Rollback();
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
            return db.ExecuteBySql(strSql);
        }

        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <returns></returns>
        public int ExecuteBySql(string strSql, params DbParameter[] dbParameter)
        {
            return db.ExecuteBySql(strSql, dbParameter);
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <returns></returns>
        public int ExecuteByProc(string procName)
        {
            return db.ExecuteByProc(procName);
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <returns></returns>
        public int ExecuteByProc(string procName, params DbParameter[] dbParameter)
        {
            return db.ExecuteByProc(procName, dbParameter);
        }

        #endregion 执行 SQL 语句

        #region 对象实体 添加、修改、删除

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="entity">对象实体</param>
        /// <returns></returns>
        public int Insert<T>(T entity) where T : class
        {
            return db.Insert<T>(entity);
        }

        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entity">对象实体集合</param>
        /// <returns></returns>
        public int Insert<T>(List<T> entity) where T : class
        {
            return db.Insert<T>(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public int Delete<T>() where T : class
        {
            return db.Delete<T>();
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="entity">对象实体</param>
        /// <returns></returns>
        public int Delete<T>(T entity) where T : class
        {
            return db.Delete<T>(entity);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entity">对象实体集合</param>
        /// <returns></returns>
        public int Delete<T>(List<T> entity) where T : class
        {
            return db.Delete<T>(entity);
        }

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public int Delete<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return db.Delete<T>(condition);
        }

        /// <summary>
        /// 根据主键删除一条数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public int Delete<T>(object keyValue) where T : class
        {
            return db.Delete<T>(keyValue);
        }

        /// <summary>
        /// 根据主键批量删除一条数据
        /// </summary>
        /// <param name="keyValue">主键数组</param>
        /// <returns></returns>
        public int Delete<T>(object[] keyValue) where T : class
        {
            return db.Delete<T>(keyValue);
        }

        /// <summary>
        /// 根据属性删除
        /// </summary>
        /// <param name="propertyValue">属性值</param>
        /// <param name="propertyName">属性名</param>
        /// <returns></returns>
        public int Delete<T>(object propertyValue, string propertyName) where T : class
        {
            return db.Delete<T>(propertyValue, propertyName);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public int Update<T>(T entity) where T : class
        {
            return db.Update<T>(entity);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entity">实体对象集合</param>
        /// <returns></returns>
        public int Update<T>(List<T> entity) where T : class
        {
            return db.Update<T>(entity);
        }

        /// <summary>
        /// 根据条件更新
        /// </summary>
        /// <param name="modelModifyProps">要修改的列及修改后列的值集合</param>
        /// <param name="condition">修改的条件</param>
        /// <returns>返回受影响行数</returns>
        public int Update<T>(T modelModifyProps, Expression<Func<T, bool>> condition) where T : class, new()
        {
            throw new NotImplementedException();
        }

        #endregion 对象实体 添加、修改、删除

        #region 对象实体 查询

        /// <summary>
        /// 根据主键获取一条数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public T FindEntity<T>(object keyValue) where T : class
        {
            return db.FindEntity<T>(keyValue);
        }

        /// <summary>
        /// 根据条件获取一条数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public T FindEntity<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return db.FindEntity<T>(condition);
        }

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> IQueryable<T>() where T : class, new()
        {
            return db.IQueryable<T>();
        }

        /// <summary>
        /// 根据条件获取IQueryable对象
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IQueryable<T> IQueryable<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return db.IQueryable<T>(condition);
        }

        /// <summary>
        /// 获取一条数据，返回对象集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>() where T : class, new()
        {
            return db.FindList<T>();
        }

        /// <summary>
        /// 根据条件获取一条数据，返回对象集合
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return db.FindList<T>(condition);
        }

        /// <summary>
        /// 根据T-SQL语句获取一条数据，返回对象集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string strSql) where T : class
        {
            return db.FindList<T>(strSql);
        }

        /// <summary>
        /// 根据T-SQL语句获取一条数据，返回对象集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string strSql, DbParameter[] dbParameter) where T : class
        {
            return db.FindList<T>(strSql, dbParameter);
        }

        /// <summary>
        /// 根据分页参数获取一条数据，返回对象集合
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(PaginationEntity pagination) where T : class, new()
        {
            int total = pagination.TotalRecords;
            var data = db.FindList<T>(pagination.Sidx, pagination.Sord.ToLower() == "asc" ? true : false, pagination.PageSize, pagination.PageIndex, out total);
            pagination.TotalRecords = total;
            return data;
        }

        /// <summary>
        /// 根据分页参数、条件获取一条数据，返回对象集合
        /// </summary>
        /// <param name="condition">条件</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition, PaginationEntity pagination) where T : class, new()
        {
            int total = pagination.TotalRecords;
            var data = db.FindList<T>(condition, pagination.Sidx, pagination.Sord.ToLower() == "asc" ? true : false, pagination.PageSize, pagination.PageIndex, out total);
            pagination.TotalRecords = total;
            return data;
        }

        /// <summary>
        /// 根据分页参数获取一条数据，返回对象集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string strSql, PaginationEntity pagination) where T : class
        {
            int total = pagination.TotalRecords;
            var data = db.FindList<T>(strSql, pagination.Sidx, pagination.Sord.ToLower() == "asc" ? true : false, pagination.PageSize, pagination.PageIndex, out total);
            pagination.TotalRecords = total;
            return data;
        }

        /// <summary>
        /// 根据分页参数获取一条数据，返回对象集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string strSql, DbParameter[] dbParameter, PaginationEntity pagination) where T : class
        {
            int total = pagination.TotalRecords;
            var data = db.FindList<T>(strSql, dbParameter, pagination.Sidx, pagination.Sord.ToLower() == "asc" ? true : false, pagination.PageSize, pagination.PageIndex, out total);
            pagination.TotalRecords = total;
            return data;
        }

        #endregion 对象实体 查询

        #region 数据源 查询

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql)
        {
            return db.FindTable(strSql);
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, DbParameter[] dbParameter)
        {
            return db.FindTable(strSql, dbParameter);
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, PaginationEntity pagination)
        {
            int total = pagination.TotalRecords;
            var data = db.FindTable(strSql, pagination.Sidx, pagination.Sord.ToLower() == "asc" ? true : false, pagination.PageSize, pagination.PageIndex, out total);
            pagination.TotalRecords = total;
            return data;
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, DbParameter[] dbParameter, PaginationEntity pagination)
        {
            int total = pagination.TotalRecords;
            var data = db.FindTable(strSql, dbParameter, pagination.Sidx, pagination.Sord.ToLower() == "asc" ? true : false, pagination.PageSize, pagination.PageIndex, out total);
            pagination.TotalRecords = total;
            return data;
        }

        /// <summary>
        /// 返回Object
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        public object FindObject(string strSql)
        {
            return db.FindObject(strSql);
        }

        /// <summary>
        /// 返回Object
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="dbParameter">DbCommand参数</param>
        /// <returns></returns>
        public object FindObject(string strSql, DbParameter[] dbParameter)
        {
            return db.FindObject(strSql, dbParameter);
        }

        #endregion 数据源 查询
    }
}