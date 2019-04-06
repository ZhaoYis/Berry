using Berry.BLL.CustomManage;
using Berry.Entity.CustomManage;
using Berry.Util;
using Senparc.NeuChar.Context;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.MP.MessageHandlers;
using System.IO;

namespace Berry.SOA.API.Controllers.Base
{
    /// <summary>
    /// 自定义MessageHandler
    /// 把MessageHandler作为基类，重写对应请求的处理方法
    /// </summary>
    public partial class CustomMessageHandler : MessageHandler<CustomMessageContext>
    {
        private WechatConfigBLL wechatConfigBll = new WechatConfigBLL();
        /// <summary>
        /// 微信授权信息
        /// </summary>
        private static WechatConfigEntity _wechatConfig = null;

        /// <summary>
        /// 自定义消息处理
        /// </summary>
        /// <param name="postModel"></param>
        /// <param name="inputStream"></param>
        /// <param name="maxRecordCount"></param>
        public CustomMessageHandler(Stream inputStream, PostModel postModel, int maxRecordCount = 0)
            : base(inputStream, postModel, maxRecordCount)
        {
            ////这里设置仅用于测试，实际开发可以在外部更全局的地方设置，
            ////比如MessageHandler<MessageContext>.GlobalGlobalMessageContext.ExpireMinutes = 3。
            GlobalMessageContext.ExpireMinutes = 3;

            //if (!string.IsNullOrEmpty(postModel.AppId))
            //{
            //    appId = postModel.AppId;//通过第三方开放平台发送过来的请求
            //}

            //在指定条件下，不使用消息去重
            base.OmitRepeatedMessageFunc = requestMessage =>
            {
                var textRequestMessage = requestMessage as RequestMessageText;
                if (textRequestMessage != null && textRequestMessage.Content == "容错")
                {
                    return false;
                }
                return true;
            };
        }

        /// <summary>
        /// 全局消息上下文
        /// </summary>
        public sealed override GlobalMessageContext<CustomMessageContext, IRequestMessageBase, IResponseMessageBase> GlobalMessageContext
        {
            get { return base.GlobalMessageContext; }
        }

        #region 微信认证事件推送

        /// <summary>
        /// 资质认证成功（此时立即获得接口权限）
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_QualificationVerifySuccessRequest(RequestMessageEvent_QualificationVerifySuccess requestMessage)
        {
            return new SuccessResponseMessage();
        }

        /// <summary>
        /// 资质认证失败
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_QualificationVerifyFailRequest(RequestMessageEvent_QualificationVerifyFail requestMessage)
        {
            return new SuccessResponseMessage();
        }

        /// <summary>
        /// 名称认证成功（即命名成功）
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_NamingVerifySuccessRequest(RequestMessageEvent_NamingVerifySuccess requestMessage)
        {
            return new SuccessResponseMessage();
        }

        /// <summary>
        /// 名称认证失败（这时虽然客户端不打勾，但仍有接口权限）
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_NamingVerifyFailRequest(RequestMessageEvent_NamingVerifyFail requestMessage)
        {
            return new SuccessResponseMessage();
        }

        /// <summary>
        /// 年审通知
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_AnnualRenewRequest(RequestMessageEvent_AnnualRenew requestMessage)
        {
            return new SuccessResponseMessage();
        }

        /// <summary>
        /// 认证过期失效通知
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_VerifyExpiredRequest(RequestMessageEvent_VerifyExpired requestMessage)
        {
            return new SuccessResponseMessage();
        }

        #endregion

        ///// <summary>
        ///// Event事件类型请求之subscribe
        ///// </summary>
        ///// <param name="requestMessage"></param>
        ///// <returns></returns>
        //public override IResponseMessageBase OnEvent_SubscribeRequest(RequestMessageEvent_Subscribe requestMessage)
        //{
        //    var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
        //    responseMessage.Content = "欢迎关注-DSX用于测试的消息";
        //    return responseMessage;
        //}

        /// <summary>
        /// Event事件类型请求之subscribe
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_SubscribeRequest(RequestMessageEvent_Subscribe requestMessage)
        {
            if (_wechatConfig == null)
            {
                string orgId = ConfigHelper.GetValue("OrgId");
                _wechatConfig = wechatConfigBll.GetEntityByOrgId(orgId);
            }

            if (_wechatConfig != null)
            {
                var responseMessage = this.CreateResponseMessage<ResponseMessageNews>();
                string regUrl = string.Format("{0}/base_info", _wechatConfig.WxDomainUrl);

                var container = new MessageContainer<Article>
                {
                    new Article()
                    {
                        Title = "感谢您的关注",
                        Description = "绑定帐号后即可享受健康信息推送服务",
                        Url = regUrl,
                        PicUrl = string.Format("{0}/static/img/register.png",_wechatConfig.WxDomainUrl)
                    }
                };
                responseMessage.Articles = container;
                return responseMessage;
            }
            else
            {
                var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
                responseMessage.Content = "感谢您的关注！";
                return responseMessage;
            }
        }

        /// <summary>
        /// Event事件类型请求之unsubscribe
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_UnsubscribeRequest(RequestMessageEvent_Unsubscribe requestMessage)
        {
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "感谢您的使用，拜拜！-DSX用于测试的消息";
            return responseMessage;
        }

        /// <summary>
        /// 发送模板消息返回结果
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_TemplateSendJobFinishRequest(RequestMessageEvent_TemplateSendJobFinish requestMessage)
        {
            return base.OnEvent_TemplateSendJobFinishRequest(requestMessage);
        }

        /// <summary>
        /// 事件之URL跳转视图（View）
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ViewRequest(RequestMessageEvent_View requestMessage)
        {
            return base.OnEvent_ViewRequest(requestMessage);
        }

        /// <summary>
        /// 默认消息
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "您发送的消息类型暂未被识别。";
            return responseMessage;
        }

        /// <summary>
        /// 未知消息类型默认消息
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnUnknownTypeRequest(RequestMessageUnknownType requestMessage)
        {
            var msgType = MsgTypeHelper.GetRequestMsgTypeString(requestMessage.RequestDocument);

            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "未知消息类型：" + msgType;

            return responseMessage;
            //return base.OnUnknownTypeRequest(requestMessage);
        }
    }
}