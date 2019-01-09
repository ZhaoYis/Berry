using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Berry.Cache.Core.Base;
using Berry.Cache.Core.Runtime;
using Berry.SignalRService.DTO;
using Berry.SignalRService.Schedu;
using Berry.SignalRService.Schedu.Jobs;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Quartz;

namespace Berry.SignalRService.Models
{
    /// <summary>
    /// 服务端主动推送消息到客户端
    /// </summary>
    public class SignalrServerToClient : IBroadcastService
    {
        #region 实例化
        //static readonly IHubContext HubContext = GlobalHost.ConnectionManager.GetHubContext<ChatsHub>();

        private IHubConnectionContext<dynamic> Clients { get; set; }
        // 单例模式
        private static readonly Lazy<SignalrServerToClient> _instance = new Lazy<SignalrServerToClient>(() => new SignalrServerToClient(GlobalHost.ConnectionManager.GetHubContext<ChatsHub>().Clients));
        private SignalrServerToClient(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
        }

        /// <summary>
        /// 获取SignalrServerToClient实例
        /// </summary>
        public static SignalrServerToClient Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        /// <summary>
        /// 获取所有连接信息
        /// </summary>
        /// <returns></returns>
        public IHubConnectionContext<dynamic> GetClients
        {
            get
            {
                return this.Clients;
            }
        }

        #endregion

        #region 基础信息
        /// <summary>
        /// 状态锁
        /// </summary>
        private readonly object _jobStateLock = new object();
        /// <summary>
        /// 系统缓存
        /// </summary>
        private readonly ICacheService _cache = RuntimeCacheService.GetCacheInstance();
        /// <summary>
        /// 任务状态 用户ID--任务编码-任务状态
        /// </summary>
        //private readonly ConcurrentDictionary<string, Dictionary<string, JobState>> _jobStateDict = new ConcurrentDictionary<string, Dictionary<string, JobState>>();//TODO 待优化，需要解决服务挂了、被IIS回收了或者用户刷新页面

        #endregion

        #region 公共推送消息方法

        /// <summary>
        /// 向所有在线用户广播消息
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <returns></returns>
        public async Task SendMessageFormAllOnlineUser(ChatMessageDTO message)
        {
            await Clients.All.BroadcastMessageFormAllOnlineUser(message);
        }

        /// <summary>
        /// 广播系统消息，广播给所有用户
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task SendSystemMessage(string message, string title = "系统消息")
        {
            await Clients.All.BroadcastSystemMessage(title, message);
        }

        /// <summary>
        /// 发送消息给指定用户
        /// </summary>
        /// <param name="connId">用户连接（客户端）ID</param>
        /// <param name="message">消息体</param>
        /// <returns></returns>
        public async Task SendMessageByUserId(string connId, string message)
        {
            await Clients.Client(connId).BroadcastMessageByUserId(message);
        }

        #endregion

        #region 任务控制（弃用）

        ///// <summary>
        ///// 开启一个或多个任务
        ///// </summary>
        ///// <param name="userId">用户ID</param>
        ///// <param name="jobCode">任务编码</param>
        //public void OpenJob(string userId, string[] jobCode)
        //{
        //    lock (_jobStateLock)
        //    {
        //        Dictionary<string, Dictionary<string, JobState>> jobStateDict =
        //            _cache.GetCache<Dictionary<string, Dictionary<string, JobState>>>("");

        //        //已有任务
        //        Dictionary<string, JobState> historyJobStatedict = new Dictionary<string, JobState>();
        //        //新加任务
        //        Dictionary<string, JobState> newJobStatedict = new Dictionary<string, JobState>();

        //        _jobStateDict.TryGetValue(userId, out historyJobStatedict);
        //        if (historyJobStatedict == null || historyJobStatedict.Count == 0)
        //        {
        //            historyJobStatedict = new Dictionary<string, JobState>();
        //            //添加任务状态到字典
        //            foreach (string code in jobCode)
        //            {
        //                historyJobStatedict.Add(code, JobState.Open);
        //            }

        //            newJobStatedict = historyJobStatedict;

        //            _jobStateDict.TryAdd(userId, historyJobStatedict);
        //        }
        //        else
        //        {
        //            //添加未标识的任务
        //            foreach (string code in jobCode)
        //            {
        //                //如果不包含该任务，则直接添加
        //                if (!historyJobStatedict.ContainsKey(code))
        //                {
        //                    historyJobStatedict.Add(code, JobState.Open);
        //                    newJobStatedict.Add(code, JobState.Open);
        //                }
        //                else
        //                {
        //                    //如果任务是关闭状态，则开启它
        //                    if (historyJobStatedict[code] == JobState.Closed)
        //                    {
        //                        historyJobStatedict[code] = JobState.Open;
        //                        newJobStatedict.Add(code, JobState.Open);
        //                    }
        //                }
        //            }

