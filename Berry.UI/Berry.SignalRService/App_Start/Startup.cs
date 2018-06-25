using Berry.SignalRService.Handle;
using Berry.SignalRService.Models;
using Berry.SignalRService.Pipeline;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(Berry.SignalRService.Startup))]
namespace Berry.SignalRService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //异常处理
            GlobalHost.HubPipeline.AddModule(new ErrorHandlingPipelineModule());

            //自定义管道
            GlobalHost.HubPipeline.AddModule(new LoggingPipelineModule());

            //允许跨域推送
            app.UseCors(CorsOptions.AllowAll);

            HubConfiguration hubConfiguration = new HubConfiguration
            {
                EnableJSONP = true,
                EnableDetailedErrors = true
            };

            #region 以下两种方式任选其一
            //注册永久连接
            app.Map("/signalr/echo", map =>
            {
                map.RunSignalR<EchoConnection>(hubConfiguration);
            });
            //注册集线器
            app.Map("/signalr/hubs", map =>
            {
                map.RunSignalR(hubConfiguration);
            });
            #endregion
        }
    }
}