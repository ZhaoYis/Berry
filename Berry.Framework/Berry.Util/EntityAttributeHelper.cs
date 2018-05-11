using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace Berry.Util
{
    /// <summary>
    /// 获取实体类Attribute自定义属性
    /// </summary>
    public sealed class EntityAttributeHelper
    {
        /// <summary>
        ///  获取实体对象Key
        /// </summary>
        /// <returns></returns>
        public static string GetEntityKey<T>()
        {
            Type type = typeof(T);
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                foreach (Attribute attr in prop.GetCustomAttributes(true))
                {
                    KeyAttribute keyattribute = attr as KeyAttribute;
                    if (keyattribute != null)
                    {
                        return prop.Name;
                    }
                }
            }
            return null;
        }

        /// <summary>
        ///  获取实体对象Key
        /// </summary>
        /// <returns></returns>
        public static List<string> GetNotMappedFields<T>()
        {
            Type type = typeof(T);
            PropertyInfo[] props = type.GetProperties();
            List<string> res = new List<string>();
            foreach (PropertyInfo prop in props)
            {
                foreach (Attribute attr in prop.GetCustomAttributes(true))
                {
                    NotMappedAttribute keyattribute = attr as NotMappedAttribute;
                    if (keyattribute != null)
                    {
                        res.Add(prop.Name);
                    }
                }
            }
            return res;
        }

        /// <summary>
        ///  获取实体对象表名
        /// </summary>
        /// <returns></returns>
        public static string GetEntityTable<T>()
        {
            Type objTye = typeof(T);
            string entityName = "";
            var tableAttribute = objTye.GetCustomAttributes(true).OfType<TableAttribute>();
            var descriptionAttributes = tableAttribute as TableAttribute[] ?? tableAttribute.ToArray();

            entityName = descriptionAttributes.Any() ? descriptionAttributes.ToList()[0].Name : objTye.Name;
            return entityName;
        }

        /// <summary>
        /// 获取实体类 字段中文名称
        /// </summary>
        /// <param name="pi">字段属性信息</param>
        /// <returns></returns>
        public static string GetFieldText(PropertyInfo pi)
        {
            string txt = "";
            var descAttrs = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);
            if (descAttrs.Any())
            {
                DisplayNameAttribute descAttr = descAttrs[0] as DisplayNameAttribute;
                if (descAttr != null) txt = descAttr.DisplayName;
            }
            else
            {
                txt = pi.Name;
            }
            return txt;
        }

        /// <summary>
        /// 获取实体类中文名称
        /// </summary>
        /// <returns></returns>
        public static string GetClassName<T>()
        {
            Type objTye = typeof(T);
            string entityName = "";
            var busingessNames = objTye.GetCustomAttributes(true).OfType<DisplayNameAttribute>();
            var descriptionAttributes = busingessNames as DisplayNameAttribute[] ?? busingessNames.ToArray();
            if (descriptionAttributes.Any())
            {
                entityName = descriptionAttributes.ToList()[0].DisplayName;
            }
            else
            {
                entityName = objTye.Name;
            }
            return entityName;
        }

        /// <summary>
        /// 获取访问元素
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}