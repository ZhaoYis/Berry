using Berry.Data;
using Berry.Data.Extension;
using Berry.Entity.CommonEntity;
using Berry.Entity.SystemManage;
using Berry.Extension;
using Berry.IService.SystemManage;
using Berry.Service.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Berry.Service.SystemManage
{
    /// <summary>
    /// 数据库管理（支持：SqlServer）
    /// </summary>
    public class DataBaseTableService : BaseService<DataBaseTableFieldEntity>, IDataBaseTableService
    {
        private IDataBaseLinkService dataBaseLinkService = new DataBaseLinkService();

        #region 获取数据

        /// <summary>
        /// 数据表列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns></returns>
        public DataTable GetTableList(string dataBaseLinkId, string tableName)
        {
            DataTable res = new DataTable();
            Logger(this.GetType(), "GetTableList-数据表列表", () =>
            {
                DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
                if (dataBaseLinkEntity != null)
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(@"DECLARE @TableInfo TABLE ( name VARCHAR(50) , sumrows VARCHAR(11) , reserved VARCHAR(50) , data VARCHAR(50) , index_size VARCHAR(50) , unused VARCHAR(50) , pk VARCHAR(50) )
                            DECLARE @TableName TABLE ( name VARCHAR(50) )
                            DECLARE @name VARCHAR(50)
                            DECLARE @pk VARCHAR(50)
                            INSERT INTO @TableName ( name ) SELECT o.name FROM sysobjects o , sysindexes i WHERE o.id = i.id AND o.Xtype = 'U' AND i.indid < 2 ORDER BY i.rows DESC , o.name
                            WHILE EXISTS ( SELECT 1 FROM @TableName ) BEGIN SELECT TOP 1 @name = name FROM @TableName DELETE @TableName WHERE name = @name DECLARE @objectid INT SET @objectid = OBJECT_ID(@name) SELECT @pk = COL_NAME(@objectid, colid) FROM sysobjects AS o INNER JOIN sysindexes AS i ON i.name = o.name INNER JOIN sysindexkeys AS k ON k.indid = i.indid WHERE o.xtype = 'PK' AND parent_obj = @objectid AND k.id = @objectid INSERT INTO @TableInfo ( name , sumrows , reserved , data , index_size , unused ) EXEC sys.sp_spaceused @name UPDATE @TableInfo SET pk = @pk WHERE name = @name END
                            SELECT F.name , F.reserved , F.data , F.index_size , RTRIM(F.sumrows) AS sumrows , F.unused , ISNULL(p.tdescription, f.name) AS tdescription , F.pk
                            FROM @TableInfo F LEFT JOIN ( SELECT name = CASE WHEN A.COLORDER = 1 THEN D.NAME ELSE '' END , tdescription = CASE WHEN A.COLORDER = 1 THEN ISNULL(F.VALUE, '') ELSE '' END FROM SYSCOLUMNS A LEFT JOIN SYSTYPES B ON A.XUSERTYPE = B.XUSERTYPE INNER JOIN SYSOBJECTS D ON A.ID = D.ID AND D.XTYPE = 'U' AND D.NAME <> 'DTPROPERTIES' LEFT JOIN sys.extended_properties F ON D.ID = F.major_id WHERE a.COLORDER = 1 AND F.minor_id = 0 ) P ON F.name = p.name
                            WHERE 1 = 1 ");
                    if (!string.IsNullOrEmpty(tableName))
                    {
                        strSql.Append(" AND f.name='" + tableName + "'");
                    }
                    strSql.Append(" ORDER BY f.name");
                    res = SqlHelper.ExecuteDataset(dataBaseLinkEntity.DbConnection, CommandType.Text, strSql.ToString()).Tables[0];
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 数据表字段列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns></returns>
        public IEnumerable<DataBaseTableFieldEntity> GetTableFiledList(string dataBaseLinkId, string tableName)
        {
            IEnumerable<DataBaseTableFieldEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetTableFiledList-数据表字段列表", () =>
            {
                DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
                if (dataBaseLinkEntity != null)
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(@"SELECT [number] = a.colorder , [column] = a.name , [datatype] = b.name , [length] = COLUMNPROPERTY(a.id, a.name, 'PRECISION') , [identity] = CASE WHEN COLUMNPROPERTY(a.id, a.name, 'IsIdentity') = 1 THEN '1' ELSE '' END , [key] = CASE WHEN EXISTS ( SELECT 1 FROM sysobjects WHERE xtype = 'PK' AND parent_obj = a.id AND name IN ( SELECT name FROM sysindexes WHERE indid IN ( SELECT indid FROM sysindexkeys WHERE id = a.id AND colid = a.colid ) ) ) THEN '1' ELSE '' END , [isnullable] = CASE WHEN a.isnullable = 1 THEN '1' ELSE '' END , [defaults] = ISNULL(e.text, '') , [remark] = ISNULL(g.[value], a.name)
                                FROM syscolumns a LEFT JOIN systypes b ON a.xusertype = b.xusertype INNER JOIN sysobjects d ON a.id = d.id AND d.xtype = 'U' AND d.name <> 'dtproperties' LEFT JOIN syscomments e ON a.cdefault = e.id LEFT JOIN sys.extended_properties g ON a.id = g.major_id AND a.colid = g.minor_id LEFT JOIN sys.extended_properties f ON d.id = f.major_id AND f.minor_id = 0
                                WHERE d.name = @tableName
                                ORDER BY a.id , a.colorder");
                    SqlParameter[] parameter =
                    {
                        new SqlParameter(DbParameters.CreateDbParmCharacter() + "tableName", tableName)
                    };
                    res = SqlHelper.ExecuteDataset(dataBaseLinkEntity.DbConnection, CommandType.Text, strSql.ToString(), parameter).Tables[0].DataTableToList<DataBaseTableFieldEntity>();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 数据库表数据列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接</param>
        /// <param name="tableName">表明</param>
        /// <param name="switchWhere">条件</param>
        /// <param name="logic">逻辑</param>
        /// <param name="keyword">关键字</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public DataTable GetTableDataList(string dataBaseLinkId, string tableName, string switchWhere, string logic, string keyword, PaginationEntity pagination)
        {
            DataTable res = new DataTable();
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetMemberList-获取成员列表", () =>
            {
                DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);

                if (dataBaseLinkEntity != null)
                {
                    StringBuilder strSql = new StringBuilder();
                    List<SqlParameter> parameter = new List<SqlParameter>();
                    strSql.Append("SELECT * FROM " + tableName + " WHERE 1=1");
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        strSql.Append(" AND " + switchWhere + "");
                        switch (logic)
                        {
                            case "Equal"://等于
                                strSql.Append(" = ");
                                parameter.Add(new SqlParameter("@" + switchWhere, keyword));
                                break;

                            case "NotEqual"://不等于
                                strSql.Append(" <> ");
                                parameter.Add(new SqlParameter("@" + switchWhere, keyword));
                                break;

                            case "Greater"://大于
                                strSql.Append(" > ");
                                parameter.Add(new SqlParameter("@" + switchWhere, keyword));
                                break;

                            case "GreaterThan"://大于等于
                                strSql.Append(" >= ");
                                parameter.Add(new SqlParameter("@" + switchWhere, keyword));
                                break;

                            case "Less"://小于
                                strSql.Append(" < ");
                                parameter.Add(new SqlParameter("@" + switchWhere, keyword));
                                break;

                            case "LessThan"://小于等于
                                strSql.Append(" >= ");
                                parameter.Add(new SqlParameter("@" + switchWhere, keyword));
                                break;

                            case "Null"://为空
                                strSql.Append(" is null ");
                                parameter.Add(new SqlParameter("@" + switchWhere, keyword));
                                break;

                            case "NotNull"://不为空
                                strSql.Append(" is not null ");
                                parameter.Add(new SqlParameter("@" + switchWhere, keyword));
                                break;

                            case "Like"://包含
                                strSql.Append(" like ");
                                parameter.Add(new SqlParameter("@" + switchWhere, '%' + keyword + '%'));
                                break;

                            default:
                                break;
                        }
                        strSql.Append("@" + switchWhere + "");
                    }

                    StringBuilder sb = new StringBuilder();
                    int pageIndex = pagination.page;
                    int pageSize = pagination.rows;
                    string orderField = pagination.sidx;
                    bool isAsc = pagination.sord.ToLower() == "asc";
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

                    string selectCountSql = "Select Count(*) From (" + strSql + ") AS t";

                    DataTable data = SqlHelper.ExecuteDataset(dataBaseLinkEntity.DbConnection, CommandType.Text, strSql.ToString(), parameter.ToArray()).Tables[0];
                    int total = SqlHelper.ExecuteNonQuery(dataBaseLinkEntity.DbConnection, CommandType.Text, selectCountSql);
                    //total = connection.ExecuteScalar<int>(selectCountSql, parameters, transaction, timeout);
                    //Tuple<DataTable, int> tuple = this.BaseRepository(dataBaseLinkEntity.DbConnection).FindTable(strSql.ToString(), parameter.ToArray(), pagination.sidx, pagination.sord.ToLower() == "asc", pagination.rows, pagination.page, tran);
                    //pagination.records = tuple.Item2;
                    //res = tuple.Item1;

                    Tuple<DataTable, int> tuple = Tuple.Create(data, total);
                    pagination.records = tuple.Item2;
                    res = tuple.Item1;
                }

            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 保存数据库表表单（新增、修改）
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param>
        /// <param name="tableDescription">表说明</param>
        /// <param name="fieldList">字段列表</param>
        public void SaveForm(string dataBaseLinkId, string tableName, string tableDescription, IEnumerable<DataBaseTableFieldEntity> fieldList)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "SaveForm-保存数据库表表单（新增、修改）", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("if exists (select 1");
                    strSql.Append("            from  sysobjects");
                    strSql.Append("            where  id = object_id('" + tableName + "')");
                    strSql.Append("            and   type = 'U')");
                    strSql.Append("   drop table " + tableName + "");
                    strSql.Append("go");

                    strSql.Append("/*==============================================================*/");
                    strSql.Append("/* Table: " + tableName + "                                     */");
                    strSql.Append("/*==============================================================*/");
                    strSql.Append("create table " + tableName + " (");

                    strSql.Append("   Id                varchar(50)        not null,");
                    strSql.Append("   SourceObjectId       varchar(50)        null,");
                    strSql.Append("   SourceContentJson    text               null,");
                    strSql.Append("   IPAddress            varchar(50)        null,");
                    strSql.Append("   IPAddressName        varchar(200)       null,");
                    strSql.Append("   Category             int                null,");

                    strSql.Append("   constraint PK_BASE_LOG primary key nonclustered (Id)");
                    strSql.Append(")");
                    strSql.Append("go");

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });

            //declare @CurrentUser sysname
            //select @CurrentUser = user_name()
            //execute sp_addextendedproperty 'MS_Description',
            //   '系统日志表',
            //   'user', @CurrentUser, 'table', 'Base_Log'
            //go

            //declare @CurrentUser sysname
            //select @CurrentUser = user_name()
            //execute sp_addextendedproperty 'MS_Description',
            //   '日志主键',
            //   'user', @CurrentUser, 'table', 'Base_Log', 'column', 'LogId'
            //go
        }

        #endregion 提交数据
    }
}