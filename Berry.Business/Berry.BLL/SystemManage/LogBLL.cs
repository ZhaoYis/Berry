using Berry.Entity.SystemManage;
using Berry.IBLL.SystemManage;
using Berry.IService.SystemManage;
using Berry.Service.SystemManage;

namespace Berry.BLL.SystemManage
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public partial class LogBLL : ILogBLL
    {
        private readonly ILogService _logService = new LogService();

        /// <summary>
        /// 日志实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public LogEntity GetEntity(string keyValue)
        {
            return _logService.GetEntity(keyValue);
        }

        /// <summary>
        /// 清空日志
        /// </summary>
        /// <param name="categoryId">日志分类Id</param>
        /// <param name="keepTime">保留时间段内</param>
        public void RemoveLog(int categoryId, string keepTime)
        {
            _logService.RemoveLog(categoryId, keepTime);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logEntity">对象</param>
        public void WriteLog(LogEntity logEntity)
        {
            _logService.WriteLog(logEntity);
        }
    }
}