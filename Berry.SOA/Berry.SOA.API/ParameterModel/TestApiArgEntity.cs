using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Berry.Code;

namespace Berry.SOA.API.ParameterModel
{
    /// <summary>
    /// 用于测试API的实体
    /// </summary>
    public class TestApiArgEntity : BaseParameterEntity, IValidatableObject
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
        [StringBetweenLength(1, 3, ErrorMessage = "特征码长度在1-3之间")]
        public string Code { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        /// <returns></returns>
        [RegularExpression(GlobalConstCode.RegTelePhone, ErrorMessage = "手机号码格式有误")]
        public string Mobile { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [Required(ErrorMessage = "身份证号码不能为空")]
        [StringFixedLength(new[] { 15, 18 }, ErrorMessage = "身份证号码只能是15或者18位")]
        public string IdCard { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [DataType(DataType.DateTime)]
        [CheckDateTime(ErrorMessage = "日期有误")]
        [NotFutureTime(ErrorMessage = "开始时间应该小于当前时间")]
        public DateTime StarTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DataType(DataType.DateTime)]
        [CheckDateTime(ErrorMessage = "日期有误")]
        [NotFutureTime(false, ErrorMessage = "结束时间应该大于当前时间")]
        public DateTime EndTime { get; set; }

        #region 自定义校验
        /// <summary>确定指定的对象是否有效。</summary>
        /// <param name="validationContext">验证上下文中。</param>
        /// <returns>保存失败验证的信息集合。</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();
            if (this.Code != "A" && this.Code != "B")
            {
                result.Add(new ValidationResult("特征码只能是A或者B"));
            }
            return result;
        }
        #endregion
    }
}