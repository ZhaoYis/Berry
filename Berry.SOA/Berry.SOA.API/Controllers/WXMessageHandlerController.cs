using System;
using System.IO;
using System.Web.Mvc;
using Berry.BLL.CustomManage;
using Berry.Entity.CustomManage;
using Berry.Extension;
using Berry.Log;
using Berry.SOA.API.Controllers.Base;
using Berry.SOA.API.Controllers.Interface;
using Berry.Util;
using Senparc.Weixin;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MvcExtension;

namespace Berry.SOA.API.Controllers
{
    /// <summary>
    /// 微信推给开发者的消息处理。微信后台的【接口配置信息】的url填写如：http://domain.weixin.com/WXMessageHandler
    /// </summary>
    public class WXMessageHandlerController : BaseController, IWXMessageHandler
    {
        //private const string Token = "BA364CC8F08749DDA4D97850B2084AE1";
        //private const string EncodingAESKey = "nVMPNUosmGYIpS5i4rhMhqtfU9pDaDgIUDzkmZYPtUL";

        private const string Token = "1F5FB204541245648F457957B9F50815";
        private const string EncodingAESKey = "AtMfmYvqlcWjyjfVjXTgpdfZh2wERMDUdewhWDgVuv9";

        private readonly Func<string> _getRandomFileName = () => DateTime.Now.ToString("yyyyMMdd-HHmmss") + Guid.NewGuid().ToString("n").Substring(0, 6);

        private WechatConfigBLL wechatConfigBll = new WechatConfigBLL();
        private LogHelper logHelper = new LogHelper(typeof(WXMessageHandlerController));
        /// <summary>
        /// 微信授权信息
        /// </summary>
        private static WechatConfigEntity _wechatConfig = null;
        
        /// <summary>
        /// 微信后台地址验证
        /// </summary>
        /// <param name="postModel">消息</param>
        /// <param name="echostr">随机字符串</param>
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get(PostModel postModel, string echostr)
        {
            //WeixinTrace.Log("请求到达(Get)，数据包：" + postModel.TryToJson());
            logHelper.Info("请求到达(Get)，数据包：" + postModel.TryToJson());

            if (CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, Token))
            {
                return Content(echostr); //返回随机字符串则表示验证通过
            }
            else
            {
                return Content("failed:" + postModel.Signature + "," + CheckSignature.GetSignature(postModel.Timestamp, postModel.Nonce, Token) + "。" +
                               "如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
            }
        }

        /// <summary>
        /// 用户发送消息后，微信平台自动POST一个请求到这里，并等待响应XML。
        /// </summary>
        /// <param name="postModel">消息</param>
        [HttpPost]
        [ActionName("Index")]
        public ActionResult Post(PostModel postModel)
        {
            //WeixinTrace.Log("请求到达(Post)，数据包：" + postModel.TryToJson());
            logHelper.Info("请求到达(Post)，数据包：" + postModel.TryToJson());

            if (!CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, Token))
            {
                return Content("参数错误！");
            }

            if (_wechatConfig == null)
            {
                string orgId = ConfigHelper.GetValue("OrgId");
                _wechatConfig = wechatConfigBll.GetEntityByOrgId(orgId);

                logHelper.Info("微信配置信息：" + _wechatConfig.TryToJson());
            }

            if (_wechatConfig != null)
            { 
                #region 打包 PostModel 信息

                postModel.Token = Token; //根据自己后台的设置保持一致
                postModel.EncodingAESKey = EncodingAESKey; //根据自己后台的设置保持一致
                postModel.AppId = _wechatConfig.AppId; //根据自己后台的设置保持一致

                #endregion

                //v4.2.2之后的版本，可以设置每个人上下文消息储存的最大数量，防止内存占用过多，如果该参数小于等于0，则不限制
                var maxRecordCount = 10;

                //自定义MessageHandler，对微信请求的详细判断操作都在这里面。
                var messageHandler = new CustomMessageHandler(Request.InputStream, postModel, maxRecordCount);

                #region 设置消息去重

                /* 如果需要添加消息去重功能，只需打开OmitRepeatedMessage功能，SDK会自动处理。
                 * 收到重复消息通常是因为微信服务器没有及时收到响应，会持续发送2-5条不等的相同内容的RequestMessage*/
                messageHandler.OmitRepeatedMessage = true; //默认已经开启，此处仅作为演示，也可以设置为false在本次请求中停用此功能

                #endregion

                try
                {
                    //messageHandler.SaveRequestMessageLog(); //记录 Request 日志（可选）
                    #region 记录 Request 日志

                    var logPath = Server.MapPath(string.Format("~/App_Data/MP/{0}/", DateTime.Now.ToString("yyyy-MM-dd")));
                    if (!Directory.Exists(logPath))
                    {
                        Directory.CreateDirectory(logPath);
                    }

                    //测试时可开启此记录，帮助跟踪数据，使用前请确保App_Data文件夹存在，且有读写权限。
                    messageHandler.RequestDocument.Save(Path.Combine(logPath, string.Format("{0}_Request_{1}_{2}.txt", _getRandomFileName(),
                        messageHandler.RequestMessage.FromUserName,
                        messageHandler.RequestMessage.MsgType)));
                    if (messageHandler.UsingEcryptMessage)
                    {
                        messageHandler.EcryptRequestDocument.Save(Path.Combine(logPath, string.Format("{0}_Request_Ecrypt_{1}_{2}.txt", _getRandomFileName(),
                            messageHandler.RequestMessage.FromUserName,
                            messageHandler.RequestMessage.MsgType)));
                    }

                    #endregion

                    messageHandler.Execute(); //执行微信处理过程（关键）

                    //messageHandler.SaveResponseMessageLog(); //记录 Response 日志（可选）
                    #region 记录 Response 日志

                    //测试时可开启，帮助跟踪数据

                    //if (messageHandler.ResponseDocument == null)
                    //{
                    //    throw new Exception(messageHandler.RequestDocument.ToString());
                    //}
                    if (messageHandler.ResponseDocument != null)
                    {
                        messageHandler.ResponseDocument.Save(Path.Combine(logPath, string.Format("{0}_Response_{1}_{2}.txt", _getRandomFileName(),
                            messageHandler.ResponseMessage.ToUserName,
                            messageHandler.ResponseMessage.MsgType)));
                    }

                    if (messageHandler.UsingEcryptMessage && messageHandler.FinalResponseDocument != null)
                    {
                        //记录加密后的响应信息
                        messageHandler.FinalResponseDocument.Save(Path.Combine(logPath, string.Format("{0}_Response_Final_{1}_{2}.txt", _getRandomFileName(),
                            messageHandler.ResponseMessage.ToUserName,
                            messageHandler.ResponseMessage.MsgType)));
                    }

                    #endregion

                    //return Content(messageHandler.ResponseDocument.ToString());//v0.7-
                    //return new WeixinResult(messageHandler);//v0.8+
                    return new FixWeixinBugWeixinResult(messageHandler); //为了解决官方微信5.0软件换行bug暂时添加的方法，平时用下面一个方法即可
                }
                catch (Exception ex)
                {
                    WeixinTrace.Log(string.Format("MessageHandler错误：{0}", ex.Message));
                    return Content("");
                }
            }
            else
            {
                return Content("未找到当前机构微信配置信息！");
            }
        }
    }
}
