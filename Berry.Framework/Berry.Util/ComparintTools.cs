using System.Collections.Generic;
using System.Linq;

namespace Berry.Util
{
    /// <summary>
    /// 根据字段过滤重复的数据
    /// </summary>
    public class ComparintTools<T> : IEqualityComparer<T> where T : class, new()
    {
        private readonly string[] _comparintFiledName;

        /// <summary>
        /// 根据字段过滤重复的数据
        /// </summary>
        /// <param name="comparintFiledName"></param>
        public ComparintTools(params string[] comparintFiledName)
        {
            this._comparintFiledName = comparintFiledName;
        }

        /// <summary>确定指定的对象是否相等。</summary>
        /// <param name="x">
        ///   类型的第一个对象 <paramref name="T" /> 进行比较。
        /// </param>
        /// <param name="y">
        ///   第二个对象类型的 <paramref name="T" /> 进行比较。
        /// </param>
        /// <returns>
        ///   如果指定的对象相等，则为 <see langword="true" />；否则为 <see langword="false" />。
        /// </returns>
        bool IEqualityComparer<T>.Equals(T x, T y)
        {
            if (x == null && y == null)
            {
                return false;
            }

            if (_comparintFiledName.Length == 0)
            {
                return x != null && x.Equals(y);
            }

            bool result = true;
            if (x != null && y != null)
            {
                var typeX = x.GetType();//获取类型
                var typeY = y.GetType();

                foreach (var filedName in _comparintFiledName)
                {
                    var xPropertyInfo = (from p in typeX.GetProperties() where p.Name.Equals(filedName) select p).FirstOrDefault();
                    var yPropertyInfo = (from p in typeY.GetProperties() where p.Name.Equals(filedName) select p).FirstOrDefault();

                    result = result
                             && xPropertyInfo != null && yPropertyInfo != null
                             && xPropertyInfo.GetValue(x, null).ToString().Equals(yPropertyInfo.GetValue(y, null));
                }
            }
            return result;
        }

        /// <summary>返回指定对象的哈希代码。</summary>
        /// <param name="obj">
        ///   <see cref="T:System.Object" /> 要为其哈希代码会返回。
        /// </param>
        /// <returns>指定对象的哈希代码。</returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///   一种 <paramref name="obj" /> 是引用类型和 <paramref name="obj" /> 是 <see langword="null" />。
        /// </exception>
        int IEqualityComparer<T>.GetHashCode(T obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}