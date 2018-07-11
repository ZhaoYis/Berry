using System;

namespace Berry.SOA.API.Attributes
{
    /// <summary>
    /// 忽略特殊Action方法
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class IngoreActionAttribute : Attribute
    {
        
    }
}