#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Berry.SOA.API.Controllers.Interface
* 项目描述 ：
* 类 名 称 ：IWXMessageHandler
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：Berry.SOA.API.Controllers.Interface
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/3/11 14:20:09
* 更新时间 ：2019/3/11 14:20:09
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Senparc.Weixin.MP.Entities.Request;

namespace Berry.SOA.API.Controllers.Interface
{
    /// <summary>
    /// 功能描述    ：微信推给开发者的消息处理。微信后台的【接口配置信息】的url填写如：http://domain.weixin.com/WXMessageHandler
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/3/11 14:20:09 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/3/11 14:20:09 
    /// </summary>
    public interface IWXMessageHandler
    {
        /// <summary>
        /// 微信后台地址验证
        /// </summary>
        /// <param name="postModel">消息</param>
        /// <param name="echostr">随机字符串</param>
        /// <returns></returns>
        ActionResult Get(PostModel postModel, string echostr);

        /// <summary>
        /// 用户发送消息后，微信平台自动POST一个请求到这里，并等待响应XML。
        /// </summary>
        /// <param name="postModel">消息</param>
        /// <returns></returns>
        ActionResult Post(PostModel postModel);
    }
}