        //            _jobStateDict[userId] = historyJobStatedict;
        //        }

        //        //TODO 调用开启、关闭任务方法
        //        this.OpenOrCloseJob(userId, newJobStatedict);
        //    }
        //}

        ///// <summary>
        ///// 关闭一个或多个任务
        ///// </summary>
        ///// <param name="userId">用户ID</param>
        ///// <param name="jobCode">任务编码</param>
        //public void CloseJob(string userId, string[] jobCode)
        //{
        //    lock (_jobStateLock)
        //    {
        //        //已有任务
        //        Dictionary<string, JobState> historyJobStatedict = new Dictionary<string, JobState>();

        //        if (_jobStateDict.Count > 0 && _jobStateDict != null)
        //        {
        //            _jobStateDict.TryGetValue(userId, out historyJobStatedict);
        //            if (historyJobStatedict != null && historyJobStatedict.Count > 0)
        //            {
        //                foreach (string code in jobCode)
        //                {
        //                    if (historyJobStatedict.ContainsKey(code))
        //                    {
        //                        if (historyJobStatedict[code] == JobState.Open)
        //                        {
        //                            historyJobStatedict[code] = JobState.Closed;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        historyJobStatedict.Add(code, JobState.Closed);
        //                    }
        //                }
        //            }
        //        }
        //        _jobStateDict[userId] = historyJobStatedict;

        //        this.OpenOrCloseJob(userId, historyJobStatedict);
        //    }
        //}

        ///// <summary>
        ///// 重置一个或多个任务
        ///// </summary>
        ///// <param name="userId">用户ID</param>
        ///// <param name="jobCode">任务编码</param>
        //public void ResetJob(string userId, string[] jobCode)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// 开启或者关闭任务
        ///// </summary>
        ///// <param name="userId"></param>
        ///// <param name="newJobStatedict"></param>
        //private void OpenOrCloseJob(string userId, Dictionary<string, JobState> newJobStatedict)
        //{
        //    foreach (KeyValuePair<string, JobState> pair in newJobStatedict)
        //    {
        //        string jobClde = pair.Key;
        //        switch (pair.Value)
        //        {
        //            case JobState.Open:
        //                //TODO 开启任务

        //                //向客户端广播消息
        //                Clients.Client(userId).BroadcastJobOpened(jobClde);
        //                break;
        //            case JobState.Closed:
        //                //TODO 关闭任务

        //                //向客户端广播消息
        //                Clients.Client(userId).BroadcastJobClosed(jobClde);
        //                break;
        //        }
        //    }
        //}

        #endregion

        #region 任务控制

