using Berry.Code;
using Berry.Code.Operator;
using Berry.Entity.BaseManage;
using Berry.Entity.CommonEntity;
using Berry.Extension;
using Berry.IService.BaseManage;
using Berry.Service.Base;
using Berry.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Berry.Service.AuthorizeManage;

namespace Berry.Service.BaseManage
{
    public class UserService : BaseService<UserEntity>, IUserService
    {
        private static AuthorizeService authorizeService = new AuthorizeService();

        /// <summary>
        /// 账户不能重复
        /// </summary>
        /// <param name="account">账户值</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistAccount(string account, string keyValue)
        {
            bool res = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "ExistAccount-账户不能重复", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    List<UserEntity> data = this.BaseRepository().FindList<UserEntity>(conn, t => t.Account == account && t.DeleteMark == false && t.EnabledMark == true, tran).ToList();
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        data = data.Where(d => d.Id != keyValue).ToList();
                    }
                    res = data.Count == 0;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 获得权限范围用户ID
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        public string GetDataAuthorUserId(OperatorEntity operators, bool isWrite = false)
        {
            string res = string.Empty;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetDataAuthorUserId-获得权限范围用户ID", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    string authorSql = authorizeService.GetDataAuthor(operators, isWrite);
                    if (string.IsNullOrEmpty(authorSql)) res = "";

                    List<UserEntity> userList = this.BaseRepository().FindList<UserEntity>(conn, authorSql, tran).ToList();
                    StringBuilder user = new StringBuilder("");

                    foreach (UserEntity item in userList)
                    {
                        user.Append(item.Id);
                        user.Append(",");
                    }

                    res = user.ToString();

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 新增一个用户
        /// </summary>
        /// <param name="userEntity">用户实体</param>
        /// <returns></returns>
        public bool AddUser(UserEntity userEntity)
        {
            bool isSucc = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "AddUser-新增一个用户", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    userEntity.Create();
                    int res = this.BaseRepository().Insert(conn, userEntity, tran);

                    if (res > 0)
                    {
                        #region 添加角色、岗位、职位信息

                        //删除历史用户角色关系
                        res = this.BaseRepository().Delete<UserRelationEntity>(conn, u => u.Id == userEntity.Id && u.IsDefault == true, tran);
                        //用户关系
                        List<UserRelationEntity> userRelation = new List<UserRelationEntity>();
                        //角色
                        if (!string.IsNullOrEmpty(userEntity.RoleId))
                        {
                            userRelation.Add(new UserRelationEntity
                            {
                                Category = 2,
                                Id = CommonHelper.GetGuid(),
                                UserId = userEntity.Id,
                                ObjectId = userEntity.RoleId,
                                CreateDate = DateTime.Now,
                                CreateUserId = OperatorProvider.Provider.Current().UserId,
                                CreateUserName = OperatorProvider.Provider.Current().UserName,
                                IsDefault = true
                            });
                        }
                        //岗位
                        if (!string.IsNullOrEmpty(userEntity.DutyId))
                        {
                            userRelation.Add(new UserRelationEntity
                            {
                                Category = 3,
                                Id = CommonHelper.GetGuid(),
                                UserId = userEntity.Id,
                                ObjectId = userEntity.DutyId,
                                CreateDate = DateTime.Now,
                                CreateUserId = OperatorProvider.Provider.Current().UserId,
                                CreateUserName = OperatorProvider.Provider.Current().UserName,
                                IsDefault = true
                            });
                        }
                        //职位
                        if (!string.IsNullOrEmpty(userEntity.PostId))
                        {
                            userRelation.Add(new UserRelationEntity
                            {
                                Category = 3,
                                Id = CommonHelper.GetGuid(),
                                UserId = userEntity.Id,
                                ObjectId = userEntity.PostId,
                                CreateDate = DateTime.Now,
                                CreateUserId = OperatorProvider.Provider.Current().UserId,
                                CreateUserName = OperatorProvider.Provider.Current().UserName,
                                IsDefault = true
                            });
                        }
                        //保持用户角色关系
                        res = this.BaseRepository().Insert<UserRelationEntity>(conn, userRelation, tran);

                        #endregion 添加角色、岗位、职位信息
                    }
                    isSucc = res > 0;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return isSucc;
        }

        /// <summary>
        /// 批量新增用户
        /// </summary>
        /// <param name="users">用户实体集合</param>
        public void AddUser(List<UserEntity> users)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "AddUser-批量新增用户", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    int res = this.BaseRepository().Insert<UserEntity>(conn, users, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }

        /// <summary>
        /// 保存用户表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="userEntity">用户实体</param>
        /// <param name="objectId">用户ID</param>
        /// <returns></returns>
        public bool AddUser(string keyValue, UserEntity userEntity, out string objectId)
        {
            bool isSucc = false;
            IDbTransaction tran = null;
            Logger(this.GetType(), "AddUser-保存用户表单（新增、修改）", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        //更新操作
                        userEntity.Modify(keyValue);
                        int res = this.BaseRepository().Update<UserEntity>(conn, userEntity, tran);
                        isSucc = res > 0;
                    }
                    else
                    {
                        //新增操作
                        userEntity.Create();

                        int res = this.BaseRepository().Insert<UserEntity>(conn, userEntity, tran);
                        isSucc = res > 0;
                    }

                    #region 添加角色、岗位、职位信息

                    //删除历史用户角色关系
                    this.BaseRepository().Delete<UserRelationEntity>(conn, u => u.IsDefault == true && u.Id == userEntity.Id, tran);
                    //用户关系
                    List<UserRelationEntity> userRelation = new List<UserRelationEntity>();
                    //角色
                    if (!string.IsNullOrEmpty(userEntity.RoleId))
                    {
                        userRelation.Add(new UserRelationEntity
                        {
                            Category = 2,
                            Id = CommonHelper.GetGuid(),
                            UserId = userEntity.Id,
                            ObjectId = userEntity.RoleId,
                            CreateDate = DateTime.Now,
                            CreateUserId = OperatorProvider.Provider.Current().UserId,
                            CreateUserName = OperatorProvider.Provider.Current().UserName,
                            IsDefault = true
                        });
                    }
                    //岗位
                    if (!string.IsNullOrEmpty(userEntity.DutyId))
                    {
                        userRelation.Add(new UserRelationEntity
                        {
                            Category = 3,
                            Id = CommonHelper.GetGuid(),
                            UserId = userEntity.Id,
                            ObjectId = userEntity.DutyId,
                            CreateDate = DateTime.Now,
                            CreateUserId = OperatorProvider.Provider.Current().UserId,
                            CreateUserName = OperatorProvider.Provider.Current().UserName,
                            IsDefault = true
                        });
                    }
                    //职位
                    if (!string.IsNullOrEmpty(userEntity.PostId))
                    {
                        userRelation.Add(new UserRelationEntity
                        {
                            Category = 3,
                            Id = CommonHelper.GetGuid(),
                            UserId = userEntity.Id,
                            ObjectId = userEntity.PostId,
                            CreateDate = DateTime.Now,
                            CreateUserId = OperatorProvider.Provider.Current().UserId,
                            CreateUserName = OperatorProvider.Provider.Current().UserName,
                            IsDefault = true
                        });
                    }
                    //保持用户角色关系
                    this.BaseRepository().Insert<UserRelationEntity>(conn, userRelation, tran);

                    #endregion 添加角色、岗位、职位信息

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });

