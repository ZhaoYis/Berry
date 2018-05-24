using Berry.App.Admin.Handler;
using Berry.BLL.BaseManage;
using Berry.Code.Operator;
using Berry.Entity.BaseManage;
using Berry.Util;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Berry.App.Admin.Controllers
{
    /// <summary>
    /// 个人中心
    /// </summary>
    public class PersonCenterController : BaseController
    {
        private UserBLL userBLL = new UserBLL();

        #region 视图功能

        /// <summary>
        /// 个人中心
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.userId = OperatorProvider.Provider.Current().UserId;
            return View();
        }

        #endregion 视图功能

        #region 获取数据

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult VerifyCode()
        {
            return File(VerifyCodeHelper.GetVerifyCode(), @"image/Gif");
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 上传头像
        /// </summary>
        /// <returns></returns>
        public ActionResult UploadFile()
        {
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            //没有文件上传，直接返回
            if (files[0].ContentLength == 0 || string.IsNullOrEmpty(files[0].FileName))
            {
                return HttpNotFound();
            }
            string fileEextension = Path.GetExtension(files[0].FileName);
            string userId = OperatorProvider.Provider.Current().UserId;
            string virtualPath = string.Format("/Resource/PhotoFile/{0}{1}", userId, fileEextension);

            string fullFileName = DirFileHelper.MapPath(virtualPath);
            //创建文件夹，保存文件
            string path = Path.GetDirectoryName(fullFileName);
            Directory.CreateDirectory(path);
            files[0].SaveAs(fullFileName);

            UserEntity userEntity = new UserEntity
            {
                Id = OperatorProvider.Provider.Current().UserId,
                HeadIcon = virtualPath
            };

            userBLL.AddUser(userEntity.Id, userEntity,out userId);

            return Success("上传成功。");
        }

        /// <summary>
        /// 验证旧密码
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ValidationOldPassword(string oldPassword)
        {
            oldPassword = Md5Helper.Md5(DESEncryptHelper.Encrypt(Md5Helper.Md5(oldPassword).ToLower(), OperatorProvider.Provider.Current().Secretkey).ToLower()).ToLower();
            if (oldPassword != OperatorProvider.Provider.Current().Password)
            {
                return Error("原密码错误，请重新输入");
            }
            else
            {
                return Success("通过信息验证");
            }
        }

        /// <summary>
        /// 提交修改密码
        /// </summary>
        /// <param name="password">新密码</param>
        /// <param name="oldPassword">旧密码</param>
        /// <param name="verifyCode">验证码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SubmitResetPassword(string password, string oldPassword, string verifyCode)
        {
            verifyCode = Md5Helper.Md5(verifyCode.ToLower());
            string code = Session["session_verifycode"].ToString();

            if (string.IsNullOrWhiteSpace(code) || verifyCode != code)
            {
                return Error("验证码错误，请重新输入");
            }

            string key = OperatorProvider.Provider.Current().Secretkey;
            oldPassword = Md5Helper.Md5(DESEncryptHelper.Encrypt(oldPassword, key).ToLower()).ToLower();
            if (oldPassword != OperatorProvider.Provider.Current().Password)
            {
                return Error("原密码错误，请重新输入");
            }

            string md5 = Md5Helper.Md5(password);
            string realPassword = Md5Helper.Md5(DESEncryptHelper.Encrypt(md5, key));

            userBLL.RevisePassword(OperatorProvider.Provider.Current().UserId, realPassword, key);

            Session.Abandon();
            Session.Clear();

            return Success("密码修改成功，请牢记新密码。\r 将会自动安全退出。");
        }

        #endregion 提交数据
    }
}