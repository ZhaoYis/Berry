using System;

namespace Berry.Code
{
    /// <summary>
    /// 取值范围枚举
    /// </summary>
    [Flags]
    public enum NumberRangeOfValueType
    {
        /// <summary>
        /// 大于
        /// </summary>
        GreaterThan = 1,
        /// <summary>
        /// 小于
        /// </summary>
        LessThan = 2,
        /// <summary>
        /// 等于
        /// </summary>
        Equal = 4,
        /// <summary>
        /// 不等于
        /// </summary>
        NotEqual = 8,
    }
}