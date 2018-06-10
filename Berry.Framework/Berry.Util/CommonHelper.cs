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
        /// <param name="format">格式化</param>
        /// <example>N：38bddf48f43c48588e0d78761eaa1ce6</example>>
        /// <example>P：(778406c2-efff-4262-ab03-70a77d09c2b5)</example>>
        /// <example>B：{09f140d5-af72-44ba-a763-c861304b46f8}</example>>
        /// <example>D：57d99d89-caab-482a-a0e9-a0a803eed3ba</example>>
        /// <returns></returns>
        public static string GetGuid(bool needReplace = true, string format = "N")
        {
            Guid res = NewSequentialGuid();//Guid.NewGuid();

            return needReplace ? res.ToString(format) : res.ToString();
        }

        [System.Runtime.InteropServices.DllImport("rpcrt4.dll", SetLastError = true)]
        static extern int UuidCreateSequential(byte[] buffer);
        /// <summary>
        /// 创建有序GUID
        /// </summary>
        /// <returns></returns>
        private static Guid NewSequentialGuid()
        {
            byte[] raw = new byte[16];
            if (UuidCreateSequential(raw) != 0)
                throw new System.ComponentModel.Win32Exception(System.Runtime.InteropServices.Marshal.GetLastWin32Error());

            byte[] fix = new byte[16];

            // 反转 0..3
            fix[0x0] = raw[0x3];
            fix[0x1] = raw[0x2];
            fix[0x2] = raw[0x1];
            fix[0x3] = raw[0x0];

            // 反转 4 & 5
            fix[0x4] = raw[0x5];
            fix[0x5] = raw[0x4];

            // 反转 6 & 7
            fix[0x6] = raw[0x7];
            fix[0x7] = raw[0x6];

            // 后8位不做操作，实际为当前MAC地址
            fix[0x8] = raw[0x8];
            fix[0x9] = raw[0x9];
            fix[0xA] = raw[0xA];
            fix[0xB] = raw[0xB];
            fix[0xC] = raw[0xC];
            fix[0xD] = raw[0xD];
            fix[0xE] = raw[0xE];
            fix[0xF] = raw[0xF];

            return new Guid(fix);
        }

        #endregion 获取全局唯一GUID

        #region Stopwatch计时器
        /// <summary>
        /// 计时器开始
        /// </summary>
        /// <returns></returns>
        public static System.Diagnostics.Stopwatch TimerStart()
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Reset();
            watch.Start();
            return watch;
        }
        /// <summary>
        /// 计时器结束
        /// </summary>
        /// <param name="watch"></param>
        /// <returns></returns>
        public static string TimerEnd(System.Diagnostics.Stopwatch watch)
        {
            watch.Stop();
            double costtime = watch.ElapsedMilliseconds;
            return costtime.ToString();
        }
        #endregion
    }
}