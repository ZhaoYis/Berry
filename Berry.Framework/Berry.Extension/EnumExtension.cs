﻿using System;
using System.ComponentModel;
using System.Reflection;

namespace Berry.Extension
{
    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 返回枚举项的描述信息
        /// </summary>
        /// <param name="value">要获取描述信息的枚举项</param>
        /// <returns>枚举想的描述信息</returns>
        public static string GetEnumDescription(this Enum value)
        {
            Type enumType = value.GetType();
            // 获取枚举常数名称
            string name = Enum.GetName(enumType, value);
            if (name != null)
            {
                // 获取枚举字段
                FieldInfo fieldInfo = enumType.GetField(name);
                if (fieldInfo != null)
                {
                    // 获取描述的属性
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
    }
}