using Berry.Data.Extension;
using Berry.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Berry.Data
{
    public static class DatabaseCommon
    {
        #region 对象参数转换DbParameter

        /// <summary>
        /// 对象参数转换DbParameter
        /// </summary>
        /// <returns></returns>
        public static DbParameter[] GetParameter<T>(T entity)
        {
            IList<DbParameter> parameter = new List<DbParameter>();
            DbType dbtype = new DbType();
            Type type = entity.GetType();
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo pi in props)
            {
                if (pi.GetValue(entity, null) != null)
                {
                    switch (pi.PropertyType.ToString())
                    {
                        case "System.Nullable`1[System.Int32]":
                            dbtype = DbType.Int32;
                            break;

                        case "System.Nullable`1[System.Decimal]":
                            dbtype = DbType.Decimal;
                            break;

                        case "System.Nullable`1[System.DateTime]":
                            dbtype = DbType.DateTime;
                            break;

                        default:
                            dbtype = DbType.String;
                            break;
                    }
                    parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + pi.Name, pi.GetValue(entity, null), dbtype));
                }
            }
            return parameter.ToArray();
        }

        /// <summary>
        /// 对象参数转换DbParameter
        /// </summary>
        /// <returns></returns>
        public static DbParameter[] GetParameter(Hashtable ht)
        {
            IList<DbParameter> parameter = new List<DbParameter>();
            DbType dbtype = new DbType();
            foreach (string key in ht.Keys)
            {
                if (ht[key] is DateTime)
                    dbtype = DbType.DateTime;
                else
                    dbtype = DbType.String;
                parameter.Add(DbParameters.CreateDbParameter(DbParameters.CreateDbParmCharacter() + key, ht[key], dbtype));
            }
            return parameter.ToArray();
        }

        #endregion 对象参数转换DbParameter

        #region 拼接 Insert SQL语句

        /// <summary>
        /// 哈希表生成Insert语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="ht">Hashtable</param>
        /// <returns>int</returns>
        public static StringBuilder InsertSql(string tableName, Hashtable ht)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Insert Into ");
            sb.Append(tableName);
            sb.Append("(");
            StringBuilder sp = new StringBuilder();
            StringBuilder sb_prame = new StringBuilder();
            foreach (string key in ht.Keys)
            {
                if (ht[key] != null)
                {
                    sb_prame.Append("," + key);
                    sp.Append("," + DbParameters.CreateDbParmCharacter() + "" + key);
                }
            }
            sb.Append(sb_prame.ToString().Substring(1, sb_prame.ToString().Length - 1) + ") Values (");
            sb.Append(sp.ToString().Substring(1, sp.ToString().Length - 1) + ")");
            return sb;
        }

        /// <summary>
        /// 泛型方法，反射生成InsertSql语句
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>int</returns>
        public static StringBuilder InsertSql<T>(T entity)
        {
            Type type = entity.GetType();
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();
            //获取不做映射的字段
            List<string> notMappedField = EntityAttributeHelper.GetNotMappedFields<T>();

            StringBuilder sb = new StringBuilder();
            sb.Append(" Insert Into ");
            sb.Append(table);
            sb.Append("(");
            StringBuilder sp = new StringBuilder();
            StringBuilder sb_prame = new StringBuilder();
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (!notMappedField.Contains(prop.Name))
                {
                    if (prop.GetValue(entity, null) != null)
                    {
                        sb_prame.Append("," + (prop.Name));
                        sp.Append("," + DbParameters.CreateDbParmCharacter() + "" + (prop.Name));
                    }
                }
            }
            sb.Append(sb_prame.ToString().Substring(1, sb_prame.ToString().Length - 1) + ") Values (");
            sb.Append(sp.ToString().Substring(1, sp.ToString().Length - 1) + ")");
            return sb;
        }

        #endregion 拼接 Insert SQL语句

        #region 拼接 Update SQL语句

        /// <summary>
        /// 哈希表生成UpdateSql语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="ht">Hashtable</param>
        /// <param name="pkName">主键</param>
        /// <returns></returns>
        public static StringBuilder UpdateSql(string tableName, Hashtable ht, string pkName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Update ");
            sb.Append(tableName);
            sb.Append(" Set ");
            bool isFirstValue = true;
            foreach (string key in ht.Keys)
            {
                if (ht[key] != null && pkName != key)
                {
                    if (isFirstValue)
                    {
                        isFirstValue = false;
                        sb.Append(key);
                        sb.Append("=");
                        sb.Append(DbParameters.CreateDbParmCharacter() + key);
                    }
                    else
                    {
                        sb.Append("," + key);
                        sb.Append("=");
                        sb.Append(DbParameters.CreateDbParmCharacter() + key);
                    }
                }
            }
            sb.Append(" Where ").Append(pkName).Append("=").Append(DbParameters.CreateDbParmCharacter() + pkName);
            return sb;
        }

        /// <summary>
        /// 泛型方法，反射生成UpdateSql语句
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="pkName">主键</param>
        /// <returns>int</returns>
        public static StringBuilder UpdateSql<T>(T entity, string pkName)
        {
            Type type = entity.GetType();
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();
            //主键
            string keyField = EntityAttributeHelper.GetEntityKey<T>();
            //获取不做映射的字段
            List<string> notMappedField = EntityAttributeHelper.GetNotMappedFields<T>();

            PropertyInfo[] props = type.GetProperties();
            StringBuilder sb = new StringBuilder();

            sb.Append(" Update ");
            sb.Append(table);
            sb.Append(" Set ");
            bool isFirstValue = true;
            foreach (PropertyInfo prop in props)
            {
                if (!notMappedField.Contains(prop.Name))
                {
                    if (prop.GetValue(entity, null) != null && keyField != prop.Name)
                    {
                        if (isFirstValue)
                        {
                            isFirstValue = false;
                            sb.Append(prop.Name);
                            sb.Append("=");
                            sb.Append(DbParameters.CreateDbParmCharacter() + prop.Name);
                        }
                        else
                        {
                            sb.Append("," + prop.Name);
                            sb.Append("=");
                            sb.Append(DbParameters.CreateDbParmCharacter() + prop.Name);
                        }
                    }
                }
            }
            sb.Append(" Where ").Append(pkName).Append("=").Append(DbParameters.CreateDbParmCharacter() + pkName);
            return sb;
        }

        /// <summary>
        /// 泛型方法，反射生成UpdateSql语句
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>int</returns>
        public static StringBuilder UpdateSql<T>(T entity)
        {
            Type type = entity.GetType();
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();
            //主键
            string keyField = EntityAttributeHelper.GetEntityKey<T>();
            //获取不做映射的字段
            List<string> notMappedField = EntityAttributeHelper.GetNotMappedFields<T>();

            PropertyInfo[] props = type.GetProperties();
            StringBuilder sb = new StringBuilder();

            sb.Append("Update ");
            sb.Append(table);
            sb.Append(" Set ");
            bool isFirstValue = true;
            foreach (PropertyInfo prop in props)
            {
                if (!notMappedField.Contains(prop.Name))
                {
                    if (prop.GetValue(entity, null) != null && keyField != prop.Name)
                    {
                        if (isFirstValue)
                        {
                            isFirstValue = false;
                            sb.Append(prop.Name);
                            sb.Append("=");
                            sb.Append(DbParameters.CreateDbParmCharacter() + prop.Name);
                        }
                        else
                        {
                            sb.Append("," + prop.Name);
                            sb.Append("=");
                            sb.Append(DbParameters.CreateDbParmCharacter() + prop.Name);
                        }
                    }
                }
            }
            sb.Append(" Where ").Append(keyField).Append("=").Append(DbParameters.CreateDbParmCharacter() + keyField);
            return sb;
        }

        #endregion 拼接 Update SQL语句

        #region 拼接 Delete SQL语句

        /// <summary>
        /// 拼接删除SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public static StringBuilder DeleteSql(string tableName)
        {
            return new StringBuilder("Delete From " + tableName);
        }

        /// <summary>
        /// 拼接删除SQL语句
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        public static StringBuilder DeleteSql<T>(string where)
        {
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();
            if (string.IsNullOrWhiteSpace(where))
                where = "1 = 1";

            return new StringBuilder("Delete From " + table + " " + where);
        }

        /// <summary>
        /// 拼接删除SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="pkName">字段主键</param>
        /// <returns></returns>
        public static StringBuilder DeleteSql(string tableName, string pkName)
        {
            return new StringBuilder("Delete From " + tableName + " Where " + pkName + " = " + DbParameters.CreateDbParmCharacter() + pkName + "");
        }

        /// <summary>
        /// 拼接删除SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="ht">多参数</param>
        /// <returns></returns>
        public static StringBuilder DeleteSql(string tableName, Hashtable ht)
        {
            StringBuilder sb = new StringBuilder("Delete From " + tableName + " Where 1=1");
            foreach (string key in ht.Keys)
            {
                sb.Append(" AND " + key + " = " + DbParameters.CreateDbParmCharacter() + "" + key + "");
            }
            return sb;
        }

        /// <summary>
        /// 拼接删除SQL语句
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public static StringBuilder DeleteSql<T>(T entity)
        {
            Type type = entity.GetType();
            PropertyInfo[] props = type.GetProperties();
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();

            StringBuilder sb = new StringBuilder("Delete From " + table + " Where 1=1");
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetValue(entity, null) != null)
                {
                    sb.Append(" AND " + prop.Name + " = " + DbParameters.CreateDbParmCharacter() + "" + prop.Name + "");
                }
            }
            return sb;
        }

        #endregion 拼接 Delete SQL语句

        #region 拼接 Select SQL语句

        /// <summary>
        /// 拼接 查询 SQL语句
        /// </summary>
        /// <returns></returns>
        public static StringBuilder SelectSql<T>() where T : new()
        {
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();

            PropertyInfo[] props = EntityAttributeHelper.GetProperties(typeof(T));
            StringBuilder sbColumns = new StringBuilder();

            foreach (PropertyInfo prop in props)
            {
                //string propertytype = prop.PropertyType.ToString();
                sbColumns.Append(prop.Name + ",");
            }
            if (sbColumns.Length > 0) sbColumns.Remove(sbColumns.ToString().Length - 1, 1);
            string strSql = "SELECT {0} FROM {1} WHERE 1=1 ";
            strSql = string.Format(strSql, sbColumns.ToString(), table + " ");
            return new StringBuilder(strSql);
        }

        /// <summary>
        /// 拼接 查询 SQL语句
        /// </summary>
        /// <param name="Top">显示条数</param>
        /// <returns></returns>
        public static StringBuilder SelectSql<T>(int Top) where T : new()
        {
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();

            PropertyInfo[] props = EntityAttributeHelper.GetProperties(typeof(T));
            StringBuilder sbColumns = new StringBuilder();
            foreach (PropertyInfo prop in props)
            {
                sbColumns.Append(prop.Name + ",");
            }
            if (sbColumns.Length > 0) sbColumns.Remove(sbColumns.ToString().Length - 1, 1);
            string strSql = "SELECT top {0} {1} FROM {2} WHERE 1=1 ";
            strSql = string.Format(strSql, Top, sbColumns.ToString(), table + " ");
            return new StringBuilder(strSql);
        }

        /// <summary>
        /// 拼接 查询 SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public static StringBuilder SelectSql(string tableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM " + tableName + " WHERE 1=1 ");
            return strSql;
        }

        /// <summary>
        /// 拼接 查询 SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="top">显示条数</param>
        /// <returns></returns>
        public static StringBuilder SelectSql(string tableName, int top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT top " + top + " * FROM " + tableName + " WHERE 1=1 ");
            return strSql;
        }

        /// <summary>
        /// 拼接 查询条数 SQL语句
        /// </summary>
        /// <returns></returns>
        public static StringBuilder SelectCountSql<T>() where T : new()
        {
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();

            return new StringBuilder("SELECT Count(1) FROM " + table + " WHERE 1=1 ");
        }

        /// <summary>
        /// 拼接 查询最大数 SQL语句
        /// </summary>
        /// <param name="propertyName">属性字段</param>
        /// <returns></returns>
        public static StringBuilder SelectMaxSql<T>(string propertyName) where T : new()
        {
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();

            return new StringBuilder("SELECT MAX(" + propertyName + ") FROM " + table + "  WHERE 1=1 ");
        }

        #endregion 拼接 Select SQL语句
    }
}