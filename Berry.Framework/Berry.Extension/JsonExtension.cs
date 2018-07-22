using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace Berry.Extension
{
    /// <summary>
    /// Json操作扩展
    /// </summary>
    public static class JsonExtension
    {
        /// <summary>
        /// 对象序列化成Json字符串
        /// </summary>
        /// <param name="obj">需要序列化的对象</param>
        /// <param name="isIgnoreNullValue">是否忽略值为NULL的属性，默认false</param>
        /// <returns></returns>
        public static string TryToJson(this object obj, bool isIgnoreNullValue = false)
        {
            string res;
            if (typeof(object) == typeof(string)) return obj.ToString();

            if (isIgnoreNullValue)
            {
                JsonSerializerSettings jsetting = new JsonSerializerSettings();

                JsonConvert.DefaultSettings = () =>
                {
                    //日期类型默认格式化处理
                    jsetting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                    jsetting.DateFormatString = "yyyy-MM-dd HH:mm:ss";

                    //空值处理,忽略值为NULL的属性
                    jsetting.NullValueHandling = NullValueHandling.Ignore;

                    return jsetting;
                };
                res = JsonConvert.SerializeObject(obj, Formatting.None, jsetting);
            }
            else
            {
                JsonSerializerSettings jsetting = new JsonSerializerSettings();

                JsonConvert.DefaultSettings = () =>
                {
                    //日期类型默认格式化处理
                    jsetting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                    jsetting.DateFormatString = "yyyy-MM-dd HH:mm:ss";

                    return jsetting;
                };
                res = JsonConvert.SerializeObject(obj, Formatting.None, jsetting);
            }
            return res;
        }

        /// <summary>
        /// Json字符串转换成DataTable
        /// </summary>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static DataTable JsonToDataTable(this string strJson)
        {
            DataTable tb = null;
            //获取数据
            Regex rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split(',');
                //创建表
                if (tb == null)
                {
                    tb = new DataTable { TableName = "Table" };
                    foreach (string str in strRows)
                    {
                        DataColumn dc = new DataColumn();
                        string[] strCell = str.Split(':');
                        dc.DataType = typeof(String);
                        dc.ColumnName = strCell[0].ToString().Replace("\"", "").Trim();
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }
                //增加内容
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    object strText = strRows[r].Split(':')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("/", "").Replace("\"", "").Trim();
                    if (strText.ToString().Length >= 5)
                    {
                        if (strText.ToString().Substring(0, 5) == "Date(")//判断是否JSON日期格式
                        {
                            strText = strText.ToString().JsonToDateTime().ToString("yyyy-MM-dd HH:mm:ss");
                        }
                    }
                    dr[r] = strText;
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }
            return tb;
        }

        /// <summary>
        /// Json字符串反序列化成对象集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<T> JsonToList<T>(this string json)
        {
            if (json.IsJson())
                return JsonConvert.DeserializeObject<List<T>>(json);

            return default(List<T>);
        }

        /// <summary>
        /// Json字符串反序列化成实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToEntity<T>(this string json)
        {
            if (json.IsJson())
                return JsonConvert.DeserializeObject<T>(json);
            return default(T);
        }

        /// <summary>
        /// Json字符串反序列化成对象
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static object JsonToObject(this string json)
        {
            return JsonConvert.DeserializeObject(json);
        }

        /// <summary>
        /// Json字符串转换成JObject
        /// </summary>
        /// <param name="json">Json字符串</param>
        /// <returns></returns>
        public static JObject TryToJObject(this string json)
        {
            return json == null ? null : JObject.Parse(json.Replace("&nbsp;", ""));
        }
    }
}