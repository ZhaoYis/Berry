namespace Berry.Entity.CommonEntity
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public class PaginationEntity
    {
        /// <summary>
        /// 每页行数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 排序列
        /// </summary>
        public string Sidx { get; set; }

        /// <summary>
        /// 排序类型，DESC或者ASC，默认DESC
        /// </summary>
        public string Sord { get; set; } = "DESC";

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage
        {
            get
            {
                if (TotalRecords > 0)
                {
                    return TotalRecords % this.PageSize == 0 ? TotalRecords / this.PageSize : TotalRecords / this.PageSize + 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 查询条件Json
        /// </summary>
        public string ConditionJson { get; set; }
    }
}