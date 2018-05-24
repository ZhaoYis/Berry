using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace Berry.Extension
{
    /// <summary>
    /// 类型转换扩展
    /// </summary>
    public static partial class Extensions
    {
        #region 数值转换

        /// <summary>
        /// 转换为整型
        /// </summary>
        /// <param name="data">数据</param>
        public static int ToInt(this object data)
        {
            if (data == null)
                return 0;
            int result;
            var success = int.TryParse(data.ToString(), out result);
            if (success)
                return result;
            try
            {
                return Convert.ToInt32(ToDouble(data, 0));
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// 转换为可空整型
        /// </summary>
        /// <param name="data">数据</param>
        public static int? ToIntOrNull(this object data)
        {
            if (data == null)
                return null;
            int result;
            bool isValid = int.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        /// 转换为双精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static double ToDouble(this object data)
        {
            if (data == null)
                return 0;
            double result;
            return double.TryParse(data.ToString(), out result) ? result : 0;
        }

        /// <summary>
        /// 转换为双精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static double ToDouble(this object data, int digits)
        {
            return Math.Round(ToDouble(data), digits);
        }

        /// <summary>
        /// 转换为可空双精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static double? ToDoubleOrNull(this object data)
        {
            if (data == null)
                return null;
            double result;
            bool isValid = double.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        /// 转换为高精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static decimal ToDecimal(this object data)
        {
            if (data == null)
                return 0;
            decimal result;
            return decimal.TryParse(data.ToString(), out result) ? result : 0;
        }

        /// <summary>
        /// 转换为高精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static decimal ToDecimal(this object data, int digits)
        {
            return Math.Round(ToDecimal(data), digits);
        }

        /// <summary>
        /// 转换为可空高精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static decimal? ToDecimalOrNull(this object data)
        {
            if (data == null)
                return null;
            decimal result;
            bool isValid = decimal.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        /// 转换为可空高精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static decimal? ToDecimalOrNull(this object data, int digits)
        {
            var result = ToDecimalOrNull(data);
            if (result == null)
                return null;
            return Math.Round(result.Value, digits);
        }

        /// <summary>
        /// 转成Char
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static char ToChar(this object data)
        {
            if (data == null) return new char();
            return Convert.ToChar(data);
        }

        #endregion 数值转换

        #region 日期转换

        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="data">数据</param>
        public static DateTime ToDate(this object data)
        {
            if (data == null)
                return DateTime.MinValue;
            DateTime result;
            return DateTime.TryParse(data.ToString(), out result) ? result : DateTime.MinValue;
        }

        /// <summary>
        /// 转换为可空日期
        /// </summary>
        /// <param name="data">数据</param>
        public static DateTime? ToDateOrNull(this object data)
        {
            if (data == null)
                return null;
            DateTime result;
            bool isValid = DateTime.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        /// Json 的日期格式与.Net DateTime类型的转换
        /// </summary>
        /// <param name="jsonDate">Date(1242357713797+0800)</param>
        /// <returns></returns>
        public static DateTime JsonToDateTime(this string jsonDate)
        {
            string value = jsonDate.Substring(5, jsonDate.Length - 6) + "+0800";
            DateTimeKind kind = DateTimeKind.Utc;
            int index = value.IndexOf('+', 1);
            if (index == -1)
                index = value.IndexOf('-', 1);
            if (index != -1)
            {
                kind = DateTimeKind.Local;
                value = value.Substring(0, index);
            }
            long javaScriptTicks = long.Parse(value, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture);
            long initialJavaScriptDateTicks = (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks;
            DateTime utcDateTime = new DateTime((javaScriptTicks * 10000) + initialJavaScriptDateTicks, DateTimeKind.Utc);
            DateTime dateTime;
            switch (kind)
            {
                case DateTimeKind.Unspecified:
                    dateTime = DateTime.SpecifyKind(utcDateTime.ToLocalTime(), DateTimeKind.Unspecified);
                    break;

                case DateTimeKind.Local:
                    dateTime = utcDateTime.ToLocalTime();
                    break;

                default:
                    dateTime = utcDateTime;
                    break;
            }
            return dateTime;
        }

        #endregion 日期转换

        #region 布尔转换

        /// <summary>
        /// 转换为布尔值
        /// </summary>
        /// <param name="data">数据</param>
        public static bool ToBool(this object data)
        {
            if (data == null)
                return false;
            bool? value = GetBool(data);
            if (value != null)
                return value.Value;
            bool result;
            return bool.TryParse(data.ToString(), out result) && result;
        }

        /// <summary>
        /// 获取布尔值
        /// </summary>
        private static bool? GetBool(this object data)
        {
            switch (data.ToString().Trim().ToLower())
            {
                case "0":
                    return false;

                case "1":
                    return true;

                case "是":
                    return true;

                case "否":
                    return false;

                case "yes":
                    return true;

                case "no":
                    return false;

                default:
                    return null;
            }
        }

        /// <summary>
        /// 转换为可空布尔值
        /// </summary>
        /// <param name="data">数据</param>
        public static bool? ToBoolOrNull(this object data)
        {
            if (data == null)
                return null;
            bool? value = GetBool(data);
            if (value != null)
                return value.Value;
            bool result;
            bool isValid = bool.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        #endregion 布尔转换

        #region 数据类型转换扩展方法

        /// <summary>
        /// object 转换成string 包括为空的情况
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>返回值不含空格</returns>
        public static string ToStringEx(this object obj)
        {
            return obj == null ? string.Empty : obj.ToString().Trim();
        }

        /// <summary>
        /// 时间object 转换成格式化的string 包括为空的情况
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="format"></param>
        /// <returns>返回值不含空格</returns>
        public static string TryToDateTimeToString(this object obj, string format)
        {
            if (obj == null)
                return string.Empty;
            DateTime dt;
            if (DateTime.TryParse(obj.ToString(), out dt))
                return dt.ToString(format);
            else
                return string.Empty;
        }

        /// <summary>
        /// 字符转Int
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>成功:返回对应Int值;失败:返回0</returns>
        public static int TryToInt32(this object obj)
        {
            int rel = 0;

            if (!string.IsNullOrEmpty(obj.ToStringEx()))
            {
                int.TryParse(obj.ToStringEx(), out rel);
            }
            return rel;
        }

        /// <summary>
        /// 字符转Int64
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Int64 TryToInt64(this object obj)
        {
            Int64 rel = 0;
            if (!string.IsNullOrEmpty(obj.ToStringEx()))
            {
                Int64.TryParse(obj.ToStringEx(), out rel);
            }
            return rel;
        }

        /// <summary>
        /// 字符转DateTime
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>成功:返回对应Int值;失败:时间初始值</returns>
        public static DateTime TryToDateTime(this object obj)
        {
            DateTime rel = new DateTime();
            if (!string.IsNullOrEmpty(obj.ToStringEx()))
            {
                DateTime.TryParse(obj.ToStringEx(), out rel);
            }
            return rel;
        }

        /// <summary>
        /// 转换成bool类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Boolean TryToBoolean(this object obj)
        {
            Boolean rel = false;
            if (!string.IsNullOrEmpty(obj.ToStringEx()))
            {
                string s = obj.ToStringEx();

                if (s.Equals("true") || s.Equals("1") || s.Equals("是"))
                {
                    rel = true;
                }
                else
                {
                    Boolean.TryParse(obj.ToStringEx(), out rel);
                }
            }
            return rel;
        }

        #endregion 数据类型转换扩展方法

        #region 对象序列化成字节流

        /// <summary>
        /// 将对象序列化到字节流中
        /// </summary>
        /// <param name="instance">对象</param>
        public static byte[] ToBytes(this object instance)
        {
            if (instance == null)
                return null;
            BinaryFormatter serializer = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, instance);
                stream.Position = 0;
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        /// <summary>
        /// 将字节流反序列化为对象
        /// </summary>
        /// <typeparam name="T">对象类名</typeparam>
        /// <param name="buffer">字节流</param>
        public static T FromBytes<T>(this byte[] buffer) where T : class
        {
            if (buffer == null)
                return default(T);
            BinaryFormatter serializer = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(buffer, 0, buffer.Length);
                stream.Position = 0;
                object result = serializer.Deserialize(stream);
                if (result == null)
                    return default(T);
                return (T)result;
            }
        }

        #endregion 对象序列化成字节流

        #region 数据源转换

        #region DataTable转换成List集合

        /// <summary>
        /// DataTable转换成List集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> DataTableToList<T>(this DataTable dt) where T : new()
        {
            // 定义集合
            IList<T> ts = new List<T>();

            // 获得此模型的类型
            Type type = typeof(T);

            // 获得此模型的公共属性
            PropertyInfo[] propertys = type.GetProperties();

            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                foreach (PropertyInfo pi in propertys)
                {
                    string tempName = pi.Name;

                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter
                        if (!pi.CanWrite) continue;

                        object value = dr[tempName];
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
                ts.Add(t);
            }
            return ts.CastTo<List<T>>();
        }

        #endregion DataTable转换成List集合

        #region DataTable转换成对象

        /// <summary>
        /// DataTable转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static T DataTableToObject<T>(this DataTable dt) where T : new()
        {
            T t = new T();
            // 获得此模型的类型
            Type type = typeof(T);
            // 获得此模型的公共属性
            PropertyInfo[] propertys = type.GetProperties();

            foreach (DataRow dr in dt.Rows)
            {
                foreach (PropertyInfo pi in propertys)
                {
                    string tempName = pi.Name;

                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter
                        if (!pi.CanWrite) continue;

                        object value = dr[tempName];
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
            }
            return t.CastTo<T>();
        }

        #endregion DataTable转换成对象

        #region List转换DataTable

        /// <summary>
        /// 将泛类型集合List类转换成DataTable
        /// </summary>
        /// <param name="entitys">泛类型集合</param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(this List<T> entitys)
        {
            //检查实体集合不能为空
            if (entitys == null || entitys.Count < 1)
            {
                throw new Exception("需转换的集合为空");
            }
            //取出第一个实体的所有Propertie
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();

            //生成DataTable的structure
            //生产代码中，应将生成的DataTable结构Cache起来，此处略
            DataTable dt = new DataTable();
            for (int i = 0; i < entityProperties.Length; i++)
            {
                //dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                dt.Columns.Add(entityProperties[i].Name);
            }
            //将所有entity添加到DataTable中
            foreach (object entity in entitys)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[entityProperties.Length];
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    entityValues[i] = entityProperties[i].GetValue(entity, null);
                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }

        #endregion List转换DataTable

        #region IList转成List<T>

        /// <summary>
        /// IList转成List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> IListToList<T>(this IList list)
        {
            T[] array = new T[list.Count];
            list.CopyTo(array, 0);
            return new List<T>(array);
        }

        #endregion IList转成List<T>

        #region DataTable根据条件过滤表的内容

        /// <summary>
        /// 根据条件过滤表的内容
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static DataTable DataFilter(this DataTable dt, string condition)
        {
            if (IsExistRows(dt))
            {
                if (condition.Trim() == "")
                {
                    return dt;
                }
                else
                {
                    DataTable newdt = new DataTable();
                    newdt = dt.Clone();
                    DataRow[] dr = dt.Select(condition);
                    for (int i = 0; i < dr.Length; i++)
                    {
                        newdt.ImportRow((DataRow)dr[i]);
                    }
                    return newdt;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据条件过滤表的内容
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="condition">条件</param>
        /// <param name="sort">排序字段</param>
        /// <returns></returns>
        public static DataTable DataFilter(this DataTable dt, string condition, string sort)
        {
            if (IsExistRows(dt))
            {
                DataTable newdt = dt.Clone();
                DataRow[] dr = dt.Select(condition, sort);
                for (int i = 0; i < dr.Length; i++)
                {
                    newdt.ImportRow((DataRow)dr[i]);
                }
                return newdt;
            }
            else
            {
                return null;
            }
        }

        #endregion DataTable根据条件过滤表的内容

        #region 检查DataTable 是否有数据行

        /// <summary>
        /// 检查DataTable 是否有数据行
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static bool IsExistRows(this DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
                return true;

            return false;
        }

        #endregion 检查DataTable 是否有数据行

        #region DataTable 转 DataTableToHashtable

        /// <summary>
        /// DataTable 转 DataTableToHashtable
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static Hashtable DataTableToHashtable(this DataTable dt)
        {
            Hashtable ht = new Hashtable();
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string key = dt.Columns[i].ColumnName;
                    ht[key] = dr[key];
                }
            }
            return ht;
        }

        #endregion DataTable 转 DataTableToHashtable

        #region DataTable/DataSet 转 XML

        /// <summary>
        /// DataTable 转 XML
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToXml(this DataTable dt)
        {
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    System.IO.StringWriter writer = new System.IO.StringWriter();
                    dt.WriteXml(writer);
                    return writer.ToString();
                }
            }
            return String.Empty;
        }

        /// <summary>
        /// DataSet 转 XML
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string DataSetToXml(this DataSet ds)
        {
            if (ds != null)
            {
                System.IO.StringWriter writer = new System.IO.StringWriter();
                ds.WriteXml(writer);
                return writer.ToString();
            }
            return String.Empty;
        }

        #endregion DataTable/DataSet 转 XML

        #region DataRow  转  HashTable

        /// <summary>
        /// DataRow  转  HashTable
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static Hashtable DataRowToHashTable(this DataRow dr)
        {
            Hashtable htReturn = new Hashtable(dr.ItemArray.Length);
            foreach (DataColumn dc in dr.Table.Columns)
                htReturn.Add(dc.ColumnName, dr[dc.ColumnName]);
            return htReturn;
        }

        #endregion DataRow  转  HashTable

        #region 使用指定字符集将string转换成byte[]

        /// <summary>
        /// 使用指定字符集将string转换成byte[]
        /// </summary>
        /// <param name="text">要转换的字符串</param>
        /// <param name="encoding">字符编码</param>
        public static byte[] StringToBytes(this string text, Encoding encoding)
        {
            return encoding.GetBytes(text);
        }

        #endregion 使用指定字符集将string转换成byte[]

        #region 使用指定字符集将byte[]转换成string

        /// <summary>
        /// 使用指定字符集将byte[]转换成string
        /// </summary>
        /// <param name="bytes">要转换的字节数组</param>
        /// <param name="encoding">字符编码</param>
        public static string BytesToString(this byte[] bytes, Encoding encoding)
        {
            return encoding.GetString(bytes);
        }

        #endregion 使用指定字符集将byte[]转换成string

        #region 将byte[]转换成int

        /// <summary>
        /// 将byte[]转换成int
        /// </summary>
        /// <param name="data">需要转换成整数的byte数组</param>
        public static int BytesToInt32(this byte[] data)
        {
            //如果传入的字节数组长度小于4,则返回0
            if (data.Length < 4)
            {
                return 0;
            }

            //定义要返回的整数
            int num = 0;

            //如果传入的字节数组长度大于4,需要进行处理
            if (data.Length >= 4)
            {
                //创建一个临时缓冲区
                byte[] tempBuffer = new byte[4];

                //将传入的字节数组的前4个字节复制到临时缓冲区
                Buffer.BlockCopy(data, 0, tempBuffer, 0, 4);

                //将临时缓冲区的值转换成整数，并赋给num
                num = BitConverter.ToInt32(tempBuffer, 0);
            }

            //返回整数
            return num;
        }

        #endregion 将byte[]转换成int

        #region IDataReader转换

        /// <summary>
        /// 将IDataReader转换为 集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static List<T> IDataReaderToList<T>(this IDataReader reader)
        {
            using (reader)
            {
                List<string> field = new List<string>(reader.FieldCount);
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    field.Add(reader.GetName(i).ToLower());
                }
                List<T> list = new List<T>();
                while (reader.Read())
                {
                    T model = Activator.CreateInstance<T>();
                    foreach (PropertyInfo property in model.GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance))
                    {
                        if (field.Contains(property.Name.ToLower()))
                        {
                            if (!IsNullOrDbNull(reader[property.Name]))
                            {
                                property.SetValue(model, HackType(reader[property.Name], property.PropertyType), null);
                            }
                        }
                    }
                    list.Add(model);
                }
                reader.Close();
                reader.Dispose();
                return list;
            }
        }

        /// <summary>
        ///  将IDataReader转换为DataTable
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static DataTable IDataReaderToDataTable(this IDataReader reader)
        {
            using (reader)
            {
                DataTable objDataTable = new DataTable("Table");
                int intFieldCount = reader.FieldCount;
                for (int intCounter = 0; intCounter < intFieldCount; ++intCounter)
                {
                    objDataTable.Columns.Add(reader.GetName(intCounter).ToLower(), reader.GetFieldType(intCounter));
                }
                objDataTable.BeginLoadData();
                object[] objValues = new object[intFieldCount];
                while (reader.Read())
                {
                    reader.GetValues(objValues);
                    objDataTable.LoadDataRow(objValues, true);
                }
                reader.Close();
                reader.Dispose();
                objDataTable.EndLoadData();
                return objDataTable;
            }
        }

        //这个类对可空类型进行判断转换，要不然会报错
        private static object HackType(object value, Type conversionType)
        {
            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (value == null)
                    return null;
                System.ComponentModel.NullableConverter nullableConverter = new System.ComponentModel.NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }
            //if (value is System.DateTime)
            //{
            //    value = Convert.ToDateTime(value).ToString("yyyyMMddHHmmss");
            //}
            return Convert.ChangeType(value, conversionType);
        }

        private static bool IsNullOrDbNull(object obj)
        {
            return ((obj is DBNull) || string.IsNullOrEmpty(obj.ToString())) ? true : false;
        }

        #endregion IDataReader转换

        #endregion 数据源转换

        #region 将对象属性转换为Key-Value键值对

        /// <summary>
        /// 将对象属性转换为Key-Value键值对
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Dictionary<string, object> Object2Dictionary(this object o)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();

            Type t = o.GetType();

            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo p in pi)
            {
                MethodInfo mi = p.GetGetMethod();

                if (mi != null && mi.IsPublic)
                {
                    map.Add(p.Name, mi.Invoke(o, new object[] { }));
                }
            }
            return map;
        }

        #endregion 将对象属性转换为Key-Value键值对

        #region 把对象类型转换成指定的类型，转化失败时返回指定默认值

        /// <summary>
        /// 把对象类型转换成指定的类型，转化失败时返回指定默认值
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="value">要转换的原对象</param>
        /// <param name="detaultValue">转换失败时返回的默认值</param>
        /// <returns>转化后指定类型对象，转化失败时返回指定默认值</returns>
        public static T CastTo<T>(this object value, T detaultValue)
        {
            object result;
            Type t = typeof(T);
            try
            {
                result = t.IsEnum ? System.Enum.Parse(t, value.ToString()) : Convert.ChangeType(value, t);
            }
            catch (Exception)
            {
                return detaultValue;
            }

            return (T)result;
        }

        #endregion 把对象类型转换成指定的类型，转化失败时返回指定默认值

        #region 把对象类型转换成指定的类型，转化失败时返回类型默认值

        /// <summary>
        /// 把对象类型转换成指定的类型，转化失败时返回类型默认值
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="value">要转换的原对象</param>
        /// <returns>转化后指定类型对象，转化失败时返回类型默认值</returns>
        public static T CastTo<T>(this object value)
        {
            object result;
            Type t = typeof(T);
            try
            {
                if (t.IsEnum)
                {
                    result = System.Enum.Parse(t, value.ToString());
                }
                else if (t == typeof(Guid))
                {
                    result = Guid.Parse(value.ToString());
                }
                else
                {
                    result = Convert.ChangeType(value, t);
                }
            }
            catch (Exception)
            {
                result = default(T);
            }

            return (T)result;
        }

        #endregion 把对象类型转换成指定的类型，转化失败时返回类型默认值

        #region 合并序列、数组去重

        /// <summary>
        /// 合并两个序列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">原数组</param>
        /// <param name="b">需要合并的数组</param>
        /// <returns></returns>
        public static T[] ConcatArray<T>(this T[] a, T[] b)
        {
            return a.Concat(b).ToArray();
        }

        /// <summary>
        /// 数组去掉重复的元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">要处理的数组</param>
        /// <returns></returns>
        public static T[] DeleteRepeatData<T>(this T[] array)
        {
            return array.GroupBy(p => p).Select(p => p.Key).ToArray();
        }

        #endregion 合并序列、数组去重

        #region 补足位数

        /// <summary>
        /// 指定字符串的固定长度，如果字符串小于固定长度，
        /// 则在字符串的前面补足零，可设置的固定长度最大为9位
        /// </summary>
        /// <param name="text">原始字符串</param>
        /// <param name="limitedLength">字符串的固定长度</param>
        public static string RepairZero(this string text, int limitedLength)
        {
            //补足0的字符串
            string temp = "";

            //补足0
            for (int i = 0; i < limitedLength - text.Length; i++)
            {
                temp += "0";
            }

            //连接text
            temp += text;

            //返回补足0的字符串
            return temp;
        }

        /// <summary>
        /// 小时、分钟、秒小于10补足0
        /// </summary>
        /// <param name="text">原始字符串</param>
        /// <returns></returns>
        public static string RepairZero(this int text)
        {
            string res = string.Empty;
            if (text >= 0 && text < 10)
            {
                res += "0" + text;
            }
            else
            {
                res = text.ToString();
            }
            return res;
        }

        #endregion 补足位数

        #region 各进制数间转换

        /// <summary>
        /// 实现各进制数间的转换。ConvertBase("15",10,16)表示将十进制数15转换为16进制的数。
        /// </summary>
        /// <param name="value">要转换的值,即原值</param>
        /// <param name="from">原值的进制,只能是2,8,10,16四个值。</param>
        /// <param name="to">要转换到的目标进制，只能是2,8,10,16四个值。</param>
        public static string ConvertBase(this string value, int from, int to)
        {
            try
            {
                int intValue = Convert.ToInt32(value, from);  //先转成10进制
                string result = Convert.ToString(intValue, to);  //再转成目标进制
                if (to == 2)
                {
                    int resultLength = result.Length;  //获取二进制的长度
                    switch (resultLength)
                    {
                        case 7:
                            result = "0" + result;
                            break;

                        case 6:
                            result = "00" + result;
                            break;

                        case 5:
                            result = "000" + result;
                            break;

                        case 4:
                            result = "0000" + result;
                            break;

                        case 3:
                            result = "00000" + result;
                            break;
                    }
                }
                return result;
            }
            catch
            {
                //LogHelper.WriteTraceLog(TraceLogLevel.Error, ex.Message);
                return "0";
            }
        }

        #endregion 各进制数间转换

        #region 判断指定类型是否为数字类型

        /// <summary>
        /// 判断指定类型是否为数字类型
        /// </summary>
        /// <param name="t">要检查的类型</param>
        /// <returns>是否是数字类型</returns>
        public static bool IsNumeric(this Type t)
        {
            return t == typeof(Byte)
                   || t == typeof(Int16)
                   || t == typeof(Int32)
                   || t == typeof(Int64)
                   || t == typeof(SByte)
                   || t == typeof(UInt16)
                   || t == typeof(UInt32)
                   || t == typeof(UInt64)
                   || t == typeof(Decimal)
                   || t == typeof(Double)
                   || t == typeof(Single);
        }

        #endregion 判断指定类型是否为数字类型

        #region 检验参数合法性，数值类型不小于0，引用类型不能为null，否则抛出异常

        /// <summary>
        /// 检验参数合法性，数值类型不小于0，引用类型不能为null，否则抛出异常
        /// </summary>
        /// <param name="arg">待检参数</param>
        /// <param name="argName">待检参数名称</param>
        /// <param name="canZero">数值类型是否可以为0</param>
        public static bool CheckArgument(this object arg, string argName, bool canZero = false)
        {
            try
            {
                if (arg == null)
                {
                    ArgumentNullException argumentNullException = new ArgumentNullException(argName);
                    throw new Exception(String.Format("参数{0}为空，引发异常", argName), argumentNullException);
                }

                Type t = arg.GetType();
                if (t.IsValueType && t.IsNumeric())
                {
                    bool flag = !canZero ? arg.CastTo(0.0) <= 0.0 : arg.CastTo(0.0) < 0.0;
                    if (flag)
                    {
                        ArgumentOutOfRangeException argumentOutOfRangeException = new ArgumentOutOfRangeException(argName);
                        throw new Exception(String.Format("参数{0}不在有效范围内，引发异常", argName), argumentOutOfRangeException);
                    }
                }
                if (t == typeof(Guid) && (Guid)arg == Guid.Empty)
                {
                    ArgumentNullException argumentNullException1 = new ArgumentNullException(argName);
                    throw new Exception(String.Format("参数{0}为空引发GUID异常", argName), argumentNullException1);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion 检验参数合法性，数值类型不小于0，引用类型不能为null，否则抛出异常

        #region Unicode/汉字互转

        /// <summary>
        /// 字符串转Unicode
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>Unicode编码后的字符串</returns>
        public static string String2Unicode(this string source)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(source);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i += 2)
            {
                stringBuilder.AppendFormat("\\u{0}{1}", bytes[i + 1].ToString("x").PadLeft(2, '0'), bytes[i].ToString("x").PadLeft(2, '0'));
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Unicode转字符串
        /// </summary>
        /// <param name="source">经过Unicode编码的字符串</param>
        /// <returns>正常字符串</returns>
        public static string Unicode2String(this string source)
        {
            return new Regex(@"\\u([0-9A-F]{4})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Replace(
                source, x => string.Empty + Convert.ToChar(Convert.ToUInt16(x.Result("$1"), 16)));
        }
        #endregion Unicode/汉字互转
    }
}