using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Roc.CMS.Content
{
    [Table("AppCategory")]
    public class Category : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// 分类代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///父类ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(500)]
        public string Remark { get; set; }

        /// <summary>
        /// 是否是导航
        /// </summary>
        public bool IsNav { get; set; }

        /// <summary>
        /// 是否是特殊
        /// </summary>
        public bool IsSpecial { get; set; }

        /// <summary>
        /// URL地址
        /// </summary>
        [Url]
        [MaxLength(400)]
        public string URL { get; set; }

        /// <summary>
        /// target类型
        /// </summary>
        public CategoryTarget Target { get; set; }
    }
}
