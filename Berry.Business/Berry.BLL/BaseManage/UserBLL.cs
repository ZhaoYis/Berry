using Berry.Code;
using Berry.Entity.BaseManage;
using Berry.Entity.CommonEntity;
using Berry.IBLL.BaseManage;
using Berry.IService.BaseManage;
using Berry.Service.BaseManage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace Berry.BLL.BaseManage
{
    /// <summary>
    /// 系统用户
    /// </summary>
    public partial class UserBLL : IUserBLL
    {
        private readonly IUserService _userService = new UserService();

        /// <summary>
        /// 缓存key
        /// </summary>
        public string CacheKey = "__UserCacheKey";

        /// <summary>
        /// 账户不能重复
        /// </summary>
        /// <param name="account">账户值</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistAccount(string account, string keyValue)
        {
            return _userService.ExistAccount(account, keyValue);
        }

        /// <summary>
        /// 新增一个用户
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns></returns>
        public bool AddUser(UserEntity user)
        {
            return _userService.AddUser(user);
        }

        /// <summary>
        /// 批量新增用户
        /// </summary>
        /// <param name="users">用户实体集合</param>
        public void AddUser(List<UserEntity> users)
        {
            _userService.AddUser(users);
        }

        /// <summary>
        /// 保存用户表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="userEntity">用户实体</param>
        /// <returns></returns>
        public bool AddUser(string keyValue, UserEntity userEntity)
        {
            return _userService.AddUser(keyValue, userEntity);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveUserByKey(string keyValue)
        {
            _userService.RemoveUserByKey(keyValue);
        }

        /// <summary>
        /// 修改用户登录密码
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="password">新密码（MD5 小写）</param>
        /// <param name="secretkey">密钥</param>
        public void RevisePassword(string keyValue, string password, string secretkey)
        {
            _userService.RevisePassword(keyValue, password, secretkey);
        }

        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="state">状态：1-启动 0-禁用</param>
        public void UpdateUserState(string keyValue, int state)
        {
            _userService.UpdateUserState(keyValue, state);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="userEntity">实体对象</param>
        public void UpdateUserInfo(UserEntity userEntity)
        {
            _userService.UpdateUserInfo(userEntity);
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
            return _userService.CheckLogin(userAccount, password, out status);
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetUserList()
        {
            return _userService.GetUserList();
        }

        /// <summary>
        /// 根据用户ID查询
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public UserEntity QueryUserByUserId(string userId)
        {
            return _userService.QueryUserByUserId(userId);
        }

        /// <summary>
        /// 根据指定条件查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public UserEntity QueryUser(Expression<Func<UserEntity, bool>> query)
        {
            return _userService.QueryUser(query);
        }

        /// <summary>
        /// 根据条件查询用户
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        public List<UserEntity> QueryUserList(Expression<Func<UserEntity, bool>> query)
        {
            return _userService.QueryUserList(query);
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetPageList(PaginationEntity pagination, string queryJson)
        {
            return _userService.GetPageList(pagination, queryJson);
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable()
        {
            return _userService.GetTable();
        }

        /// <summary>
        /// 用户列表（ALL）
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllUserTable()
        {
            return _userService.GetAllUserTable();
        }

        /// <summary>
        /// 导出用户列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetExportList()
        {
            return _userService.GetExportList();
        }
    }
}