            objectId = userEntity.Id;
            return isSucc;
        }

        /// <summary>
        /// 删除用户，逻辑删除
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveUserByKey(string keyValue)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "RemoveUserByKey-删除用户，逻辑删除", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    UserEntity entity = new UserEntity
                    {
                        DeleteMark = true,
                        EnabledMark = false
                    };
                    int res = this.BaseRepository().Update<UserEntity>(conn, entity, u => u.Id == keyValue, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }

        /// <summary>
        /// 修改用户登录密码
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="password">新密码（MD5 小写）</param>
        /// <param name="secretkey">密钥</param>
        public void RevisePassword(string keyValue, string password, string secretkey)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "RevisePassword-修改用户登录密码", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    UserEntity user = new UserEntity
                    {
                        Id = keyValue,
                        Password = password,
                        Secretkey = secretkey
                    };
                    this.BaseRepository().Update<UserEntity>(conn, user, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }

        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="state">状态：1-启动 0-禁用</param>
        public void UpdateUserState(string keyValue, int state)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "UpdateUserState-修改用户状态", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    UserEntity user = new UserEntity
                    {
                        Id = keyValue,
                        EnabledMark = state == 1
                    };
                    this.BaseRepository().Update<UserEntity>(conn, user, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="userEntity">实体对象</param>
        public void UpdateUserInfo(UserEntity userEntity)
        {
            IDbTransaction tran = null;
            Logger(this.GetType(), "UpdateUserInfo-修改用户信息", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    this.BaseRepository().Update<UserEntity>(conn, userEntity, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
        }

        /// <summary>
        /// 根据条件查询用户
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        public List<UserEntity> QueryUserList(Expression<Func<UserEntity, bool>> query)
        {
            List<UserEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "QueryUserList-根据条件查询用户", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindList<UserEntity>(conn, query, tran).ToList();

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetPageList(PaginationEntity pagination, string queryJson)
        {
            IEnumerable<UserEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetPageList-用户列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    var expression = LambdaExtension.True<UserEntity>();
                    JObject queryParam = queryJson.TryToJObject();
                    if (queryParam != null)
                    {
                        //公司主键
                        if (!queryParam["organizeId"].IsEmpty())
                        {
                            string organizeId = queryParam["organizeId"].ToString();
                            expression = expression.And(t => t.OrganizeId == organizeId);
                        }
                        //部门主键
                        if (!queryParam["departmentId"].IsEmpty())
                        {
                            string departmentId = queryParam["departmentId"].ToString();
                            expression = expression.And(t => t.DepartmentId == departmentId);
                        }
                        //查询条件
                        if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
                        {
                            string condition = queryParam["condition"].ToString();
                            string keyord = queryParam["keyword"].ToString();
                            switch (condition)
                            {
                                case "Account"://账户
                                    expression = expression.And(t => t.Account.Contains(keyord));
                                    break;

                                case "RealName"://姓名
                                    expression = expression.And(t => t.RealName.Contains(keyord));
                                    break;

                                case "Mobile"://手机
                                    expression = expression.And(t => t.Mobile.Contains(keyord));
                                    break;
                            }
                        }
                    }

                    expression = expression.And(u => u.DeleteMark == false);
                    Tuple<IEnumerable<UserEntity>, int> tuple = this.BaseRepository().FindList<UserEntity>(conn, expression, pagination.sidx, pagination.sord.ToLower() == "asc", pagination.rows, pagination.page, tran);
                    pagination.records = tuple.Item2;
                    res = tuple.Item1;

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable()
        {
            DataTable res = new DataTable();
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetTable-用户列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(@"SELECT  u.*,
                                    d.FullName AS DepartmentName
                            FROM    Base_User u
                                    LEFT JOIN Base_Department d ON d.Id = u.DepartmentId
                            WHERE   1 = 1");
                    strSql.Append(" AND u.Id <> 'System' AND u.EnabledMark = 1 AND u.DeleteMark = 0");

                    res = this.BaseRepository().FindTable(conn, strSql.ToString(), tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 用户列表（ALL）
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllUserTable()
        {
            DataTable res = new DataTable();
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetAllUserTable-用户列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(@"SELECT  u.Id ,
                                    u.EnCode ,
                                    u.Account ,
                                    u.RealName ,
                                    u.Gender ,
                                    u.Birthday ,
                                    u.Mobile ,
                                    u.Manager ,
                                    u.OrganizeId,
                                    u.DepartmentId,
                                    o.FullName AS OrganizeName ,
                                    d.FullName AS DepartmentName ,
                                    u.RoleId ,
                                    u.DutyName ,
                                    u.PostName ,
                                    u.EnabledMark ,
                                    u.CreateDate,
                                    u.Description
                            FROM    Base_User u
                                    LEFT JOIN Base_Organize o ON o.Id = u.OrganizeId
                                    LEFT JOIN Base_Department d ON d.Id = u.DepartmentId
                            WHERE   1 = 1");
                    strSql.Append(" AND u.Id <> 'System' AND u.EnabledMark = 1 AND u.DeleteMark = 0 order by o.FullName,d.FullName,u.RealName");

                    res = this.BaseRepository().FindTable(conn, strSql.ToString(), tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 导出用户列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetExportList()
        {
            DataTable res = new DataTable();
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetExportList-导出用户列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(@"SELECT u.[Account]
                                  ,u.[RealName]
                                  ,CASE WHEN Gender = 1 THEN '男' ELSE '女' END AS Gender
                                  ,u.[Birthday]
                                  ,u.[Mobile]
                                  ,u.[Telephone]
                                  ,u.[Email]
                                  ,u.[WeChat]
                                  ,u.[MSN]
                                  ,u.[Manager]
                                  ,o.FullName AS Organize
                                  ,d.FullName AS Department
                                  ,u.[Description]
                                  ,u.[CreateDate]
                                  ,u.[CreateUserName]
                              FROM Base_User u
                              INNER JOIN Base_Department d ON u.DepartmentId = d.Id
                              INNER JOIN Base_Organize o ON u.OrganizeId = o.Id");

                    res = this.BaseRepository().FindTable(conn, strSql.ToString(), tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 登录校验
        /// </summary>
        /// <param name="userAccount">用户账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public Tuple<UserEntity, JsonObjectStatus> CheckLogin(string userAccount, string password)
        {
            Tuple<UserEntity, JsonObjectStatus> res = new Tuple<UserEntity, JsonObjectStatus>(null, JsonObjectStatus.UserNotExist);
            IDbTransaction tran = null;
            Logger(this.GetType(), "CheckLogin-登录校验", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    if (!string.IsNullOrEmpty(userAccount) && !string.IsNullOrEmpty(password))
                    {
                        //根据用户账号得到用户信息
                        //UserEntity user = this.BaseRepository().FindEntity<UserEntity>(u => u.Account.Equals(userAccount));
                        UserEntity user = this.BaseRepository().FindEntity<UserEntity>(conn, u => u.Account == userAccount, tran);
                        if (user != null)
                        {
                            if (user.EnabledMark)
                            {
                                string realPassword = Md5Helper.Md5(DESEncryptHelper.Encrypt(password, user.Secretkey));
                                if (realPassword.Equals(user.Password))
                                {
                                    DateTime lastVisit = DateTime.Now;
                                    int logOnCount = (user.LogOnCount).TryToInt32() + 1;

                                    if (user.LastVisit != null)
                                    {
                                        user.PreviousVisit = user.LastVisit.TryToDateTime();
                                    }

                                    user.LastVisit = lastVisit;
                                    user.LogOnCount = logOnCount;
                                    user.UserOnLine = 1;
                                    //更新登录信息
                                    //int isSucc = this.BaseRepository().Update<UserEntity>(new UserEntity { Id = user.Id, LastVisit = lastVisit, LogOnCount = logOnCount, UserOnLine = 1 }, e => e.Id == user.Id);
                                    UserEntity update = new UserEntity
                                    {
                                        Id = user.Id,
                                        LastVisit = lastVisit,
                                        LogOnCount = logOnCount,
                                        UserOnLine = 1,
                                        EnabledMark = user.EnabledMark,
                                        DeleteMark = user.DeleteMark
                                    };
                                    int isSucc = this.BaseRepository().Update<UserEntity>(conn, update, tran);
                                    res = new Tuple<UserEntity, JsonObjectStatus>(user, JsonObjectStatus.Success);
                                }
                                else
                                {
                                    res = new Tuple<UserEntity, JsonObjectStatus>(null, JsonObjectStatus.PasswordErr);
                                }
                            }
                            else
                            {
                                res = new Tuple<UserEntity, JsonObjectStatus>(null, JsonObjectStatus.AccountNotEnabled);
                            }
                        }
                        else
                        {
                            res = new Tuple<UserEntity, JsonObjectStatus>(null, JsonObjectStatus.UserNotExist);
                        }
                    }
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetUserList()
        {
            IEnumerable<UserEntity> res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "GetUserList-用户列表", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository()
                        .FindList<UserEntity>(conn, t => t.Id != "System" && t.EnabledMark == true && t.DeleteMark == false, tran)
                        .OrderByDescending(u => u.CreateDate).ToList();

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 根据用户ID查询
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public UserEntity QueryUserByUserId(string userId)
        {
            UserEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "QueryUserByUserId-根据用户ID查询", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();
                    res = this.BaseRepository().FindEntity<UserEntity>(conn, u => u.Id == userId, tran);
                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 根据指定条件查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public UserEntity QueryUser(Expression<Func<UserEntity, bool>> query)
        {
            UserEntity res = null;
            IDbTransaction tran = null;
            Logger(this.GetType(), "QueryUser-根据指定条件查询", () =>
            {
                using (var conn = this.BaseRepository().GetBaseConnection())
                {
                    tran = conn.BeginTransaction();

                    res = this.BaseRepository().FindEntity<UserEntity>(conn, query, tran);

                    tran.Commit();
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }
    }
}