using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;

namespace Berry.Util
{
    /// <summary>
    /// 公共帮助类
    /// </summary>
    public sealed class CommonHelper
    {
        #region 将XML内容转换成目标对象实体集合

        /// <summary>
        /// 将XML内容转换成目标对象实体集合
        /// </summary>
        /// <typeparam name="T">目标对象实体</typeparam>
        /// <param name="fileName">完整文件名(根目录下只需文件名称)</param>
        /// <param name="rootNodeName">根节点名称</param>
        /// <returns></returns>
        public static List<T> ConvertXmlToObject<T>(string fileName, string rootNodeName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            List<T> result = new List<T>();

            Type type = typeof(T);
            XmlNodeList nodeList = doc.ChildNodes;
            if (!string.IsNullOrEmpty(rootNodeName))
            {
                foreach (XmlNode node in doc.ChildNodes)
                {
                    if (node.Name != rootNodeName) continue;
                    nodeList = node.ChildNodes;
                    break;
                }
            }

            object obj = null;
            foreach (XmlNode node in nodeList)
            {
                if (node.NodeType == XmlNodeType.Comment || node.NodeType == XmlNodeType.XmlDeclaration) continue;
                if (type.FullName != null) obj = type.Assembly.CreateInstance(type.FullName);

                foreach (XmlNode item in node.ChildNodes)
                {
                    if (item.NodeType == XmlNodeType.Comment) continue;

                    PropertyInfo property = type.GetProperty(item.Name);
                    if (property != null)
                        property.SetValue(obj, Convert.ChangeType(item.InnerText, property.PropertyType), null);
                }
                result.Add((T)obj);
            }
            return result;
        }

        #endregion 将XML内容转换成目标对象实体集合

        #region 获取全局唯一GUID

        /// <summary>
        /// 获取全局唯一GUID
        /// </summary>
        /// <param name="needReplace">是否需要替换-</param>
        /// <returns></returns>
        public static string GetGuid(bool needReplace = true)
        {
            string res = Guid.NewGuid().ToString();

            return needReplace ? res.Replace("-", "") : res;
        }

        #endregion 获取全局唯一GUID
    }
}