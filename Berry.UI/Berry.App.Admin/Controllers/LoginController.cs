using Berry.App.Admin.Handler;
using Berry.BLL.AuthorizeManage;
using Berry.BLL.BaseManage;
using Berry.Code;
using Berry.Code.Operator;
using Berry.Entity.BaseManage;
using Berry.Entity.SystemManage;
using Berry.Extension;
using Berry.Util;
using System;
using System.Web.Mvc;
using Berry.BLL.SystemManage;
using Berry.Entity;

namespace Berry.App.Admin.Controllers
{
    /// <summary>
    /// 系统登录
    /// </summary>
    [HandlerLogin(LoginMode.Ignore)]
    [AllowAnonymous]
    public class LoginController : BaseController
    {
        private LogBLL logBll = new LogBLL();
        private UserBLL userBll = new UserBLL();
        private AuthorizeBLL authorizeBLL = new AuthorizeBLL();
        private PermissionBLL permissionBll = new PermissionBLL();

        #region 视图功能

        /// <summary>
        /// 默认页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Default()
        {
            return View();
        }

        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        #endregion 视图功能

        #region 提交数据

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult VerifyCode()
        {
            return File(VerifyCodeHelper.GetVerifyCode(), @"image/Gif");
        }

        /// <summary>
        /// 安全退出
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult OutLogin()
        {
            #region 用户下线操作
            LogEntity logEntity = new LogEntity
            {

                CategoryId = (int)CategoryType.Login,
                OperateTypeId = ((int)OperationType.Exit).ToString(),
                OperateType = OperationType.Exit.GetEnumDescription(),
                OperateAccount = OperatorProvider.Provider.Current().Account,
                OperateUserId = OperatorProvider.Provider.Current().UserId,
                ExecuteResult = 1,
                ExecuteResultJson = "退出系统",
                Module = ConfigHelper.GetValue("SoftName")
            };
            logBll.WriteLog(logEntity);

            //TODO 更新用户下线状态
            UserEntity update = new UserEntity
            {
                Id = OperatorProvider.Provider.Current().UserId,
                LastVisit = DateTime.Now,
                UserOnLine = 2,
                EnabledMark = true,
                DeleteMark = false
            };
            userBll.UpdateUserInfo(update);

            Session.Abandon();//清除当前会话
            Session.Clear();//清除当前浏览器所有Session
            OperatorProvider.Provider.EmptyCurrent();//清除登录者信息
            CookieHelper.DelCookie("__autologin");//清除自动登录 
            #endregion

            return Content(new BaseJsonResult<string> { Status = (int)JsonObjectStatus.Success, Message = "退出系统" }.TryToJson());
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="verifycode">验证码</param>
        /// <param name="autologin">下次自动登录</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult CheckLogin(string username, string password, string verifycode, int autologin)
        {
            ActionResult res = null;
            LogEntity logEntity = new LogEntity
            {
                CategoryId = (int)CategoryType.Login,
                OperateTypeId = ((int)OperationType.Login).ToString(),
                OperateType = OperationType.Login.GetEnumDescription(),
                OperateAccount = username,
                OperateUserId = username,
                OperateTime = DateTime.Now,
                IPAddress = NetHelper.Ip,
                IPAddressName = NetHelper.GetAddressByIP(NetHelper.Ip),
                Browser = NetHelper.Browser,
                Module = ConfigHelper.GetValue("SoftName")
            };

            Logger(this.GetType(), "登录验证-CheckLogin", () =>
            {
                #region 验证码验证
                string code = Md5Helper.Md5(verifycode.ToLower());
                string sessionCode = SessionHelper.GetSession<string>("session_verifycode");
                if (string.IsNullOrEmpty(sessionCode) || code != sessionCode)
                {
                    res = Error("验证码错误，请重新输入");
                }
                #endregion

                #region 账户验证
                else
                {
                    JsonObjectStatus status;
                    UserEntity user = userBll.CheckLogin(username, password, out status);
                    if (status != JsonObjectStatus.Success || user == null)
                    {
                        res = Error(status.GetEnumDescription());
                    }
                    else
                    {
                        string objId = permissionBll.GetObjectString(user.Id);

                        OperatorEntity operators = new OperatorEntity
                        {
                            UserId = user.Id,
                            Code = user.EnCode,
                            Account = user.Account,
                            UserName = user.RealName ?? user.NickName,
                            Password = user.Password,
                            Secretkey = user.Secretkey,
                            CompanyId = user.OrganizeId,
                            DepartmentId = user.DepartmentId,
                            IPAddress = NetHelper.Ip,
                            IPAddressName = NetHelper.GetAddressByIP(NetHelper.Ip),
                            ObjectId = objId,
                            LoginTime = DateTime.Now,
                            Token = DESEncryptHelper.Encrypt(CommonHelper.GetGuid(), user.Secretkey)
                        };

                        //写入当前用户数据权限
                        string ReadAutorize = authorizeBLL.GetDataAuthor(operators);
                        string ReadAutorizeUserId = authorizeBLL.GetDataAuthorUserId(operators);
                        string WriteAutorize = authorizeBLL.GetDataAuthor(operators, true);
                        string WriteAutorizeUserId = authorizeBLL.GetDataAuthorUserId(operators, true);

                        AuthorizeDataModel dataAuthorize = new AuthorizeDataModel
                        {
                            ReadAutorize = ReadAutorize,
                            ReadAutorizeUserId = ReadAutorizeUserId,
                            WriteAutorize = WriteAutorize,
                            WriteAutorizeUserId = WriteAutorizeUserId
                        };
                        operators.DataAuthorize = dataAuthorize;
                        //判断是否系统管理员
                        operators.IsSystem = user.Account == "System";

                        //写入登录信息
                        OperatorProvider.Provider.AddCurrent(operators);

                        //写入日志
                        logEntity.ExecuteResult = 1;
                        logEntity.ExecuteResultJson = "登录成功";
                        logBll.WriteLog(logEntity);

                        res = Success("登录成功", user, "/Home/AdminDefault");
                    }
                }
                #endregion

            }, e =>
            {
                CookieHelper.DelCookie("__autologin");//清除自动登录
                logEntity.ExecuteResult = -1;
                logEntity.ExecuteResultJson = e.Message;
                logBll.WriteLog(logEntity);

                res = Error("系统异常：" + e.Message);
            }, () =>
            {
                SessionHelper.RemoveSession("session_verifycode");
            });
            return res;
        }

        #endregion 提交数据

        #region 注册账户、登录限制

        /// <summary>
        /// 登录限制
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="iPAddress">IP</param>
        /// <param name="iPAddressName">IP所在城市</param>
        public void LoginLimit(string account, string iPAddress, string iPAddressName)
        {
            //if (account == "System")
            //{
            //    return;
            //}

            //string platform = NetHelper.Browser;
            //accountBLL.LoginLimit(platform, account, iPAddress, iPAddressName);
        }

        #endregion 注册账户、登录限制
    }
}