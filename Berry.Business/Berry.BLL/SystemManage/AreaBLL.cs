using Berry.Entity.SystemManage;
using Berry.IBLL.SystemManage;
using System.Collections.Generic;
using System.Linq;
using Berry.IService.SystemManage;
using Berry.Service.SystemManage;

namespace Berry.BLL.SystemManage
{
    /// <summary>
    /// 区域管理
    /// </summary>
    public class AreaBLL : IAreaBLL
    {
        private IAreaService service = new AreaService();

        /// <summary>
        /// 缓存key
        /// </summary>
        public string CacheKey = "__AreaCache";

        #region 获取数据

        /// <summary>
        /// 区域列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AreaEntity> GetList()
        {
            return service.GetList();
        }
        
        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 删除区域
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            service.RemoveForm(keyValue);
        }

        /// <summary>
        /// 保存区域表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="areaEntity">区域实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, AreaEntity areaEntity)
        {
            service.SaveForm(keyValue, areaEntity);
        }

        #endregion 提交数据
    }
}