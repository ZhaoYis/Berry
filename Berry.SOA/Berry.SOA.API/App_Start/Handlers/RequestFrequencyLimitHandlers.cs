using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Berry.Code;
using Berry.Entity;
using Berry.Extension;
using Berry.SOA.API.Caching;

namespace Berry.SOA.API.Handlers
{
    /// <summary>
    /// 请求频率限制
    /// </summary>
    public sealed class RequestFrequencyLimitHandlers : DelegatingHandler
    {
        private readonly IThrottleStore _store;
        private readonly Func<string, long> _maxRequestsForUserIdentifier;
        private readonly TimeSpan _period;
        private readonly string _message;
        private RequestFrequencyLimitHandlers()
        {
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="store"></param>
        /// <param name="maxRequestsForUserIdentifier"></param>
        /// <param name="period"></param>
        /// <param name="message"></param>
        public RequestFrequencyLimitHandlers(IThrottleStore store, Func<string, long> maxRequestsForUserIdentifier, TimeSpan period, string message = "对不起，您的请求频率过高（{0}次/分钟），请稍后再试。")
        {
            _store = store;
            _maxRequestsForUserIdentifier = maxRequestsForUserIdentifier;
            _period = period;
            _message = message;
        }

        /// <summary>
        /// 获取请求IP地址
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string GetUserIdentifier(HttpRequestMessage request)
        {
            return request.GetClientIpAddress();
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Key，即IP地址
            string identifier = GetUserIdentifier(request);

            if (string.IsNullOrEmpty(identifier))
            {
                return CreateResponse(request, HttpStatusCode.Forbidden, "无法识别客户机.");
            }

            long maxRequests = _maxRequestsForUserIdentifier(identifier);

            Trace.WriteLine("IP地址为：" + identifier + "，请求了服务。");

            ThrottleEntry entry;
            if (_store.TryGetValue(identifier, out entry))
            {
                if (entry.PeriodStart + _period < DateTime.UtcNow)
                {
                    _store.Rollover(identifier);
                }
            }
            _store.IncrementRequests(identifier);
            if (!_store.TryGetValue(identifier, out entry))
            {
                return CreateResponse(request, HttpStatusCode.Forbidden, "无法识别客户机.");
            }

            Task<HttpResponseMessage> response = entry.Requests > maxRequests ? CreateResponse(request, HttpStatusCode.Conflict, string.Format(_message, maxRequests)) : base.SendAsync(request, cancellationToken);

            return response.ContinueWith(task =>
            {
                long remaining = maxRequests - entry.Requests;
                if (remaining < 0)
                {
                    remaining = 0;
                }

                HttpResponseMessage httpResponse = task.Result;
                httpResponse.Headers.Add("RateLimit-Limit", maxRequests.ToString());
                httpResponse.Headers.Add("RateLimit-Remaining", remaining.ToString());

                Trace.WriteLine("剩余可调用次数为：" + remaining);

                return httpResponse;
            }, cancellationToken);
        }

        /// <summary>
        /// 返回到客户端的消息
        /// </summary>
        /// <param name="request"></param>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private Task<HttpResponseMessage> CreateResponse(HttpRequestMessage request, HttpStatusCode statusCode, string message)
        {
            BaseJsonResult<string> resultMsg = new BaseJsonResult<string> { Status = (int)JsonObjectStatus.Fail, Message = message, Data = null };

            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();

            HttpResponseMessage response = resultMsg.TryToJson().ToHttpResponseMessage();
            //request.CreateResponse(statusCode);
            //response.ReasonPhrase = message;

            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}