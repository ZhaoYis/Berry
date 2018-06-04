using System;

namespace Berry.Code
{
    /// <summary>
    /// 自定义特性
    /// </summary>
    public class CustomAttribute
    {
    }

    /// <summary>
    /// 主键字段特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class PrimaryKeyAttribute : Attribute
    {
        public PrimaryKeyAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string Name { get; set; }
    }
    
}