using Berry.Code;
using Berry.Data.Extension;
using System;
using System.Data;
using System.Data.Common;

namespace Berry.Data
{
    /// <summary>
    /// 数据库访问扩展
    /// </summary>
    public class DbHelper
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public static DatabaseType DbType { get; set; }

        #region 构造函数

        /// <summary>
        /// _dbConnection
        /// </summary>
        /// <param name="dbConnection"></param>
        public DbHelper(DbConnection dbConnection)
        {
            this.DbConnection = dbConnection;
            DbCommand = this.DbConnection.CreateCommand();
        }

        #endregion 构造函数

        #region 属性

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        private DbConnection DbConnection { get; set; }

        /// <summary>
        /// 执行命令对象
        /// </summary>
        private IDbCommand DbCommand { get; set; }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            if (DbConnection != null && DbConnection.State != ConnectionState.Closed)
            {
                DbConnection.Close();
                DbConnection.Dispose();
            }
            if (DbCommand != null)
            {
                DbCommand.Dispose();
            }
        }

        #endregion 属性

        /// <summary>
        /// 执行SQL返回 DataReader
        /// </summary>
        /// <param name="cmdType">命令的类型</param>
        /// <param name="strSql">Sql语句</param>
        /// <returns></returns>
        public IDataReader ExecuteReader(CommandType cmdType, string strSql)
        {
            return ExecuteReader(cmdType, strSql, null);
        }

        /// <summary>
        /// 执行SQL返回 DataReader
        /// </summary>
        /// <param name="cmdType">命令的类型</param>
        /// <param name="strSql">Sql语句</param>
        /// <param name="dbParameter">Sql参数</param>
        /// <returns></returns>
        public IDataReader ExecuteReader(CommandType cmdType, string strSql, params DbParameter[] dbParameter)
        {
            try
            {
                PrepareCommand(DbConnection, DbCommand, null, cmdType, strSql, dbParameter);
                IDataReader rdr = DbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                return rdr;
            }
            catch (Exception)
            {
                this.Close();
                throw;
            }
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集
        /// </summary>
        /// <param name="cmdType">命令的类型</param>
        /// <param name="strSql">Sql语句</param>
        /// <returns></returns>
        public object ExecuteScalar(CommandType cmdType, string strSql)
        {
            return ExecuteScalar(cmdType, strSql, null);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集
        /// </summary>
        /// <param name="cmdType">命令的类型</param>
        /// <param name="cmdText">Sql语句或者存储过程名称</param>
        /// <param name="parameters">Sql参数</param>
        /// <returns></returns>
        public object ExecuteScalar(CommandType cmdType, string cmdText, params DbParameter[] parameters)
        {
            try
            {
                PrepareCommand(DbConnection, DbCommand, null, cmdType, cmdText, parameters);
                object val = DbCommand.ExecuteScalar();
                DbCommand.Parameters.Clear();
                return val;
            }
            catch (Exception)
            {
                this.Close();
                throw;
            }
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集
        /// </summary>
        /// <param name="cmdType">命令的类型</param>
        /// <param name="cmdText">Sql语句</param>
        /// <param name="parameters">Sql参数</param>
        /// <returns></returns>
        public IDataReader ExecuteDataReader(CommandType cmdType, string cmdText, params DbParameter[] parameters)
        {
            try
            {
                PrepareCommand(DbConnection, DbCommand, null, cmdType, cmdText, parameters);
                IDataReader val = DbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                DbCommand.Parameters.Clear();
                return val;
            }
            catch (Exception)
            {
                this.Close();
                throw;
            }
        }

        /// <summary>
        /// 为即将执行准备一个命令
        /// </summary>
        /// <param name="conn">SqlConnection对象</param>
        /// <param name="cmd">SqlCommand对象</param>
        /// <param name="isOpenTrans">DbTransaction对象</param>
        /// <param name="cmdType">执行命令的类型（存储过程或T-SQL，等等）</param>
        /// <param name="cmdText">存储过程名称或者T-SQL命令行, e.g. Select * from Products</param>
        /// <param name="dbParameter">执行命令所需的sql语句对应参数</param>
        private void PrepareCommand(DbConnection conn, IDbCommand cmd, DbTransaction isOpenTrans, CommandType cmdType, string cmdText, params DbParameter[] dbParameter)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (isOpenTrans != null)
                cmd.Transaction = isOpenTrans;
            cmd.CommandType = cmdType;
            if (dbParameter != null)
            {
                dbParameter = DbParameters.ToDbParameter(dbParameter);
                foreach (var parameter in dbParameter)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
        }
    }
}