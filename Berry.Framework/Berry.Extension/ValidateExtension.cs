using System;
using System.Reflection;

namespace Berry.Extension
{
    /// <summary>
    /// 数据验证扩展
    /// </summary>
    public static class ValidateExtension
    {
        /// <summary>
        /// 比较两个对象是否完全相等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oneT"></param>
        /// <param name="twoT"></param>
        /// <returns></returns>
        public static bool CompareObject<T>(T oneT, T twoT)
        {
            bool result = true;//两个类型作比较时使用,如果有不一样的就false
            Type typeOne = oneT.GetType();
            Type typeTwo = twoT.GetType();
            //如果两个T类型不一样  就不作比较
            if (typeOne != typeTwo) { return false; }

            PropertyInfo[] pisOne = typeOne.GetProperties(); //获取所有公共属性(Public)
            PropertyInfo[] pisTwo = typeTwo.GetProperties();
            //如果长度为0返回false
            if (pisOne.Length <= 0 || pisTwo.Length <= 0)
            {
                return false;
            }

            //如果长度不一样，返回false
            if (!pisOne.Length.Equals(pisTwo.Length)) { return false; }

            //遍历两个T类型，遍历属性，并作比较
            for (int i = 0; i < pisOne.Length; i++)
            {
                //获取属性名
                string oneName = pisOne[i].Name;
                string twoName = pisTwo[i].Name;
                //获取属性的值
                object oneValue = pisOne[i].GetValue(oneT, null);
                object twoValue = pisTwo[i].GetValue(twoT, null);
                //比较,只比较值类型
                if ((pisOne[i].PropertyType.IsValueType || pisOne[i].PropertyType.Name.StartsWith("String")) && (pisTwo[i].PropertyType.IsValueType || pisTwo[i].PropertyType.Name.StartsWith("String")))
                {
                    if (oneName.Equals(twoName))
                    {
                        if (oneValue == null)
                        {
                            if (twoValue != null)
                            {
                                result = false;
                                break; //如果有不一样的就退出循环
                            }
                        }
                        else
                        {
                            if (twoValue != null)
                            {
                                if (!oneValue.Equals(twoValue))
                                {
                                    result = false;
                                    break; //如果有不一样的就退出循环
                                }
                            }
                            else
                            {
                                result = false;
                                break; //如果有不一样的就退出循环
                            }
                        }
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
                else
                {
                    //如果对象中的属性是实体类对象，递归遍历比较
                    bool b = CompareObject(oneValue, twoValue);
                    if (!b) { result = b; break; }
                }
            }
            return result;
        }

        /// <summary>
        /// 检测空值,为null则抛出ArgumentNullException异常
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="parameterName">参数名</param>
        public static void CheckNull(this object obj, string parameterName)
        {
            if (obj == null)
                throw new ArgumentNullException(parameterName);
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this Guid? value)
        {
            if (value == null)
                return true;
            return IsEmpty(value.Value);
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this Guid value)
        {
            if (value == Guid.Empty)
                return true;
            return false;
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this object value)
        {
            if (value != null && !string.IsNullOrEmpty(value.ToStringEx()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}