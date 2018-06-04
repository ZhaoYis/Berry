using System;

namespace Berry.SOA.API.ParameterModel
{
    /// <summary>
    /// 用于测试API的实体
    /// </summary>
    public class TestApiArgEntity : BaseParameterEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 特征码
        /// <value>A-区域001 B-区域002</value>
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StarTime { get; set; }
    }
}