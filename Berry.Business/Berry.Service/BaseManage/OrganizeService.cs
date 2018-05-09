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
            var expression = LambdaExtension.True<OrganizeEntity>();
            expression = expression.And(t => t.FullName == organizeName);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.Id != keyValue);
            }
            bool hasExist = this.BaseRepository().IQueryable(expression).Any();

            return hasExist;
        }

        /// <summary>
        /// 外文名称不能重复
        /// </summary>
        /// <param name="enCode">外文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            var expression = LambdaExtension.True<OrganizeEntity>();
            expression = expression.And(t => t.EnCode == enCode);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.Id != keyValue);
            }
            bool hasExist = this.BaseRepository().IQueryable(expression).Any();

            return hasExist;
        }

        /// <summary>
        /// 中文名称不能重复
        /// </summary>
        /// <param name="shortName">中文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistShortName(string shortName, string keyValue)
        {
            var expression = LambdaExtension.True<OrganizeEntity>();
            expression = expression.And(t => t.ShortName == shortName);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.Id != keyValue);
            }
            bool hasExist = this.BaseRepository().IQueryable(expression).Any();

            return hasExist;
        }

        /// <summary>
        /// 删除机构
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveOrganizeByKey(string keyValue)
        {
            int count = this.BaseRepository().IQueryable<OrganizeEntity>(t => t.ParentId == keyValue).Count();
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