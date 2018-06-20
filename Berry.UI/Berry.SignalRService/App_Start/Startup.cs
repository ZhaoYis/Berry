using Berry.SignalRService.Handle;
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

            app.MapSignalR();
        }
    }
}