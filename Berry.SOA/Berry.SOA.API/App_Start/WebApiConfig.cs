using System;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;
using System.Web.Routing;
using Berry.Extension;
using Berry.SOA.API.Caching;
using Berry.SOA.API.Explorer;
using Berry.SOA.API.Filters;
using Berry.SOA.API.Handlers;
using Berry.SOA.API.Selector;
using Berry.Util;

namespace Berry.SOA.API
{
    /// <summary>
    /// Web API 配置和服务
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API 路由
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultVersionApi",
            //    routeTemplate: "api/{version}/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional, version = "v1" },
            //    constraints: new { HttpMethod = new HttpMethodConstraint("GET", "POST", "OPTIONS") }
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { HttpMethod = new HttpMethodConstraint("GET", "POST", "OPTIONS") }
            );

            //注册自定义API过滤器，接口授权
            //config.Filters.Add(new ApiSecurityFilter());
            config.Filters.Add(new CustomActionFilterAttribute());

            //注册自定义Action过滤器
            config.Filters.Add(new ActionFilter());

            //添加版本控制
            config.Services.Replace(typeof(IHttpControllerSelector), new WebApiControllerSelector(config));

            //注册自定义API探测器
            config.Services.Replace(typeof(IApiExplorer), new CustomApiExplorer(config));

            //注册请求频率限制
            RegisterRequestLimitHandlers(config);

            //启用跨域
            //EnableCorsAttribute cors = new EnableCorsAttribute(ConfigHelper.GetValue("Origins"), "*", "GET,POST,OPTIONS,DELETE,PUT");
            //config.EnableCors(cors);

            //解决自定义请求头下的跨域问题
            config.MessageHandlers.Add(new CrosHandler());
        }

        /// <summary>
        /// 注册请求频率限制
        /// </summary>
        /// <param name="config"></param>
        private static void RegisterRequestLimitHandlers(HttpConfiguration config)
        {
            //请求频率限制，默认一分钟60次
            int times = ConfigHelper.GetValue("RequestFrequencyLimit").TryToInt32();
            times = times == 0 ? 60 : times;

            config.MessageHandlers.Add(new RequestFrequencyLimitHandlers(
                new InMemoryThrottleStore(),
                no => times,
                TimeSpan.FromMinutes(1)));
        }
    }
}
