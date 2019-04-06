#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：SY.HL7.Parser.Tools
* 项目描述 ：
* 类 名 称 ：XmlHL7Parser
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：SY.HL7.Parser.Tools
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/3/6 23:39:15
* 更新时间 ：2019/3/6 23:39:15
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using Berry.Extension;
using HtmlAgilityPack;
using SY.HL7.Parser.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SY.HL7.Parser.Tools
{
    /// <summary>
    /// 功能描述    ：XmlHL7Parser  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/3/6 23:39:15 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/3/6 23:39:15 
    /// </summary>
    public class XmlHL7Parser
    {
        #region 构造

        private HtmlDocument xmldoc = new HtmlDocument();

        public XmlHL7Parser()
        {

        }

        public XmlHL7Parser(string xml)
        {
            if (!string.IsNullOrEmpty(xml))
            {
                xmldoc.LoadHtml(xml);
            }
        }
        #endregion

        #region 正解析

        /// <summary>
        /// 解析
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <returns></returns>
        public T Parser<T>() where T : BaseEntity, new()
        {
            T t = new T();
            Type type = typeof(T);

            foreach (PropertyInfo p in type.GetProperties())
            {
                string path = type.GetCustomAttributeValue<HL7FiledAttribute>(x => x.XPath, p.Name);

                if (!string.IsNullOrEmpty(path))
                {
                    path = t.Root + path;
                    string val = this.GetText(xmldoc, path);
                    p.SetValue(t, val, null);
                }
            }

            return t;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <typeparam name="T1">目标类型包含的数组第1个实体类型</typeparam>
        /// <returns></returns>
        public T Parser<T, T1>() where T : BaseEntity, new() where T1 : IHL7ArrayItem, new()
        {
            T t = new T();
            Type type = typeof(T);

            foreach (PropertyInfo p in type.GetProperties())
            {
                string path = type.GetCustomAttributeValue<HL7FiledAttribute>(x => x.XPath, p.Name);
                if (!string.IsNullOrEmpty(path))
                {
                    var attr = p.GetCustomAttribute<HL7FiledAttribute>();
                    if (attr != null && !attr.IsArray)
                    {
                        path = t.Root + path;
                        string val = this.GetText(xmldoc, path.ToLower());
                        p.SetValue(t, val, null);
                    }
                    else
                    {
                        path = t.Root + path;
                        List<Dictionary<string, object>> list = this.GetTextList(xmldoc, path.ToLower());
                        if (list != null)
                        {
                            Type listItemType = typeof(T1);
                            List<T1> listo = new List<T1>();

                            foreach (Dictionary<string, object> dictionary in list)
                            {
                                T1 o = new T1();

                                foreach (KeyValuePair<string, object> pair in dictionary)
                                {
                                    foreach (PropertyInfo p1 in listItemType.GetProperties())
                                    {
                                        var attr1 = p1.GetCustomAttribute<HL7FiledAttribute>();
                                        if (t.Root + attr1.XPath == pair.Key)
                                        {
                                            p1.SetValue(o, pair.Value, null);
                                            break;
                                        }
                                    }
                                }
                                listo.Add(o);
                            }

                            p.SetValue(t, listo, null);
                        }
                    }
                }
            }

            return t;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <typeparam name="T1">目标类型包含的数组第1个实体类型</typeparam>
        /// <typeparam name="T2">目标类型包含的数组第2个实体类型</typeparam>
        /// <returns></returns>
        public T Parser<T, T1, T2>() where T : BaseEntity, new() where T1 : IHL7ArrayItem, new()
            where T2 : IHL7ArrayItem, new()
        {
            T t = new T();
            Type type = typeof(T);

            foreach (PropertyInfo p in type.GetProperties())
            {
                string path = type.GetCustomAttributeValue<HL7FiledAttribute>(x => x.XPath, p.Name);
                if (!string.IsNullOrEmpty(path))
                {
                    var attr = p.GetCustomAttribute<HL7FiledAttribute>();
                    if (!attr.IsArray)
                    {
                        path = t.Root + path;
                        string val = this.GetText(xmldoc, path.ToLower());
                        p.SetValue(t, val, null);
                    }
                    else
                    {
                        path = t.Root + path;
                        List<Dictionary<string, object>> list = this.GetTextList(xmldoc, path.ToLower());
                        if (list != null)
                        {
                            if (attr.ObjectIndex == 1)
                            {
                                Type listItemType = typeof(T1);
                                List<T1> listo = new List<T1>();

                                foreach (Dictionary<string, object> dictionary in list)
                                {
                                    T1 o = new T1();
                                    foreach (KeyValuePair<string, object> pair in dictionary)
                                    {
                                        foreach (PropertyInfo p1 in listItemType.GetProperties())
                                        {
                                            var attr1 = p1.GetCustomAttribute<HL7FiledAttribute>();
                                            if (t.Root + attr1.XPath == pair.Key)
                                            {
                                                p1.SetValue(o, pair.Value, null);
                                                break;
                                            }
                                        }
                                    }
                                    listo.Add(o);
                                }
                                p.SetValue(t, listo, null);
                            }
                            else if (attr.ObjectIndex == 2)
                            {
                                Type listItemType = typeof(T2);
                                List<T2> listo = new List<T2>();

                                foreach (Dictionary<string, object> dictionary in list)
                                {
                                    T2 o = new T2();
                                    foreach (KeyValuePair<string, object> pair in dictionary)
                                    {
                                        foreach (PropertyInfo p1 in listItemType.GetProperties())
                                        {
                                            var attr1 = p1.GetCustomAttribute<HL7FiledAttribute>();
                                            if (t.Root + attr1.XPath == pair.Key)
                                            {
                                                p1.SetValue(o, pair.Value, null);
                                                break;
                                            }
                                        }
                                    }
                                    listo.Add(o);
                                }
                                p.SetValue(t, listo, null);
                            }
                        }
                    }
                }
            }

            return t;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <typeparam name="T1">目标类型包含的数组第1个实体类型</typeparam>
        /// <typeparam name="T2">目标类型包含的数组第2个实体类型</typeparam>
        /// <typeparam name="T3">目标类型包含的数组第3个实体类型</typeparam>
        /// <returns></returns>
        public T Parser<T, T1, T2, T3>() where T : BaseEntity, new() where T1 : IHL7ArrayItem, new()
            where T2 : IHL7ArrayItem, new() where T3 : IHL7ArrayItem, new()
        {
            T t = new T();
            Type type = typeof(T);

            foreach (PropertyInfo p in type.GetProperties())
            {
                string path = type.GetCustomAttributeValue<HL7FiledAttribute>(x => x.XPath, p.Name);
                if (!string.IsNullOrEmpty(path))
                {
                    var attr = p.GetCustomAttribute<HL7FiledAttribute>();
                    if (!attr.IsArray)
                    {
                        path = t.Root + path;
                        string val = this.GetText(xmldoc, path.ToLower());
                        p.SetValue(t, val, null);
                    }
                    else
                    {
                        path = t.Root + path;
                        List<Dictionary<string, object>> list = this.GetTextList(xmldoc, path.ToLower());
                        if (list != null)
                        {
                            if (attr.ObjectIndex == 1)
                            {
                                Type listItemType = typeof(T1);
                                List<T1> listo = new List<T1>();

                                foreach (Dictionary<string, object> dictionary in list)
                                {
                                    T1 o = new T1();
                                    foreach (KeyValuePair<string, object> pair in dictionary)
                                    {
                                        foreach (PropertyInfo p1 in listItemType.GetProperties())
                                        {
                                            var attr1 = p1.GetCustomAttribute<HL7FiledAttribute>();
                                            if (t.Root + attr1.XPath == pair.Key)
                                            {
                                                p1.SetValue(o, pair.Value, null);
                                                break;
                                            }
                                        }
                                    }
                                    listo.Add(o);
                                }
                                p.SetValue(t, listo, null);
                            }
                            else if (attr.ObjectIndex == 2)
                            {
                                Type listItemType = typeof(T2);
                                List<T2> listo = new List<T2>();

                                foreach (Dictionary<string, object> dictionary in list)
                                {
                                    T2 o = new T2();
                                    foreach (KeyValuePair<string, object> pair in dictionary)
                                    {
                                        foreach (PropertyInfo p1 in listItemType.GetProperties())
                                        {
                                            var attr1 = p1.GetCustomAttribute<HL7FiledAttribute>();
                                            if (t.Root + attr1.XPath == pair.Key)
                                            {
                                                p1.SetValue(o, pair.Value, null);
                                                break;
                                            }
                                        }
                                    }
                                    listo.Add(o);
                                }
                                p.SetValue(t, listo, null);
                            }
                            else if (attr.ObjectIndex == 3)
                            {
                                Type listItemType = typeof(T3);
                                List<T3> listo = new List<T3>();
                                foreach (Dictionary<string, object> dictionary in list)
                                {
                                    T3 o = new T3();
                                    foreach (KeyValuePair<string, object> pair in dictionary)
                                    {
                                        foreach (PropertyInfo p1 in listItemType.GetProperties())
                                        {
                                            var attr1 = p1.GetCustomAttribute<HL7FiledAttribute>();
                                            if (t.Root + attr1.XPath == pair.Key)
                                            {
                                                p1.SetValue(o, pair.Value, null);
                                                break;
                                            }
                                        }
                                    }
                                    listo.Add(o);
                                }
                                p.SetValue(t, listo, null);
                            }
                        }
                    }
                }
            }

            return t;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <typeparam name="T1">目标类型包含的数组第1个实体类型</typeparam>
        /// <typeparam name="T2">目标类型包含的数组第2个实体类型</typeparam>
        /// <typeparam name="T3">目标类型包含的数组第3个实体类型</typeparam>
        /// <typeparam name="T4">目标类型包含的数组第4个实体类型</typeparam>
        /// <returns></returns>
        public T Parser<T, T1, T2, T3, T4>() where T : BaseEntity, new() where T1 : IHL7ArrayItem, new()
            where T2 : IHL7ArrayItem, new() where T3 : IHL7ArrayItem, new() where T4 : IHL7ArrayItem, new()
        {
            T t = new T();
            Type type = typeof(T);

            foreach (PropertyInfo p in type.GetProperties())
            {
                string path = type.GetCustomAttributeValue<HL7FiledAttribute>(x => x.XPath, p.Name);
                if (!string.IsNullOrEmpty(path))
                {
                    var attr = p.GetCustomAttribute<HL7FiledAttribute>();
                    if (!attr.IsArray)
                    {
                        path = t.Root + path;
                        string val = this.GetText(xmldoc, path.ToLower());
                        p.SetValue(t, val, null);
                    }
                    else
                    {
                        path = t.Root + path;
                        List<Dictionary<string, object>> list = this.GetTextList(xmldoc, path.ToLower());
                        if (list != null)
                        {
                            if (attr.ObjectIndex == 1)
                            {
                                Type listItemType = typeof(T1);
                                List<T1> listo = new List<T1>();

                                foreach (Dictionary<string, object> dictionary in list)
                                {
                                    T1 o = new T1();
                                    foreach (KeyValuePair<string, object> pair in dictionary)
                                    {
                                        foreach (PropertyInfo p1 in listItemType.GetProperties())
                                        {
                                            var attr1 = p1.GetCustomAttribute<HL7FiledAttribute>();
                                            if (t.Root + attr1.XPath == pair.Key)
                                            {
                                                p1.SetValue(o, pair.Value, null);
                                                break;
                                            }
                                        }
                                    }
                                    listo.Add(o);
                                }
                                p.SetValue(t, listo, null);
                            }
                            else if (attr.ObjectIndex == 2)
                            {
                                Type listItemType = typeof(T2);
                                List<T2> listo = new List<T2>();

                                foreach (Dictionary<string, object> dictionary in list)
                                {
                                    T2 o = new T2();
                                    foreach (KeyValuePair<string, object> pair in dictionary)
                                    {
                                        foreach (PropertyInfo p1 in listItemType.GetProperties())
                                        {
                                            var attr1 = p1.GetCustomAttribute<HL7FiledAttribute>();
                                            if (t.Root + attr1.XPath == pair.Key)
                                            {
                                                p1.SetValue(o, pair.Value, null);
                                                break;
                                            }
                                        }
                                    }
                                    listo.Add(o);
                                }
                                p.SetValue(t, listo, null);
                            }
                            else if (attr.ObjectIndex == 3)
                            {
                                Type listItemType = typeof(T3);
                                List<T3> listo = new List<T3>();
                                foreach (Dictionary<string, object> dictionary in list)
                                {
                                    T3 o = new T3();
                                    foreach (KeyValuePair<string, object> pair in dictionary)
                                    {
                                        foreach (PropertyInfo p1 in listItemType.GetProperties())
                                        {
                                            var attr1 = p1.GetCustomAttribute<HL7FiledAttribute>();
                                            if (t.Root + attr1.XPath == pair.Key)
                                            {
                                                p1.SetValue(o, pair.Value, null);
                                                break;
                                            }
                                        }
                                    }
                                    listo.Add(o);
                                }
                                p.SetValue(t, listo, null);
                            }
                            else if (attr.ObjectIndex == 4)
                            {
                                Type listItemType = typeof(T4);
                                List<T4> listo = new List<T4>();
                                foreach (Dictionary<string, object> dictionary in list)
                                {
                                    T4 o = new T4();
                                    foreach (KeyValuePair<string, object> pair in dictionary)
                                    {
                                        foreach (PropertyInfo p1 in listItemType.GetProperties())
                                        {
                                            var attr1 = p1.GetCustomAttribute<HL7FiledAttribute>();
                                            if (t.Root + attr1.XPath == pair.Key)
                                            {
                                                p1.SetValue(o, pair.Value, null);
                                                break;
                                            }
                                        }
                                    }
                                    listo.Add(o);
                                }
                                p.SetValue(t, listo, null);
                            }
                        }
                    }
                }
            }

            return t;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <typeparam name="T1">目标类型包含的数组第1个实体类型</typeparam>
        /// <typeparam name="T2">目标类型包含的数组第2个实体类型</typeparam>
        /// <typeparam name="T3">目标类型包含的数组第3个实体类型</typeparam>
        /// <typeparam name="T4">目标类型包含的数组第4个实体类型</typeparam>
        /// <typeparam name="T5">目标类型包含的数组第5个实体类型</typeparam>
        /// <returns></returns>
        public T Parser<T, T1, T2, T3, T4, T5>() where T : BaseEntity, new() where T1 : IHL7ArrayItem, new()
            where T2 : IHL7ArrayItem, new() where T3 : IHL7ArrayItem, new() where T4 : IHL7ArrayItem, new() where T5 : IHL7ArrayItem, new()
        {
            T t = new T();
            Type type = typeof(T);

            foreach (PropertyInfo p in type.GetProperties())
            {
                string path = type.GetCustomAttributeValue<HL7FiledAttribute>(x => x.XPath, p.Name);
                if (!string.IsNullOrEmpty(path))
                {
                    var attr = p.GetCustomAttribute<HL7FiledAttribute>();
                    if (!attr.IsArray)
                    {
                        path = t.Root + path;
                        string val = this.GetText(xmldoc, path.ToLower());
                        p.SetValue(t, val, null);
                    }
                    else
                    {
                        path = t.Root + path;
                        List<Dictionary<string, object>> list = this.GetTextList(xmldoc, path.ToLower());
                        if (list != null)
                        {
                            if (attr.ObjectIndex == 1)
                            {
                                Type listItemType = typeof(T1);
                                List<T1> listo = new List<T1>();

                                foreach (Dictionary<string, object> dictionary in list)
                                {
                                    T1 o = new T1();
                                    foreach (KeyValuePair<string, object> pair in dictionary)
                                    {
                                        foreach (PropertyInfo p1 in listItemType.GetProperties())
                                        {
                                            var attr1 = p1.GetCustomAttribute<HL7FiledAttribute>();
                                            if (t.Root + attr1.XPath == pair.Key)
                                            {
                                                p1.SetValue(o, pair.Value, null);
                                                break;
                                            }
                                        }
                                    }
                                    listo.Add(o);
                                }
                                p.SetValue(t, listo, null);
                            }
                            else if (attr.ObjectIndex == 2)
                            {
                                Type listItemType = typeof(T2);
                                List<T2> listo = new List<T2>();

                                foreach (Dictionary<string, object> dictionary in list)
                                {
                                    T2 o = new T2();
                                    foreach (KeyValuePair<string, object> pair in dictionary)
                                    {
                                        foreach (PropertyInfo p1 in listItemType.GetProperties())
                                        {
                                            var attr1 = p1.GetCustomAttribute<HL7FiledAttribute>();
                                            if (t.Root + attr1.XPath == pair.Key)
                                            {
                                                p1.SetValue(o, pair.Value, null);
                                                break;
                                            }
                                        }
                                    }
                                    listo.Add(o);
                                }
                                p.SetValue(t, listo, null);
                            }
                            else if (attr.ObjectIndex == 3)
                            {
                                Type listItemType = typeof(T3);
                                List<T3> listo = new List<T3>();
                                foreach (Dictionary<string, object> dictionary in list)
                                {
                                    T3 o = new T3();
                                    foreach (KeyValuePair<string, object> pair in dictionary)
                                    {
                                        foreach (PropertyInfo p1 in listItemType.GetProperties())
                                        {
                                            var attr1 = p1.GetCustomAttribute<HL7FiledAttribute>();
                                            if (t.Root + attr1.XPath == pair.Key)
                                            {
                                                p1.SetValue(o, pair.Value, null);
                                                break;
                                            }
                                        }
                                    }
                                    listo.Add(o);
                                }
                                p.SetValue(t, listo, null);
                            }
                            else if (attr.ObjectIndex == 4)
                            {
                                Type listItemType = typeof(T4);
                                List<T4> listo = new List<T4>();
                                foreach (Dictionary<string, object> dictionary in list)
                                {
                                    T4 o = new T4();
                                    foreach (KeyValuePair<string, object> pair in dictionary)
                                    {
                                        foreach (PropertyInfo p1 in listItemType.GetProperties())
                                        {
                                            var attr1 = p1.GetCustomAttribute<HL7FiledAttribute>();
                                            if (t.Root + attr1.XPath == pair.Key)
                                            {
                                                p1.SetValue(o, pair.Value, null);
                                                break;
                                            }
                                        }
                                    }
                                    listo.Add(o);
                                }
                                p.SetValue(t, listo, null);
                            }
                            else if (attr.ObjectIndex == 5)
                            {
                                Type listItemType = typeof(T5);
                                List<T5> listo = new List<T5>();
                                foreach (Dictionary<string, object> dictionary in list)
                                {
                                    T5 o = new T5();
                                    foreach (KeyValuePair<string, object> pair in dictionary)
                                    {
                                        foreach (PropertyInfo p1 in listItemType.GetProperties())
                                        {
                                            var attr1 = p1.GetCustomAttribute<HL7FiledAttribute>();
                                            if (t.Root + attr1.XPath == pair.Key)
                                            {
                                                p1.SetValue(o, pair.Value, null);
                                                break;
                                            }
                                        }
                                    }
                                    listo.Add(o);
                                }
                                p.SetValue(t, listo, null);
                            }
                        }
                    }
                }
            }

            return t;
        }

        #endregion

        #region 反解析

        /// <summary>
        /// 组装成HL7XML消息
        /// </summary>
        /// <typeparam name="T">待转换对象类型</typeparam>
        /// <param name="source">待转换对象</param>
        /// <param name="template">模板字符串</param>
        /// <returns></returns>
        public string Parser<T>(T source, string template) where T : MSH, new()
        {
            string res = string.Empty;
            if (source != null && !string.IsNullOrEmpty(template))
            {
                Type type = typeof(T);
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (PropertyInfo p in type.GetProperties())
                {
                    string name = p.Name;
                    string value = p.GetValue(source) as string;
                    if (!dictionary.ContainsKey(name))
                    {
                        dictionary.Add("{{" + name + "}}", value);
                    }
                }
                res = this.ReplaceTemplateTag(dictionary, template);
            }
            else
            {
                res = "";
            }
            return res;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 替换特征字符串
        /// </summary>
        /// <param name="source">特征字符串-待填充的数据</param>
        /// <param name="template">模板字符串</param>
        /// <returns></returns>
        private string ReplaceTemplateTag(Dictionary<string, string> source, string template)
        {
            if (source != null && source.Count > 0)
            {
                template = source.Aggregate(template, (current, data) => current.Replace(data.Key, data.Value));
            }

            return template;
        }

        /// <summary>
        /// 读取XML某节点值
        /// </summary>
        /// <param name="xmlObject"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetText(HtmlDocument xmlObject, string path)
        {
            HtmlNode node = xmlObject.DocumentNode.SelectSingleNode(path);
            return node != null ? node.InnerText : "";
        }

        /// <summary>
        /// 读取XML某节点值
        /// </summary>
        /// <param name="xmlObject"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private List<Dictionary<string, object>> GetTextList(HtmlDocument xmlObject, string path)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

            HtmlNodeCollection nodeList = xmlObject.DocumentNode.SelectNodes(path);
            if (nodeList != null && nodeList.Count > 0)
            {
                foreach (HtmlNode node in nodeList)
                {
                    Dictionary<string, object> dictionary = GetChildNodeText(node);

                    string json = dictionary.TryToJson();
                    list.Add(json.JsonToEntity<Dictionary<string, object>>());

                    dict.Clear();
                }
                return list;
            }
            else
            {
                return new List<Dictionary<string, object>>();
            }
        }

        Dictionary<string, object> dict = new Dictionary<string, object>();
        /// <summary>
        /// 获取数组对象所有元素
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Dictionary<string, object> GetChildNodeText(HtmlNode node)
        {
            if (node.ChildNodes.Count > 0)
            {
                foreach (HtmlNode childNode in node.ChildNodes)
                {
                    if (childNode.ChildNodes.Count > 0)
                    {
                        this.GetChildNodeText(childNode);
                    }
                    else
                    {
                        string path = Regex.Replace(childNode.XPath, @"(\[\d])|(#\S+])", "").ToUpper();
                        string key = path.LastIndexOf("/", StringComparison.Ordinal) > 0 ? path.Substring(0, path.Length - 1) : path;
                        if (!dict.ContainsKey(key) && !string.IsNullOrEmpty(childNode.InnerText.Trim()))
                        {
                            dict.Add(key, childNode.InnerText.Trim());
                        }
                    }
                }
            }
            return dict;
        }
        #endregion
    }
}
