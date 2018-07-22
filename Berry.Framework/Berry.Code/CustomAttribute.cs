using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Berry.Extension;

namespace Berry.Code
{
    #region 自定义模型验证

    #region DateTime验证，输入时间不能大于当前时间或者输入时间不能小于当前时间
    /// <summary>
    /// DateTime验证，输入时间不能大于当前时间或者输入时间不能小于当前时间
    /// <para>默认true，输入时间不能大于当前时间</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NotFutureTimeAttribute : ValidationAttribute
    {
        private bool _flag;

        /// <summary>
        /// 默认true，输入时间不能大于当前时间
        /// </summary>
        /// <param name="flag"></param>
        public NotFutureTimeAttribute(bool flag = true)
        {
            this._flag = flag;
        }

        /// <summary>确定指定的值的对象是否有效。</summary>
        /// <param name="value">要验证的对象的值。</param>
        /// <returns>
        ///   <see langword="true" /> 如果指定的值是否有效，则为否则为 <see langword="false" />。
        /// </returns>
        public override bool IsValid(object value)
        {
            DateTime dt = (DateTime)value;
            if (_flag)
            {
                //输入时间不能大于当前时间
                if (dt < DateTime.Now)
                {
                    return true;
                }
            }
            else
            {
                //输入时间不能小于当前时间
                if (dt > DateTime.Now)
                {
                    return true;
                }
            }
            return false;
        }
    }
    #endregion

    #region 校验DateTime是否有效

    /// <summary>
    /// 校验DateTime是否有效
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDateTimeAttribute : ValidationAttribute
    {
        /// <summary>确定指定的值的对象是否有效。</summary>
        /// <param name="value">要验证的对象的值。</param>
        /// <returns>
        ///   <see langword="true" /> 如果指定的值是否有效，则为否则为 <see langword="false" />。
        /// </returns>
        public override bool IsValid(object value)
        {
            DateTime dt = (DateTime)value;
            return dt.CheckDateTime();
        }
    }
    #endregion

    #region 验证字符串长度在[n,m]之间，n < m
    /// <summary>
    /// 验证字符串长度在[n,m]之间，n < m
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]

    public class StringBetweenLengthAttribute : ValidationAttribute
    {
        private int _min;
        private int _max;

        public StringBetweenLengthAttribute(int min, int max)
        {
            this._min = min;
            this._max = max;
        }

        /// <summary>确定指定的值的对象是否有效。</summary>
        /// <param name="value">要验证的对象的值。</param>
        /// <returns>
        ///   <see langword="true" /> 如果指定的值是否有效，则为否则为 <see langword="false" />。
        /// </returns>
        public override bool IsValid(object value)
        {
            if (value == null) return false;
            string source = value.ToString();

            return source.Length >= _min && source.Length <= _max;
        }
    }
    #endregion

    #region 验证字符串只能是指定固定长度
    /// <summary>
    /// 验证字符串只能是指定固定长度
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class StringFixedLengthAttribute : ValidationAttribute
    {
        private int[] _fixedLength;

        public StringFixedLengthAttribute(int[] fixedLength)
        {
            this._fixedLength = fixedLength;
        }

        /// <summary>确定指定的值的对象是否有效。</summary>
        /// <param name="value">要验证的对象的值。</param>
        /// <returns>
        ///   <see langword="true" /> 如果指定的值是否有效，则为否则为 <see langword="false" />。
        /// </returns>
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            string source = value.ToString();
            int thisStrLen = source.Length;

            return _fixedLength.Contains(thisStrLen);
        }
    }
    #endregion

    #endregion
}