using Berry.Data.Repository;
using Berry.Entity.SystemManage;
using Berry.IService.SystemManage;
using System.Collections.Generic;
using System.Linq;
using Berry.Cache;
using Berry.Extension;

namespace Berry.Service.SystemManage
{
    /// <summary>
    /// 区域管理
    /// </summary>
    public class AreaService : RepositoryFactory, IAreaService
    {
        #region 获取数据

        /// <summary>
        /// 区域列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AreaEntity> GetList()
        {
            return this.BaseRepository().FindList<AreaEntity>(t => t.DeleteMark == false && t.EnabledMark == true).OrderBy(t => t.CreateDate).ToList();
        }

        /// <summary>
        /// 区域列表
        /// </summary>
        /// <param name="parentId">节点Id</param>
        /// <param name="keyword">关键字查询</param>
        /// <returns></returns>
        public IEnumerable<AreaEntity> GetList(string parentId, string keyword)
        {
            var expression = LambdaExtension.True<AreaEntity>();
            if (!string.IsNullOrEmpty(parentId))
            {
                expression = expression.And(t => t.ParentId == parentId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.AreaCode.Contains(keyword));
                expression = expression.Or(t => t.AreaName.Contains(keyword));
            }
            return this.BaseRepository().FindList(expression).OrderBy(t => t.CreateDate).ToList();
        }

        /// <summary>
        /// 区域实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public AreaEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity<AreaEntity>(keyValue);
        }

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 删除区域
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue){

            CacheFactory.GetCacheInstance().RemoveCache("__AreaCache");
            this.BaseRepository().Delete(keyValue);
        }

        /// <summary>
        /// 保存区域表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="areaEntity">区域实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, AreaEntity areaEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                areaEntity.Modify(keyValue);
                this.BaseRepository().Update(areaEntity);
            }
            else
            {
                areaEntity.Create();
                this.BaseRepository().Insert(areaEntity);
            }

            CacheFactory.GetCacheInstance().RemoveCache("__AreaCache");
        }

        #endregion 提交数据
    }
}