        /// <summary>
        /// 开启一个或多个任务
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="connId">用户ID-连接ID</param>
        /// <param name="jobCode">任务编码</param>
        public void OpenJob(string userId, Dictionary<string, string> connId, string[] jobCode)
        {
            lock (_jobStateLock)
            {
                #region 1-获取用户列表（放在客户端连接时操作）
                ////1-获取用户列表
                List<string> jobUserList = _cache.Get<List<string>>("__JobUserCacheKey");
                if (jobUserList != null && jobUserList.Count != 0)
                {
                    //判断当前用户是否在集合里面
                    if (!jobUserList.Contains(userId))
                    {
                        jobUserList.AddRange(new List<string> { userId });
                    }
                    _cache.Add("__JobUserCacheKey", jobUserList);
                }
                else
                {
                    jobUserList = new List<string> { userId };
                    _cache.Add("__JobUserCacheKey", jobUserList);
                }
                #endregion

                #region 2-获取此用户已经在使用的任务列表
                //2-获取此用户已经在使用的任务列表
                List<string> usedJobList = _cache.Get<List<string>>(userId + "_UsedJobListCacheKey");
                if (usedJobList == null || usedJobList.Count == 0)
                {
                    usedJobList = new List<string>();
                    //如果还没使用任何任务，则直接全部加入
                    usedJobList.AddRange(jobCode);
                    //加入缓存
                    _cache.Add(userId + "_UsedJobListCacheKey", usedJobList);
                }
                else
                {
                    //检测是否重复开启
                    List<string> temp = jobCode.ToList();
                    //筛选出差集
                    //List<string> except = usedJobList.Except(temp).ToList();
                    //取并集并去重
                    List<string> union = usedJobList.Union(temp).Distinct().ToList();
                    if (union.Count > 0)
                    {
                        usedJobList = union;
                        //加入缓存
                        _cache.Add(userId + "_UsedJobListCacheKey", usedJobList);
                    }
                }
                #endregion

                #region 3-检测每个任务是否开启
                //防止重复开启任务
                Dictionary<string, JobState> doJob = new Dictionary<string, JobState>();
                //3-检测每个任务是否开启
                Dictionary<string, JobState> jobStateDict = _cache.Get<Dictionary<string, JobState>>("__JobStateCacheKey");
                if (jobStateDict == null || jobStateDict.Count == 0)
                {
                    jobStateDict = new Dictionary<string, JobState>();
                    //检测状态
                    foreach (string code in jobCode)
                    {
                        jobStateDict.Add(code, JobState.Open);
                        doJob.Add(code, JobState.Open);
                    }
                }
                else
                {
                    foreach (string code in jobCode)
                    {
                        if (!jobStateDict.ContainsKey(code))
                        {
                            jobStateDict.Add(code, JobState.Open);
                            doJob.Add(code, JobState.Open);
                        }
                        else
                        {
                            if (jobStateDict[code] == JobState.Closed)
                            {
                                jobStateDict[code] = JobState.Open;
                                doJob.Add(code, JobState.Open);
                            }
                        }
                    }
                }
                _cache.Add("__JobStateCacheKey", jobStateDict);
                #endregion

                #region 4-开启任务并推送消息
                ////4-开启任务并推送消息
                ////准备广播消息的用户ID
                //List<string> connIds = new List<string>();
                //foreach (string id in userList)
                //{
                //    connIds.Add(connId[id]);
                //}
                this.OpenJob(userId, doJob);

                #endregion

                #region 弃用代码
                ////已有任务
                //Dictionary<string, JobState> historyJobStatedict = new Dictionary<string, JobState>();
                ////新加任务
                //Dictionary<string, JobState> newJobStatedict = new Dictionary<string, JobState>();

                //_jobStateDict.TryGetValue(userId, out historyJobStatedict);
                //if (historyJobStatedict == null || historyJobStatedict.Count == 0)
                //{
                //    historyJobStatedict = new Dictionary<string, JobState>();
                //    //添加任务状态到字典
                //    foreach (string code in jobCode)
                //    {
                //        historyJobStatedict.Add(code, JobState.Open);
                //    }

                //    newJobStatedict = historyJobStatedict;

                //    _jobStateDict.TryAdd(userId, historyJobStatedict);
                //}
                //else
                //{
                //    //添加未标识的任务
                //    foreach (string code in jobCode)
                //    {
                //        //如果不包含该任务，则直接添加
                //        if (!historyJobStatedict.ContainsKey(code))
                //        {
                //            historyJobStatedict.Add(code, JobState.Open);
                //            newJobStatedict.Add(code, JobState.Open);
                //        }
                //        else
                //        {
                //            //如果任务是关闭状态，则开启它
                //            if (historyJobStatedict[code] == JobState.Closed)
                //            {
                //                historyJobStatedict[code] = JobState.Open;
                //                newJobStatedict.Add(code, JobState.Open);
                //            }
                //        }
                //    }

                //    _jobStateDict[userId] = historyJobStatedict;
                //} 
                #endregion

            }
        }

