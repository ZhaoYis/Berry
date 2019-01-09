using Berry.Code;
using Berry.Entity.BaseManage;
using Berry.Entity.CommonEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using Berry.Code.Operator;

namespace Berry.IService.BaseManage
{
    /// <summary>
    /// 操作用户接口
    /// </summary>
    public interface IUserService
    {
        #region 获取数据

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserEntity> GetUserList();

        /// <summary>
        /// 根据用户ID查询
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        UserEntity QueryUserByUserId(string userId);

        /// <summary>
        /// 获得权限范围用户ID
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        string GetDataAuthorUserId(OperatorEntity operators, bool isWrite = false);

        /// <summary>
        /// 根据指定条件查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        UserEntity QueryUser(Expression<Func<UserEntity, bool>> query);

        /// <summary>
        /// 登录校验
        /// </summary>
        /// <param name="userAccount">用户账号</param>
        /// <param name="password">密码</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        Tuple<UserEntity, JsonObjectStatus> CheckLogin(string userAccount, string password);

        /// <summary>
        /// 根据条件查询用户
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        List<UserEntity> QueryUserList(Expression<Func<UserEntity, bool>> query);

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<UserEntity> GetPageList(PaginationEntity pagination, string queryJson);

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        DataTable GetTable();

        /// <summary>
        /// 用户列表（ALL）
        /// </summary>
        /// <returns></returns>
        DataTable GetAllUserTable();

        /// <summary>
        /// 导出用户列表
        /// </summary>
        /// <returns></returns>
        DataTable GetExportList();

        #endregion 获取数据

        #region 验证数据

        /// <summary>
        /// 账户不能重复
        /// </summary>
        /// <param name="account">账户值</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistAccount(string account, string keyValue);

        #endregion 验证数据

        #region 提交数据

        /// <summary>
        /// 新增一个用户
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns></returns>
        bool AddUser(UserEntity user);

        /// <summary>
        /// 批量新增用户
        /// </summary>
        /// <param name="users">用户实体集合</param>
        void AddUser(List<UserEntity> users);

        /// <summary>
        /// 保存用户表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="userEntity">用户实体</param>
        /// <param name="objectId">用户ID</param>
        /// <returns></returns>
        bool AddUser(string keyValue, UserEntity userEntity,out string objectId);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveUserByKey(string keyValue);

        /// <summary>
        /// 修改用户登录密码
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="password">新密码（MD5 小写）</param>
        /// <param name="secretkey">密钥</param>
        void RevisePassword(string keyValue, string password, string secretkey);

        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="state">状态：1-启动 0-禁用</param>
        void UpdateUserState(string keyValue, int state);

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="userEntity">实体对象</param>
        void UpdateUserInfo(UserEntity userEntity);

        #endregion 提交数据
    }
}