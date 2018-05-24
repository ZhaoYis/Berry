using Berry.Entity.BaseManage;
using Berry.Extension;
using Berry.IService.BaseManage;
using Berry.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Berry.Service.BaseManage
{
    /// <summary>
    /// 机构管理
    /// </summary>
    public class OrganizeService : BaseService, IOrganizeService
    {
        /// <summary>
        /// 机构列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrganizeEntity> GetOrganizeList()
        {
            List<OrganizeEntity> res = this.BaseRepository().FindList<OrganizeEntity>(or => or.DeleteMark == false)
                .OrderByDescending(or => or.SortCode).ToList();

            return res;
        }

        /// <summary>
        /// 机构实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public OrganizeEntity GetOrganizeEntity(string keyValue)
        {
            OrganizeEntity res = this.BaseRepository().FindEntity<OrganizeEntity>(keyValue);

            return res;
        }

        /// <summary>
        /// 公司名称不能重复
        /// </summary>
        /// <param name="organizeName">公司名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string organizeName, string keyValue)
        {
            List<OrganizeEntity> data = this.BaseRepository().FindList<OrganizeEntity>(t => t.FullName == organizeName).ToList();
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = data.Where(t => t.Id != keyValue).ToList();
            }

            bool hasExit = data.Count > 0;

            return hasExit;
        }

        /// <summary>
        /// 外文名称不能重复
        /// </summary>
        /// <param name="enCode">外文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            List<OrganizeEntity> data = this.BaseRepository().FindList<OrganizeEntity>(t => t.EnCode == enCode).ToList();
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = data.Where(t => t.Id != keyValue).ToList();
            }

            bool hasExit = data.Count > 0;

            return hasExit;
        }

        /// <summary>
        /// 中文名称不能重复
        /// </summary>
        /// <param name="shortName">中文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistShortName(string shortName, string keyValue)
        {
            List<OrganizeEntity> data = this.BaseRepository().FindList<OrganizeEntity>(t => t.ShortName == shortName).ToList();
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = data.Where(t => t.Id != keyValue).ToList();
            }

            bool hasExit = data.Count > 0;

            return hasExit;
        }

        /// <summary>
        /// 删除机构
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveOrganizeByKey(string keyValue)
        {
            int count = this.BaseRepository().FindList<OrganizeEntity>(t => t.ParentId == keyValue).Count();
            if (count > 0)
            {
                throw new Exception("当前所选数据有子节点数据！");
            }

            int res = this.BaseRepository().Delete<OrganizeEntity>(keyValue);
        }

        /// <summary>
        /// 保存机构表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="organizeEntity">机构实体</param>
        /// <returns></returns>
        public void AddOrganize(string keyValue, OrganizeEntity organizeEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                organizeEntity.Modify(keyValue);

                int res = this.BaseRepository().Update<OrganizeEntity>(organizeEntity);
            }
            else
            {
                organizeEntity.Create();

                int res = this.BaseRepository().Insert<OrganizeEntity>(organizeEntity);
            }
        }
    }
}