using System.ComponentModel.DataAnnotations;

namespace Berry.SOA.API.ParameterModel
{
    /// <summary>
    /// 基础参数实体
    /// </summary>
    public class BaseParameterEntity
    {
        /// <summary>
        /// 校验值，一般为时间戳
        /// </summary>
        [Required(ErrorMessage = "校验值不能为空")]
        [MaxLength(10, ErrorMessage = "最大长度为10")]
        public string t { get; set; }
    }
}