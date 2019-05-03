using System.Collections.Concurrent;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace Berry.Extension.QueryableEx
{
    /// <summary>
    /// 将字符串的属性名转换成Lambda表达式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class QueryableHelper<T>
    {
        /// <summary>
        /// 缓存Lambda表达式，方便重复使用
        /// </summary>
        private static readonly ConcurrentDictionary<string, LambdaExpression> Cache = new ConcurrentDictionary<string, LambdaExpression>();

        /// <summary>
        /// 对某个数据源按照某列、某个方向进行排序
        /// </summary>
        /// <param name="source">要排序的数据源</param>
        /// <param name="propName">排序字段</param>
        /// <param name="listSort">排序方向</param>
        /// <returns>排序后的结果</returns>
        public static IOrderedQueryable<T> OrderBy(IQueryable<T> source, string propName, ListSortDirection listSort)
        {
            dynamic keySelector = GetLambdaExpression(propName);
            return listSort == ListSortDirection.Ascending
                ? Queryable.OrderBy(source, keySelector)
                : Queryable.OrderByDescending(source, keySelector);
        }

        /// <summary>
        /// 对某个排序后的数据源再按照某列、某个方向进行排序
        /// </summary>
        /// <param name="source">已经排序后的数据源</param>
        /// <param name="propName">排序字段</param>
        /// <param name="listSort">排序方向</param>
        /// <returns>排序后的结果</returns>
        public static IOrderedQueryable<T> ThenBy(IOrderedQueryable<T> source, string propName, ListSortDirection listSort)
        {
            dynamic keySelector = GetLambdaExpression(propName);
            return listSort == ListSortDirection.Ascending
                ? Queryable.OrderBy(source, keySelector)
                : Queryable.OrderByDescending(source, keySelector);
        }

        /// <summary>
        /// 得到Lambda表达式
        /// </summary>
        /// <param name="propName"></param>
        /// <returns></returns>
        private static LambdaExpression GetLambdaExpression(string propName)
        {
            LambdaExpression keySelector = null;

            //if (!Cache.ContainsKey(propName))
            //{
            //    ParameterExpression parameter = Expression.Parameter(typeof(T));
            //    MemberExpression body = Expression.Property(parameter, propName);
            //    keySelector = Expression.Lambda(body, parameter);

            //    Cache.TryAdd(propName, keySelector);
            //}
            //else
            //{
            //    keySelector = Cache[propName];
            //}
            //return keySelector;

            ParameterExpression parameter = Expression.Parameter(typeof(T));
            MemberExpression body = Expression.Property(parameter, propName);
            keySelector = Expression.Lambda(body, parameter);

            return keySelector;
        }
    }
}