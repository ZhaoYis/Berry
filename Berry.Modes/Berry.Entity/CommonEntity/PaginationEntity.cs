﻿namespace Berry.Entity.CommonEntity
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public class PaginationEntity
    {
        /// <summary>
        /// 每页行数
        /// </summary>
        public int rows { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// 排序列
        /// </summary>
        public string sidx { get; set; }

        /// <summary>
        /// 排序类型，DESC或者ASC，默认DESC
        /// </summary>
        public string sord { get; set; } = "DESC";

        /// <summary>
        /// 总记录数
        /// </summary>
        public int records { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int total
        {
            get
            {
                if (records > 0)
                {
                    return records % this.rows == 0 ? records / this.rows : records / this.rows + 1;
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
        public string conditionJson { get; set; }
    }
}