using System;

namespace Berry.UnitTest.Model
{
    public class UserInfo
    {
        public int PK { get; set; }
        public int Age { get; set; }

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

        public DateTime CreateTime { get; set; }

        public int Sex { get; set; }
    }
    
    public class UserInfoDTO
    {
        //public int UID { get; set; }
        //public int Age { get; set; }
        //public string Ex { get; set; }
        //public DateTime AddTime { get; set; }

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