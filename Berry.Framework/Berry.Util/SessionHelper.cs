using System.Web;

namespace Berry.Util
{
    /// <summary>
    /// <para>　Session操作类</para>
    /// <para>　----------------------------------------------------------</para>
    /// <para>　AddSession：添加Session,有效期为默认</para>
    /// <para>　AddSession：添加Session，并调整有效期为分钟或几年</para>
    /// <para>　GetSession：读取某个Session对象值</para>
    /// <para>　DelSession：删除某个Session对象</para>
    /// </summary>
    public static class SessionHelper
    {
        #region 添加Session,有效期为默认

        /// <summary>
        /// 添加Session,有效期为默认
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="objValue">Session值</param>
        public static void AddSession(string strSessionName, object objValue)
        {
            HttpContext context = HttpContext.Current;

            context.Session[strSessionName] = objValue;
        }

        #endregion 添加Session,有效期为默认

        #region 添加Session，并调整有效期为分钟或几年

        /// <summary>
        /// 添加Session，并调整有效期为分钟或几年
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="objValue">Session值</param>
        /// <param name="iExpires">分钟数：大于0则以分钟数为有效期，等于0则以后面的年为有效期</param>
        /// <param name="iYear">年数：当分钟数为0时按年数为有效期，当分钟数大于0时此参数随意设置</param>
        public static void AddSession(string strSessionName, object objValue, int iExpires, int iYear)
        {
            HttpContext context = HttpContext.Current;

            context.Session[strSessionName] = objValue;
            if (iExpires > 0)
            {
                context.Session.Timeout = iExpires;
            }
            else if (iYear > 0)
            {
                context.Session.Timeout = 60 * 24 * 365 * iYear;
            }
        }

        #endregion 添加Session，并调整有效期为分钟或几年

        #region 读取某个Session对象值

        /// <summary>
        /// 读取某个Session对象值
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <returns>Session对象值</returns>
        public static T GetSession<T>(string strSessionName) where T : class
        {
            HttpContext context = HttpContext.Current;

            return context.Session[strSessionName] as T;
        }

        #endregion 读取某个Session对象值

        #region 删除某个Session对象

        /// <summary>
        /// 删除某个Session对象
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        public static void RemoveSession(string strSessionName)
        {
            HttpContext context = HttpContext.Current;

            context.Session.Remove(strSessionName);
        }

        /// <summary>
        /// 删除所有Session对象
        /// </summary>
        public static void RemoveAllSession()
        {
            HttpContext context = HttpContext.Current;

            context.Session.RemoveAll();
        }

        #endregion 删除某个Session对象
    }
}