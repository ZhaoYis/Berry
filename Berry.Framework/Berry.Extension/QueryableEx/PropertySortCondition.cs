using System.ComponentModel;

namespace Berry.Extension.QueryableEx
{
    /// <summary>
    /// 排序条件
    /// </summary>
    public class PropertySortCondition
    {
        /// <summary>
        /// 获取或者设置排序属性名称
        /// </summary>
        public string PropertyName { get; private set; }

        /// <summary>
        /// 获取或者设置排序方向
        /// </summary>
        public ListSortDirection ListSortDirection { get; private set; }

        /// <summary>
        /// 构造排序属性名称贺排序方式的排序条件
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="listSortDirection">排序方式，默认升序排序</param>
        public PropertySortCondition(string propertyName, ListSortDirection listSortDirection = ListSortDirection.Ascending)
        {
            this.PropertyName = propertyName;
            this.ListSortDirection = listSortDirection;
        }
    }
}