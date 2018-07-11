using System;
using AutoMapper;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Berry.Extension
{
    /// <summary>
    /// AutoMapper扩展帮助类
    /// </summary>
    public static class AutoMapperExtension
    {
        /// <summary>
        /// 类型映射
        /// </summary>
        /// <typeparam name="TDestination">映射后的对象</typeparam>
        /// <param name="obj">要映射的对象</param>
        /// <returns></returns>
        public static TDestination MapTo<TDestination>(this object obj) where TDestination : class
        {
            if (obj == null) return default(TDestination);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<TDestination, object>());
            var mapper = config.CreateMapper();
            return mapper.Map<TDestination>(obj);
        }

        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        /// <typeparam name="TDestination">目标对象类型</typeparam>
        /// <param name="source">数据源</param>
        /// <returns></returns>
        public static List<TDestination> MapTo<TDestination>(this IEnumerable source) where TDestination : class
        {
            if (source == null) return default(List<TDestination>);

            var config = new MapperConfiguration(cfg => cfg.CreateMap(typeof(TDestination), source.GetType()));
            var mapper = config.CreateMapper();
            return mapper.Map<List<TDestination>>(source);
        }

        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        /// <typeparam name="TSource">数据源类型</typeparam>
        /// <typeparam name="TDestination">目标对象类型</typeparam>
        /// <param name="source">数据源</param>
        /// <returns></returns>
        public static List<TDestination> MapTo<TSource, TDestination>(this IEnumerable<TSource> source) where TDestination : class where TSource : class
        {
            if (source == null) return new List<TDestination>();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<TDestination, TSource>());
            var mapper = config.CreateMapper();
            return mapper.Map<List<TDestination>>(source);
        }

        /// <summary>
        /// 类型映射
        /// </summary>
        /// <typeparam name="TSource">数据源类型</typeparam>
        /// <typeparam name="TDestination">目标对象类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="destination">目标对象</param>
        /// <returns></returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination) where TSource : class where TDestination : class
        {
            if (source == null) return destination;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<TDestination, TSource>());
            var mapper = config.CreateMapper();
            return mapper.Map<TSource, TDestination>(source, destination);
        }

        /// <summary>
        /// 类型映射,默认字段名字一一对应
        /// </summary>
        /// <typeparam name="TDestination">转化之后的model，可以理解为viewmodel</typeparam>
        /// <typeparam name="TSource">要被转化的实体，Entity</typeparam>
        /// <param name="source">可以使用这个扩展方法的类型，任何引用类型</param>
        /// <returns>转化之后的实体</returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source) where TDestination : class where TSource : class
        {
            if (source == null) return default(TDestination);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<TDestination, TSource>());
            var mapper = config.CreateMapper();
            return mapper.Map<TDestination>(source);
        }

        /// <summary>
        /// DataReader映射
        /// </summary>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <param name="reader">数据源</param>
        /// <returns></returns>
        public static IEnumerable<T> MapTo<T>(this IDataReader reader)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IDataReader, IEnumerable<T>>());
            var mapper = config.CreateMapper();
            return mapper.Map<IDataReader, IEnumerable<T>>(reader);
        }

        /// <summary>  
        /// 将 DataTable 转为实体对象  
        /// </summary>  
        /// <typeparam name="T">目标对象类型</typeparam>  
        /// <param name="dt">数据源</param>  
        /// <returns></returns>  
        public static List<T> MapTo<T>(this DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
                return default(List<T>);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<IDataReader, List<T>>());
            var mapper = config.CreateMapper();
            return mapper.Map<IDataReader, List<T>>(dt.CreateDataReader());
        }
        
        /// <summary>
        /// 将List转换为Datatable
        /// </summary>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <param name="list">数据源</param>
        /// <returns></returns>
        public static DataTable MapTo<T>(this IEnumerable<T> list)
        {
            if (list == null) return default(DataTable);

            //创建属性的集合
            List<PropertyInfo> pList = new List<PropertyInfo>();
            //获得反射的入口
            System.Type type = typeof(T);
            DataTable dt = new DataTable();
            //把所有的public属性加入到集合 并添加DataTable的列
            Array.ForEach<PropertyInfo>(type.GetProperties(), p => { pList.Add(p); dt.Columns.Add(p.Name, p.PropertyType); });
            foreach (var item in list)
            {
                //创建一个DataRow实例
                DataRow row = dt.NewRow();
                //给row 赋值
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));
                //加入到DataTable
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}