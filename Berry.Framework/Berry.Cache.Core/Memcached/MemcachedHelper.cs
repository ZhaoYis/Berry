using System.Collections.Generic;
using System.Net;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;

namespace Berry.Cache.Core.Memcached
{
    /// <summary>
    /// Memcached帮助类
    /// </summary>
    public class MemcachedHelper
    {
        /// <summary>
        /// 服务列表
        /// </summary>
        private List<IPEndPoint> ServerList = new List<IPEndPoint>();

        /// <summary>
        /// 默认配置
        /// </summary>
        public MemcachedHelper()
        {
            ServerList.Add(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11211));
        }

        /// <summary>
        /// 自定义服务器
        /// </summary>
        /// <param name="server"></param>
        public MemcachedHelper(List<IPEndPoint> server)
        {
            this.ServerList = server;
        }

        /// <summary>
        /// 创建Memcache客户端
        /// </summary>
        /// <returns></returns>
        public MemcachedClient CreateServer()
        {
            MemcachedClientConfiguration config = new MemcachedClientConfiguration();//创建配置参数
            foreach (IPEndPoint server in ServerList)
            {
                config.Servers.Add(new IPEndPoint(IPAddress.Parse(server.Address.ToString()), server.Port));//增加服务节点
            }

            config.Protocol = MemcachedProtocol.Text;
            config.Authentication.Type = typeof(PlainTextAuthenticator);//设置验证模式
            config.Authentication.Parameters["userName"] = "";//用户名参数
            config.Authentication.Parameters["password"] = "";//密码参数
            MemcachedClient mac = new MemcachedClient(config);//创建客户端
            return mac;
        }

        /// <summary>
        /// 创建Memcache客户端
        /// </summary>
        /// <returns></returns>
        public MemcachedClient CreateServer(List<IPEndPoint> serverList)
        {
            MemcachedClientConfiguration config = new MemcachedClientConfiguration();//创建配置参数
            foreach (IPEndPoint server in serverList)
            {
                config.Servers.Add(new IPEndPoint(IPAddress.Parse(server.Address.ToString()), server.Port));//增加服务节点
            }

            config.Protocol = MemcachedProtocol.Text;
            config.Authentication.Type = typeof(PlainTextAuthenticator);//设置验证模式
            config.Authentication.Parameters["userName"] = "";//用户名参数
            config.Authentication.Parameters["password"] = "";//密码参数
            MemcachedClient mac = new MemcachedClient(config);//创建客户端
            return mac;
        }

    }
}