using Microsoft.AspNet.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace Berry.SignalRService.Models
{
    /// <summary>
    /// 创建永久连接
    /// </summary>
    public class EchoConnection : PersistentConnection
    {
        /// <summary>
        /// 连接数
        /// </summary>
        private static int _connections = 0;

        /// <summary>
        /// 连接创建
        /// </summary>
        protected override async Task OnConnected(IRequest request, string connectionId)
        {
            Interlocked.Increment(ref _connections);
            await Connection.Send(connectionId, "双向连接成功，连接ID：" + connectionId);

            System.Diagnostics.Trace.WriteLine("双向连接成功，连接ID：" + connectionId);
            System.Diagnostics.Trace.WriteLine("=====================================");
            System.Diagnostics.Trace.WriteLine("新的连接加入，连接ID：" + connectionId + ",已有连接数：" + _connections);

            //广播消息
            await Connection.Broadcast("新的连接加入，连接ID：" + connectionId + ",已有连接数：" + _connections);
        }

        /// <summary>
        /// 连接断开
        /// </summary>
        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            Interlocked.Decrement(ref _connections);

            System.Diagnostics.Trace.WriteLine(connectionId + "退出连接，已有连接数：" + _connections);

            return Connection.Broadcast(connectionId + "退出连接，已有连接数：" + _connections);
        }

        /// <summary>
        /// 接受到消息
        /// </summary>
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            var message = connectionId + "发送内容>>" + data;

            System.Diagnostics.Trace.WriteLine(message);

            return Connection.Broadcast(data);
        }
    }
}