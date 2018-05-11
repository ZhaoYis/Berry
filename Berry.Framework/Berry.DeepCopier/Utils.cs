using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace Berry.DeepCopier
{
    /// <summary>
    /// 工具类
    /// </summary>
    internal static class Utils
    {
        private static readonly Type TypeString = typeof(string);

        private static readonly Type TypeIEnumerable = typeof(IEnumerable);

        private static readonly ConcurrentDictionary<Type, Func<object>> Ctors = new ConcurrentDictionary<Type, Func<object>>();

        /// <summary>
        /// 判断是否是string以外的引用类型
        /// </summary>
        /// <returns>True：是string以外的引用类型，False：不是string以外的引用类型</returns>
        public static bool IsRefTypeExceptString(Type type) => !type.IsValueType && type != TypeString;

        /// <summary>
        /// 判断是否是string以外的可遍历类型
        /// </summary>
        /// <returns>True：是string以外的可遍历类型，False：不是string以外的可遍历类型</returns>
        public static bool IsIEnumerableExceptString(Type type) => TypeIEnumerable.IsAssignableFrom(type) && type != TypeString;

        /// <summary>
        /// 创建指定类型实例
        /// </summary>
        /// <param name="type">类型信息</param>
        /// <returns>指定类型的实例</returns>
        public static object CreateNewInstance(Type type) => Ctors.GetOrAdd(type, t => Expression.Lambda<Func<object>>(Expression.New(t)).Compile())();
    }
}
