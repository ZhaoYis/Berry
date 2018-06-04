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
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Berry.Service.BaseManage
{
    public class UserService : BaseService, IUserService
    {
        /// <summary>
        /// 账户不能重复
        /// </summary>
        /// <param name="account">账户值</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistAccount(string account, string keyValue)
        {
            List<UserEntity> data = this.BaseRepository().FindList<UserEntity>(t => t.Account == account && t.DeleteMark == false && t.EnabledMark == true).ToList();
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = data.Where(d => d.Id != keyValue).ToList();
            }

            bool hasExist = data.Any();

            return hasExist;
        }

        /// <summary>
        /// 新增一个用户
        /// </summary>
        /// <param name="userEntity">用户实体</param>
        /// <returns></returns>
        public bool AddUser(UserEntity userEntity)
        {
            userEntity.Create();
            int res = this.BaseRepository().Insert(userEntity);

            if (res > 0)
            {
                #region 添加角色、岗位、职位信息

                //删除历史用户角色关系
                res = this.BaseRepository().Delete<UserRelationEntity>(u => u.Id == userEntity.Id && u.IsDefault == true);
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
                res = this.BaseRepository().Insert<UserRelationEntity>(userRelation);

                #endregion 添加角色、岗位、职位信息
            }

            return res > 0;
        }

        /// <summary>
        /// 批量新增用户
        /// </summary>
        /// <param name="users">用户实体集合</param>
        public void AddUser(List<UserEntity> users)
        {
            this.BaseRepository().Insert<UserEntity>(users);
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
            if (!string.IsNullOrEmpty(keyValue))
            {
                //更新操作
                userEntity.Modify(keyValue);
                int res = this.BaseRepository().Update<UserEntity>(userEntity);
                isSucc = res > 0;
            }
            else
            {
                //新增操作
                userEntity.Create();

                int res = this.BaseRepository().Insert<UserEntity>(userEntity);
                isSucc = res > 0;
            }

            #region 添加角色、岗位、职位信息

            //删除历史用户角色关系
            this.BaseRepository().Delete<UserRelationEntity>(u => u.IsDefault == true && u.Id == userEntity.Id);
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
            this.BaseRepository().Insert<UserRelationEntity>(userRelation);

            #endregion 添加角色、岗位、职位信息

            objectId = userEntity.Id;
            return isSucc;
        }

        /// <summary>
        /// 删除用户，逻辑删除
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveUserByKey(string keyValue)
        {
            this.BaseRepository().Update<UserEntity>(new UserEntity { Id = keyValue }, u => u.DeleteMark == true && u.EnabledMark == false);
        }

        /// <summary>
        /// 修改用户登录密码
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="password">新密码（MD5 小写）</param>
        /// <param name="secretkey">密钥</param>
        public void RevisePassword(string keyValue, string password, string secretkey)
        {
            UserEntity user = new UserEntity
            {
                Id = keyValue,
                Password = password,
                Secretkey = secretkey
            };

            this.BaseRepository().Update<UserEntity>(user);
        }

        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="state">状态：1-启动 0-禁用</param>
        public void UpdateUserState(string keyValue, int state)
        {
            UserEntity user = new UserEntity
            {
                Id = keyValue,
                EnabledMark = state == 1
            };

            this.BaseRepository().Update<UserEntity>(user);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="userEntity">实体对象</param>
        public void UpdateUserInfo(UserEntity userEntity)
        {
            this.BaseRepository().Update<UserEntity>(userEntity);
        }

        /// <summary>
        /// 根据条件查询用户
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        public List<UserEntity> QueryUserList(Expression<Func<UserEntity, bool>> query)
        {
            List<UserEntity> res = this.BaseRepository().FindList<UserEntity>(query).ToList();
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
            IEnumerable<UserEntity> res = this.BaseRepository().FindList<UserEntity>(expression, pagination);

            return res;
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  u.*,
                                    d.FullName AS DepartmentName
                            FROM    Base_User u
                                    LEFT JOIN Base_Department d ON d.Id = u.DepartmentId
                            WHERE   1 = 1");
            strSql.Append(" AND u.Id <> 'System' AND u.EnabledMark = 1 AND u.DeleteMark = 0");

            DataTable data = this.BaseRepository().FindTable(strSql.ToString());

            return data;
        }

        /// <summary>
        /// 用户列表（ALL）
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllUserTable()
        {
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

            DataTable data = this.BaseRepository().FindTable(strSql.ToString());

            return data;
        }

        /// <summary>
        /// 导出用户列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetExportList()
        {
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

            DataTable data = this.BaseRepository().FindTable(strSql.ToString());

            return data;
        }

        /// <summary>
        /// 登录校验
        /// </summary>
        /// <param name="userAccount">用户账号</param>
        /// <param name="password">密码</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public UserEntity CheckLogin(string userAccount, string password, out JsonObjectStatus status)
        {
            if (!string.IsNullOrEmpty(userAccount) && !string.IsNullOrEmpty(password))
            {
                //根据用户账号得到用户信息
                //UserEntity user = this.BaseRepository().FindEntity<UserEntity>(u => u.Account.Equals(userAccount));
                UserEntity user = this.BaseRepository().FindEntity<UserEntity>(u => u.Account == userAccount);
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
                            int isSucc = this.BaseRepository().Update<UserEntity>(update);

                            status = JsonObjectStatus.Success;
                            return user;
                        }
                        else
                        {
                            status = JsonObjectStatus.PasswordErr;
                            return user;
                        }
                    }
                    else
                    {
                        status = JsonObjectStatus.AccountNotEnabled;
                        return user;
                    }
                }
                else
                {
                    status = JsonObjectStatus.UserNotExist;
                    return null;
                }
            }

            status = JsonObjectStatus.UserNotExist;
            return null;
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetUserList()
        {
            IEnumerable<UserEntity> res = this.BaseRepository()
                .FindList<UserEntity>(t => t.Id != "System" && t.EnabledMark == true && t.DeleteMark == false)
                .OrderByDescending(u => u.CreateDate).ToList();

            return res;
        }

        /// <summary>
        /// 根据用户ID查询
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public UserEntity QueryUserByUserId(string userId)
        {
            UserEntity res = this.BaseRepository().FindEntity<UserEntity>(u => u.Id == userId);
            return res;
        }

        /// <summary>
        /// 根据指定条件查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public UserEntity QueryUser(Expression<Func<UserEntity, bool>> query)
        {
            UserEntity res = this.BaseRepository().FindEntity<UserEntity>(query);
            return res;
        }
    }
}