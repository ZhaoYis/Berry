using System;

namespace Berry.Util.Stopwatch
{
    /// <summary>
    /// 计算某一段代码执行时间帮助类
    /// </summary>
    public static class StopwatchHelper
    {
        /// <summary>
        /// 计算时间
        /// </summary>
        /// <param name="function">要被执行的代码</param>
        /// <returns></returns>
        public static string Stopwatch(Action function)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            //开始执行业务代码
            function();

            sw.Stop();
            TimeSpan timeSpan = sw.Elapsed;

            return (timeSpan.TotalMilliseconds / 1000) + "s";
        }
    }
}