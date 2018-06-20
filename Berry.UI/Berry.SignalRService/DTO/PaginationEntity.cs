namespace Berry.SignalRService.DTO
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public class PaginationEntity
    {
        /// <summary>
        /// 索引
        /// </summary>
        public int rows { get; set; }
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string sidx { get; set; }
        /// <summary>
        /// 排序方式，desc或者asc
        /// </summary>
        public string sord { get; set; }
    }
}