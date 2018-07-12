using System.ComponentModel.DataAnnotations;

namespace Berry.SOA.API.ParameterModel
{
    /// <summary>
    /// 获取Token参数
    /// </summary>
    public class GetTokenArgEntity : BaseParameterEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Required(ErrorMessage = "UserId不能为空")]
        public string UserId { get; set; }
        /// <summary>
        /// 帐号
        /// </summary>
        [Required(ErrorMessage = "Account不能为空")]
        public string Account { get; set; }
    }
}