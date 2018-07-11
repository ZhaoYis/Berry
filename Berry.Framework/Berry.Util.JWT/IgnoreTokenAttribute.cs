using System;

namespace Berry.Util.JWT
{
    /// <summary>
    /// 忽略验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class IgnoreTokenAttribute : Attribute
    {
        public bool Ignore { get; set; }
        /// <summary>
        /// 忽略验证.默认忽略
        /// </summary>
        /// <param name="ignore"></param>
        public IgnoreTokenAttribute(bool ignore = true)
        {
            this.Ignore = ignore;
        }
    }
}