        /// <summary>
        /// 关闭一个或多个任务
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="connId">用户ID-连接ID</param>
        /// <param name="jobCode">任务编码</param>
        public void CloseJob(string userId, Dictionary<string, string> connId, string[] jobCode)
        {
            lock (_jobStateLock)
            {
                #region 1-检查是否有用户正在使用待关闭的任务
                //1-检查是否有用户正在使用待关闭的任务
                List<string> allJobList = new List<string>();
                //正在使用相关任务的用户
                List<string> userList = _cache.Get<List<string>>("__JobUserCacheKey");
                foreach (string user in userList)
                {
                    List<string> usedJobList = _cache.Get<List<string>>(user + "_UsedJobListCacheKey");
                    if (usedJobList != null && usedJobList.Count > 0)
                    {
                        allJobList.AddRange(usedJobList);
                    }
                }
                #endregion

                #region 2-判断是否需要移除此用户
                //2-判断是否需要移除此用户
                List<string> thisUserJobList = _cache.Get<List<string>>(userId + "_UsedJobListCacheKey");
                //移除需要关闭的任务
                foreach (var code in jobCode)
                {
                    thisUserJobList.Remove(code);
                }
                if (thisUserJobList == null || thisUserJobList.Count == 0)
                {
                    userList.Remove(userId);
                    _cache.Add("__JobUserCacheKey", userList);
                }

                //取交集，如果有其他用户正在使用待关闭任务，则忽略此次关闭
                List<string> intersect = allJobList.Distinct().Intersect(jobCode.ToList()).ToList();
                //获取真正需要关闭的任务
                List<string> realDealJobList = jobCode.ToList().Intersect(intersect).ToList();

                if (realDealJobList.Count > 0)
                {
                    Dictionary<string, JobState> newJobStatedict = new Dictionary<string, JobState>();
                    realDealJobList.ForEach(j =>
                    {
                        newJobStatedict.Add(j, JobState.Closed);
                    });

                    //TODO 调用关闭任务的方法
                    this.CloseJob(userId, newJobStatedict);
                }
                #endregion

                Dictionary<string, JobState> jobStateDict = new Dictionary<string, JobState>();
                List<string> temp = intersect.Except(realDealJobList).ToList();
                foreach (string s in temp)
                {
                    jobStateDict.Add(s, JobState.Open);
                }
                foreach (string s in realDealJobList)
                {
                    if (!jobStateDict.ContainsKey(s))
                        jobStateDict.Add(s, JobState.Closed);
                }
                _cache.Add("__JobStateCacheKey", jobStateDict);

                #region 弃用代码
                ////已有任务
                //Dictionary<string, JobState> historyJobStatedict = new Dictionary<string, JobState>();

                //if (_jobStateDict.Count > 0 && _jobStateDict != null)
                //{
                //    _jobStateDict.TryGetValue(userId, out historyJobStatedict);
                //    if (historyJobStatedict != null && historyJobStatedict.Count > 0)
                //    {
                //        foreach (string code in jobCode)
                //        {
                //            if (historyJobStatedict.ContainsKey(code))
                //            {
                //                if (historyJobStatedict[code] == JobState.Open)
                //                {
                //                    historyJobStatedict[code] = JobState.Closed;
                //                }
                //            }
                //            else
                //            {
                //                historyJobStatedict.Add(code, JobState.Closed);
                //            }
                //        }
                //    }
                //}
                //_jobStateDict[userId] = historyJobStatedict; 
                #endregion

            }
        }

        /// <summary>
        /// 重置一个或多个任务
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="connId">用户ID-连接ID</param>
        /// <param name="jobCode">任务编码</param>
        public void ResetJob(string userId, Dictionary<string, string> connId, string[] jobCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 开启或者关闭任务
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="newJobStatedict"></param>
        private void OpenJob(string userId, Dictionary<string, JobState> newJobStatedict)
        {
            Dictionary<string, string> dict = _cache.Get<Dictionary<string, string>>("__ConnectionUserCacheKey");
            if (dict.Count > 0)
            {
                foreach (KeyValuePair<string, JobState> pair in newJobStatedict)
                {
                    string jobCode = pair.Key;
                    switch (pair.Value)
                    {
                        case JobState.Open:
                            //开启任务，操作数据，然后将数据广播给指定用户
                            //Cron表达式 ：秒  分钟  小时  日的日  月  某一天的周  年
                            //每分钟执行
                            string CronTime = "0/5 * * * * ? ";
                            //附带参数
                            JobDataMap map;

                            switch (jobCode)
                            {
                                case "SysJob":
                                    map = new JobDataMap { { "Clients", Clients } };
                                    DateTimeOffset time = QuartzUtil.AddJob<SysJob>(jobCode, CronTime, map);
                                    break;
                            }
                            //向客户端广播消息
                            if (dict.ContainsKey(userId))
                            {
                                string connId = dict[userId];
                                Clients.Client(connId).BroadcastJobOpened(jobCode + "已开启");
                            }
                            break;
                        case JobState.Closed:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 关闭任务
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="newJobStatedict">要关闭的任务</param>
        private void CloseJob(string userId, Dictionary<string, JobState> newJobStatedict)
        {
            Dictionary<string, string> dict = _cache.Get<Dictionary<string, string>>("__ConnectionUserCacheKey");
            if (dict.Count > 0)
            {
                foreach (KeyValuePair<string, JobState> pair in newJobStatedict)
                {
                    string jobClde = pair.Key;
                    switch (pair.Value)
                    {
                        case JobState.Open:
                            break;
                        case JobState.Closed:
                            // 关闭任务
                            QuartzUtil.DeleteJob(jobClde);
                            //向客户端广播消息
                            if (dict.ContainsKey(userId))
                            {
                                string connId = dict[userId];
                                Clients.Client(connId).BroadcastJobClosed(jobClde + "已关闭");
                            }
                            break;
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 更新联系人列表
        /// </summary>
        /// <param name="connId">用户ID</param>
        /// <returns></returns>
        public void UpdateUserList(string connId)
        {
            List<UserInfoDTO> userAllList = new List<UserInfoDTO>();
            List<UserInfoDTO> onLineUserList = new List<UserInfoDTO>();
            //TODO 

            this.Clients.Client(connId).IMUpdateUserList(userAllList, onLineUserList);
        }
    }
}