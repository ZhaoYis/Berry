using System;
using System.ComponentModel.DataAnnotations;
using Berry.Code;

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
        [Required(ErrorMessage = "ID不能为空")]
        public int Id { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        [MinLength(6, ErrorMessage = "密码最小长度6")]
        [Compare("RepeatPassword", ErrorMessage = "两次密码不一致")]
        public string Password { get; set; }

        /// <summary>
        /// 确认密码
        /// </summary>
        [Required(ErrorMessage = "确认密码不能为空")]
        public string RepeatPassword { get; set; }

        /// <summary>
        /// 特征码
        /// <value>A-区域001 B-区域002</value>
        /// </summary>
        [Required(ErrorMessage = "特征码不能为空")]
        [MaxLength(2, ErrorMessage = "特征码最大长度为2")]
        public string Code { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        /// <returns></returns>
        [RegularExpression(GlobalConstCode.RegTelePhone, ErrorMessage = "手机号码格式有误")]
        public string Mobile { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StarTime { get; set; }
    }
}