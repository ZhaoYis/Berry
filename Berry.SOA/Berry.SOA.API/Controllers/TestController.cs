using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Berry.SOA.API.Controllers
{
    /// <summary>
    /// API测试控制器
    /// </summary>
    public class TestController : ApiController
    {
        /// <summary>
        /// 根据用户ID获取用户名
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户名</returns>
        [HttpGet]
        public string GetUserNameById(int userId)
        {
            return "用户ID：" + userId;
        }
    }
}
