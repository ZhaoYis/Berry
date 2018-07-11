using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Berry.Util;

namespace Berry.Entity
{
    /// <summary>
    /// 实体类基类
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// PK
        /// </summary>
        [NotMapped]
        public int PK { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 新增调用
        /// </summary>
        public virtual void Create()
        {
            this.Id = CommonHelper.GetGuid();
        }

        /// <summary>
        /// 删除调用
        /// </summary>
        /// <param name="id">主键值</param>
        public virtual void Remove(string id)
        {
            this.Id = id;
        }

        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="id">主键值</param>
        public virtual void Modify(string id)
        {
            this.Id = id;
        }
    }
}