#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Berry.Extension
* 项目描述 ：
* 类 名 称 ：QueryableExtension
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：Berry.Extension
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/2 20:52:56
* 更新时间 ：2019/5/2 20:52:56
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace Berry.Extension.QueryableEx
{
    /// <summary>
    /// 功能描述    ：QueryableExtension  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/2 20:52:56 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/2 20:52:56 
    /// </summary>
    public static class QueryableExtension
    {

        #region IQueryable<T>的扩展方法

        #region 根据第三方条件是否为真是否执行指定条件的查询
        /// <summary>
        /// 根据第三方条件是否为真是否执行指定条件的查询
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source">要查询的数据源</param>
        /// <param name="where">条件</param>
        /// <param name="condition">第三方条件</param>
        /// <returns>查询的结果</returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, bool>> where,
            bool condition)
        {
            if (where.CheckArgument("where"))
            {
                return condition ? source.Where(where) : source;
            }
            return null;
        }
        #endregion

        #region 把IQueryable<T>集合按照指定的属性与排序方式进行排序
        /// <summary>
        /// 把IQueryable集合按照指定的属性与排序方式进行排序
        /// </summary>
        /// <typeparam name="T">数据集类型</typeparam>
        /// <param name="source">要排序的数据集</param>
        /// <param name="propName">要排序的属性名称</param>
        /// <param name="listSort">排序方式</param>
        /// <returns>返回排序后的结果集</returns>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propName,
            ListSortDirection listSort = ListSortDirection.Ascending)
        {
            if (propName.CheckArgument("propName"))
            {
                return QueryableHelper<T>.OrderBy(source, propName, listSort);
            }
            return null;
        }
        #endregion

        #region 把IQueryable<T>集合按照指定的属性与排序方式进行排序
        /// <summary>
        /// 把IQueryable集合按照指定的属性与排序方式进行排序
        /// </summary>
        /// <typeparam name="T">数据集类型</typeparam>
        /// <param name="source">要排序的数据集</param>
        /// <param name="sortCondition">排序条件</param>
        /// <returns>返回排序后的结果集</returns>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, PropertySortCondition sortCondition)
        {
            if (sortCondition.CheckArgument("sortCondition"))
            {
                return source.OrderBy(sortCondition.PropertyName, sortCondition.ListSortDirection);
            }
            return null;
        }
        #endregion

        #region 把IOrderedQueryable<T>集合按照指定的属性与排序方式进行再排序
        /// <summary>
        /// 把IOrderedQueryable集合按照指定的属性与排序方式进行排序
        /// </summary>
        /// <typeparam name="T">数据集类型</typeparam>
        /// <param name="source">要排序的数据集</param>
        /// <param name="propName">要排序的属性名称</param>
        /// <param name="listSort">排序方式</param>
        /// <returns>返回排序后的结果集</returns>
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propName,
            ListSortDirection listSort = ListSortDirection.Ascending)
        {
            if (propName.CheckArgument("propName"))
            {
                return QueryableHelper<T>.ThenBy(source, propName, listSort);
            }
            return null;
        }
        #endregion

        #region 把IOrderedQueryable<T>集合按照指定的属性与排序方式进行再排序
        /// <summary>
        /// 把IOrderedQueryable集合按照指定的属性与排序方式进行排序
        /// </summary>
        /// <typeparam name="T">数据集类型</typeparam>
        /// <param name="source">要排序的数据集</param>
        /// <param name="sortCondition">排序条件</param>
        /// <returns>返回排序后的结果集</returns>
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, PropertySortCondition sortCondition)
        {
            if (sortCondition.CheckArgument("sortCondition"))
            {
                return QueryableHelper<T>.ThenBy(source, sortCondition.PropertyName, sortCondition.ListSortDirection);
            }
            return null;
        }
        #endregion

        #region 多条件排序分页查询
        /// <summary>
        /// 把IQueryable集合按照指定的属性与排序方式进行排序后，再按照指定的条件提取指定页码指定条目数据
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source">要排序的数据集</param>
        /// <param name="where">检索条件</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="total">总页数</param>
        /// <param name="sortConditions">排序条件</param>
        /// <returns>子集</returns>
        public static IQueryable<T> WhereEx<T>(this IQueryable<T> source, Expression<Func<T, bool>> where, int pageIndex,
            int pageSize, out int total, params PropertySortCondition[] sortConditions) where T : class, new()
        {
            IQueryable<T> temp = null;

            int i = 0;
            if (source.CheckArgument("source")
                    && where.CheckArgument("where")
                    && pageIndex.CheckArgument("pageIndex")
                    && pageSize.CheckArgument("pageSize")
                    && sortConditions.CheckArgument("sortConditions"))
            {
                //判断是不是首个排序条件
                int count = 0;
                //得到满足条件的总记录数
                i = source.Count(where);
                //对数据源进行排序
                IOrderedQueryable<T> orderSource = null;
                foreach (PropertySortCondition sortCondition in sortConditions)
                {
                    orderSource = count == 0
                        ? source.OrderBy(sortCondition.PropertyName, sortCondition.ListSortDirection)
                        : orderSource.ThenBy(sortCondition.PropertyName, sortCondition.ListSortDirection);
                    count++;
                }
                source = orderSource;

                temp = source != null
                    ? source.Where(where).Skip((pageIndex - 1) * pageSize).Skip(pageSize)
                    : Enumerable.Empty<T>().AsQueryable();
            }

            total = i;

            return temp;
        }
        #endregion

        #region 多条件排序查询
        /// <summary>
        /// 多条件排序查询
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source">要排序的数据集</param>
        /// <param name="where">检索条件</param>
        /// <param name="sortConditions">排序条件</param>
        /// <returns>子集</returns>
        public static IQueryable<T> WhereEx<T>(this IQueryable<T> source, Expression<Func<T, bool>> where, params PropertySortCondition[] sortConditions) where T : class, new()
        {
            IQueryable<T> temp = null;

            if (source.CheckArgument("source") && where.CheckArgument("where") && sortConditions.CheckArgument("sortConditions"))
            {
                //判断是不是首个排序条件
                int count = 0;
                //对数据源进行排序
                IOrderedQueryable<T> orderSource = null;
                foreach (PropertySortCondition sortCondition in sortConditions)
                {
                    orderSource = count == 0
                        ? source.OrderBy(sortCondition.PropertyName, sortCondition.ListSortDirection)
                        : orderSource.ThenBy(sortCondition.PropertyName, sortCondition.ListSortDirection);
                    count++;
                }
                source = orderSource;

                temp = source != null ? source.Where(where) : Enumerable.Empty<T>().AsQueryable();
            }
            return temp;
        }
        #endregion

        #endregion

        #region IEnumerable<T>的扩展方法

        #region 将集合展开分别转换成字符串，再以指定分隔字符串链接，拼成一个字符串返回
        /// <summary>
        /// 将集合展开分别转换成字符串，再以指定分隔字符串链接，拼成一个字符串返回
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="collection">要处理的集合</param>
        /// <param name="separator">分隔符</param>
        /// <returns>拼接后的字符串</returns>
        public static string ExpandAndToString<T>(this IEnumerable<T> collection, string separator)
        {
            List<T> source = collection as List<T> ?? collection.ToList();
            if (source.IsEmpty())
            {
                return "";
            }

            string result = source.Cast<object>()
                 .Aggregate<object, string>(null, (current, o) => current + string.Format("{0}{1}", o, separator));

            return result.Substring(0, result.LastIndexOf(separator, StringComparison.Ordinal));
        }
        #endregion

        #region 根据指定条件返回集合中不重复的元素
        /// <summary>
        /// 根据指定条件返回集合中不重复的元素
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <typeparam name="TKey">动态筛选条件类型</typeparam>
        /// <param name="source">要操作的数据源</param>
        /// <param name="keySelector">重复数据的筛选条件</param>
        /// <returns>不重复元素的集合</returns>
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            //取分组集合中每组的第一条数据
            return source.GroupBy(keySelector).Select(group => group.First());
        }
        #endregion

        #region 根据第三方条件是否为真是否执行指定条件的查询
        /// <summary>
        /// 根据第三方条件是否为真是否执行指定条件的查询
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source">要查询的数据源</param>
        /// <param name="where">条件</param>
        /// <param name="condition">第三方条件</param>
        /// <returns>查询的结果</returns>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, bool> where, bool condition)
        {
            return condition ? source.Where(where) : source;
        }
        #endregion

        #endregion

        #region 其他
        /// <summary>
        /// 扩展Between 操作符
        /// 使用 var query = db.People.Between(person => person.Age, 18, 21);
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source">当前值</param>
        /// <param name="keySelector">拉姆达表达式</param>
        /// <param name="low">低</param>
        /// <param name="high">高</param>
        /// <returns></returns>
        public static IQueryable<TSource> Between<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, TKey low, TKey high) where TKey : IComparable<TKey>
        {
            Expression key = Expression.Invoke(keySelector, keySelector.Parameters.ToArray());

            Expression lowerBound = Expression.GreaterThanOrEqual(key, Expression.Constant(low));

            Expression upperBound = Expression.LessThanOrEqual(key, Expression.Constant(high));

            Expression and = Expression.AndAlso(lowerBound, upperBound);

            Expression<Func<TSource, bool>> lambda = Expression.Lambda<Func<TSource, bool>>(and, keySelector.Parameters);

            return source.Where(lambda);
        }

        /// <summary>
        /// In
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool In<T>(this T value, params T[] values)
        {
            return values.Contains(value);
        }

        /// <summary>
        /// Between
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="i"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static bool Between<T>(this T i, T start, T end) where T : IComparable<T>
        {
            return i.CompareTo(start) >= 0 && i.CompareTo(end) <= 0;
        }

        /// <summary>
        /// And
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool And(this bool left, bool right)
        {
            return left && right;
        }

        /// <summary>
        /// Or
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool Or(this bool left, bool right)
        {
            return left || right;
        }

        #endregion

    }
}
