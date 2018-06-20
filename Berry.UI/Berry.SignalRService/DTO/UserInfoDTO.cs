namespace Berry.SignalRService.DTO
{
    /// <summary>
    /// 用户基础信息
    /// </summary>
    public class UserInfoDTO
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public string DepartmentId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 是否在线 1-在线 0-离线
        /// </summary>
        public int UserOnLine { get; set; }
    }
}