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
        private readonly bool _flag;

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
            if (value == null) return false;
            if (!value.ToString().CheckDateTime()) return false;

            DateTime dt = value.TryToDateTime();
            return dt.CheckDateTime();
        }
    }
    #endregion

    #region 校验时间戳

    /// <summary>
    /// 校验时间戳
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckTimeStampAttribute : ValidationAttribute
    {
        /// <summary>确定指定的值的对象是否有效。</summary>
        /// <param name="value">要验证的对象的值。</param>
        /// <returns>
        ///   <see langword="true" /> 如果指定的值是否有效，则为否则为 <see langword="false" />。
        /// </returns>
        public override bool IsValid(object value)
        {
            if (value == null) return false;
            string time = value.ToString();

            return time.CheckTimeStamp();
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
        private readonly int _min;
        private readonly int _max;

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
        private readonly int[] _fixedLength;

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

    #region 验证数字取值范围
    /// <summary>
    /// 验证数字取值范围
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NumberCheckAttribute : ValidationAttribute
    {
        /// <summary>
        /// 比较类型
        /// </summary>
        private readonly NumberRangeOfValueType _type;
        /// <summary>
        /// 阈值
        /// </summary>
        private readonly int _threshold;

        public NumberCheckAttribute(NumberRangeOfValueType type, int threshold)
        {
            this._type = type;
            this._threshold = threshold;
        }

        /// <summary>确定对象的指定值是否有效。</summary>
        /// <returns>如果指定的值有效，则为 true；否则，为 false。</returns>
        /// <param name="value">要验证的对象的值。</param>
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            int source = value.TryToInt32();
            if (_type == NumberRangeOfValueType.GreaterThan)
            {
                //大于
                return source > _threshold;
            }
            else if ((_type & NumberRangeOfValueType.GreaterThan) == NumberRangeOfValueType.GreaterThan &&
               (_type & NumberRangeOfValueType.Equal) == NumberRangeOfValueType.Equal)
            {
                //大于等于
                return source >= _threshold;
            }
            else if (_type == NumberRangeOfValueType.LessThan)
            {
                //小于
                return source < _threshold;
            }
            else if ((_type & NumberRangeOfValueType.LessThan) == NumberRangeOfValueType.LessThan &&
                     (_type & NumberRangeOfValueType.Equal) == NumberRangeOfValueType.Equal)
            {
                //小于等于
                return source <= _threshold;
            }
            else if (_type == NumberRangeOfValueType.Equal)
            {
                //等于
                return source == _threshold;
            }
            else if (_type == NumberRangeOfValueType.NotEqual)
            {
                //不等于
                return source != _threshold;
            }

            return false;
        }
    }

    #endregion

    #region 校验金额，必须大于或者等于0
    /// <summary>
    /// 校验金额，必须大于或者等于0
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckMoneyAttribute : ValidationAttribute
    {
        /// <summary>确定对象的指定值是否有效。</summary>
        /// <returns>如果指定的值有效，则为 true；否则，为 false。</returns>
        /// <param name="value">要验证的对象的值。</param>
        public override bool IsValid(object value)
        {
            if (value == null) return false;
            decimal source = value.ToDecimal();

            return source >= 0;
        }
    }
    #endregion

    #endregion
}