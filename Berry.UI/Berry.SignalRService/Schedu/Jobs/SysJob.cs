using System;
using System.Collections.Generic;
using Berry.Cache;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Quartz;

namespace Berry.SignalRService.Schedu.Jobs
{
    /// <summary>
    /// 系统推送
    /// </summary>
    public class SysJob : IJob
    {
        /// <summary>
        /// 系统缓存
        /// </summary>
        private readonly WebCache _cache = WebCache.WebCacheInstance;

        private IHubConnectionContext<dynamic> _clients;

        //private SysJob(IHubConnectionContext<dynamic> clients)
        //{
        //    Clients = clients;
        //}

        /// <summary>
        /// 执行函数
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                JobKey jobkey = context.JobDetail.Key;

                _clients = (IHubConnectionContext<dynamic>)context.JobDetail.JobDataMap.Get("Clients");

                var testDat = "服务器主动推送消息-->" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                List<string> connidList = GetUserConnList(jobkey.Name);

                //向所有开启服务的客户端推送查询到的数据
                _clients.Clients(connidList).BroadcastSysData(testDat);
                //string connIds = context.JobDetail.JobDataMap.GetString("connIds");
            }
            catch (System.Exception e)
            {
                throw new HubException("发送消息发生异常.", new { message = e.Message });
            }
        }

        /// <summary>
        /// 获取准备推送数据的在线用户列表
        /// </summary>
        /// <param name="jobName"></param>
        /// <returns></returns>
        private List<string> GetUserConnList(string jobName)
        {
            List<string> res = new List<string>();
            Dictionary<string, string> dict = _cache.GetCache<Dictionary<string, string>>("__ConnectionUserCacheKey");
            if (dict.Count > 0)
            {
                List<string> userIdsList = new List<string>();
                foreach (KeyValuePair<string, string> pair in dict)
                {
                    if (!pair.Key.Contains("S_"))
                        userIdsList.Add(pair.Key);
                }

                List<string> temp = new List<string>();
                foreach (string userId in userIdsList)
                {
                    List<string> usedJobList = _cache.GetCache<List<string>>(userId + "_UsedJobListCacheKey");
                    if (usedJobList != null && usedJobList.Contains(jobName))
                    {
                        temp.Add(userId);
                    }
                }

                foreach (string s in temp)
                {
                    if (dict.ContainsKey(s))
                    {
                        res.Add(dict[s]);
                    }
                }
            }
            return res;
        }
    }
}